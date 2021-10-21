using BAL;
using DAL;
using MetaDados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetOnTrack.Controllers
{
    public static class FrontSupport
    {
        public static List<Servico> SelectListService()
        {
            // Select do BD
            List<Servico> servico_lista = new List<Servico>();
            ServicoBAL.SelectListService(/**/out servico_lista);

            // retorna esta lista prenchida
            return servico_lista;

        }
        public static List<Pet> SelectListPet(int id_cliente)
        {
            // Select do BD
            List<Pet> pet_lista = new List<Pet>();
            PetBAL.SelectListPet(/**/out pet_lista, id_cliente);

            // retorna esta lista prenchida
            return pet_lista;

        }

        public static List<Cliente> SelectListClient()
        {


            List<Cliente> lista = new List<Cliente>();

            lista = BAL.ClienteBAL.SelectListClient(0);

            return lista;
        }

        public static List<Cliente> SelectListClient(int id_cliente)
        {


            List<Cliente> lista = new List<Cliente>();

            lista = BAL.ClienteBAL.SelectListClient(id_cliente);

            return lista;
        }

        public static Pet SelectOnePet(int id_pet)
        {
            // Select do BD
            Pet pet = new Pet();
            PetBAL.SelectPet(/**/out pet, id_pet);

            // retorna este pet
            return pet;

        }
        public static List<Agenda> SelectListSchedule(int id_funcionario, DateTime data)
        {


            List<Agenda> lista = new List<Agenda>();

            Response resp = BAL.AgendaBAL.SelectListSchedule(out lista, id_funcionario, data);

            if (!resp.Executed)
            {
                lista = new List<Agenda>();
            }

            return lista;
        }
    }
}
