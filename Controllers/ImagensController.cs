﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AlbumDeFotos.Models;

namespace AlbumDeFotos.Controllers
{
    public class ImagensController : Controller
    {
        private readonly Contexto _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        #region InjecaoDeDependencia
        public ImagensController(Contexto context,IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        #endregion


        // GET: Imagens/Create
        public IActionResult Create(int id)
        {
            var album = _context.Albuns.FirstOrDefault(x => x.AlbumId == id);
            if (album == null)
            {
                return NotFound("Album não encontrado.");
            }

            ViewBag.Destinos = album;
            return View();
        }

        // POST: Imagens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImagemId,Link,AlbumId")] Imagem imagem, IFormFile arquivo)
        {
            if (ModelState.IsValid)
            {
                var linkUpload = Path.Combine(_webHostEnvironment.WebRootPath, "Imagens");

                if (arquivo != null)
                {
                    using (var fileStream = new FileStream(Path.Combine(linkUpload, arquivo.FileName), FileMode.Create))
                    {
                        await arquivo.CopyToAsync(fileStream);
                        imagem.Link = "~/Imagens/" + arquivo.FileName;
                    }
                }

                _context.Add(imagem);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Albuns", new { id = imagem.AlbumId });
            }
            ViewData["AlbumId"] = new SelectList(_context.Albuns, "AlbumId", "Destino", imagem.AlbumId);
            return View(imagem);
        }

    }
}
