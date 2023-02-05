using LivrariaApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LivrariaApp.Pages
{
    public class IdiomasModel : PageModel
    {

        public IEnumerable<Idioma> IdiomaList { get; set; }

        //� chamado sempre que algu�m consulta a p�gina

        public void OnGet()
        {

            LivrariaContext context = new LivrariaContext();
            IdiomaList = context.getAllIdioma();

        }


      
            //Recebe o formul�rio HTML e executa o c�digo 
            public void OnPost()
            {
                Idioma idioma = new Idioma()
                {
                    Id = Int32.Parse(Request.Form["id"]),
                    Nome = Request.Form["nome"],
                    Sigla = Request.Form["sigla"]
                };

                LivrariaContext context = new LivrariaContext();
                context.updateIdioma(idioma);

                OnGet();
            }




        }
    }



