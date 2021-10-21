using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetOnTrack.Controllers
{
    public class AgendaController : Controller
    {
        public IActionResult AuthSchedule(string input_agenda)
        {
            return RedirectToAction("Agenda", "Home", new { data_consulta = input_agenda });
        }

        public IActionResult DeleteAgenda(int id_agenda)
        {

            return RedirectToAction("Agenda", "Home");
        }
    }
}
