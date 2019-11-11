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
    /// <summary>
    /// class model for index page
    /// </summary>
    public class IndexModel : PageModel
    {
        /// <summary>
        /// user
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1051:Do not declare visible instance fields", Justification = "Needed by the view")]
        public AppUser user;
        /// <summary>
        /// used logger
        /// </summary>
        private readonly ILogger<IndexModel> _logger;

        /// <summary>
        /// create a new index model
        /// </summary>
        /// <param name="logger">logger</param>
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// OnGet
        /// </summary>
        public void OnGet()
        {
            user = new AppUser() { GameName = "UserName" };
            user.UserCiv = new Engine.Civilization();
            user.UserCiv.Population.TotalPop = 10;
        }
    }
}
