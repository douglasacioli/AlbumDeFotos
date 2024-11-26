using AlbumDeFotos.Models;
using Microsoft.AspNetCore.Mvc;
using static AlbumDeFotos.Models.UnidadeFuncional;

namespace AlbumDeFotos.Controllers
{
    public class MapaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult MapaAndar()
        {
            var viewModel = new MapaLeitoStatusViewModel
            {
                Andar = "1º Andar",
                ImagemAndar = "/Imagens/Mapa.png",  // Caminho da imagem da planta do andar
                UnidadesFuncionais = UnidadeFuncionalRepository.ObterUnidades()
            };

            return View(viewModel);
        }

        //[HttpPost]
        //public JsonResult SalvarCoordenadas(int id, double xInicio, double yInicio, double xFim, double yFim)
        //{
        //    try
        //    {
        //        // Atualiza as coordenadas no repositório (banco de dados)
        //        UnidadeFuncionalRepository.AtualizarCoordenadas(id, xInicio, yInicio, xFim, yFim);

        //        return Json(new { success = true, message = "Coordenadas atualizadas com sucesso!" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { success = false, message = "Erro ao atualizar coordenadas: " + ex.Message });
        //    }
        //}


    }
}
