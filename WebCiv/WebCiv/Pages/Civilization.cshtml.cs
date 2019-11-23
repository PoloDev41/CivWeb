using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebCiv.Configuration;
using WebCiv.DAL;
using WebCiv.Engine;

namespace WebCiv.Pages
{
    /// <summary>
    /// model of the civilization view
    /// </summary>
    [Authorize]
    public class CivilizationModel : PageModel
    {
        private readonly WebCiv.DAL.ApplicationDbContext _context;
        /// <summary>
        /// create a new civilization model
        /// </summary>
        /// <param name="context">Db context</param>
        public CivilizationModel(WebCiv.DAL.ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// On get
        /// </summary>
        /// <returns>action result</returns>
        public IActionResult OnGet()
        {
            using (var dal = new DAL_User(_context))
            {
                string id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                AppUser = dal.GetUser(id);
            }

            return Page();
        }

        /// <summary>
        /// Current user
        /// </summary>
        [BindProperty]
        public AppUser AppUser { get; set; }


        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
#pragma warning disable CS1998 // Cette méthode async n'a pas d'opérateur 'await' et elle s'exécutera de façon synchrone
                              /// <summary>
                              /// On post Async
                              /// </summary>
                              /// <returns>action result</returns>
        public async Task<IActionResult> OnPostAsync()
#pragma warning restore CS1998 // Cette méthode async n'a pas d'opérateur 'await' et elle s'exécutera de façon synchrone
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            using (var dal = new DAL_User(_context))
            {
                var bdUser = dal.GetUser(IDAL_User.GetUserId(User));
                bdUser.GameName = AppUser.GameName;
                var canBe = dal.CreateCivilization(bdUser.Id, bdUser.GameName);
                if(canBe == false)
                {
                    ViewData["MessageError"] = "Name of the civilization is already used";
                }
                AppUser = bdUser;
            }

            return Page();
        }
    }
}
