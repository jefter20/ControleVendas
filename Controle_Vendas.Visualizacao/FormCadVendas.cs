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
    public partial class FormCadVendas : Form
    {
        VendaDominio objVenda = new VendaDominio();

        public FormCadVendas()
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
                        objVenda.NomeCliente = txtPesquisar.Text;

                        List<VendaDominio> lista = new List<VendaDominio>();
                        lista = new VendaNegocios().Buscar(objVenda);
                        GridVendas.AutoGenerateColumns = false;
                        GridVendas.DataSource = lista;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao pesquisar Dados" + ex.Message);
                    }
                    break;

                case "Novo":
                    HabilitarCampos();
                    LimparCampos();
                    break;

                case "Salvar":
                    try
                    {
                        if (txtCodigoCliente.Text == "" | txtCodigoProduto.Text == "" | txtCodigoVendedor.Text == "" | txtCreditoLoja.Text == "" | txtQuantidade.Text == "" | txtPreco.Text == "")
                        {
                            MessageBox.Show("Preencha os campos marcados com (*), e verifique se os códigos informados estão corretos!");
                            txtCodigoCliente.Focus();
                            return;
                        }

                        objVenda.CodigoCliente = Convert.ToInt32(txtCodigoCliente.Text);
                        objVenda.CodigoProduto = Convert.ToInt32(txtCodigoProduto.Text);
                        objVenda.CodigoVendedor = Convert.ToInt32(txtCodigoVendedor.Text);
                        objVenda.CreditoLoja = Convert.ToDouble(txtCreditoLoja.Text);
                        objVenda.NomeCliente = txtNomeCliente.Text;
                        objVenda.NomeProduto = txtNomeProduto.Text;
                        objVenda.NomeVendedor = txtNomeVendedor.Text;
                        objVenda.Quantidade = Convert.ToInt32(txtQuantidade.Text);
                        objVenda.Preco = Convert.ToDouble(txtPreco.Text);
                        objVenda.DataHora = txtDataHora.Text;
                     
                        int x = VendaNegocios.Inserir(objVenda);

                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Venda de {0} efetuada com sucesso!", txtNomeProduto.Text));
                            LimparCampos();
                            DesabilitarCampos();
                            ListarGrid();
                        }
                        else
                        {
                            MessageBox.Show("Venda não finalizada");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao salvar " + ex);
                        
                    }
                    break;

                case "Editar":
                    try
                    {
                        objVenda.CodigoVenda = Convert.ToInt32(txtCodigoVenda.Text);
                        objVenda.CodigoCliente = Convert.ToInt32(txtCodigoCliente.Text);
                        objVenda.CodigoProduto = Convert.ToInt32(txtCodigoProduto.Text);
                        objVenda.CodigoVendedor = Convert.ToInt32(txtCodigoVendedor.Text);
                        objVenda.CreditoLoja = Convert.ToDouble(txtCreditoLoja.Text);
                        objVenda.NomeCliente = txtNomeCliente.Text.ToString();
                        objVenda.NomeProduto = txtNomeProduto.Text.ToString();
                        objVenda.NomeVendedor = txtNomeVendedor.Text.ToString();
                        objVenda.Quantidade = Convert.ToInt32(txtQuantidade.Text);
                        objVenda.Preco = Convert.ToDouble(txtPreco.Text);
                        objVenda.DataHora = txtDataHora.Text.ToString();

                        int x = VendaNegocios.Editar(objVenda);

                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Venda {0} alterada com sucesso!", txtCodigoVenda.Text));
                            LimparCampos();
                            DesabilitarCampos();
                            ListarGrid();
                        }
                        else
                        {
                            MessageBox.Show("Venda não alterado!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao alterar " + ex.Message);

                    }
                    break;

                case "Excluir":
                    try
                    {
                        objVenda.CodigoVenda = Convert.ToInt32(txtCodigoVenda.Text);

                        int x = VendaNegocios.Excluir(objVenda);

                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Venda {0} desfeita com sucesso!", txtCodigoVenda.Text));
                            LimparCampos();
                            DesabilitarCampos();
                            ListarGrid();
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível desfazer a venda!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao excluir " + ex.Message);

                    }
                    break;
            }
        }

        private void FormCadVendas_Load(object sender, EventArgs e)
        {
            DesabilitarCampos();
            ListarGrid();

            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
            txtCodigoVenda.Enabled = false;                
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            opcoes = "Novo";
            IniciarOpcoes();

            btnNovo.Enabled = false;
            btnSalvar.Enabled = true;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            txtCodigoCliente.Focus();

        }

        private void btnVendaSalvar_Click(object sender, EventArgs e)
        {
            
            opcoes = "Salvar";
            IniciarOpcoes();

            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = false;

        }

        private void btnVendaEditar_Click(object sender, EventArgs e)
        {
            opcoes = "Editar";
            IniciarOpcoes();

            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
        }

        private void btnVendaExcluir_Click(object sender, EventArgs e)
        {
            opcoes = "Excluir";
            IniciarOpcoes();

            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
        }

        private void HabilitarCampos()
        {
            txtCodigoCliente.Enabled = true;
            txtCodigoProduto.Enabled = true;
            txtCodigoVendedor.Enabled = true;
            txtCreditoLoja.Enabled = true;
            txtNomeCliente.Enabled = true;
            txtNomeProduto.Enabled = true;
            txtNomeVendedor.Enabled = true;
            txtQuantidade.Enabled = true;
            txtPreco.Enabled = true;
            txtDataHora.Enabled = true;
        }

        private void DesabilitarCampos()
        {
            txtCodigoCliente.Enabled = false;
            txtCodigoProduto.Enabled = false;
            txtCodigoVendedor.Enabled = false;
            txtCreditoLoja.Enabled = false;
            txtNomeCliente.Enabled = false;
            txtNomeProduto.Enabled = false;
            txtNomeVendedor.Enabled = false;
            txtQuantidade.Enabled = false;
            txtPreco.Enabled = false;
            txtDataHora.Enabled = false;
        }

        private void LimparCampos()
        {
            txtCodigoVenda.Text = "";
            txtCodigoCliente.Text = "";
            txtCodigoProduto.Text = "";
            txtCodigoVendedor.Text = "";
            txtCreditoLoja.Text = "";
            txtNomeCliente.Text = "";
            txtNomeProduto.Text = "";
            txtNomeVendedor.Text = "";
            txtQuantidade.Text = "";
            txtPreco.Text = "";
            txtDataHora.Text = "";
        }

        public void ListarGrid()
        {
            try
            {
                List<VendaDominio> lista = new List<VendaDominio>();
                lista = new VendaNegocios().Lista();
                GridVendas.AutoGenerateColumns = false;
                GridVendas.DataSource = lista;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao listar Dados " + ex.Message);
            }
        }

        private void GridVendas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoVenda.Text = GridVendas.CurrentRow.Cells[0].Value.ToString();
            txtCodigoCliente.Text = GridVendas.CurrentRow.Cells[1].Value.ToString();
            txtNomeCliente.Text = GridVendas.CurrentRow.Cells[2].Value.ToString();
            txtCodigoProduto.Text = GridVendas.CurrentRow.Cells[3].Value.ToString();
            txtNomeProduto.Text = GridVendas.CurrentRow.Cells[4].Value.ToString();
            txtCodigoVendedor.Text = GridVendas.CurrentRow.Cells[5].Value.ToString();
            txtNomeVendedor.Text = GridVendas.CurrentRow.Cells[6].Value.ToString();
            txtCreditoLoja.Text = GridVendas.CurrentRow.Cells[7].Value.ToString();
            txtQuantidade.Text = GridVendas.CurrentRow.Cells[8].Value.ToString();
            txtPreco.Text = GridVendas.CurrentRow.Cells[9].Value.ToString();
            txtDataHora.Text = GridVendas.CurrentRow.Cells[10].Value.ToString();

            HabilitarCampos();

            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
        }

        private void btnCadastroClientes_Click(object sender, EventArgs e)
        {
            FormCadClientes form =  new FormCadClientes();
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
