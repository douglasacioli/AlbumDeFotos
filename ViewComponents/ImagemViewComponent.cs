using AlbumDeFotos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlbumDeFotos.ViewComponents
{
    public class ImagemViewComponent : ViewComponent
    {
        private readonly Contexto _contexto;

        public ImagemViewComponent(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var imagens = await _contexto.Imagens.Where(i => i.AlbumId == id).ToListAsync();
            return View(imagens);
        }
    }
}
