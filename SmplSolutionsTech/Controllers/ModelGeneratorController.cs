using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmplSolutionsTech.Helpers.Classes;
using SmplSolutionsTech.Helpers.Enums;
using SmplSolutionsTech.Logic;
using SmplSolutionsTech.Models.App;

namespace SmplSolutionsTech.Controllers
{
    //[Authorize(Policy = nameof(AuthorizationPoliciesEnum.MidDev))]
    public class ModelGeneratorController : Controller
    {
        private readonly Config _config;
        private readonly ILogger<ModelGeneratorController> _logger;
        private readonly IGeneratorLogic _generatorLogic;
        private readonly IEmailHelper _emailHelper;

        public ModelGeneratorController(Config config, ILogger<ModelGeneratorController> logger, IGeneratorLogic generatorLogic, IEmailHelper emailHelper)
        {
            _config = config;
            _logger = logger;
            _generatorLogic = generatorLogic;
            _emailHelper = emailHelper;
        }
        [HttpGet("OpenGenerator")]
        public async Task<IActionResult> OpenGenerator()
        {
            try
            {
                var model = await _generatorLogic.GetOpenGeneratorModel();
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unexpected error occurred: {ex.Message}");
                throw new ApplicationException("Oops something unexpected happened please contact support.");
            }
        }
        [HttpPost("OpenGeneratorCreate")]
        public async Task<bool> OpenGeneratorCreate(OpenCodeGeneratorForm model)
        {
            //TODO Create the file and return it to user.

            return Task.CompletedTask.IsCompletedSuccessfully;
        }
    }
}
