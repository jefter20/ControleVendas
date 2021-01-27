using Controle_Vendas.Dados;
using Controle_Vendas.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_Vendas.Negocios
{
    public class ProdutoNegocios
    {
        public List<ProdutoDominio> Buscar(ProdutoDominio objProduto)
        {
            return new ProdutoDados().Buscar(objProduto);
        }

        public static int Inserir(ProdutoDominio objProduto)
        {
            return new ProdutoDados().Inserir(objProduto);

        }

        public static int Editar(ProdutoDominio objProduto)
        {
            return new ProdutoDados().Editar(objProduto);

        }

        public static int Excluir(ProdutoDominio objProduto)
        {
            return new ProdutoDados().Excluir(objProduto);
        }

        public List<ProdutoDominio> Lista()
        {
            return new ProdutoDados().Lista();
        }
    }
}
