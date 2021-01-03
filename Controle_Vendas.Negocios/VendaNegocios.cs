using Controle_Vendas.Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controle_Vendas.Dominio;


namespace Controle_Vendas.Negocios
{
    public class VendaNegocios
    {
        public List<VendaDominio> Buscar(VendaDominio objVenda)
        {
            return new VendaDados().Buscar(objVenda);
        }

        public List<ClienteDominio> BuscaCliente(ClienteDominio objCliente)
        {
            return new VendaDados().BuscaCliente(objCliente);
        }

        public List<ProdutoDominio> BuscaProduto(ProdutoDominio objProduto)
        {
            return new VendaDados().BuscaProduto(objProduto);
        }

        public List<VendedorDominio> BuscaVendedor(VendedorDominio objVendedor)
        {
            return new VendaDados().BuscaVendedor(objVendedor);
        }

        public static int Inserir(VendaDominio objVenda)
        {
            return new VendaDados().Inserir(objVenda);
        }

        public static int Editar(VendaDominio objVenda)
        {
            return new VendaDados().Editar(objVenda);
        }

        public static int Excluir(VendaDominio objVenda)
        {
            return new VendaDados().Excluir(objVenda);
        }

        public List<VendaDominio> Lista()
        {
            return new VendaDados().Lista();
        }

        public static int AddClienteCompra(ClienteCompraDominio objCompra)
        {
            return new VendaDados().AddClienteCompra(objCompra);

        }
    }
}
