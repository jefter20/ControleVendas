using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_Vendas.Dominio
{
    public class VendaDominio
    {
        private int codigoVenda;
        private int codigoCliente;
        private int codigoProduto;
        private int codigoVendedor;
        private double creditoLoja;
        private string nomeCliente;
        private string nomeProduto;
        private string nomeVendedor;
        private int quantidade;
        private double preco;
        private string dataHora;

        public int CodigoVenda { get => codigoVenda; set => codigoVenda = value; }
        public int CodigoCliente { get => codigoCliente; set => codigoCliente = value; }
        public int CodigoProduto { get => codigoProduto; set => codigoProduto = value; }
        public int CodigoVendedor { get => codigoVendedor; set => codigoVendedor = value; }
        public double CreditoLoja { get => creditoLoja; set => creditoLoja = value; }
        public string NomeCliente { get => nomeCliente; set => nomeCliente = value; }
        public string NomeProduto { get => nomeProduto; set => nomeProduto = value; }
        public string NomeVendedor { get => nomeVendedor; set => nomeVendedor = value; }
        public int Quantidade { get => quantidade; set => quantidade = value; }
        public double Preco { get => preco; set => preco = value; }
        public string DataHora { get => dataHora; set => dataHora = value; }
    }
}
