using LivrariaApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LivrariaApp.Pages
{
    public class ContinentesModel : PageModel
    {


        public IEnumerable<Continente> ContinenteList { get; set; }

        //� chamado sempre que algu�m consulta a p�gina

        public void OnGet()
        {


            LivrariaContext context = new LivrariaContext();
            ContinenteList = context.getAllContinente();



        }

        //Recebe o formul�rio HTML e executa o c�digo 
        public void OnPost()
        {
            Continente continente = new Continente()
            {
                Id = Int32.Parse(Request.Form["id"]),
                Nome = Request.Form["nome"],
               
            };

            LivrariaContext context = new LivrariaContext();
            context.updateContinente(continente);

            OnGet();
        }



    }
}
