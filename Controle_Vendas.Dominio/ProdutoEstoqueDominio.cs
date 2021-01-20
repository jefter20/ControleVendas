using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_Vendas.Dominio
{
    public class ProdutoEstoqueDominio
    {
        private int codigoEstoque;
        private int codigoProduto;
        private string nomeProduto;
        private string embalagem;
        private string tamanho;
        private string sabor;
        private double quantidadeEstoque;
        private double produtoPrimeiraCompra;

        public int CodigoEstoque { get => codigoEstoque; set => codigoEstoque = value; }
        public int CodigoProduto { get => codigoProduto; set => codigoProduto = value; }
        public string NomeProduto { get => nomeProduto; set => nomeProduto = value; }
        public string Embalagem { get => embalagem; set => embalagem = value; }
        public string Tamanho { get => tamanho; set => tamanho = value; }
        public string Sabor { get => sabor; set => sabor = value; }
        public double QuantidadeEstoque { get => quantidadeEstoque; set => quantidadeEstoque = value; }
        public double ProdutoPrimeiraCompra { get => produtoPrimeiraCompra; set => produtoPrimeiraCompra = value; }
    }
}
