using Controle_Vendas.Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controle_Vendas.Dominio;
using Controle_Vendas.Dados;

namespace Controle_Vendas.Negocios
{
    public class ClienteNegocios
    {
        public static int Inserir(ClienteDominio objCliente)
        {
            return new ClienteDados().Inserir(objCliente);
        }

        public List<ClienteDominio> Lista()
        {
            return new ClienteDados().Lista();
        }
    }
}
