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
    public class ProdutoEstoqueDados
    {
        public List<ProdutoEstoqueDominio> Lista()
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;

                con.Open();

                comando.CommandText = "SELECT CODIGO_ESTOQUE, CODIGO_PRODUTO, NOME_PRODUTO, EMBALAGEM, TAMANHO, SABOR, QUANTIDADE_EM_ESTOQUE FROM TABELA_PRODUTO_ESTOQUE ORDER BY CODIGO_ESTOQUE";

                comando.Connection = con;

                SqlDataReader dr;
                List<ProdutoEstoqueDominio> lista = new List<ProdutoEstoqueDominio>();

                dr = comando.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ProdutoEstoqueDominio dado = new ProdutoEstoqueDominio();

                        dado.CodigoEstoque = Convert.ToInt32(dr["CODIGO_ESTOQUE"]);
                        dado.CodigoProduto = Convert.ToInt32(dr["CODIGO_PRODUTO"]);
                        dado.NomeProduto = Convert.ToString(dr["NOME_PRODUTO"]);
                        dado.Embalagem = Convert.ToString(dr["EMBALAGEM"]);
                        dado.Tamanho = Convert.ToString(dr["TAMANHO"]);
                        dado.Sabor = Convert.ToString(dr["SABOR"]);
                        dado.QuantidadeEstoque = Convert.ToDouble(dr["QUANTIDADE_EM_ESTOQUE"]);

                        lista.Add(dado);
                    }
                }
                return lista;
            }
        }

        public List<ProdutoEstoqueDominio> Buscar(ProdutoEstoqueDominio objEstoque)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;

                con.Open();

                comando.CommandText = "SELECT [CODIGO_ESTOQUE], [CODIGO_PRODUTO], [NOME_PRODUTO], [EMBALAGEM], [TAMANHO], [SABOR], [QUANTIDADE_EM_ESTOQUE] FROM TABELA_PRODUTO_ESTOQUE WHERE NOME_PRODUTO LIKE @NOME_PRODUTO";

                comando.Parameters.Add("NOME_PRODUTO", SqlDbType.VarChar).Value = objEstoque.NomeProduto + "%";

                comando.Connection = con;

                SqlDataReader dr;
                List<ProdutoEstoqueDominio> lista = new List<ProdutoEstoqueDominio>();

                dr = comando.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ProdutoEstoqueDominio dado = new ProdutoEstoqueDominio();

                        dado.CodigoEstoque = Convert.ToInt32(dr["CODIGO_ESTOQUE"]);
                        dado.CodigoProduto = Convert.ToInt32(dr["CODIGO_PRODUTO"]);
                        dado.NomeProduto = Convert.ToString(dr["NOME_PRODUTO"]);
                        dado.Embalagem = Convert.ToString(dr["EMBALAGEM"]);
                        dado.Tamanho = Convert.ToString(dr["TAMANHO"]);
                        dado.Sabor = Convert.ToString(dr["SABOR"]);
                        dado.QuantidadeEstoque = Convert.ToDouble(dr["QUANTIDADE_EM_ESTOQUE"]);

                        lista.Add(dado);
                    }
                }
                return lista;
            }
        }
    }
}
