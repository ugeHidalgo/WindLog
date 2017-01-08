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
    //[Route("api/materialtypes")]
    public class MaterialTypesController : Controller
    {
        private ILogger<MaterialTypesController> _logger;
        private IWindlogRepository _repository;

        public MaterialTypesController(IWindlogRepository repository, ILogger<MaterialTypesController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("/api/materialtypes")]
        public ActionResult Get()
        {
            try
            {
                IEnumerable<MaterialType> data = _repository.GetAllMaterialTypes(User.Identity.Name);
                return Ok(Mapper.Map<IEnumerable<MaterialTypeViewModel>>(data));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when getting all material types: {ex}", ex);
                return BadRequest("An error occurred while getting material types.");
            }
        }

        [HttpPost("/api/materialtypes")]
        public async Task<ActionResult> Post([FromBody]MaterialTypeViewModel newMatTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                MaterialType newMatType = Mapper.Map<MaterialType>(newMatTypeViewModel);
                newMatType.UserName = User.Identity.Name;

                _repository.AddMaterialType(newMatType);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"api/materialtypes/{newMatTypeViewModel.Name}", Mapper.Map<MaterialTypeViewModel>(newMatTypeViewModel));
                }
            }
            return BadRequest("Failed to save changes to database");
        }

        [HttpDelete("/api/materialtypes/{id}")]
        public async Task<ActionResult> RemoveMaterialType(int id)
        {
            try
            {
                bool result = _repository.RemoveMaterialType(id, User.Identity.Name);
                if (result)
                {
                    if (await _repository.SaveChangesAsync())
                    {
                        return Ok();
                    }
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"Failed to remove material type {id} : {ex}");
            }
            return BadRequest($"Failed to remove material type {id}.");
        }
    }
}
