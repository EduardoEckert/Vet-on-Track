using MetaDados;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace DAL
{
    public static class ServicoDB
    {
        /// <summary>
        /// Insere no dbo.servico -> Objeto servico (nome, valor, descricao)
        /// </summary>
        /// <param name="servico"></param>
        /// <returns>Response(int id_dado)</returns>
        public static Response InsertService(Servico servico)
        {
            string insert = "insert into dbo.servico (nome,valor,descricao) values (@nome,@valor,@descricao)";
            SqlCommand cmd = new SqlCommand(insert, ConnectionString.Connection);
            Response resp = new Response();
            try
            {
                ConnectionString.Connection.Open();
                cmd.Parameters.AddWithValue("@nome", servico.nome);
                cmd.Parameters.AddWithValue("@valor", servico.valor);                        // Adiciona os parâmetros atribuindo os valores ao objeto
                cmd.Parameters.AddWithValue("@descricao", servico.descricao);                // (Método para evitar SQL Injection)
                cmd.ExecuteNonQuery();                                                       // Executa o comando imediatamente
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
        /// Seleciona a lista de todos os serviços
        /// </summary>
        /// <param name="servico_lista"></param>
        /// <returns>Response List(servico)</returns>
        public static Response SelectListService(/**/ out List<Servico> servico_lista)
        {
            servico_lista = new List<Servico>();
            string select = "select * from dbo.servico";
            SqlCommand cmd = new SqlCommand(select, ConnectionString.Connection);
            Response resp = new Response();
            try
            {
                ConnectionString.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();         //Executa a leitura do banco de dados
                while (dr.Read())
                {
                    servico_lista.Add(new Servico(dr));

                }
                dr.Close();
                ConnectionString.Connection.Close();
                //Comando executado corretamente
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
        /// Deleta um serviço
        /// </summary>
        /// <param name="id_servico"></param>
        /// <returns>Response</returns>
        public static Response DeleteService(int id_servico)
        {

            string delete = "delete  from dbo.servico where id_servico = @id_servico";
            SqlCommand cmd = new SqlCommand(delete, ConnectionString.Connection);
            Response resp = new Response();
            try
            {
                resp = AgendaDB.DeleteScheduleService(id_servico);
                if (!resp.Executed)
                {
                    return resp;
                }
                ConnectionString.Connection.Open();
                cmd.Parameters.AddWithValue("@id_servico", id_servico);
                cmd.ExecuteNonQuery();
                ConnectionString.Connection.Close();
                //Comando executado corretamente
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


