using Controle_Vendas.Dominio;
using Controle_Vendas.Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controle_Vendas.Visualizacao
{
    public partial class FormCadClienteCompras : Form
    {
        ClienteCompraDominio objCompra = new ClienteCompraDominio();
        public FormCadClienteCompras()
        {
            InitializeComponent();
        }
        
        public void ListarGrid()
        {
            try
            {
                List<ClienteCompraDominio> lista = new List<ClienteCompraDominio>();
                lista = new ClienteCompraNegocios().Lista();
                GridClienteCompras.AutoGenerateColumns = false;
                GridClienteCompras.DataSource = lista;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao listar Dados da compra" + ex.Message);
            }
        }

        private void FormCadClienteCompras_Load(object sender, EventArgs e)
        {
            ListarGrid();
        }
    }
}
