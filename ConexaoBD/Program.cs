using System;
using System.Data.SqlClient;
using System.Data;

namespace ConexaoBD
{
    class Program
    {
        static bd banco = new bd();

        static void Main(string[] args)
        {
            //DeletarUsuario(3);
            ListarUsuarios();
            Console.ReadKey();
        }


        static void DeletarUsuario(int id)
        {            
            banco.ExecutaComando(string.Format("DELETE FROM usuarios WHERE id_usuario = {0}", id));            
        }

        static void AtualizaUsuario(int id, string nome, string cargo)
        {
            banco.ExecutaComando(string.Format("UPDATE usuarios SET nome='{0}', cargo='{1}' WHERE id_usuario = {2}", nome, cargo, id));
        }


        static void InserirUsuario(string nome, string cargo)
        {
            banco.ExecutaComando(string.Format("INSERT INTO usuarios VALUES('{0}', '{1}')", nome, cargo));
        }

        static void ListarUsuarios()
        {
            SqlDataReader dados = banco.ExecutaComandoRetorno("SELECT * FROM usuarios");
            while (dados.Read())
            {
                Console.WriteLine("IdUsuario: {0}, Nome: {1}, Cargo: {2}", dados[0], dados[1], dados[2]);
            }
        }      
    }
}
