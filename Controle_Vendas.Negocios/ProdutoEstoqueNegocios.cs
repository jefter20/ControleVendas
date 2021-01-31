using Controle_Vendas.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controle_Vendas.Dados;

namespace Controle_Vendas.Negocios
{
    public class ProdutoEstoqueNegocios
    {
        public List<ProdutoEstoqueDominio> Buscar(ProdutoEstoqueDominio objEstoque)
        {
            return new ProdutoEstoqueDados().Buscar(objEstoque);
        }

        public List<ProdutoEstoqueDominio> Lista()
        {
            return new ProdutoEstoqueDados().Lista();
        }
    }
}
