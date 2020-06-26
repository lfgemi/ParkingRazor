using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Parking.DAL.Repository;

namespace Parking.Razor.Pages.Carro
{
    public class AddModel : PageModel
    {
        ICarroRepository _carroRepository;

        public AddModel(ICarroRepository carroRepository)
        {
            _carroRepository = carroRepository;
        }

        [BindProperty]
        public Entities.Carro carro { get; set; }

        [TempData]
        public string Message { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                var count = _carroRepository.Add(carro);
                if(count > 0)
                {
                    Message = "Novo carro incluído com sucesso.";
                    return RedirectToPage("/Carro/Index");
                }
            }

            return Page();
        }
    }
}