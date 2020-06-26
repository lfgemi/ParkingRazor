using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Parking.DAL.Repository;

namespace Parking.Razor.Pages.Manobrista
{
    public class AddModel : PageModel
    {
        IManobristaRepository _manobristaRepository;

        public AddModel(IManobristaRepository manobristaRepository)
        {
            _manobristaRepository = manobristaRepository;
        }

        [BindProperty]
        public Entities.Manobrista manobrista { get; set; }

        [TempData]
        public string Message { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var count = _manobristaRepository.Add(manobrista);
                if (count > 0)
                {
                    Message = "Novo manobrista incluído com sucesso.";
                    return RedirectToPage("/Manobrista/Index");
                }
            }

            return Page();
        }
    }
}