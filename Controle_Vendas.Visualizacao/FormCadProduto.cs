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
    public partial class FormCadProduto : Form
    {
        ProdutoDominio objProduto = new ProdutoDominio();

        public FormCadProduto()
        {
            InitializeComponent();
        }

        private string opcoes = "";

        private void ValidaProduto()
        {
            if (txtNomeProduto.Text == "" || txtEmbalagem.Text == "" || txtTamanho.Text == "" || txtSabor.Text == "" || txtQuantidadeEstoque.Text == "" || txtPreco.Text == "")
            {
                MessageBox.Show("Por favor, preencha todos os campos com (*)!");
                return;
            }

            opcoes = "SalvarProduto";
            IniciarOpcoes();
        }


        private void HabilitarCampos()
        {
            txtNomeProduto.Enabled = true;
            txtEmbalagem.Enabled = true;
            txtTamanho.Enabled = true;
            txtSabor.Enabled = true;
            txtQuantidadeEstoque.Enabled = true;
            txtPreco.Enabled = true;
        }

        private void DesabilitarCampos()
        {
            txtNomeProduto.Enabled = false;
            txtEmbalagem.Enabled = false;
            txtTamanho.Enabled = false;
            txtSabor.Enabled = false;
            txtQuantidadeEstoque.Enabled = false;
            txtPreco.Enabled = false;
        }

        private void LimparCampos()
        {
            txtCodigoProduto.Text = "";
            txtNomeProduto.Text = "";
            txtEmbalagem.Text = "";
            txtTamanho.Text = "";
            txtSabor.Text = "";
            txtQuantidadeEstoque.Text = "";
            txtPreco.Text = "";
        }

        public void ListarGrid()
        {
            try
            {
                List<ProdutoDominio> lista = new List<ProdutoDominio>();
                lista = new ProdutoNegocios().Lista();
                GridProdutos.AutoGenerateColumns = false;
                GridProdutos.DataSource = lista;
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
                        objProduto.NomeProduto = txtPesquisar.Text;

                        List<ProdutoDominio> lista = new List<ProdutoDominio>();
                        lista = new ProdutoNegocios().Buscar(objProduto);
                        GridProdutos.AutoGenerateColumns = false;
                        GridProdutos.DataSource = lista;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao pesquisar Dados " + ex.Message);
                    }
                    break;

                case "Novo":
                    HabilitarCampos();
                    LimparCampos();
                    break;

                case "SalvarProduto":
                    try
                    {
                        objProduto.NomeProduto = Convert.ToString(txtNomeProduto.Text);
                        objProduto.Embalagem = Convert.ToString(txtEmbalagem.Text);
                        objProduto.Tamanho = Convert.ToString(txtTamanho.Text);
                        objProduto.Sabor = Convert.ToString(txtSabor.Text);
                        objProduto.QuantidadeEstoque = Convert.ToInt32(txtQuantidadeEstoque.Text);
                        objProduto.PrecoDeLista = Convert.ToDecimal(txtPreco.Text);

                        int x = ProdutoNegocios.Inserir(objProduto);

                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Produto {0} adicionado com sucesso!", txtNomeProduto.Text));

                            LimparCampos();
                            DesabilitarCampos();
                            ListarGrid();
                        }
                        else
                        {
                            MessageBox.Show("Produto não adicionado");
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Erro ao adicionado Produto " + ex.Message);
                    }
                    break;

                case "Editar":
                    try
                    {
                        objProduto.CodigoProduto = Convert.ToInt32(txtCodigoProduto.Text);
                        objProduto.NomeProduto = Convert.ToString(txtNomeProduto.Text);
                        objProduto.Embalagem = Convert.ToString(txtEmbalagem.Text);
                        objProduto.Tamanho = Convert.ToString(txtTamanho.Text);
                        objProduto.Sabor = Convert.ToString(txtSabor.Text);
                        objProduto.QuantidadeEstoque = Convert.ToInt32(txtQuantidadeEstoque.Text);
                        objProduto.PrecoDeLista = Convert.ToDecimal(txtPreco.Text);

                        int x = ProdutoNegocios.Editar(objProduto);

                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Produto {0} alterado com sucesso!", txtNomeProduto.Text));

                            LimparCampos();
                            DesabilitarCampos();
                            ListarGrid();
                        }
                        else
                        {
                            MessageBox.Show("Produto não alterado");
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Erro ao alterado Produto " + ex.Message);
                    }
                    break;

                case "Excluir":
                    try
                    {
                        objProduto.CodigoProduto = Convert.ToInt32(txtCodigoProduto.Text);

                        int x = ProdutoNegocios.Excluir(objProduto);

                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Produto {0} excluido com sucesso!", txtNomeProduto.Text));

                            LimparCampos();
                            DesabilitarCampos();
                            ListarGrid();
                        }
                        else
                        {
                            MessageBox.Show("Produto não excluido");
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Erro ao excluir Produto " + ex.Message);
                    }
                    break;
            }
        }

        private void btnCadastroVendas_Click(object sender, EventArgs e)
        {
            FormCadVendas form = new FormCadVendas();
            this.Hide();
            form.Show();
        }

        private void btnControleEstoque_Click(object sender, EventArgs e)
        {
            FormCadProdutoEstoque form = new FormCadProdutoEstoque();
            this.Hide();
            form.Show();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            opcoes = "Novo";
            IniciarOpcoes();

            btnNovo.Enabled = false;
            btnSalvar.Enabled = true;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            txtNomeProduto.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            ValidaProduto();

            btnNovo.Enabled = true;
            btnSalvar.Enabled = true;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            opcoes = "Editar";
            IniciarOpcoes();

            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            opcoes = "Excluir";
            IniciarOpcoes();

            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
        }

        private void FormCadProduto_Load(object sender, EventArgs e)
        {
            DesabilitarCampos();
            ListarGrid();
            LimparCampos();

            txtPesquisar.Focus();
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            opcoes = "Pesquisar";
            IniciarOpcoes();
        }

        private void GridProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoProduto.Text = GridProdutos.CurrentRow.Cells[0].Value.ToString();
            txtNomeProduto.Text = GridProdutos.CurrentRow.Cells[1].Value.ToString();
            txtSabor.Text = GridProdutos.CurrentRow.Cells[2].Value.ToString();
            txtEmbalagem.Text = GridProdutos.CurrentRow.Cells[3].Value.ToString();
            txtTamanho.Text = GridProdutos.CurrentRow.Cells[4].Value.ToString();
            txtQuantidadeEstoque.Text = GridProdutos.CurrentRow.Cells[5].Value.ToString();
            txtPreco.Text = GridProdutos.CurrentRow.Cells[6].Value.ToString();

            HabilitarCampos();

            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
        }
    }
}
