using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Parking.DAL.Repository;

namespace Parking.Razor.Pages.Carro
{
    public class EditModel : PageModel
    {
        ICarroRepository _carroRepository;
        public EditModel(ICarroRepository carroRepository)
        {
            _carroRepository = carroRepository;
        }

        [BindProperty]
        public Entities.Carro carro { get; set; }

        public void OnGet(int id)
        {
            carro = _carroRepository.Get(id);
        }

        public IActionResult OnPost()
        {
            var dados = carro;
            if (ModelState.IsValid)
            {
                var count = _carroRepository.Edit(dados);
                if(count > 0)
                {
                    return RedirectToPage("/Carro/Index");
                }
            }
            return Page();
        }

    }
}