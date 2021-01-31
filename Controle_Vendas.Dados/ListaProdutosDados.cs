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
    public class ListaProdutosDados
    {
        public List<ListaProdutosDominio> Lista()
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;

                con.Open();

                comando.CommandText = "SELECT CODIGO_PRODUTO, NOME_PRODUTO, EMBALAGEM, TAMANHO, SABOR, QUANTIDADE_EM_ESTOQUE, PRECO_DE_LISTA FROM TABELA_PRODUTOS ORDER BY CODIGO_PRODUTO";

                comando.Connection = con;

                SqlDataReader dr;
                List<ListaProdutosDominio> lista = new List<ListaProdutosDominio>();

                dr = comando.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ListaProdutosDominio dado = new ListaProdutosDominio();

                        dado.CodigoProduto = Convert.ToInt32(dr["CODIGO_PRODUTO"]);
                        dado.NomeProduto = Convert.ToString(dr["NOME_PRODUTO"]);
                        dado.Embalagem = Convert.ToString(dr["EMBALAGEM"]);
                        dado.Tamanho = Convert.ToString(dr["TAMANHO"]);
                        dado.Sabor = Convert.ToString(dr["SABOR"]);
                        dado.QuantidadeEstoqueInicial = Convert.ToInt32(dr["QUANTIDADE_EM_ESTOQUE"]);
                        dado.PrecoDeLista = Convert.ToDecimal(dr["PRECO_DE_LISTA"]);

                        lista.Add(dado);
                    }
                }
                return lista;
            }
        }

        public List<ListaProdutosDominio> Buscar(ListaProdutosDominio objListaProdutos)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;

                con.Open();

                comando.CommandText = "SELECT CODIGO_PRODUTO, NOME_PRODUTO, EMBALAGEM, TAMANHO, SABOR, QUANTIDADE_EM_ESTOQUE, PRECO_DE_LISTA FROM TABELA_PRODUTOS WHERE NOME_PRODUTO LIKE @NOME_PRODUTO";

                comando.Parameters.Add("NOME_PRODUTO", SqlDbType.VarChar).Value = objListaProdutos.NomeProduto + "%";

                comando.Connection = con;

                SqlDataReader dr;
                List<ListaProdutosDominio> lista = new List<ListaProdutosDominio>();

                dr = comando.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ListaProdutosDominio dado = new ListaProdutosDominio();

                        dado.CodigoProduto = Convert.ToInt32(dr["CODIGO_PRODUTO"]);
                        dado.NomeProduto = Convert.ToString(dr["NOME_PRODUTO"]);
                        dado.Embalagem = Convert.ToString(dr["EMBALAGEM"]);
                        dado.Tamanho = Convert.ToString(dr["TAMANHO"]);
                        dado.Sabor = Convert.ToString(dr["SABOR"]);
                        dado.QuantidadeEstoqueInicial = Convert.ToInt32(dr["QUANTIDADE_EM_ESTOQUE"]);
                        dado.PrecoDeLista = Convert.ToDecimal(dr["PRECO_DE_LISTA"]);

                        lista.Add(dado);
                    }
                }
                return lista;
            }
        }
    }
}
