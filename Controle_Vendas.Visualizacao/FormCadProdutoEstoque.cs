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
        ProdutoEstoqueDominio objEstoque = new ProdutoEstoqueDominio();

        public FormCadProdutoEstoque()
        {
            InitializeComponent();
        }

        private string opcoes = "";

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

                MessageBox.Show("Erro ao listar Dados " + ex.Message);
            }
        }

        private void IniciarOpcoes()
        {
            switch (opcoes)
            {
                case "Pesquisar":
                    try
                    {
                        objEstoque.NomeProduto = txtPesquisar.Text;

                        List<ProdutoEstoqueDominio> lista = new List<ProdutoEstoqueDominio>();
                        lista = new ProdutoEstoqueNegocios().Buscar(objEstoque);
                        GridProdutoEstoque.AutoGenerateColumns = false;
                        GridProdutoEstoque.DataSource = lista;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao pesquisar Dados " + ex.Message);
                    }
                    break;
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

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            opcoes = "Pesquisar";
            IniciarOpcoes();
        }
    }
}
