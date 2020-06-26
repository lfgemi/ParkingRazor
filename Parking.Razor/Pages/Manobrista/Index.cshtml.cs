using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Parking.DAL.Repository;

namespace Parking.Razor.Pages.Manobrista
{
    public class IndexModel : PageModel
    {
        IManobristaRepository _manobristaRepository;

        public IndexModel(IManobristaRepository manobristaRepository)
        {
            _manobristaRepository = manobristaRepository;
        }

        [BindProperty]
        public List<Entities.Manobrista> listaManobristas { get; set; }

        [BindProperty]
        public Entities.Manobrista manobrista { get; set; }

        [TempData]
        public string Message { get; set; }

        public void OnGet()
        {
            listaManobristas = _manobristaRepository.GetManobristas();
        }

        public IActionResult OnPostDelete(int id)
        {
            if (id > 0)
            {
                var count = _manobristaRepository.Delete(id);
                if (count > 0)
                {
                    Message = "Manobrista deletado com sucesso.";
                    return RedirectToPage("/Manobrista/Index");
                }
            }
            return Page();
        }
    }
}