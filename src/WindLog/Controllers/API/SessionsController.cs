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
                var result = new List<SessionViewModel>();
                IEnumerable<Session> sessions = _repository.GetAllSessions(User.Identity.Name);
                foreach (var session in sessions)
                {
                    SessionViewModel sessionViewModel = FillSessionData(session);
                    FillSpotData(session, sessionViewModel);
                    FillMaterialsData(session, sessionViewModel);

                    result.Add(sessionViewModel);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when getting all sessions: {ex}", ex);
                return BadRequest("An error occurred while getting sessions.");
            }
        }

        #region Private methods

        private static SessionViewModel FillSessionData(Session session)
        {
            return Mapper.Map<SessionViewModel>(session);
        }

        private static void FillSpotData(Session session, SessionViewModel sessionViewModel)
        {
            sessionViewModel.Spot = Mapper.Map<SpotViewModel>(session.Spot);
        }

        private static void FillMaterialsData(Session session, SessionViewModel sessionViewModel)
        {
            if (session.SessionMaterials != null)
            {
                sessionViewModel.Materials = new List<MaterialViewModel>();
                foreach (var sessionMaterial in session.SessionMaterials)
                {
                    var materialViewModel = Mapper.Map<MaterialViewModel>(sessionMaterial.Material);
                    sessionViewModel.Materials.Add(materialViewModel);
                }
            }
        }

        #endregion
    }
}
