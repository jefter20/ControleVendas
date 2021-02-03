using Controle_Vendas.Dominio;
using Controle_Vendas.Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            if (txtNomeProduto.Text == "" || txtEmbalagem.Text == "" || txtTamanho.Text == "" || cmbMedida.Text == "" || txtSabor.Text == "" || txtQuantidadeEstoqueInicial.Text == "" || txtPreco.Text == "")
            {
                MessageBox.Show("Por favor, preencha todos os campos com (*)!");
                return;
            }

            opcoes = "SalvarProduto";
            IniciarOpcoes();
        }

        private void ValidaUnidadeMedidaTamanho()
        {
            if (!string.IsNullOrEmpty(txtTamanho.Text))
            {
                if (Convert.ToDouble(txtTamanho.Text) > 0 && Convert.ToDouble(txtTamanho.Text) <= 1)
                {
                    cmbMedida.Text = " Litro";
                    return;
                }

                if (Convert.ToDouble(txtTamanho.Text) > 1 && Convert.ToDouble(txtTamanho.Text) < 100)
                {
                    cmbMedida.Text = " Litros";
                    return;
                }

                if (Convert.ToDouble(txtTamanho.Text) >= 100 && Convert.ToDouble(txtTamanho.Text) < 1000)
                {
                    cmbMedida.Text = " ml";
                    return;
                }

                if (Convert.ToDouble(txtTamanho.Text) >= 1000)
                {
                    MessageBox.Show("Valor acima do permitido!");
                    txtTamanho.Text = "";
                    cmbMedida.Text = "";
                    return;
                }

               if (Convert.ToDouble(txtTamanho.Text) <= 0)
                {
                    txtTamanho.Text = "";
                    cmbMedida.Text = "";
                    return;
                }
            }
            else
            {
                txtTamanho.Text = "";
                cmbMedida.Text = "";
            }

            
        }

        private void ApenasCaracteresTexto(KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && !Char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void ApenasNumerosDecimais(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar.Equals((char)Keys.Back))
            {
                TextBox t = (TextBox) sender;
                string s = Regex.Replace(t.Text, "[^0-9]", string.Empty);
                if (s == string.Empty) s = "00";

                if (s.Length > 0) 
                {
                    if (e.KeyChar.Equals((char)Keys.Back))
                        s = s.Substring(0, s.Length - 1);
                    else
                        s += e.KeyChar;
                }
                else
                {
                    return;
                }

                t.Text = string.Format("{0:#,##0.00}", Double.Parse(s) / 100);
            }

            e.Handled = true;
        }

        private void ApenasNumerosInteiros(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar.Equals((char)Keys.Back))
            {
                TextBox t = (TextBox) sender;
                string s = Regex.Replace(t.Text, "[^0-9]", string.Empty);

                if (s.Length > 0)
                {
                    if (e.KeyChar.Equals((char)Keys.Back))
                        s = s.Substring(0, s.Length - 1);
                    else
                        s += e.KeyChar;
                }
                else
                {
                    return;
                }

                if (s == string.Empty) s = "00";
                t.Text = string.Format("{0:#,##}", Double.Parse(s));
            }

            e.Handled = true;
        }

        private void HabilitarCampos()
        {
            txtNomeProduto.Enabled = true;
            txtEmbalagem.Enabled = true;
            txtTamanho.Enabled = true;
            txtSabor.Enabled = true;
            txtQuantidadeEstoqueInicial.Enabled = true;
            txtPreco.Enabled = true;
        }

        private void DesabilitarCampos()
        {
            txtNomeProduto.Enabled = false;
            txtEmbalagem.Enabled = false;
            txtTamanho.Enabled = false;
            cmbMedida.Enabled = false;
            txtSabor.Enabled = false;
            txtQuantidadeEstoqueInicial.Enabled = false;
            txtPreco.Enabled = false;
        }

        private void LimparCampos()
        {
            txtCodigoProduto.Text = "";
            txtNomeProduto.Text = "";
            txtEmbalagem.Text = "";
            txtTamanho.Text = "";
            cmbMedida.Text = "";
            txtSabor.Text = "";
            txtQuantidadeEstoqueInicial.Text = "";
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
                        objProduto.UnidadeMedida = Convert.ToString(cmbMedida.Text);
                        objProduto.Sabor = Convert.ToString(txtSabor.Text);
                        objProduto.QuantidadeEstoqueInicial = Convert.ToString(txtQuantidadeEstoqueInicial.Text);
                        objProduto.PrecoDeLista = Convert.ToString(txtPreco.Text);

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

                        MessageBox.Show("Erro ao adicionar Produto " + ex.Message);
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
                        objProduto.QuantidadeEstoqueInicial = Convert.ToString(txtQuantidadeEstoqueInicial.Text);
                        objProduto.PrecoDeLista = Convert.ToString(txtPreco.Text);

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
            cmbMedida.Enabled = false;
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

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            opcoes = "Pesquisar";
            IniciarOpcoes();
        }

        private void txtTamanho_TextChanged(object sender, EventArgs e)
        {
            ValidaUnidadeMedidaTamanho();
        }

        private void txtNomeProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            ApenasCaracteresTexto(e);
        }

        private void txtSabor_KeyPress(object sender, KeyPressEventArgs e)
        {
            ApenasCaracteresTexto(e);
        }

        private void txtEmbalagem_KeyPress(object sender, KeyPressEventArgs e)
        {
            ApenasCaracteresTexto(e);
        }

        private void txtTamanho_KeyPress(object sender, KeyPressEventArgs e)
        {
            ApenasNumerosDecimais(sender, e);
        }

        private void txtQuantidadeEstoqueInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            ApenasNumerosInteiros(sender, e);
        }

        private void txtPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            ApenasNumerosDecimais(sender, e);
        }

        private void GridProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoProduto.Text = GridProdutos.CurrentRow.Cells[0].Value.ToString();
            txtNomeProduto.Text = GridProdutos.CurrentRow.Cells[1].Value.ToString();
            txtSabor.Text = GridProdutos.CurrentRow.Cells[2].Value.ToString();
            txtEmbalagem.Text = GridProdutos.CurrentRow.Cells[3].Value.ToString();
            txtTamanho.Text = GridProdutos.CurrentRow.Cells[4].Value.ToString();
            cmbMedida.Text = GridProdutos.CurrentRow.Cells[6].Value.ToString();
            txtQuantidadeEstoqueInicial.Text = GridProdutos.CurrentRow.Cells[7].Value.ToString();
            txtPreco.Text = GridProdutos.CurrentRow.Cells[8].Value.ToString();

            HabilitarCampos();

            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
        }
    }
}
