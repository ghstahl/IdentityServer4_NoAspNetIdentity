using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace My.FederatedGateway.Areas.Identity.Pages.Account
{
    public class RedirectModel : PageModel
    {
        public async void OnGetAsync(string redirectUrl)
        {
            RedirectUrl = redirectUrl;
        }

        public string RedirectUrl { get; set; }
    }
}