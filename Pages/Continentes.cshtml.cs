using LivrariaApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LivrariaApp.Pages
{
    public class ContinentesModel : PageModel
    {


        public IEnumerable<Continente> ContinenteList { get; set; }

        //É chamado sempre que alguém consulta a página

        public void OnGet()
        {


            LivrariaContext context = new LivrariaContext();
            ContinenteList = context.getAllContinente();



        }

        //Recebe o formulário HTML e executa o código 
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
