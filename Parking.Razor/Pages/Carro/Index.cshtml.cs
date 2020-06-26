using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Parking.DAL.Repository;

namespace Parking.Razor.Pages.Carro
{
    public class IndexModel : PageModel
    {
        ICarroRepository _carroRepository;

        public IndexModel(ICarroRepository carroRepository)
        {
            _carroRepository = carroRepository;
        }

        [BindProperty]
        public List<Entities.Carro> listaCarros { get; set; }

        [BindProperty]
        public Entities.Carro carro { get; set; }

        [TempData]
        public string Message { get; set; }

        public void OnGet()
        {
            listaCarros = _carroRepository.GetCarros();
        }

        public IActionResult OnPostDelete(int id)
        {
            if (id > 0)
            {
                var count = _carroRepository.Delete(id);
                if (count > 0)
                {
                    Message = "Carro deletado com sucesso!";
                    return RedirectToPage("/Carro/Index");
                }
            }
            return Page();
        }
    }
}