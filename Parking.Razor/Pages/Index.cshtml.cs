using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Parking.DAL.Repository;

namespace Parking.Razor.Pages
{
    public class IndexModel : PageModel
    {
        IManobraRepository _manobraRepository;
        ICarroRepository _carroRepository;
        IManobristaRepository _manobristaRepository;
        public IndexModel(IManobraRepository manobraRepository, ICarroRepository carroRepository, IManobristaRepository manobristaRepository)
        {
            _manobraRepository = manobraRepository;
            _carroRepository = carroRepository;
            _manobristaRepository = manobristaRepository;
        }

        [BindProperty]
        public List<Entities.Manobra> listaManobras { get; set; }
        public List<Entities.Carro> listaCarros { get; set; }
        public List<Entities.Manobrista> listaManobristas { get; set; }
        public List<Entities.TipoManobra> listaTipoManobras { get; set; }

        public List<SelectListItem> optionsManobrista { get; set; }
        public List<SelectListItem> optionsCarro { get; set; }
        public List<SelectListItem> optionsTipoManobra { get; set; }

        [BindProperty]
        public Entities.Manobra manobra { get; set; }

        [TempData]
        public string Message { get; set; }

        public void OnGet()
        {
            listaManobras = _manobraRepository.GetManobras();
            listaCarros = _carroRepository.GetCarros();
            listaManobristas = _manobristaRepository.GetManobristas();
            listaTipoManobras = _manobraRepository.GetTipoManobras();

            optionsManobrista = listaManobristas.Select(a => new SelectListItem
            {
                Value = a.IdManobrista.ToString(),
                Text = a.Nome
            }).ToList();

            optionsCarro = listaCarros.Select(a => new SelectListItem
            {
                Value = a.IdCarro.ToString(),
                Text = a.Placa
            }).ToList();

            optionsManobrista = listaManobristas.Select(a => new SelectListItem
            {
                Value = a.IdManobrista.ToString(),
                Text = a.Nome
            }).ToList();

            optionsTipoManobra = listaTipoManobras.Select(a => new SelectListItem
            {
                Value = a.IdTipoManobra.ToString(),
                Text = a.Descricao
            }).ToList();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var count = _manobraRepository.Add(manobra);
                if (count > 0)
                {
                    Message = "Manobra incluída com sucesso.";
                    return RedirectToPage("/Index");
                }
            }

            return Page();
        }

        public IActionResult OnPostDelete(int id)
        {
            if (id > 0)
            {
                var count = _manobraRepository.Delete(id);
                if (count > 0)
                {
                    Message = "Manobra deletada com sucesso!";
                    return RedirectToPage("/Index");
                }
            }
            return Page();
        }

    }
}
