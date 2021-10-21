using BAL;
using DAL;
using MetaDados;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetOnTrack.Controllers
{
    public class CadastrosController : Controller
    {
        /// <summary>
        /// Retorna a view CadastroFuncionario
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Retorna a view CadastroCliente
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Retorna a view CadastroPet
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Retorna a view CadastroServico
        /// </summary>
        /// <returns></returns>
        public IActionResult CadastroServico()
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

        /// <summary>
        /// Recebe os campos da view CadastroCliente e executa os comandos
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AuthCadastroCliente()
        {
            Cliente cliente = new Cliente();
            cliente.email = Request.Form["input_email"];
            cliente.senha = Request.Form["input_senha"];
            cliente.nome = Request.Form["input_name"];
            cliente.data_nascimento = Request.Form["input_data_de_nascimento"];
            cliente.cpf = Request.Form["input_cpf"];
            cliente.telefone_1 = Request.Form["input_tel_1"];
            cliente.telefone_2 = Request.Form["input_tel_2"];
            cliente.cep = Request.Form["input_cep"];
            cliente.cidade = Request.Form["input_cidade"];
            cliente.estado = Request.Form["input_estado"];
            cliente.rua = Request.Form["input_rua"];
            cliente.numero_residencia = Convert.ToInt32(Request.Form["input_numero_residencia"]);
            cliente.bairro = Request.Form["input_bairro"];
            cliente.complemento = Request.Form["input_complemento"];
            cliente.nivel = 0;

            Response res = ClienteBAL.InsertClient(cliente);

            if (res.Executed)
            {
                //Retorna para a página de cadastro concluído
                return RedirectToAction("CadastroOk", "Extra");
            }
            else
            {
                //Retorna para a página de cadastro não concluído
                ViewData["ErrorLog"] = res.ErrorMessage;
                return RedirectToAction("CadastroNaoOk", "Extra");
            }
        }

        /// <summary>
        /// Recebe os campos da view CadastroFuncionario e executa os comandos
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AuthCadastroFuncionario()
        {
            Funcionario func = new Funcionario();
            func.email = Request.Form["input_email"];
            func.senha = Request.Form["input_senha"];
            func.nome = Request.Form["input_name"];
            func.data_nascimento = Request.Form["input_data_de_nascimento"];
            func.cpf = Request.Form["input_cpf"];
            func.telefone_1 = Request.Form["input_tel_1"];
            func.telefone_2 = Request.Form["input_tel_2"];
            func.cep = Request.Form["input_cep"];
            func.cidade = Request.Form["input_cidade"];
            func.estado = Request.Form["input_estado"];
            func.rua = Request.Form["input_rua"];
            func.numero_residencia = Convert.ToInt32(Request.Form["input_numero_residencia"]);
            func.bairro = Request.Form["input_bairro"];
            func.cargo = Request.Form["input_cargo"];
            func.complemento = Request.Form["input_complemento"];
            func.crmv = Request.Form["input_crmv"];
            string salario = Checker.StringCleaner(Request.Form["input_salario"]);
            func.salario = Convert.ToDouble(salario);
            func.nivel = Convert.ToInt32(Request.Form["input_nivel"]);

            Response res = FuncionarioBAL.InsertEmployee(func);

            if (res.Executed)
            {
                //Retorna para a página de cadastro concluído
                return RedirectToAction("CadastroOk", "Extra");
            }
            else
            {
                //Retorna para a página de cadastro não concluído
                ViewData["ErrorLog"] = res.ErrorMessage;
                return RedirectToAction("CadastroNaoOk", "Extra");
            }
        }

        /// <summary>
        /// Recebe os campos da view CadastroPet e executa os comandos
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AuthCadastroPet()
        {
            Pet pet = new Pet();
            pet.id_cliente = Convert.ToInt32(Request.Form["input_id_cliente"]);
            pet.nome = Request.Form["input_nome_pet"];
            pet.data_nascimento = Request.Form["input_data_de_nascimento_pet"];
            pet.sexo = Convert.ToChar(Request.Form["input_sexo"]);
            pet.peso = Request.Form["input_peso"];
            pet.altura = Request.Form["input_altura"];
            pet.comprimento = Request.Form["input_comprimento"];
            pet.especie = Request.Form["input_especie"];
            pet.raca = Request.Form["input_raca"];
            pet.reg_animal = Request.Form["input_reg_animal"];
            pet.observacao = Request.Form["input_observacao"];


            Response res = PetBAL.InsertPet(pet);

            if (res.Executed)
            {
                //Retorna para a página de cadastro concluído
                return RedirectToAction("CadastroOk", "Extra");
            }
            else
            {
                //Retorna para a página de cadastro não concluído
                ViewData["ErrorLog"] = res.ErrorMessage;
                return RedirectToAction("CadastroNaoOk", "Extra");
            }


        }

        /// <summary>
        /// Recebe os campos da view CadastroServico e executa os comandos
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AuthCadastroServico()
        {
            Servico servico = new Servico();
            servico.nome = Request.Form["input_nome"];
            servico.valor = Convert.ToDouble(Request.Form["input_valor"]);
            servico.descricao = Request.Form["input_observacao"];

            Response res = ServicoBAL.InsertService(servico);

            if (res.Executed)
            {
                //Retorna para a página de cadastro concluído
                return RedirectToAction("CadastroOk", "Extra");
            }
            else
            {
                //Retorna para a página de cadastro não concluído
                ViewData["ErrorLog"] = res.ErrorMessage;
                return RedirectToAction("CadastroNaoOk", "Extra");
            }
        }
        [HttpPost]
        public IActionResult AuthCadastroAgendamento()
        {

            Agenda agenda = new Agenda();
            agenda.id_cliente = Convert.ToInt32(Request.Form["input_id_cliente"]);
            agenda.id_pet = Convert.ToInt32(Request.Form["input_id_pet"]);
            agenda.string_horario = Request.Form["input_agenda"] + Request.Form[""];
            agenda.id_servico = Convert.ToInt32(Request.Form["input_servico"]);



            Response res = AgendaBAL.InsertSchedule(agenda);

            if (res.Executed)
            {
                if (res.Executed)
                {
                    return RedirectToAction("CadastroServico", "Cadastros");
                }
                else
                {
                    ViewData["ErrorLog"] = res.ErrorMessage;
                    return RedirectToAction("Login", "Home");
                }
            }

            return RedirectToAction("Login", "Home");
        }

        public void SetError(string error)
        {
            ViewBag.Error = error;
        }

    }
}
