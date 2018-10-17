using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using My.FederatedGateway.Services;
using Newtonsoft.Json;

namespace My.FederatedGateway.Areas.Identity.Pages.Diagnostics
{
    public class DiagnosticsViewModel
    {
        public DiagnosticsViewModel(AuthenticateResult result)
        {
            AuthenticateResult = result;

            if (result.Properties.Items.ContainsKey("client_list"))
            {
                var encoded = result.Properties.Items["client_list"];
                var bytes = Base64Url.Decode(encoded);
                var value = Encoding.UTF8.GetString(bytes);

                Clients = JsonConvert.DeserializeObject<string[]>(value);
            }
        }

        public AuthenticateResult AuthenticateResult { get; }
        public IEnumerable<string> Clients { get; } = new List<string>();
    }
    [Authorize]
    public class IndexModel : PageModel
    {
        private IHttpContextAccessor _httpContextAccessor;
        private IAuthenticatedInformation _authenticatedInformation;

        public IndexModel(
            IHttpContextAccessor httpContextAccessor,
            IAuthenticatedInformation authenticatedInformation)
        {
            _httpContextAccessor = httpContextAccessor;
            _authenticatedInformation = authenticatedInformation;
        }
        [BindProperty]
        public DiagnosticsViewModel DiagnosticsViewModel { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            var localAddresses = new string[] { "127.0.0.1", "::1", _httpContextAccessor.HttpContext.Connection.LocalIpAddress.ToString() };
            if (!localAddresses.Contains(_httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString()))
            {
                return NotFound();
            }

            DiagnosticsViewModel = new DiagnosticsViewModel(await _authenticatedInformation.GetAuthenticateResultAsync());
            return Page();
        }
    }
}