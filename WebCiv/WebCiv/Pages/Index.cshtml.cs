using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebCiv.Configuration;

namespace WebCiv.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            User user = new User() { Name = "myName" };
            user.UserCiv = new Engine.Civilization();
            user.UserCiv.Population.TotalPop = 10;

            ViewData["UserName"] = user.Name;
            ViewData["NbrPop"] = user.UserCiv.Population.TotalPop;
        }
    }
}
