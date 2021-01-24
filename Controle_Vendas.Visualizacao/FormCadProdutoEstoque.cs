using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controle_Vendas.Dominio;
using Controle_Vendas.Negocios;


namespace Controle_Vendas.Visualizacao
{
    public partial class FormCadProdutoEstoque : Form
    {
        public FormCadProdutoEstoque()
        {
            InitializeComponent();
        }

        public void ListarGrid()
        {
            try
            {
                List<ProdutoEstoqueDominio> lista = new List<ProdutoEstoqueDominio>();
                lista = new ProdutoEstoqueNegocios().Lista();
                GridProdutoEstoque.AutoGenerateColumns = false;
                GridProdutoEstoque.DataSource = lista;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao listar Dados da compra" + ex.Message);
            }
        }

        private void FormCadProdutoEstoque_Load(object sender, EventArgs e)
        {
            ListarGrid();
        }

        private void btnCadastroVendas_Click(object sender, EventArgs e)
        {
            FormCadVendas form = new FormCadVendas();
            this.Hide();
            form.Show();
        }
    }
}
