using DAL;
using MetaDados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class PetBAL
    {
        /// <summary>
        /// Ligação para a função InsertPet do banco de dados
        /// </summary>
        /// <param name="pet"></param>
        /// <returns>Response</returns>
        public static Response InsertPet(Pet pet)
        {
            pet.data_nascimento = Checker.StringCleaner(pet.data_nascimento);
            Response resp = PetDB.InsertPet(pet);
            return resp;

        }

        /// <summary>
        /// Ligação para a função SelectPet do banco de dados para trazer uma lista de pets
        /// </summary>
        /// <param name="pet_lista"></param>
        /// <param name="id_cliente"></param>
        /// <returns></returns>
        public static Response SelectListPet(/**/out List<Pet> pet_lista, int id_cliente)
        {

            Response resp = PetDB.SelectListPet(out pet_lista, id_cliente);
            return resp;

        }
        /// <summary>
        /// Ligação para a função SelectPet do banco de dados para trazer um pet
        /// </summary>
        /// <param name="pet"></param>
        /// <param name="id_pet"></param>
        /// <returns></returns>
        public static Response SelectPet(/**/out Pet pet, int id_pet)
        {

            Response resp = PetDB.SelectPet(out pet, id_pet);
            return resp;

        }
    }
}
