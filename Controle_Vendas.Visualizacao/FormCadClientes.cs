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
    public partial class FormCadClientes : Form
    {
        ClienteDominio objCliente = new ClienteDominio();
        public FormCadClientes()
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
                        objCliente.Nome = txtPesquisar.Text;

                        List<ClienteDominio> lista = new List<ClienteDominio>();
                        lista = new ClienteNegocios().Buscar(objCliente);
                        Grid.AutoGenerateColumns = false;
                        Grid.DataSource = lista;
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
                        if (txtNomeCliente.Text == "" | txtCPF.Text == "" | txtEndereco1.Text == "")
                        {
                            MessageBox.Show("Preencha todos os campos!");
                            txtNomeCliente.Focus();
                            return;
                        }

                        objCliente.Nome = txtNomeCliente.Text;
                        objCliente.Cpf = txtCPF.Text;
                        objCliente.Endereco1 = txtEndereco1.Text;
                        objCliente.Endereco2 = txtEndereco2.Text;
                        objCliente.Bairro = txtBairro.Text;
                        objCliente.Cidade = txtCidade.Text;
                        objCliente.Uf = txtUF.Text;
                        objCliente.Cep = txtCEP.Text;
                        objCliente.DataNascimento = txtDataNascimento.Text;
                        objCliente.Sexo = txtSexo.Text;
                        objCliente.LimiteCredito = txtLimiteCredito.Text;
                        objCliente.VolumeCompra = txtVolumeCompra.Text;

                        int x = ClienteNegocios.Inserir(objCliente);

                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Cliente {0} inserido com sucesso!", txtNomeCliente.Text));
                            LimparCampos();
                            DesabilitarCampos();
                            ListarGrid();
                        }
                        else
                        {
                            MessageBox.Show("Cliente não inserido");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao salvar " + ex.Message);

                    }
                    break;
            }
        }
        private void FormCadClientes_Load(object sender, EventArgs e)
        {
            DesabilitarCampos();
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
            txtCodigoCliente.Enabled = false;
            ListarGrid();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            opcoes = "Novo";
            IniciarOpcoes();
            btnNovo.Enabled = false;
            btnSalvar.Enabled = true;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            txtNomeCliente.Focus();

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            opcoes = "Salvar";
            IniciarOpcoes();
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            opcoes = "Editar";
            IniciarOpcoes();

            btnNovo.Enabled = true;
            btnSalvar.Enabled = true;
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

        public void ListarGrid()
        {
            try
            {
                List<ClienteDominio> lista = new List<ClienteDominio>();
                lista = new ClienteNegocios().Lista();
                Grid.AutoGenerateColumns = false;
                Grid.DataSource = lista;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao listar Dados" + ex.Message);
            }
        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoCliente.Text = Grid.CurrentRow.Cells[0].Value.ToString();
            txtNomeCliente.Text = Grid.CurrentRow.Cells[1].Value.ToString();
            txtCPF.Text = Grid.CurrentRow.Cells[2].Value.ToString();
            txtEndereco1.Text = Grid.CurrentRow.Cells[3].Value.ToString();
            txtEndereco2.Text = Grid.CurrentRow.Cells[4].Value.ToString();
            txtBairro.Text = Grid.CurrentRow.Cells[5].Value.ToString();
            txtCidade.Text = Grid.CurrentRow.Cells[6].Value.ToString();
            txtUF.Text = Grid.CurrentRow.Cells[7].Value.ToString();
            txtCEP.Text = Grid.CurrentRow.Cells[8].Value.ToString();
            txtDataNascimento.Text = Grid.CurrentRow.Cells[9].Value.ToString();
            txtSexo.Text = Grid.CurrentRow.Cells[10].Value.ToString();
            txtLimiteCredito.Text = Grid.CurrentRow.Cells[11].Value.ToString();
            txtVolumeCompra.Text = Grid.CurrentRow.Cells[12].Value.ToString();

            HabilitarCampos();

            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
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

        private void HabilitarCampos()
        {
            txtNomeCliente.Enabled = true;
            txtCPF.Enabled = true;
            txtEndereco1.Enabled = true;
            txtEndereco2.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
            txtUF.Enabled = true;
            txtCEP.Enabled = true;
            txtDataNascimento.Enabled = true;
            txtSexo.Enabled = true;
            txtLimiteCredito.Enabled = true;
            txtVolumeCompra.Enabled = true;
        }

        private void DesabilitarCampos()
        {
            txtCodigoCliente.Enabled = false;
            txtNomeCliente.Enabled = false;
            txtCPF.Enabled = false;
            txtEndereco1.Enabled = false;
            txtEndereco2.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            txtUF.Enabled = false;
            txtCEP.Enabled = false;
            txtDataNascimento.Enabled = false;
            txtSexo.Enabled = false;
            txtLimiteCredito.Enabled = false;
            txtVolumeCompra.Enabled = false;
        }

        private void LimparCampos()
        {
            txtCodigoCliente.Text = "";
            txtNomeCliente.Text = "";
            txtCPF.Text = "";
            txtEndereco1.Text = "";
            txtEndereco2.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            txtUF.Text = "";
            txtCEP.Text = "";
            txtDataNascimento.Text = "";
            txtSexo.Text = "";
            txtLimiteCredito.Text = "";
            txtVolumeCompra.Text = "";
        }
    }
}
