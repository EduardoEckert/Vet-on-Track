using BAL;
using DAL;
using MetaDados;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetOnTrack.Models;

namespace VetOnTrack.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //----------------------- // ------------------------------//
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return Unauthorized();
            }
        }

        public IActionResult CadastroFuncionario()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return Unauthorized();
            }
        }

        public IActionResult CadastroCliente()
        {

            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return Unauthorized();
            }
        }

        public IActionResult CadastroPet()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return Unauthorized();
            }
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return Unauthorized();
            }
        }
        public IActionResult Cliente()
        {

            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return Unauthorized();
            }
        }
        public IActionResult Agenda(string data_consulta)
        {
            if (User.Identity.IsAuthenticated)
            {

                byte[] sessionIdFuncionario;
                HttpContext.Session.TryGetValue("idFuncionario", out sessionIdFuncionario);

                string idFuncionario = Encoding.ASCII.GetString(sessionIdFuncionario);

                ViewBag.IdFunc = Convert.ToInt32(idFuncionario);
                if (string.IsNullOrEmpty(data_consulta))
                {
                    ViewBag.data_agenda = DateTime.Today;
                }
                else
                {
                    ViewBag.data_agenda = Convert.ToDateTime(data_consulta);
                }
                return View();
            }
            else
            {
                return Unauthorized();
            }
        }
        public IActionResult Servico()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return Unauthorized();
            }
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();

            HttpContext.Session.Clear();

            HttpContext.Session.Remove("idAcesso");
            HttpContext.Session.Remove("idFuncionario");

            return Redirect("login");
        }

        public IActionResult Perfil()
        {
            if (User.Identity.IsAuthenticated)
            {

                //byte[] sessionIdAcesso;
                byte[] sessionIdFuncionario;

                //HttpContext.Session.TryGetValue("idAcesso", out sessionIdAcesso);

                HttpContext.Session.TryGetValue("idFuncionario", out sessionIdFuncionario);

                //string idAcesso = Encoding.ASCII.GetString(sessionIdAcesso);
                string idFuncionario = Encoding.ASCII.GetString(sessionIdFuncionario);

                Funcionario func = new Funcionario();

                Response res = FuncionarioBAL.SelectProfileEmployee(Convert.ToInt32(idFuncionario), out func);

                if (res.Executed)
                {
                    ViewBag.Perfil = func;
                }
                else
                {
                    if (res.ErrorMessage != null || res.Exception != null)
                    {
                        ViewBag.ErroMessage = res.ErrorMessage;
                        ViewBag.Exception = res.Exception;
                    }
                    else
                    {
                        ViewBag.ErroMessage = "Não foi possível buscar o perfil do funcionário :(";
                    }
                }

                return View();

            }
            else
            {
                return Unauthorized();
            }
        }

        public void SetError(string error)
        {
            ViewBag.Error = error;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
