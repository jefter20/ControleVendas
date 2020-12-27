using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_Vendas.Dominio
{
    public class VendedorDominio
    {
        private int codigoVendedor;
        private string nomeVendedor;
        private double percentualComissao;
        private string dataAdmissao;
        private double statusFerias;
        private string usuario;
        private string senha;

        public int CodigoVendedor { get => codigoVendedor; set => codigoVendedor = value; }
        public string NomeVendedor { get => nomeVendedor; set => nomeVendedor = value; }
        public double PercentualComissao { get => percentualComissao; set => percentualComissao = value; }
        public string DataAdmissao { get => dataAdmissao; set => dataAdmissao = value; }
        public double StatusFerias { get => statusFerias; set => statusFerias = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Senha { get => senha; set => senha = value; }
    }
}
