using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WindLog.Models;

namespace WindLog.Controllers.API
{
    [Authorize]
    [Route("api/sessions")]
    public class SessionsController : Controller
    {
        private ILogger<SessionsController> _logger;
        private IWindlogRepository _repository;

        public SessionsController(IWindlogRepository repository, ILogger<SessionsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public ActionResult Get()
        {
            try
            {
                IEnumerable<Session> data = _repository.GetAllSessions();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when getting all sessions: {ex}", ex);
                return BadRequest("An error occurred while getting sessions.");
            }
        }
    }
}
