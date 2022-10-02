using Microsoft.AspNetCore.Mvc;
using SmplSolutionsTech.Models.App;

namespace SmplSolutionsTech.Controllers.Components
{
    public class AddPropertiesViewComponent : ViewComponent
    {
        private readonly ILogger<AddPropertiesViewComponent> _logger;
        private readonly IHttpContextAccessor _context;

        public AddPropertiesViewComponent(ILogger<AddPropertiesViewComponent> logger, IHttpContextAccessor context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(ModelGeneratorModel model)
        {
            try
            {
                return View("AddProperties", model);
            }
            catch (Exception e)
            {
                return View("../../Error");
            }
        }
    }
}
