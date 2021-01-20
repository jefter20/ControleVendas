using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_Vendas.Dominio
{
    public class ClienteCompraDominio
    {
        private int codigoCompra;
        private int codigoVenda;
        private int codigoCliente;
        private int codigoProduto;
        private string nomeProduto;
        private int quantidade;
        private double creditoLoja;
        private double limiteCredito;
        private double preco;
        private double precoTotal;
        private string dataHora;
        private double clientePrimeiraCompra;
        private string usuario;
        private string senha;

        public int CodigoCompra { get => codigoCompra; set => codigoCompra = value; }
        public int CodigoVenda { get => codigoVenda; set => codigoVenda = value; }
        public int CodigoCliente { get => codigoCliente; set => codigoCliente = value; }
        public int CodigoProduto { get => codigoProduto; set => codigoProduto = value; }
        public string NomeProduto { get => nomeProduto; set => nomeProduto = value; }
        public int Quantidade { get => quantidade; set => quantidade = value; }
        public double CreditoLoja { get => creditoLoja; set => creditoLoja = value; }
        public double LimiteCredito { get => limiteCredito; set => limiteCredito = value; }
        public double Preco { get => preco; set => preco = value; }
        public double PrecoTotal { get => precoTotal; set => precoTotal = value; }
        public string DataHora { get => dataHora; set => dataHora = value; }
        public double ClientePrimeiraCompra { get => clientePrimeiraCompra; set => clientePrimeiraCompra = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Senha { get => senha; set => senha = value; }
    }
}
