using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WindLog.Models;

namespace WindLog.Controllers.API
{
    [Route("api/spots")]
    public class SpotsController : Controller
    {
        private ILogger<SpotsController> _logger;
        private IWindlogRepository _repository;

        public SpotsController(IWindlogRepository repository, ILogger<SpotsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public ActionResult Get()
        {
            try
            {
                IEnumerable<Spot> data = _repository.GetAllSpots();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when getting all spots: {ex}", ex);
                return BadRequest("An error occurred while getting spots.");
            }
        }
    }
}
