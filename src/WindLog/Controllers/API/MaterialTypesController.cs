using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WindLog.Models;
using WindLog.ViewModels;

namespace WindLog.Controllers.API
{
    [Authorize]
    [Route("api/materialtypes")]
    public class MaterialTypesController : Controller
    {
        private ILogger<MaterialTypesController> _logger;
        private IWindlogRepository _repository;

        public MaterialTypesController(IWindlogRepository repository, ILogger<MaterialTypesController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
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
    }
}
