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
            // check if all fields are already present
            string checkPlayerQuery = 
            $@"
                SELECT * FROM players 
                WHERE first_name = '{player.FirstName}' 
                AND last_name = '{player.LastName}' 
                AND number = '{player.Number}' 
            ";
            List<string> words = new List<string>()
            {
                "one", "two", "thre"
            };

            int num_words = words.Count();
            List<Dictionary<string, object>> playersOrNone = DbConnector.Query(checkPlayerQuery);
            if(playersOrNone.Count() > 0)
            {
                ModelState.AddModelError("FirstName", "Player already exists");
            }
            // Manually add Model Errors

            if(ModelState.IsValid)
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
            ViewBag.Players = DbConnector.Query("SELECT * FROM players");
            return View("Index");
        }

    }
}
