using Controle_Vendas.Dados;
using Controle_Vendas.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_Vendas.Negocios
{
    public class ListaProdutosNegocios
    {
        public List<ListaProdutosDominio> Lista()
        {
            return new ListaProdutosDados().Lista();
        }

        public List<ListaProdutosDominio> Buscar(ListaProdutosDominio objListaProdutos)
        {
            return new ListaProdutosDados().Buscar(objListaProdutos);
        }
    }
}
