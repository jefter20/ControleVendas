using Controle_Vendas.Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controle_Vendas.Dominio;

namespace Controle_Vendas.Negocios
{
    public class ClienteNegocios
    {
        public List<ClienteDominio> Buscar(ClienteDominio objCliente)
        {
            return new ClienteDados().Buscar(objCliente);
        }

        public static int Inserir(ClienteDominio objCliente)
        {
            return new ClienteDados().Inserir(objCliente);
        }

        public List<ClienteDominio> Lista()
        {
            return new ClienteDados().Lista();
        }

        public ClienteDominio Login(ClienteDominio objCliente)
        {
            return new ClienteDados().Login(objCliente);
        }
    }
}
