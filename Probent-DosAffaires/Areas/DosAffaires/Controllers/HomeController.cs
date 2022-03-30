/* Copyright (C) 2022  Thibaut Hebert--Henriette
 * See https://github.com/ThibautHH/Probent-DosAffaires/blob/main/NOTICE for full notice.
 */

using Microsoft.AspNetCore.Mvc;

namespace ProbentDosAffaires.Areas.DosAffaires.Controllers
{
    [Area("DosAffaires")]
    public class HomeController : Controller
    {
        public IActionResult Index() => this.View();

        public IActionResult APropos() => this.View();
    }
}