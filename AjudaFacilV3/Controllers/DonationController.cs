﻿using AjudaFacilV3.Data;
using AjudaFacilV3.Models;
using AjudaFacilV3.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace AjudaFacilV3.Controllers;

[Authorize]
public class DonationController : Controller
{
    private readonly ApplicationDbContext _context;

    private string caminhoServidor;

    public DonationController(ApplicationDbContext context, IWebHostEnvironment sistema)
    {
        caminhoServidor = sistema.WebRootPath;
        _context = context;
    }

    public IActionResult CreateClothingDonation()
    {
        return View();
    }

    public IActionResult CreateSchoolSupplieDonation()
    {
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateSchoolSupplieDonation(SchoolSupplieDonationViewModel donation)
    {
        string caminhoParaSalvarImagem = caminhoServidor + "\\imagem\\";
        string novoNomeParaImagem = Guid.NewGuid().ToString() + "_" + donation.Base64Image.FileName;


        if (!Directory.Exists(caminhoParaSalvarImagem))
        {
            Directory.CreateDirectory(caminhoParaSalvarImagem);
        }

        try
        {
            using (var stream = System.IO.File.Create(caminhoParaSalvarImagem + novoNomeParaImagem))
            {
                await donation.Base64Image.CopyToAsync(stream);
            }
        }
        catch (Exception errorMessage)
        {
            return new JsonResult(errorMessage.Message);
        }


        // Se o modelo que vem do front não for valido eu retorno um apagina de erro
        if (!ModelState.IsValid)
        {
            return NotFound();
        }



        if (ModelState.IsValid)
        {
            // Inicia um novo objeto das doações e passa os valores da viewModel para o objeto verdadeiro a ser salva no banco
            var schoolSupplieDonation = new SchoolSupplieDonation
            {
                Id = donation.Id,
                Description = donation.Description,
                Weight = donation.Weight,
                Image = novoNomeParaImagem,
                Donations = new Donation
                {
                    Id = donation.Id,
                    CreateAt = DateTime.Now,
                    User = User.Identity.Name
                }
            };
            _context.Add(schoolSupplieDonation); // adiciona ao contexto
            await _context.SaveChangesAsync(); // salva tudo no banco
            return RedirectToAction(nameof(CreateSchoolSupplieDonation)); // retorno para a mesma pagina de doacao
        }

        return View(donation);
    }


    public async Task<ViewResult> DetailsDonation(int? pagina)
    {
        // Cria uma lista para adicionar todos os tipos de doacoes
        List<UserDonationsViewModel> donationsList = new List<UserDonationsViewModel>();


        // Acesso o banco nas doacoes de school, pega a doação que é somente do usuario que esta logado
        // cria uma viewModel para enviar as informações das doações padronizadas pro front-end.
        var schoolSupplieDonationList = _context.SchoolSupplieDonations
            .AsNoTracking()
            .Include(x => x.Donations)
            .Where(x => x.Donations.User == User.Identity.Name)
            .Select(x => new UserDonationsViewModel
            {
                Id = x.Id,
                CreateAt = x.Donations.CreateAt,
                Name = "Materiais Escolares.",
                Description = x.Description,
                Weight = x.Weight,
                Image = x.Image,
                User = x.Donations.User
            })
            .ToPagedList();

        var clothingDonationList = _context.ClothingDonations
            .AsNoTracking()
            .Include(x => x.Donations)
            .Where(x => x.Donations.User == User.Identity.Name)
            .Select(x => new UserDonationsViewModel
            {
                Id = x.Id,
                CreateAt = x.Donations.CreateAt,
                Name = "Roupas",
                Description = x.Description,
                Weight = x.Weight,
                Image = x.Image,
                User = x.Donations.User
            })
            .ToPagedList();

        // adiciona as duas listas de doacoes a lista principal
        donationsList.AddRange(schoolSupplieDonationList);
        donationsList.AddRange(clothingDonationList);

        int tamanhoPagina = 5;
        int numeroPagina = pagina ?? 1;

        // retorna pro front-end com a classe ToPagedList para poder fazer paginacao e controlar a quantidade de doações que é enviada.
        return View(await donationsList
            .OrderByDescending(x => x.CreateAt)
            .ToPagedListAsync(numeroPagina, tamanhoPagina));
    }


    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> CreateClothingDonation(ClothingDonationViewModel model)
    {
        var caminhoParaSalvarImagem = caminhoServidor + "//imagem//";
        var novoNomeParaImagem = Guid.NewGuid().ToString() + "_" + model.Base64Image.FileName;

        if (!Directory.Exists(caminhoParaSalvarImagem))
        {
            Directory.CreateDirectory(caminhoParaSalvarImagem);
        }

        try
        {
            using (var stream = System.IO.File.Create(caminhoParaSalvarImagem + novoNomeParaImagem))
            {
                await model.Base64Image.CopyToAsync(stream);
            }
        }
        catch (Exception)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return NotFound();
        }

        var clothingDonation = new ClothingDonation
        {
            Id = model.Id,
            Description = model.Description,
            Weight = model.Weight,
            Image = novoNomeParaImagem,
            Donations = new Donation
            {
                Id = model.Id,
                CreateAt = DateTime.Now,
                User = User.Identity.Name
            }
        };
        _context.Add(clothingDonation);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(CreateClothingDonation));
    }
}
