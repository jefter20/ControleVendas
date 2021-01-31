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
    public partial class FormCadListaProdutos : Form
    {
        ListaProdutosDominio objListaProdutos = new ListaProdutosDominio();
        public FormCadListaProdutos()
        {
            InitializeComponent();
        }

        private string opcoes = "";

        private void IniciarOpcoes()
        {
            switch (opcoes)
            {
                case "Pesquisar":
                    try
                    {
                        objListaProdutos.NomeProduto = txtPesquisar.Text;

                        List<ListaProdutosDominio> lista = new List<ListaProdutosDominio>();
                        lista = new ListaProdutosNegocios().Buscar(objListaProdutos);
                        GridListaProdutos.AutoGenerateColumns = false;
                        GridListaProdutos.DataSource = lista;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao pesquisar Dados " + ex.Message);
                    }
                    break;
            }
        }

        public void ListarGrid()
        {
            try
            {
                List<ListaProdutosDominio> lista = new List<ListaProdutosDominio>();
                lista = new ListaProdutosNegocios().Lista();
                GridListaProdutos.AutoGenerateColumns = false;
                GridListaProdutos.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar Dados " + ex.Message);
            }
        }

        private void FormCadListaProdutos_Load(object sender, EventArgs e)
        {
            ListarGrid();
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            opcoes = "Pesquisar";
            IniciarOpcoes();
        }
    }
}
