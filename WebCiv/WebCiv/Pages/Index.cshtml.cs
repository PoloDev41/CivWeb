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
        public User user;

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            user = new User() { Name = "UserName" };
            user.UserCiv = new Engine.Civilization();
            user.UserCiv.Population.TotalPop = 10;
        }
    }
}
