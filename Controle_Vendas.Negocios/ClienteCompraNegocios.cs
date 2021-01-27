using Controle_Vendas.Dados;
using Controle_Vendas.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_Vendas.Negocios
{
    public class ClienteCompraNegocios
    {
        public List<ClienteCompraDominio> Lista()
        {
            return new ClienteCompraDados().Lista();
        }

        public List<ClienteCompraDominio> Buscar(ClienteCompraDominio objCompra)
        {
            return new ClienteCompraDados().Buscar(objCompra);
        }
    }
}
