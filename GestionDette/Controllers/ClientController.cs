using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GestionDette.Models;
using Cours.Services;
using Cours.Models;

namespace GestionDette.Controllers;

public class ClientController : Controller
{
    private readonly ILogger<ClientController> _logger;
    private readonly IClientService _clientService;


    /* 
        ViewBag => Recupérer le même type
        ViewData => Dictionnaire durant une requête C => V | V => C
        TempData => Dictionnaire durant des requêtes successives
     */

    public ClientController(ILogger<ClientController> logger, IClientService clientService)
    {
        _logger = logger;
        _clientService = clientService;
    }
    // Home/Index | Routes
    public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10)
{
    // Obtenez le nombre total de clients pour calculer les pages
    int totalClients = await _clientService.GetTotalClientsCountAsync();

    // Récupérez la liste des clients paginée
    var clients = await _clientService.GetClientsAsync(pageNumber, pageSize);

    // Calculez le nombre total de pages
    int totalPages = (int)Math.Ceiling((double)totalClients / pageSize);

    // Passez les informations de pagination à la vue
    ViewBag.CurrentPage = pageNumber;
    ViewBag.TotalPages = totalPages;
    ViewBag.PageSize = pageSize;

    return View(clients);
}

    public  IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public  async Task<IActionResult> Create([Bind("Surnom,Telephone,Adresse")] Client client)
    {
        if (ModelState.IsValid)
        {
            Console.WriteLine($"***********************************************{client.Adresse}***********************************************");
            var clientAdded = await _clientService.Create(client);
            // if (clientAdded != null)
            // {
                TempData["Message"] = "Client créé avec succès!";
                return RedirectToAction(nameof(Index));
            // }
        }
        return View(client);
    }

   

   

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}



