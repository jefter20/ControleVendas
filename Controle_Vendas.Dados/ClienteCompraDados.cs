﻿using Controle_Vendas.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_Vendas.Dados
{
    public class ClienteCompraDados
    {
        public List<ClienteCompraDominio> Lista()
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;

                con.Open();

                comando.CommandText = "SELECT CODIGO_COMPRA, CODIGO_PRODUTO, NOME_PRODUTO, QUANTIDADE, CREDITO_LOJA, PRECO, PRECO_TOTAL, DATA_HORA FROM TABELA_CLIENTE_COMPRAS ORDER BY NOME_PRODUTO";

                comando.Connection = con;

                SqlDataReader dr;
                List<ClienteCompraDominio> lista = new List<ClienteCompraDominio>();

                dr = comando.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ClienteCompraDominio dado = new ClienteCompraDominio();

                        dado.CodigoCompra = Convert.ToInt32(dr["CODIGO_COMPRA"]);
                        dado.CodigoProduto = Convert.ToInt32(dr["CODIGO_PRODUTO"]);
                        dado.NomeProduto = Convert.ToString(dr["NOME_PRODUTO"]);
                        dado.Quantidade = Convert.ToInt32(dr["QUANTIDADE"]);
                        dado.CreditoLoja = Convert.ToDouble(dr["CREDITO_LOJA"]);
                        dado.Preco = Convert.ToDouble(dr["PRECO"]);
                        dado.PrecoTotal = Convert.ToDouble(dr["PRECO_TOTAL"]);
                        dado.DataHora = Convert.ToString(dr["DATA_HORA"]);

                        lista.Add(dado);
                    }
                }
                return lista;
            }
        }
    }
}
