using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GestionDette.Models;
using Cours.Services;
using Cours.Services.Impl;

namespace GestionDette.Controllers;

public class PaiementController : Controller
{
    private readonly ILogger<PaiementController> _logger;
    private readonly IPaiementService _paiementService;

    /* 
        ViewBag => Recupérer le même type
        ViewData => Dictionnaire durant une requête C => V | V => C
        TempData => Dictionnaire durant des requêtes successives
     */

    public PaiementController(ILogger<PaiementController> logger, IPaiementService paiementService)
    {
        _logger = logger;
        _paiementService = paiementService;
    }
    // Home/Index | Routes
    public async Task<IActionResult> Index()
    {
        
        return View();
    }

    public async Task<IActionResult> PaiementsDette(int Id)
    {
        var paiementsDette = await _paiementService.GetDettePaiementsAsync(Id);
        return View(paiementsDette);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
