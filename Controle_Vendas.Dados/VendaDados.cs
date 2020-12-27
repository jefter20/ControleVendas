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
    public class VendaDados
    {
        public int Inserir(VendaDominio objVenda)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;

                con.Open();

                comando.CommandText = "INSERT INTO TABELA_VENDAS ([CODIGO_CLIENTE], [CODIGO_PRODUTO], [CODIGO_VENDEDOR], [CREDITO_LOJA], [QUANTIDADE], [PRECO], [DATA_HORA]) VALUES (@CODIGO_CLIENTE, @CODIGO_PRODUTO, @CODIGO_VENDEDOR, @CREDITO_LOJA, @QUANTIDADE, @PRECO, @DATA_HORA)";

                comando.Parameters.Add("CODIGO_CLIENTE", SqlDbType.Int).Value = objVenda.CodigoCliente;
                comando.Parameters.Add("CODIGO_PRODUTO", SqlDbType.Int).Value = objVenda.CodigoProduto;
                comando.Parameters.Add("CODIGO_VENDEDOR", SqlDbType.Int).Value = objVenda.CodigoVendedor;
                comando.Parameters.Add("CREDITO_LOJA", SqlDbType.Decimal).Value = objVenda.CreditoLoja;
                comando.Parameters.Add("QUANTIDADE", SqlDbType.Int).Value = objVenda.Quantidade;
                comando.Parameters.Add("PRECO", SqlDbType.Float).Value = objVenda.Preco;
                comando.Parameters.Add("DATA_HORA", SqlDbType.DateTime).Value = objVenda.DataHora;

                comando.Connection = con;

                int qtd = comando.ExecuteNonQuery();
                Console.Write(qtd);
                return qtd;
            }
        }

        public int Editar(VendaDominio objVenda)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;

                con.Open();

                comando.CommandText = "UPDATE TABELA_VENDAS SET CODIGO_CLIENTE = @CODIGO_CLIENTE, CODIGO_PRODUTO = @CODIGO_PRODUTO, CODIGO_VENDEDOR = @CODIGO_VENDEDOR, CREDITO_LOJA = @CREDITO_LOJA, QUANTIDADE = @QUANTIDADE, PRECO = @PRECO, DATA_HORA = @DATA_HORA WHERE CODIGO_VENDA = @CODIGO_VENDA";

                comando.Parameters.Add("CODIGO_VENDA", SqlDbType.Int).Value = objVenda.CodigoVenda;
                comando.Parameters.Add("CODIGO_CLIENTE", SqlDbType.Int).Value = objVenda.CodigoCliente;
                comando.Parameters.Add("CODIGO_PRODUTO", SqlDbType.Int).Value = objVenda.CodigoProduto;
                comando.Parameters.Add("CODIGO_VENDEDOR", SqlDbType.Int).Value = objVenda.CodigoVendedor;
                comando.Parameters.Add("CREDITO_LOJA", SqlDbType.Float).Value = objVenda.CreditoLoja;
                comando.Parameters.Add("QUANTIDADE", SqlDbType.Int).Value = objVenda.Quantidade;
                comando.Parameters.Add("PRECO", SqlDbType.Float).Value = objVenda.Preco;
                comando.Parameters.Add("DATA_HORA", SqlDbType.VarChar).Value = objVenda.DataHora;

                comando.Connection = con;

                int qtd = comando.ExecuteNonQuery();
                Console.Write(qtd);
                return qtd;
            }
        }

        public int Excluir(VendaDominio objVenda)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;

                con.Open();

                comando.CommandText = "DELETE FROM TABELA_VENDAS WHERE CODIGO_VENDA = @CODIGO_VENDA";

                comando.Parameters.Add("CODIGO_VENDA", SqlDbType.Int).Value = objVenda.CodigoVenda;

                comando.Connection = con;

                int qtd = comando.ExecuteNonQuery();
                Console.Write(qtd);
                return qtd;
            };
        }

        public List<VendaDominio> Lista()
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;

                con.Open();

                comando.CommandText = "SELECT VAS.CODIGO_VENDA, C.CODIGO_CLIENTE, C.NOME, P.CODIGO_PRODUTO, P.NOME_PRODUTO, VES.CODIGO_VENDEDOR, VES.NOME_VENDEDOR, VAS.CREDITO_LOJA, VAS.QUANTIDADE, VAS.PRECO, VAS.DATA_HORA FROM TABELA_VENDAS AS VAS INNER JOIN TABELA_CLIENTES AS C ON VAS.CODIGO_CLIENTE = C.CODIGO_CLIENTE INNER JOIN TABELA_PRODUTOS AS P ON VAS.CODIGO_PRODUTO = P.CODIGO_PRODUTO INNER JOIN TABELA_VENDEDORES AS VES ON VAS.CODIGO_VENDEDOR = VES.CODIGO_VENDEDOR ORDER BY C.NOME";

                comando.Connection = con;

                SqlDataReader dr;
                List<VendaDominio> lista = new List<VendaDominio>();

                dr = comando.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        VendaDominio dado = new VendaDominio();

                        dado.CodigoVenda = Convert.ToInt32(dr["CODIGO_VENDA"]);
                        dado.CodigoCliente = Convert.ToInt32(dr["CODIGO_CLIENTE"]);
                        dado.CodigoProduto = Convert.ToInt32(dr["CODIGO_PRODUTO"]);
                        dado.CodigoVendedor = Convert.ToInt32(dr["CODIGO_VENDEDOR"]);
                        dado.CreditoLoja = Convert.ToDouble(dr["CREDITO_LOJA"]);
                        dado.NomeCliente = Convert.ToString(dr["NOME"]);
                        dado.NomeProduto = Convert.ToString(dr["NOME_PRODUTO"]);
                        dado.NomeVendedor = Convert.ToString(dr["NOME_VENDEDOR"]);
                        dado.Quantidade = Convert.ToInt32(dr["QUANTIDADE"]);
                        dado.Preco = Convert.ToDouble(dr["PRECO"]);
                        dado.DataHora = Convert.ToString(dr["DATA_HORA"]);

                        lista.Add(dado);
                    }
                }
                return lista;
            }
        }

    }
}
