using DAL;
using MetaDados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class ServicoBAL
    {
        /// <summary>
        /// Ligação para a função InsertService do banco de dados
        /// </summary>
        /// <param name="servico"></param>
        /// <returns>Response</returns>
        public static Response InsertService(Servico servico)
        {
            Response resp = ServicoDB.InsertService(servico);
            return resp;

        }

        /// <summary>
        /// Ligação para a função SelectListService do banco de dados
        /// </summary>
        /// <param name="servico_lista"></param>
        /// <returns>Response</returns>
        public static Response SelectListService(/**/out List<Servico> servico_lista)
        {

            Response resp = ServicoDB.SelectListService(out servico_lista);
            return resp;

        }

        /// <summary>
        /// Ligação para a função DeleteService do banco de dados
        /// </summary>
        /// <param name="id_servico"></param>
        /// <returns></returns>
        public static Response DeleteService(int id_servico)
        {

            Response resp = ServicoDB.DeleteService(id_servico);
            return resp;

        }
    }
}
