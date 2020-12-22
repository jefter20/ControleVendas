using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controle_Vendas.Dominio;
using Controle_Vendas.Dados;

namespace Controle_Vendas.Dados
{
    public class ClienteDados
    {        
        public int Inserir(ClienteDominio objCliente)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;

                con.Open();

                comando.CommandText = "INSERT INTO TABELA_CLIENTES ([NOME], [CPF], [ENDERECO_1], [ENDERECO_2], [BAIRRO], [CIDADE], [UF], [CEP], [DATA_NASCIMENTO], [SEXO], [LIMITE_CREDITO], [VOLUME_COMPRA], [PRIMEIRA_COMPRA]) VALUES (@NOME, @CPF, @ENDERECO_1, @ENDERECO_2, @BAIRRO, @CIDADE, @UF, @CEP, @DATA_NASCIMENTO, @SEXO, @LIMITE_CREDITO, @VOLUME_COMPRA, @PRIMEIRA_COMPRA)";

                comando.Parameters.Add("NOME", SqlDbType.VarChar).Value = objCliente.Nome;
                comando.Parameters.Add("CPF", SqlDbType.VarChar).Value = objCliente.Cpf;
                comando.Parameters.Add("ENDERECO_1", SqlDbType.VarChar).Value = objCliente.Endereco1;
                comando.Parameters.Add("ENDERECO_2", SqlDbType.VarChar).Value = objCliente.Endereco2;
                comando.Parameters.Add("BAIRRO", SqlDbType.VarChar).Value = objCliente.Bairro;
                comando.Parameters.Add("CIDADE", SqlDbType.VarChar).Value = objCliente.Cidade;
                comando.Parameters.Add("UF", SqlDbType.VarChar).Value = objCliente.Uf;
                comando.Parameters.Add("CEP", SqlDbType.VarChar).Value = objCliente.Cep;
                comando.Parameters.Add("DATA_NASCIMENTO", SqlDbType.VarChar).Value = objCliente.DataNascimento;
                comando.Parameters.Add("SEXO", SqlDbType.VarChar).Value = objCliente.Sexo;
                comando.Parameters.Add("LIMITE_CREDITO", SqlDbType.VarChar).Value = objCliente.LimiteCredito;
                comando.Parameters.Add("VOLUME_COMPRA", SqlDbType.VarChar).Value = objCliente.VolumeCompra;
                comando.Parameters.Add("PRIMEIRA_COMPRA", SqlDbType.VarChar).Value = objCliente.PrimeiraCompra;

                comando.Connection = con;

                int qtd = comando.ExecuteNonQuery();
                Console.Write(qtd);
                return qtd;
            }
        }
                
        public List<ClienteDominio> Lista()
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;

                con.Open();

                comando.CommandText = "SELECT * FROM TABELA_CLIENTES ORDER BY NOME";

                comando.Connection = con;

                SqlDataReader dr;
                List<ClienteDominio> lista = new List<ClienteDominio>();

                dr = comando.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ClienteDominio dado = new ClienteDominio();

                        dado.CodigoCliente = Convert.ToInt32(dr["CODIGO_CLIENTE"]);
                        dado.Nome = Convert.ToString(dr["NOME"]);
                        dado.Cpf = Convert.ToString(dr["CPF"]);
                        dado.Endereco1 = Convert.ToString(dr["ENDERECO_1"]);
                        dado.Endereco2 = Convert.ToString(dr["ENDERECO_2"]);
                        dado.Bairro = Convert.ToString(dr["BAIRRO"]);
                        dado.Cidade = Convert.ToString(dr["CIDADE"]);
                        dado.Uf = Convert.ToString(dr["UF"]);
                        dado.Cep = Convert.ToString(dr["CEP"]);
                        dado.DataNascimento = Convert.ToString(dr["DATA_NASCIMENTO"]);
                        dado.Sexo = Convert.ToString(dr["SEXO"]);
                        dado.LimiteCredito = Convert.ToString(dr["LIMITE_CREDITO"]);
                        dado.VolumeCompra = Convert.ToString(dr["VOLUME_COMPRA"]);
                        dado.PrimeiraCompra = Convert.ToString(dr["PRIMEIRA_COMPRA"]);

                        lista.Add(dado);
                    }
                }

                return lista;
            }
        }
    }
}
