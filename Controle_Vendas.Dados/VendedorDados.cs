using Controle_Vendas.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_Vendas.Dados
{
    public class VendedorDados
    {
        public VendedorDominio Login(VendedorDominio objVendedor)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;

                con.Open();

                comando.CommandText = "SELECT * FROM TABELA_VENDEDORES WHERE usuario = @usuario AND senha = @senha";

                comando.Connection = con;

                comando.Parameters.Add("usuario", SqlDbType.VarChar).Value = objVendedor.Usuario;
                comando.Parameters.Add("senha", SqlDbType.VarChar).Value = objVendedor.Senha;

                SqlDataReader dr;

                dr = comando.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        VendedorDominio dado = new VendedorDominio();

                        dado.Usuario = Convert.ToString(dr["usuario"]);
                        dado.Senha = Convert.ToString(dr["senha"]);
                    }
                }
                else
                {
                    objVendedor.Usuario = null;
                    objVendedor.Senha = null;
                }

                return objVendedor;
            }
        }
    }
}
