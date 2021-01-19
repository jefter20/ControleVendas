using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_Vendas.Dominio
{
    public class ClienteDominio
    {
        private int codigoCliente;
        private string nome;
        private string cpf;
        private string endereco1;
        private string endereco2;
        private string bairro;
        private string cidade;
        private string uf;
        private string cep;
        private string dataNascimento;
        private string sexo;
        private string limiteCredito;
        private string volumeCompra;
        private string primeiraCompra;
        private string usuario;
        private string senha;

        public int CodigoCliente { get => codigoCliente; set => codigoCliente = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Endereco1 { get => endereco1; set => endereco1 = value; }
        public string Endereco2 { get => endereco2; set => endereco2 = value; }
        public string Bairro { get => bairro; set => bairro = value; }
        public string Cidade { get => cidade; set => cidade = value; }
        public string Uf { get => uf; set => uf = value; }
        public string Cep { get => cep; set => cep = value; }
        public string DataNascimento { get => dataNascimento; set => dataNascimento = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        public string LimiteCredito { get => limiteCredito; set => limiteCredito = value; }
        public string VolumeCompra { get => volumeCompra; set => volumeCompra = value; }
        public string PrimeiraCompra { get => primeiraCompra; set => primeiraCompra = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Senha { get => senha; set => senha = value; }
    }
}
