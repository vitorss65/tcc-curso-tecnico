﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TechReciclyingAlpha.Filters;
using TechReciclyingAlpha.Models;

namespace TechReciclyingAlpha.Controllers
{

    [PaginaParaUsuarioLogado] 
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}