using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlbumDeFotos.Models;

namespace AlbumDeFotos.Controllers
{
    public class AlbunsController : Controller
    {
        private readonly Contexto _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AlbunsController(Contexto context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Albuns
        public async Task<IActionResult> Index()
        {
            return View(await _context.Albuns.ToListAsync());
        }

        // GET: Albuns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albuns
                .FirstOrDefaultAsync(m => m.AlbumId == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // GET: Albuns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Albuns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([Bind("AlbumId,Destino,FotoTopo,Inicio,Fim")] Album album, IFormFile arquivo)
        {
            if (ModelState.IsValid)
            {
                var linkUplod = Path.Combine(_webHostEnvironment.WebRootPath, "Imagens");
                if(arquivo != null)
                {
                    using(var fileStream = new FileStream(Path.Combine(linkUplod, arquivo.FileName), FileMode.Create))
                    {
                        await arquivo.CopyToAsync(fileStream);
                        album.FotoTopo = "~/imagens/" + arquivo.FileName;
                    }
                }

                _context.Add(album);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(album);
        }

        // GET: Albuns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albuns.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }
            TempData["FotoTopo"] = album.FotoTopo;
            return View(album);
        }

        // POST: Albuns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlbumId,Destino,FotoTopo,Inicio,Fim")] Album album, IFormFile arquivo)
        {
            if (id != album.AlbumId)
            {
                return NotFound();
            }

            if (String.IsNullOrEmpty(album.FotoTopo))
            
                album.FotoTopo = TempData["FotoTopo"].ToString();

            if (ModelState.IsValid)
            {
                try
                {
                    var linkUpload = Path.Combine(_webHostEnvironment.WebRootPath, "Imagens");

                    if(arquivo != null)
                    {
                        using(var fileStream = new FileStream(Path.Combine(linkUpload, arquivo.FileName), FileMode.Create))
                        {
                            await arquivo.CopyToAsync(fileStream);
                            album.FotoTopo = "~/Imagens/" + arquivo.FileName;
                        }

                    }
                    _context.Update(album);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumExists(album.AlbumId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(album);
        }

        // POST: Albuns/Delete/5
        [HttpPost]
        public async Task<JsonResult> Delete(int AlbumId)
        {
            try
            {
                var album = await _context.Albuns.FindAsync(AlbumId);
                IEnumerable<string> links = _context.Imagens.Where(i => i.AlbumId == AlbumId)
                    .Select(i => i.Link);

                //apagar imagens do diretorio
                foreach(var link in links)
                {
                    var linkImagem = link.Replace("~", "wwwroot");
                    System.IO.File.Delete(linkImagem);
                }
                //apagar imagens do banco 
                _context.Imagens.RemoveRange(_context.Imagens.Where
                    (x => x.AlbumId == AlbumId));

                //apagar imagem de topo do album
                string linkFotoAlbum = album.FotoTopo;
                linkFotoAlbum = linkFotoAlbum.Replace("~", "wwwroot");
                System.IO.File.Delete(linkFotoAlbum);


                if (album != null)
                {
                    _context.Albuns.Remove(album);
                    await _context.SaveChangesAsync();
                }
                return Json(new { success = true, message = "Álbum excluído com sucesso!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Erro ao excluir o álbum: " + ex.Message });
            }
        }

        private bool AlbumExists(int id)
        {
            return _context.Albuns.Any(e => e.AlbumId == id);
        }
    }
}
