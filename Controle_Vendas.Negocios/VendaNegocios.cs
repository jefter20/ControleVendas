﻿using Controle_Vendas.Dados;
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
        public static int Inserir(VendaDominio objVenda)
        {
            return new VendaDados().Inserir(objVenda);
        }

        public List<VendaDominio> Lista()
        {
            return new VendaDados().Lista();
        }

        public static int Editar(VendaDominio objVenda)
        {
            return new VendaDados().Editar(objVenda);
        }

        public static int Excluir(VendaDominio objVenda)
        {
            return new VendaDados().Excluir(objVenda);
        }
    }
}
