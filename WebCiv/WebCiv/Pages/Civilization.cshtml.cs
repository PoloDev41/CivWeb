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
    [Authorize]
    public class CivilizationModel : PageModel
    {
        private readonly WebCiv.DAL.ApplicationDbContext _context;

        public CivilizationModel(WebCiv.DAL.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            using (var dal = new DAL_User(_context))
            {
                string id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                AppUser = dal.GetUser(id);
            }

            return Page();
        }

        [BindProperty]
        public AppUser AppUser { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
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
