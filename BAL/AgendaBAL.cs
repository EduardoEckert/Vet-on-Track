using DAL;
using MetaDados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public static class AgendaBAL
    {
        /// <summary>
        /// Ligação para a função InsertSchedule do banco de dados
        /// </summary>
        /// <param name="agenda"></param>
        /// <returns></returns>
        public static Response InsertSchedule(Agenda agenda)
        {

            //tratamento de dados

            DateTime test = Convert.ToDateTime(agenda.string_horario);//teste



            try
            {
                AgendaDB.InsertSchedule(agenda);

                return new Response()
                {
                    Executed = true
                };
            }
            catch (Exception e)
            {
                return new Response()
                {
                    Executed = false,
                    ErrorMessage = "Insert de Agenda Inválido",
                    Exception = e
                };
            }

        }
        /// <summary>
        /// Ligação para a função SelectListSchedule do banco de dados
        /// </summary>
        /// <param name="list_agenda"></param>
        /// <param name="id_funcionario"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Response SelectListSchedule(out List<Agenda> list_agenda, int id_funcionario, DateTime data)
        {

            //tratamento de dados

            //DateTime test = Convert.ToDateTime(agenda.string_horario);//teste

            list_agenda = new List<Agenda>();
            DateTime datafinal = data;
            TimeSpan ts = new TimeSpan(23, 59, 0);
            datafinal = datafinal.Date + ts;
            try
            {
                AgendaDB.SelectListSchedule(out list_agenda, data, datafinal, id_funcionario);

                return new Response()
                {
                    Executed = true
                };
            }
            catch (Exception e)
            {
                return new Response()
                {
                    Executed = false,
                    ErrorMessage = "Update de Agenda Inválido",
                    Exception = e
                };
            }

        }


    }
}
