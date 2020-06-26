using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Parking.DAL.Repository;

namespace Parking.Razor.Pages.Manobrista
{
    public class EditModel : PageModel
    {
        IManobristaRepository _manobristaRepository;
        public EditModel(IManobristaRepository manobristaRepository)
        {
            _manobristaRepository = manobristaRepository;
        }

        [BindProperty]
        public Entities.Manobrista manobrista { get; set; }

        public void OnGet(int id)
        {
            manobrista = _manobristaRepository.Get(id);
        }

        public IActionResult OnPost()
        {
            var dados = manobrista;
            if (ModelState.IsValid)
            {
                var count = _manobristaRepository.Edit(dados);
                if (count > 0)
                {
                    return RedirectToPage("/Manobrista/Index");
                }
            }
            return Page();
        }
    }
}