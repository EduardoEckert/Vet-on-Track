using DAL;
using BAL;
using Microsoft.AspNetCore.Mvc;

namespace VetOnTrack.Controllers
{
    public class ServicoController : Controller
    {
        public IActionResult DeleteService(int id_servico)
        {


            Response res = ServicoBAL.DeleteService(id_servico);
            if (res.Executed)
            {
                //Retorna para a página de cadastro concluído
                return RedirectToAction("ServicoDeletado", "Extra");
            }
            else
            {
                //Retorna para a página de cadastro não concluído
                ViewData["ErrorLog"] = res.ErrorMessage;
                return RedirectToAction("ServicoNaoDeletado", "Extra");
            }
        }
    }
}
