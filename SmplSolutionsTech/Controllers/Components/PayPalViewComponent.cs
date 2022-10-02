using Microsoft.AspNetCore.Mvc;
using SmplSolutionsTech.Models.App;

namespace SmplSolutionsTech.Controllers.Components
{
    public class PayPalViewComponent : ViewComponent
    {
        private readonly ILogger<PayPalViewComponent> _logger;
        private readonly IHttpContextAccessor _context;

        public PayPalViewComponent(ILogger<PayPalViewComponent> logger, IHttpContextAccessor context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                return View("PayPal");
            }
            catch (Exception e)
            {
                return View("../../Error");
            }
        }
    }
}
