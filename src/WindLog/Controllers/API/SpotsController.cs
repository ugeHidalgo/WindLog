using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WindLog.Models;
using WindLog.ViewModels;

namespace WindLog.Controllers.API
{
    [Authorize]
    public class SpotsController : Controller
    {
        private ILogger<SpotsController> _logger;
        private IWindlogRepository _repository;

        public SpotsController(IWindlogRepository repository, ILogger<SpotsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("api/spots")]
        public ActionResult Get()
        {
            try
            {
                IEnumerable<Spot> data = _repository.GetAllSpots(User.Identity.Name);
                return Ok(Mapper.Map<IEnumerable<SpotViewModel>>(data));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when getting all spots: {ex}", ex);
                return BadRequest("An error occurred while getting spots.");
            }
        }

        [HttpGet("/api/spots/{id}")]
        public ActionResult Get(string id)
        {
            try
            {
                Spot spot = _repository.GetSpotById(Convert.ToInt32(id), User.Identity.Name);
                if (spot == null)
                {
                    return BadRequest(string.Format("Spot with id {0} does not exist.", id));
                }
                var spotViewModel = Mapper.Map<SpotViewModel>(spot);

                return Ok(spotViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when getting spot with id {id}: {ex}", id, ex);
                return BadRequest(string.Format("An error occurred while getting spot with id {0}.", id));
            }
        }

        [HttpPost("/api/spots")]
        public async Task<ActionResult> Post([FromBody]SpotViewModel newSpotViewModel)
        {
            if (ModelState.IsValid)
            {
                Spot newSpot = Mapper.Map<Spot>(newSpotViewModel);
                newSpot.UserName = User.Identity.Name;

                if (newSpot.Id == 0)
                {
                    _repository.AddSpot(newSpot);
                }
                else
                {
                    _repository.UpdateSpot(newSpot);
                }

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"api/spots/{newSpotViewModel.Name}", Mapper.Map<SpotViewModel>(newSpotViewModel));
                }
            }
            return BadRequest("Failed to save changes to database");
        }
    }
}
