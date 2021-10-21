using MetaDados;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class PetDB
    {
        /// <summary>
        /// Insere no dbo.pet -> Objeto pet (id_dado_fk, id_cliente_fk, sexo, peso, altura, especie, raca, porte, reg_animal, observacao)
        /// </summary>
        /// <param name="pet"></param>
        /// <returns></returns>
        public static Response InsertPet(Pet pet)
        {
            Response resp = new Response();
            resp = GenericDB.InsertData(new Dado(pet.nome, pet.data_nascimento));    // Insere e retorna o dado

            if (!resp.Executed)
            {
                return resp;
            }
            pet.id_dado = resp.ElementId;
            string insert = "insert into dbo.pet (id_dado_fk,id_cliente,sexo,peso,altura,comprimento,especie,raca,reg_animal,observacao) values (@id_dado_fk, @id_cliente,@sexo, @peso, @altura,@comprimento, @especie, @raca, @reg_animal, @observacao)";

            SqlCommand cmd = new SqlCommand(insert, ConnectionString.Connection);
            try
            {
                ConnectionString.Connection.Open();
                cmd.Parameters.AddWithValue("@id_dado_fk", pet.id_dado);
                cmd.Parameters.AddWithValue("@id_cliente", pet.id_cliente);
                cmd.Parameters.AddWithValue("@sexo", pet.sexo);
                cmd.Parameters.AddWithValue("@peso", pet.peso);
                cmd.Parameters.AddWithValue("@altura", pet.altura);                 //   Adiciona os parâmetros atribuindo os valores ao objeto
                cmd.Parameters.AddWithValue("@comprimento", pet.comprimento);
                cmd.Parameters.AddWithValue("@especie", pet.especie);               //   (Método para evitar SQL Injection)
                cmd.Parameters.AddWithValue("@raca", pet.raca);
                cmd.Parameters.AddWithValue("@reg_animal", pet.reg_animal);
                cmd.Parameters.AddWithValue("@observacao", pet.observacao);
                cmd.ExecuteNonQuery();                                              // Executa o comando imediatamente
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
        /// Seleciona um pet de determinado cliente
        /// </summary>
        /// <param name="pet"></param>
        /// <param name="id_pet"></param>
        /// <returns></returns>
        public static Response SelectPet(out Pet pet, int id_pet)
        {
            pet = new Pet();
            string select;
            select = "select * from dbo.pet where id_pet = @id_pet";
            Response resp = new Response();

            SqlCommand cmd = new SqlCommand(select, ConnectionString.Connection);

            try
            {
                ConnectionString.Connection.Open();
                cmd.Parameters.AddWithValue("@id_pet", id_pet);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    pet.id_pet = Convert.ToInt32(dr["id_pet"]);
                    pet.id_dado = Convert.ToInt32(dr["id_dado_fk"]);
                    pet.id_cliente = Convert.ToInt32(dr["id_cliente"]);
                    pet.sexo = Convert.ToChar(dr["sexo"]);
                    pet.peso = dr["peso"].ToString();
                    pet.altura = dr["altura"].ToString();
                    cmd.Parameters.AddWithValue("@comprimento", pet.comprimento);
                    pet.comprimento = dr["comprimento"].ToString();
                    pet.especie = dr["especie"].ToString();
                    pet.raca = dr["raca"].ToString();
                    pet.reg_animal = dr["reg_animal"].ToString();
                    pet.observacao = dr["observacao"].ToString();
                }
                dr.Close();
                ConnectionString.Connection.Close();

                try
                {
                    Dado dado = new Dado();
                    resp = GenericDB.SelectData(out dado, pet.id_dado);

                    if (!resp.Executed)
                    {
                        return resp;
                    }

                    pet.nome = dado.nome;
                    pet.data_nascimento = dado.data_nascimento;

                }
                //Erro encontrado
                catch (Exception e)
                {
                    // Fecha a conexão caso esteja aberta
                    if (ConnectionString.Connection.State == System.Data.ConnectionState.Open)
                    {
                        ConnectionString.Connection.Close();
                    }
                    //Retorna o erro 
                    resp.Executed = false;
                    resp.ErrorMessage = "Erro";
                    resp.Exception = e;

                    return resp;
                }


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
        /// Seleciona a lista de todos os pets de determinado cliente
        /// </summary>
        /// <param name="list_pet"></param>
        /// <param name="id_cliente"></param>
        /// <returns>Response List(pet)</returns>
        public static Response SelectListPet(out List<Pet> list_pet, int id_cliente)
        {
            list_pet = new List<Pet>();
            Response resp = new Response();
            string select = "select * from dbo.pet where id_cliente = @id_cliente";

            SqlCommand cmd = new SqlCommand(select, ConnectionString.Connection);

            try
            {
                ConnectionString.Connection.Open();
                cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Pet pet = new Pet();
                    pet.id_pet = Convert.ToInt32(dr["id_pet"]);
                    pet.id_dado = Convert.ToInt32(dr["id_dado_fk"]);
                    pet.id_cliente = Convert.ToInt32(dr["id_cliente"]);
                    pet.sexo = Convert.ToChar(dr["sexo"]);
                    pet.peso = dr["peso"].ToString();
                    pet.altura = dr["altura"].ToString();
                    pet.comprimento = dr["comprimento"].ToString();
                    pet.especie = dr["especie"].ToString();
                    pet.raca = dr["raca"].ToString();
                    pet.reg_animal = dr["reg_animal"].ToString();
                    pet.observacao = dr["observacao"].ToString();

                    list_pet.Add(pet);

                }
                dr.Close();
                ConnectionString.Connection.Close();

                foreach (var item in list_pet)
                {
                    try
                    {
                        Dado dado = new Dado();
                        resp = GenericDB.SelectData(out dado, item.id_dado);
                        if (!resp.Executed)
                        {
                            return resp;
                        }

                        item.nome = dado.nome;
                        item.data_nascimento = dado.data_nascimento;
                    }
                    catch (Exception e)
                    {
                        return new Response()
                        {
                            Executed = false,
                            ErrorMessage = "Erro", //mudar
                            Exception = e
                        };
                    }
                }

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
        /// Deleta todos os pets de um determinado cliente
        /// </summary>
        /// <param name="id_cliente"></param>
        /// <returns>Response</returns>
        public static Response DeletePetsClient(int id_cliente)
        {
            Response resp = new Response();
            try
            {
                List<Pet> lista_pet = new List<Pet>();
                resp = SelectListPet(out lista_pet, id_cliente);
                if (!resp.Executed)
                {
                    return resp;
                }

                foreach (var item in lista_pet)
                {
                    resp = GenericDB.DeleteData(item.id_dado);
                    if (!resp.Executed)
                    {
                        return resp;
                    }
                }
                //Comando executado corretamente
                resp.Executed = true;
            }//Erro encontrado
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
        /// Deleta um pet de determinado cliente
        /// </summary>
        /// <param name="id_pet"></param>
        /// <returns>Response</returns>
        public static Response DeletePet(int id_pet)
        {
            Response resp = new Response();
            Pet pet = new Pet();
            try
            {
                resp = AgendaDB.DeleteSchedulePet(id_pet);
                if (!resp.Executed)
                {
                    return resp;
                }
                SelectPet(out pet, id_pet);
                resp = GenericDB.DeleteData(pet.id_dado);

                if (!resp.Executed)
                {
                    return resp;
                }
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
