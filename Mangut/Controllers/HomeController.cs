using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SegundaEntrega.Data;
using SegundaEntrega.Models;
using SegundaEntrega.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SegundaEntrega.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            dbContext = context;
            webHostEnvironment = hostEnvironment;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var produto = await dbContext.Produtos.ToListAsync();
            return View(produto);
        }

        public IActionResult New()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Home()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Busca()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult QuemSomos()
        {
            return View();
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(ProdutoViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);

                Produto produto = new Produto
                {
                    Nome = model.Nome,
                    Tipo = model.Tipo,
                    NomeTipo = model.Nome + " " + model.Tipo,
                    ImagemProduto = uniqueFileName
                };
                dbContext.Add(produto);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }



        private string UploadedFile(ProdutoViewModel model)
        {
            string uniqueFileName = null;

            if (model.ImagemProduto != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImagemProduto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImagemProduto.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
