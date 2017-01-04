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
    [Route("api/materials")]
    public class MaterialsController : Controller
    {
        private ILogger<MaterialsController> _logger;
        private IWindlogRepository _repository;

        public MaterialsController(IWindlogRepository repository, ILogger<MaterialsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public ActionResult Get()
        {
            try
            {
                IEnumerable<Material> data = _repository.GetAllMaterials(User.Identity.Name);
                return Ok(Mapper.Map<IEnumerable<MaterialViewModel>>(data));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when getting all materials: {ex}", ex);
                return BadRequest("An error occurred while getting materials.");
            }
        }
    }
}
