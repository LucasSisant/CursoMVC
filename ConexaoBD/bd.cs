using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexaoBD
{
    class bd : IDisposable
    {
        private readonly SqlConnection conexao;

        public bd()
        {
            conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
            conexao.Open();
        }

        public void ExecutaComando(string querySTR)
        {
            //string queryINS = String.Format(@"INSERT INTO usuarios VALUES('{0}', '{1}')", nome, cargo);
            var cmd = new SqlCommand
            {
                CommandText = querySTR,
                CommandType = CommandType.Text,
                Connection = conexao
            };
            cmd.ExecuteNonQuery();
        }

        public SqlDataReader ExecutaComandoRetorno (string querySTR)
        {
            //string querySEL = string.Format(@"SELECT * FROM usuarios where nome like '%{0}%'", nome);
            SqlCommand cmd = new SqlCommand(querySTR, conexao);
            return cmd.ExecuteReader();            
        }

        public void Dispose()
        {
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }
    }
}
