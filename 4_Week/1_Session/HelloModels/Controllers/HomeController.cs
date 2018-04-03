using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HelloModels.Models;

namespace HelloModels.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            // List<Dictionary<string, object>>
            ViewBag.Players = DbConnector.Query("SELECT * FROM players");
            return View();
        }
        [HttpPost("create")]
        public IActionResult Create(Player player)
        {
            // Insert new player
            // write sql insert query
            string insertQuery = $@"
                INSERT INTO players (first_name, last_name, number) 
                VALUES ('{player.FirstName}', '{player.LastName}', '{player.Number}')
            ";
            DbConnector.Execute(insertQuery);

            return RedirectToAction("Index");
        }

    }
}
