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
    public class MaterialsController : Controller
    {
        private ILogger<MaterialsController> _logger;
        private IWindlogRepository _repository;

        public MaterialsController(IWindlogRepository repository, ILogger<MaterialsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("/api/materials")]
        public ActionResult Get()
        {
            try
            {
                var result = new List<MaterialViewModel>();
                //var materialViewModel = new MaterialViewModel();
                //var materialTypeViewModel = new MaterialTypeViewModel();

                IEnumerable<Material> data = _repository.GetAllMaterials(User.Identity.Name);
                foreach (var material in data)
                {
                    var materialViewModel = Mapper.Map<MaterialViewModel>(material);
                    materialViewModel.MaterialTypeViewModel = Mapper.Map<MaterialTypeViewModel>(material.MaterialType);
                    result.Add(materialViewModel);
                }              
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when getting all materials: {ex}", ex);
                return BadRequest("An error occurred while getting materials.");
            }
        }

        [HttpGet("/api/materials/{id}")]
        public ActionResult Get(string id)
        {
            try
            {                
                Material material = _repository.GetMaterialById(Convert.ToInt32(id),User.Identity.Name);
                if (material == null)
                {
                    return BadRequest(string.Format("Material with id {0} does not exist.", id));
                }                
                var materialViewModel = Mapper.Map<MaterialViewModel>(material);
                materialViewModel.MaterialTypeViewModel = Mapper.Map<MaterialTypeViewModel>(material.MaterialType);

                return Ok(materialViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when getting materials with id {id}: {ex}",id, ex);
                return BadRequest(string.Format("An error occurred while getting material with id {0}.",id));
            }
        }

        [HttpPost("/api/materials")]
        public async Task<ActionResult> Post([FromBody]MaterialViewModel newMaterialViewModel)
        {
            if (ModelState.IsValid)
            {
                Material newMaterial = Mapper.Map<Material>(newMaterialViewModel);
                newMaterial.UserName = User.Identity.Name;
                MaterialType newMaterialType = Mapper.Map<MaterialType>(newMaterialViewModel.MaterialTypeViewModel);
                if (newMaterialType != null)
                {
                    newMaterial.MaterialType = newMaterialType;
                    newMaterial.MaterialType.UserName = User.Identity.Name;
                }
                newMaterial.SessionMaterials = new List<SessionMaterials>();

                try
                {
                    if (newMaterial.Id == 0)
                    {
                        _repository.AddMaterial(newMaterial);
                    }
                    else
                    {
                        _repository.UpdateMaterial(newMaterial);
                    }

                    if (await _repository.SaveChangesAsync())
                    {
                        return Created($"api/materials/{newMaterialViewModel.Name}", Mapper.Map<MaterialViewModel>(newMaterialViewModel));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error when saving new material: {ex}", ex);
                    return BadRequest("Failed to save changes to database: " + ex);
                }
            }
            return BadRequest("Failed to save changes to database: Not valid material.");
        }
    }
}
