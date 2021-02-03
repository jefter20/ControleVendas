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
    public class ProdutoDados
    {
        public List<ProdutoDominio> Buscar(ProdutoDominio objProduto)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;

                con.Open();

                comando.CommandText = "SELECT [CODIGO_PRODUTO], [NOME_PRODUTO], [EMBALAGEM], [TAMANHO], [UNIDADE_MEDIDA], [SABOR], [QUANTIDADE_ESTOQUE_INICIAL], [PRECO_DE_LISTA] FROM TABELA_PRODUTOS WHERE NOME_PRODUTO LIKE @NOME_PRODUTO";

                comando.Parameters.Add("NOME_PRODUTO", SqlDbType.VarChar).Value = objProduto.NomeProduto + "%";

                comando.Connection = con;

                SqlDataReader dr;
                List<ProdutoDominio> lista = new List<ProdutoDominio>();

                dr = comando.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ProdutoDominio dado = new ProdutoDominio();

                        dado.CodigoProduto = Convert.ToInt32(dr["CODIGO_PRODUTO"]);
                        dado.NomeProduto = Convert.ToString(dr["NOME_PRODUTO"]);
                        dado.Embalagem = Convert.ToString(dr["EMBALAGEM"]);
                        dado.Tamanho = Convert.ToString(dr["TAMANHO"]);
                        dado.UnidadeMedida = Convert.ToString(dr["UNIDADE_MEDIDA"]);
                        dado.Sabor = Convert.ToString(dr["SABOR"]);
                        dado.QuantidadeEstoqueInicial = Convert.ToString(dr["QUANTIDADE_ESTOQUE_INICIAL"]);
                        dado.PrecoDeLista = Convert.ToString(dr["PRECO_DE_LISTA"]);
                        
                        lista.Add(dado);
                    }
                }
                return lista;
            }
        }

        public int Inserir(ProdutoDominio objProduto)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;

                con.Open();

                comando.CommandText = "INSERT INTO TABELA_PRODUTOS ([NOME_PRODUTO], [EMBALAGEM], [TAMANHO], [UNIDADE_MEDIDA], [SABOR], [QUANTIDADE_ESTOQUE_INICIAL], [PRECO_DE_LISTA]) VALUES (@NOME_PRODUTO, @EMBALAGEM, @TAMANHO, @UNIDADE_MEDIDA, @SABOR, @QUANTIDADE_ESTOQUE_INICIAL, @PRECO_DE_LISTA)";

                comando.Parameters.Add("NOME_PRODUTO", SqlDbType.VarChar).Value = objProduto.NomeProduto;
                comando.Parameters.Add("EMBALAGEM", SqlDbType.VarChar).Value = objProduto.Embalagem;
                comando.Parameters.Add("TAMANHO", SqlDbType.Decimal).Value = objProduto.Tamanho;
                comando.Parameters.Add("UNIDADE_MEDIDA", SqlDbType.VarChar).Value = objProduto.UnidadeMedida;
                comando.Parameters.Add("SABOR", SqlDbType.VarChar).Value = objProduto.Sabor;
                comando.Parameters.Add("QUANTIDADE_ESTOQUE_INICIAL", SqlDbType.Decimal).Value = objProduto.QuantidadeEstoqueInicial;
                comando.Parameters.Add("PRECO_DE_LISTA", SqlDbType.Decimal).Value = objProduto.PrecoDeLista;

                comando.Connection = con;

                int qtd = comando.ExecuteNonQuery();
                Console.Write(qtd);
                return qtd;
            }
        }
        public int Excluir(ProdutoDominio objProduto)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;

                con.Open();

                comando.CommandText = "DELETE FROM TABELA_PRODUTOS WHERE CODIGO_PRODUTO = @CODIGO_PRODUTO";

                comando.Parameters.Add("CODIGO_PRODUTO", SqlDbType.Int).Value = objProduto.CodigoProduto;

                comando.Connection = con;

                int qtd = comando.ExecuteNonQuery();
                Console.Write(qtd);
                return qtd;
            }
        }

        public int Editar(ProdutoDominio objProduto)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;

                con.Open();

                comando.CommandText = "UPDATE TABELA_PRODUTOS SET NOME_PRODUTO = @NOME_PRODUTO, EMBALAGEM = @EMBALAGEM, TAMANHO = @TAMANHO, UNIDADE_MEDIDA = @UNIDADE_MEDIDA, SABOR = @SABOR, QUANTIDADE_ESTOQUE_INICIAL = @QUANTIDADE_ESTOQUE_INICIAL, PRECO_DE_LISTA = @PRECO_DE_LISTA WHERE CODIGO_PRODUTO = @CODIGO_PRODUTO";

                comando.Parameters.Add("CODIGO_PRODUTO", SqlDbType.Int).Value = objProduto.CodigoProduto;
                comando.Parameters.Add("NOME_PRODUTO", SqlDbType.VarChar).Value = objProduto.NomeProduto;
                comando.Parameters.Add("EMBALAGEM", SqlDbType.VarChar).Value = objProduto.Embalagem;
                comando.Parameters.Add("TAMANHO", SqlDbType.Decimal).Value = objProduto.Tamanho;
                comando.Parameters.Add("UNIDADE_MEDIDA", SqlDbType.VarChar).Value = objProduto.UnidadeMedida;
                comando.Parameters.Add("SABOR", SqlDbType.VarChar).Value = objProduto.Sabor;
                comando.Parameters.Add("QUANTIDADE_ESTOQUE_INICIAL", SqlDbType.Decimal).Value = objProduto.QuantidadeEstoqueInicial;
                comando.Parameters.Add("PRECO_DE_LISTA", SqlDbType.Decimal).Value = objProduto.PrecoDeLista;

                comando.Connection = con;

                int qtd = comando.ExecuteNonQuery();
                Console.Write(qtd);
                return qtd;
            }
        }
             
        public List<ProdutoDominio> Lista()
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;

                con.Open();

                comando.CommandText = "SELECT CODIGO_PRODUTO, NOME_PRODUTO, EMBALAGEM, TAMANHO, CONCAT(TAMANHO, UNIDADE_MEDIDA) AS TAMANHO_MEDIDA, UNIDADE_MEDIDA, SABOR, QUANTIDADE_ESTOQUE_INICIAL, PRECO_DE_LISTA FROM TABELA_PRODUTOS ORDER BY CODIGO_PRODUTO";

                comando.Connection = con;

                SqlDataReader dr;
                List<ProdutoDominio> lista = new List<ProdutoDominio>();

                dr = comando.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ProdutoDominio dado = new ProdutoDominio();

                        dado.CodigoProduto = Convert.ToInt32(dr["CODIGO_PRODUTO"]);
                        dado.NomeProduto = Convert.ToString(dr["NOME_PRODUTO"]);
                        dado.Embalagem = Convert.ToString(dr["EMBALAGEM"]);
                        dado.Tamanho = Convert.ToString(dr["TAMANHO"]);
                        dado.ConcatTamanhoMedida = Convert.ToString(dr["TAMANHO_MEDIDA"]);
                        dado.UnidadeMedida = Convert.ToString(dr["UNIDADE_MEDIDA"]);
                        dado.Sabor = Convert.ToString(dr["SABOR"]);
                        dado.QuantidadeEstoqueInicial = Convert.ToString(dr["QUANTIDADE_ESTOQUE_INICIAL"]);
                        dado.PrecoDeLista = Convert.ToString(dr["PRECO_DE_LISTA"]);

                        lista.Add(dado);
                    }
                }
                return lista;
            }
        }
    }
}
