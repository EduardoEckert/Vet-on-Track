using System;
using System.Data.SqlClient;

namespace MetaDados
{
    public class Servico
    {
        public int id_servico { get; set; }
        public string nome { get; set; }
        public double valor { get; set; }
        public string descricao { get; set; }
        public Servico()
        {

        }
        public Servico(SqlDataReader dr)
        {
            this.id_servico = Convert.ToInt32(dr["id_servico"].ToString());
            this.nome = dr["nome"].ToString();
            this.valor = Convert.ToDouble(dr["valor"].ToString());
            this.descricao = dr["descricao"].ToString();
        }
    }

}
