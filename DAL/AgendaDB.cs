using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDados;

namespace DAL
{
    public static class AgendaDB
    {
        /// <summary>
        /// Insere no dbo.agenda -> Objeto agenda (id_servico, hr_agenda, id_cliente_fk, id_pet_fk)
        /// </summary>
        /// <param name="agenda"></param>
        /// <returns></returns>
        public static Response InsertSchedule(Agenda agenda)
        {
            string insert = "insert into dbo.agenda (id_servico, hr_agenda, id_cliente_fk, id_pet_fk) values (@id_servico, @hr_agenda, @id_cliente_fk, @id_pet_fk)";
            Response resp = new Response();
            SqlCommand cmd = new SqlCommand(insert, ConnectionString.Connection);

            try
            {
                ConnectionString.Connection.Open();
                cmd.Parameters.AddWithValue("@id_servico", agenda.id_servico);
                cmd.Parameters.AddWithValue("@hr_agenda", agenda.hr_agenda.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@id_cliente_fk", agenda.id_cliente);
                cmd.Parameters.AddWithValue("@id_pet_fk", agenda.id_pet);

                cmd.ExecuteNonQuery();
                ConnectionString.Connection.Close();
                resp.Executed = true;

            }
            //Erro encontrado
            catch (Exception e)
            {
                //Retorna o erro 
                resp.Executed = false;
                resp.ErrorMessage = "Erro";
                resp.Exception = e;
            }
            // Fecha a conexão caso esteja aberta
            if (ConnectionString.Connection.State == System.Data.ConnectionState.Open)
            {
                ConnectionString.Connection.Close();
            }
            return resp;
        }
        /// <summary>
        /// Seleciona a lista filtrada de todos os agendamentos do dia selecionado de um funcionário
        /// </summary>
        /// <param name="list_Agenda"></param>
        /// <param name="filtro_Inicio"></param>
        /// <param name="filtro_Final"></param>
        /// <param name="id_funcionario"></param>
        /// <returns></returns>
        public static Response SelectListSchedule(out List<Agenda> list_Agenda, DateTime filtro_Inicio, DateTime filtro_Final, int id_funcionario)
        {
            list_Agenda = new List<Agenda>();
            string select;
            bool tem_filtro = false;
            if (filtro_Final == DateTime.MinValue && filtro_Inicio == DateTime.MinValue)
            {
                select = $"select * from dbo.agenda";

            }
            else
            {
                select = $"select * from dbo.agenda where hr_agenda >= @filtro_Inicio and hr_agenda <= @filtro_Final and id_funcionario = @id_funcionario"; //colocar pra usar o id_funcionario como filtro tmb
                tem_filtro = true;
            }
            Response resp = new Response();
            SqlCommand cmd = new SqlCommand(select, ConnectionString.Connection);

            try
            {
                ConnectionString.Connection.Open();
                if (tem_filtro)
                {
                    cmd.Parameters.AddWithValue("@filtro_Inicio", filtro_Inicio.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@filtro_Final", filtro_Final.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@id_funcionario", id_funcionario);

                }
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //colocar o que precisa na agenda

                    Agenda agenda = new Agenda();
                    agenda.id_agenda = Convert.ToInt32(dr["id_agenda"]);
                    agenda.id_servico = Convert.ToInt32(dr["id_servico"]);
                    agenda.hr_agenda = Convert.ToDateTime(dr["hr_agenda"]);
                    agenda.id_cliente = Convert.ToInt32(dr["id_cliente"]);
                    agenda.id_pet = Convert.ToInt32(dr["id_pet"]);
                    agenda.id_funcionario = Convert.ToInt32(dr["id_funcionario"]);

                    list_Agenda.Add(agenda);

                }
                dr.Close();
                ConnectionString.Connection.Close();
                resp.Executed = true;

            }
            //Erro encontrado
            catch (Exception e)
            {
                //Retorna o erro 
                resp.Executed = false;
                resp.ErrorMessage = "Erro";
                resp.Exception = e;
            }
            // Fecha a conexão caso esteja aberta
            if (ConnectionString.Connection.State == System.Data.ConnectionState.Open)
            {
                ConnectionString.Connection.Close();
            }
            return resp;
        }
        /// <summary>
        /// Deleta os agendamentos relacionados ao pet deletado
        /// </summary>
        /// <param name="id_pet"></param>
        /// <returns></returns>
        public static Response DeleteSchedulePet(int id_pet)
        {
            string delete = "delete from dbo.agenda where id_pet = @id_pet";
            Response resp = new Response();
            SqlCommand cmd = new SqlCommand(delete, ConnectionString.Connection);
            try
            {
                ConnectionString.Connection.Open();
                cmd.Parameters.AddWithValue("@id_pet", id_pet);

                cmd.ExecuteNonQuery();
                ConnectionString.Connection.Close();
                resp.Executed = true;

            }
            //Erro encontrado
            catch (Exception e)
            {
                //Retorna o erro 
                resp.Executed = false;
                resp.ErrorMessage = "Erro";
                resp.Exception = e;
            }
            // Fecha a conexão caso esteja aberta
            if (ConnectionString.Connection.State == System.Data.ConnectionState.Open)
            {
                ConnectionString.Connection.Close();
            }
            return resp;
        }
        /// <summary>
        /// Deleta os agendamentos relacionados ao cliente deletado
        /// </summary>
        /// <param name="id_cliente"></param>
        /// <returns></returns>
        public static Response DeleteScheduleClient(int id_cliente)
        {
            string delete = "delete from dbo.agenda where id_cliente = @id_cliente";
            Response resp = new Response();
            SqlCommand cmd = new SqlCommand(delete, ConnectionString.Connection);
            try
            {
                ConnectionString.Connection.Open();
                cmd.Parameters.AddWithValue("@id_cliente", id_cliente);

                cmd.ExecuteNonQuery();
                ConnectionString.Connection.Close();
                resp.Executed = true;

            }
            //Erro encontrado
            catch (Exception e)
            {
                //Retorna o erro 
                resp.Executed = false;
                resp.ErrorMessage = "Erro";
                resp.Exception = e;
            }
            // Fecha a conexão caso esteja aberta
            if (ConnectionString.Connection.State == System.Data.ConnectionState.Open)
            {
                ConnectionString.Connection.Close();
            }
            return resp;
        }

        /// <summary>
        /// Deleta os agendamentos relacionados ao servico deletado
        /// </summary>
        /// <param name="id_servico"></param>
        /// <returns></returns>
        public static Response DeleteScheduleService(int id_servico)
        {
            string delete = "delete from dbo.agenda where id_servico = @id_servico";
            Response resp = new Response();
            SqlCommand cmd = new SqlCommand(delete, ConnectionString.Connection);
            try
            {
                ConnectionString.Connection.Open();
                cmd.Parameters.AddWithValue("@id_servico", id_servico);

                cmd.ExecuteNonQuery();
                ConnectionString.Connection.Close();
                resp.Executed = true;

            }
            //Erro encontrado
            catch (Exception e)
            {
                //Retorna o erro 
                resp.Executed = false;
                resp.ErrorMessage = "Erro";
                resp.Exception = e;
            }
            // Fecha a conexão caso esteja aberta
            if (ConnectionString.Connection.State == System.Data.ConnectionState.Open)
            {
                ConnectionString.Connection.Close();
            }
            return resp;
        }
    }
}
