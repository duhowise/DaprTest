﻿using DaprTest.Mvc.Front.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using DaprTest.Mvc.Front.Services;

namespace DaprTest.Mvc.Front.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWeatherClient _weatherClient;

        public HomeController(ILogger<HomeController> logger, IWeatherClient weatherClient)
        {
            _logger = logger;
            _weatherClient = weatherClient;
        }

        public async Task<IActionResult> Index()
        {
            //logging info
            _logger.LogInformation("Entered Index method");
            var data = await _weatherClient.GetWeather();
            //logging info
            _logger.LogInformation($"Returning data {JsonSerializer.Serialize(data)}");
            return View(data);
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