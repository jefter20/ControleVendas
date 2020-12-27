using Controle_Vendas.Dominio;
using Controle_Vendas.Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_Vendas.Negocios
{
    public class VendedorNegocios
    {
        public VendedorDominio Login(VendedorDominio objVendedor)
        {
            return new VendedorDados().Login(objVendedor);
        }
    }
}
