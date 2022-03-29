/* Copyright (C) 2022  Thibaut Hebert--Henriette
 * See https://github.com/ThibautHH/Probent-DosAffaires/blob/main/NOTICE for full notice.
 */

using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using ProbentDosAffaires.Models;

namespace ProbentDosAffaires.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => this.View();

        public IActionResult APropos() => this.View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
    }
}