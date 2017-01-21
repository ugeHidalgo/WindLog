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

        [HttpGet("/api/materialtypes/{id}")]
        public ActionResult Get(string id)
        {
            try
            {
                MaterialType materialType = _repository.GetMaterialTypeById(Convert.ToInt32(id), User.Identity.Name);
                if (materialType == null)
                {
                    return BadRequest(string.Format("Material type with id {0} does not exist.", id));
                }
                var materialTypeViewModel = Mapper.Map<MaterialTypeViewModel>(materialType);                

                return Ok(materialTypeViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when getting material type with id {id}: {ex}", id, ex);
                return BadRequest(string.Format("An error occurred while getting material type with id {0}.", id));
            }
        }

        [HttpPost("/api/materialtypes")]
        public async Task<ActionResult> Post([FromBody]MaterialTypeViewModel newMatTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                MaterialType newMatType = Mapper.Map<MaterialType>(newMatTypeViewModel);
                newMatType.UserName = User.Identity.Name;

                if (newMatType.Id==0)
                {
                    _repository.AddMaterialType(newMatType);
                }
                else
                {
                    _repository.UpdateMaterialType(newMatType);
                }

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
