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
        ClienteDominio objCliente = new ClienteDominio();
        ProdutoDominio objProduto = new ProdutoDominio();
        VendedorDominio objVendedor = new VendedorDominio();
        ClienteCompraDominio objCompra = new ClienteCompraDominio();
        ProdutoEstoqueDominio objEstoque = new ProdutoEstoqueDominio();

        public FormCadVendas()
        {
            InitializeComponent();
        }

        private string opcoes = "";
        private double clienteLimiteCredito = 0;// TROCAR POR LimiteCreditoInicial
        private double compraLimiteCredito = 0;// TROCAR POR LimiteCreditoAtual
        private int compraCodigoCliente = 0;// TROCAR POR vendaCodigoCliente
        private int estoqueCodigoProduto = 0;
        private double produtosEstoqueAtual = 0;
        private double produtosEstoqueInicial = 0;
        private double ClientePrimeiraCompra = 0;
        private double ProdutoPrimeiraCompra = 0; 

        private void BuscaDadosClientes()
        {
            objCliente.Cpf = Convert.ToString(txtBuscaCliente.Text);

            List<ClienteDominio> lista = new List<ClienteDominio>();
            lista = new VendaNegocios().BuscaCliente(objCliente);

            foreach (var item in lista)
            {
                txtNomeCliente.Text = Convert.ToString(item.Nome);
                txtCodigoCliente.Text = Convert.ToString(item.CodigoCliente);
                clienteLimiteCredito = Convert.ToDouble(item.LimiteCredito);
                objCompra.CodigoCliente = Convert.ToInt32(item.CodigoCliente);
            }
        }

        private void BuscaDadosClienteCompras()
        {
            objCompra.CodigoCliente = Convert.ToInt32(txtCodigoCliente.Text);

            List<ClienteCompraDominio> lista2 = new List<ClienteCompraDominio>();
            lista2 = new VendaNegocios().BuscaClienteCompra(objCompra);

            compraLimiteCredito = lista2.Select(x => x.LimiteCredito).LastOrDefault();
            compraCodigoCliente = lista2.Select(x => x.CodigoCliente).LastOrDefault();

            foreach (var item2 in lista2)
            {
                compraLimiteCredito = Convert.ToDouble(item2.LimiteCredito);
                compraCodigoCliente = Convert.ToInt32(item2.CodigoCliente);
            }
        }

        private void VerificaClientePrimeiraCompra()
        {
            if (txtCodigoCliente.Text != Convert.ToString(compraCodigoCliente))
            {
                ClientePrimeiraCompra = Convert.ToDouble(1);
            }
            else
            {
                ClientePrimeiraCompra = Convert.ToDouble(0);
            }
        }

        private void BuscaDadosProdutos()
        {
            objProduto.CodigoProduto = Convert.ToInt32(txtCodigoProduto.Text);

            List<ProdutoDominio> lista = new List<ProdutoDominio>();
            lista = new VendaNegocios().BuscaProduto(objProduto);

            foreach (var item in lista)
            {
                txtNomeProduto.Text = Convert.ToString(item.NomeProduto);
                txtPreco.Text = Convert.ToString(item.PrecoDeLista);
                txtEmbalagem.Text = Convert.ToString(item.Embalagem);
                txtTamanho.Text = Convert.ToString(item.Tamanho);
                txtSabor.Text = Convert.ToString(item.Sabor);
                produtosEstoqueInicial = Convert.ToDouble(item.QuantidadeEstoque);

                objEstoque.CodigoProduto = Convert.ToInt32(item.CodigoProduto);
            }
        }

        private void BuscaDadosProdutoEstoque()
        {
            objEstoque.CodigoProduto = Convert.ToInt32(txtCodigoProduto.Text);

            List<ProdutoEstoqueDominio> lista2 = new List<ProdutoEstoqueDominio>();
            lista2 = new VendaNegocios().BuscaProdutoEstoque(objEstoque);

            produtosEstoqueAtual = lista2.Select(x => x.CodigoEstoque).LastOrDefault();
            estoqueCodigoProduto = lista2.Select(x => x.CodigoProduto).LastOrDefault();

            foreach (var item2 in lista2)
            {
                produtosEstoqueAtual = Convert.ToDouble(item2.QuantidadeEstoque);
                estoqueCodigoProduto = Convert.ToInt32(item2.CodigoProduto);
            }
        }

        private void VerificaProdutoPrimeiraCompra()
        {
            if (txtCodigoProduto.Text != Convert.ToString(estoqueCodigoProduto))
            {
                ProdutoPrimeiraCompra = Convert.ToDouble(1);
            }
            else
            {
                ProdutoPrimeiraCompra = Convert.ToDouble(0);
            }
        }

        private void BuscaDadosVendedores()
        {
            objVendedor.CodigoVendedor = Convert.ToInt32(txtCodigoVendedor.Text);

            List<VendedorDominio> lista = new List<VendedorDominio>();
            lista = new VendaNegocios().BuscaVendedor(objVendedor);

            foreach (var item in lista)
            {
                txtNomeVendedor.Text = Convert.ToString(item.NomeVendedor);
            }
        }

        private void CalculaLimiteCredito()
        {
            if (objVenda.CreditoLoja == 1)
            {
                if (objVenda.ClientePrimeiraCompra == 1)
                {
                    objCompra.LimiteCredito = Convert.ToDouble(clienteLimiteCredito) - Convert.ToDouble(objVenda.PrecoTotal);
                }
                else
                {
                    objCompra.LimiteCredito = Convert.ToDouble(compraLimiteCredito) - Convert.ToDouble(objVenda.PrecoTotal);
                }
            }

            if (objVenda.CreditoLoja == 0)
            {
                if (objVenda.ClientePrimeiraCompra == 1)
                {
                    objCompra.LimiteCredito = Convert.ToDouble(clienteLimiteCredito);
                }
                else
                {
                    objCompra.LimiteCredito = Convert.ToDouble(compraLimiteCredito);
                }
            }
        }

        private void CalculaQuantidadeEstoque()
        {
            if (objVenda.ProdutoPrimeiraCompra == 1)
            {
                objEstoque.QuantidadeEstoque = Convert.ToDouble(produtosEstoqueInicial) - Convert.ToDouble(txtQuantidade.Text);
            }

            if (objVenda.ProdutoPrimeiraCompra == 0)
            {
                objEstoque.QuantidadeEstoque = Convert.ToDouble(produtosEstoqueAtual) - Convert.ToDouble(txtQuantidade.Text);
            }
        }

        private void ValidaVenda()
        {
            if (txtCodigoCliente.Text == "" || txtCodigoProduto.Text == "" || txtCodigoVendedor.Text == "" || txtCreditoLoja.Text == "" || txtQuantidade.Text == "")
            {
                MessageBox.Show("Por favor, preencha todos os campos com (*)!");
                return;
            }

            if (txtCreditoLoja.Text == Convert.ToString(1))
            {
                if (ClientePrimeiraCompra == Convert.ToDouble(1))
                {
                    if (Convert.ToDouble(txtPrecoTotal.Text) > Convert.ToDouble(clienteLimiteCredito))
                    {
                        MessageBox.Show(string.Format("Valor da compra acima do Limite de Crédito. O Limite de Crédito restante é {0}", clienteLimiteCredito));
                        return;
                    }
                }
                if (ClientePrimeiraCompra == Convert.ToDouble(0))
                {
                    if (Convert.ToDouble(txtPrecoTotal.Text) > Convert.ToDouble(compraLimiteCredito))
                    {
                        MessageBox.Show(string.Format("Valor da compra acima do Limite de Crédito. O Limite de Crédito restante é {0}", compraLimiteCredito));
                        return;
                    }
                }

                if (ProdutoPrimeiraCompra == Convert.ToDouble(1))
                {
                    if (Convert.ToDouble(txtQuantidade.Text) > Convert.ToDouble(produtosEstoqueInicial))
                    {
                        MessageBox.Show(string.Format("Estoque do produto insuficiente. No momento a quantidade em estoque é de {0} ", produtosEstoqueInicial));
                        return;
                    }
                }

                if (ProdutoPrimeiraCompra == Convert.ToDouble(0))
                {
                    if (Convert.ToDouble(txtQuantidade.Text) > Convert.ToDouble(produtosEstoqueAtual))
                    {
                        MessageBox.Show(string.Format("Estoque do produto insuficiente. No momento a quantidade em estoque é de {0} ", produtosEstoqueAtual));
                        return;
                    }
                }

                opcoes = "SalvarVenda";
                IniciarOpcoes();
            }

            if (txtCreditoLoja.Text == Convert.ToString(0))
            {
                if (ProdutoPrimeiraCompra == Convert.ToDouble(1))
                {
                    if (Convert.ToDouble(txtQuantidade.Text) > Convert.ToDouble(produtosEstoqueInicial))
                    {
                        MessageBox.Show(string.Format("Estoque do produto insuficiente. No momento a quantidade em estoque é de {0} ", produtosEstoqueInicial));
                        return;
                    }
                }

                if (ProdutoPrimeiraCompra == Convert.ToDouble(0))
                {
                    if (Convert.ToDouble(txtQuantidade.Text) > Convert.ToDouble(produtosEstoqueAtual))
                    {
                        MessageBox.Show(string.Format("Estoque do produto insuficiente. No momento a quantidade em estoque é de {0} ", produtosEstoqueAtual));
                        return;
                    }
                }

                opcoes = "SalvarVenda";
                IniciarOpcoes();
            }
        }

        private void CaulculaPrecoTotal()
        {
            if (!string.IsNullOrEmpty(txtPreco.Text) && !string.IsNullOrEmpty(txtQuantidade.Text))
            {
                var precoTotal = Convert.ToInt32(txtQuantidade.Text) * Convert.ToDouble(txtPreco.Text);
                txtPrecoTotal.Text = Convert.ToString(precoTotal);
            }
            else
            {
                txtPrecoTotal.Text = "";
            }
        }
        /*
        private DateTime DataHoraAtual()
        {
            //DateTime data = DateTime.Now.ToString("yyyy/MM/dd" + " - " + "HH:mm:ss");

            
        }*/

        private void HabilitarCampos()
        {
            txtCodigoProduto.Enabled = true;
            txtCodigoVendedor.Enabled = true;
            txtCreditoLoja.Enabled = true;
            txtBuscaCliente.Enabled = true;
            txtQuantidade.Enabled = true;
        }

        private void DesabilitarCampos()
        {
            txtCodigoProduto.Enabled = false;
            txtCodigoVendedor.Enabled = false;
            txtCreditoLoja.Enabled = false;
            txtBuscaCliente.Enabled = false;
            txtQuantidade.Enabled = false;
        }

        private void LimparCampos()
        {
            txtCodigoVenda.Text = "";
            txtCodigoCliente.Text = "";
            txtCodigoProduto.Text = "";
            txtEmbalagem.Text = "";
            txtCodigoVendedor.Text = "";
            txtCreditoLoja.Text = "";
            txtNomeCliente.Text = "";
            txtNomeProduto.Text = "";
            txtTamanho.Text = "";
            txtNomeVendedor.Text = "";
            txtBuscaCliente.Text = "";
            txtQuantidade.Text = "";
            txtSabor.Text = "";
            txtPreco.Text = "";
            txtPrecoTotal.Text = "";
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

                case "BuscaCliente":
                    try
                    {
                        BuscaDadosClientes();

                        BuscaDadosClienteCompras();

                        VerificaClientePrimeiraCompra();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro ao buscar cliente. Por favor, verifique se o CPF informado está correto e tente novamente!");
                    }
                    break;

                case "BuscaProduto":
                    try
                    {
                        BuscaDadosProdutos();

                        BuscaDadosProdutoEstoque();

                        VerificaProdutoPrimeiraCompra();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao buscar produto" + ex.Message);
                    }
                    break;

                case "BuscaVendedor":
                    try
                    {
                        BuscaDadosVendedores();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao buscar vendedor" + ex.Message);
                    }
                    break;

                case "Novo":
                    HabilitarCampos();
                    LimparCampos();
                    break;

                case "SalvarVenda":
                    try
                    {
                        DateTime dataHora = DateTime.Now;
                        string dataHoraFormato = dataHora.ToString("yyyy/MM/dd " + "HH:mm:ss");
                        DateTime dataHoraAtual = Convert.ToDateTime(dataHoraFormato);

                        objVenda.CodigoCliente = Convert.ToInt32(txtCodigoCliente.Text);
                        objVenda.CodigoProduto = Convert.ToInt32(txtCodigoProduto.Text);
                        objVenda.Embalagem = txtEmbalagem.Text;
                        objVenda.CodigoVendedor = Convert.ToInt32(txtCodigoVendedor.Text);
                        objVenda.CreditoLoja = Convert.ToDouble(txtCreditoLoja.Text);
                        objVenda.NomeCliente = txtNomeCliente.Text;
                        objVenda.NomeProduto = txtNomeProduto.Text;
                        objVenda.Tamanho = txtTamanho.Text;
                        objVenda.NomeVendedor = txtNomeVendedor.Text;
                        objVenda.DataHora = dataHoraAtual;
                        objVenda.Quantidade = Convert.ToInt32(txtQuantidade.Text);
                        objVenda.Sabor = txtSabor.Text;
                        objVenda.Preco = Convert.ToDouble(txtPreco.Text);
                        objVenda.PrecoTotal = Convert.ToDouble(txtQuantidade.Text) * Convert.ToDouble(txtPreco.Text);
                        objVenda.ClientePrimeiraCompra = Convert.ToDouble(ClientePrimeiraCompra);
                        objVenda.ProdutoPrimeiraCompra = Convert.ToDouble(ProdutoPrimeiraCompra);


                        int x = VendaNegocios.Inserir(objVenda);

                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Venda de {0} efetuada com sucesso!", txtNomeProduto.Text));

                            opcoes = "AddProdutoEstoque";
                            IniciarOpcoes();

                            opcoes = "AddClienteCompra";
                            IniciarOpcoes();
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
                        objVenda.CodigoCliente = Convert.ToInt32(objCliente.CodigoCliente);
                        objVenda.CodigoProduto = Convert.ToInt32(txtCodigoProduto.Text);
                        objVenda.CodigoVendedor = Convert.ToInt32(txtCodigoVendedor.Text);
                        objVenda.CreditoLoja = Convert.ToDouble(txtCreditoLoja.Text);
                        objVenda.NomeCliente = txtNomeCliente.Text.ToString();
                        objVenda.NomeProduto = txtNomeProduto.Text.ToString();
                        objVenda.NomeVendedor = txtNomeVendedor.Text.ToString();
                        //objVenda.DataHora = dataHoraAtual;
                        objVenda.Quantidade = Convert.ToInt32(txtQuantidade.Text);
                        objVenda.Preco = Convert.ToDouble(txtPreco.Text);
                        objVenda.PrecoTotal = Convert.ToDouble(txtQuantidade.Text) * Convert.ToDouble(txtPreco.Text);

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

                case "AddClienteCompra":
                    try
                    {
                        objCompra.CodigoCliente = Convert.ToInt32(txtCodigoCliente.Text);
                        objCompra.CodigoProduto = Convert.ToInt32(txtCodigoProduto.Text);
                        objCompra.NomeProduto = Convert.ToString(txtNomeProduto.Text);
                        objCompra.Quantidade = Convert.ToInt32(txtQuantidade.Text);
                        objCompra.CreditoLoja = Convert.ToDouble(txtCreditoLoja.Text);

                        CalculaLimiteCredito();

                        objCompra.Preco = Convert.ToDouble(txtPreco.Text);
                        objCompra.PrecoTotal = Convert.ToDouble(objVenda.PrecoTotal);
                        objCompra.DataHora = objVenda.DataHora;
                        objCompra.ClientePrimeiraCompra = Convert.ToDouble(ClientePrimeiraCompra);

                        int x = VendaNegocios.AddClienteCompra(objCompra);

                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Compra de {0} efetuada com sucesso!", txtNomeProduto.Text));
                            LimparCampos();
                            DesabilitarCampos();
                            ListarGrid();
                        }
                        else
                        {
                            MessageBox.Show("Compra não finalizada");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao realizar compra " + ex);

                    }
                    break;

                case "AddProdutoEstoque":
                    try
                    {
                        objEstoque.CodigoProduto = Convert.ToInt32(txtCodigoProduto.Text);
                        objEstoque.NomeProduto = Convert.ToString(txtNomeProduto.Text);
                        objEstoque.Embalagem = objVenda.Embalagem;
                        objEstoque.Tamanho = objVenda.Tamanho;
                        objEstoque.Sabor = objVenda.Sabor;

                        CalculaQuantidadeEstoque();

                        objEstoque.ProdutoPrimeiraCompra = ProdutoPrimeiraCompra;

                        int x = VendaNegocios.AddProdutoEstoque(objEstoque);

                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("O estoque do {0} foi atualizado com sucesso!", txtNomeProduto.Text));
                        }
                        else
                        {
                            MessageBox.Show("O estoque não foi atualizado");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao atualizar o estoque " + ex);

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
            LimparCampos();

            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
            txtCodigoVenda.Enabled = false;
            txtEmbalagem.Enabled = false;
            txtCodigoCliente.Enabled = false;
            txtNomeCliente.Enabled = false;
            txtNomeProduto.Enabled = false;
            txtTamanho.Enabled = false;
            txtNomeVendedor.Enabled = false;
            txtSabor.Enabled = false;
            txtPreco.Enabled = false;
            txtPrecoTotal.Enabled = false;
            txtPesquisar.Focus();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            opcoes = "Novo";
            IniciarOpcoes();

            btnNovo.Enabled = false;
            btnSalvar.Enabled = true;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            txtBuscaCliente.Focus();
        }

        private void btnVendaSalvar_Click(object sender, EventArgs e)
        {
            ValidaVenda();

            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = false;
            txtPesquisar.Focus();
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

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            opcoes = "Pesquisar";
            IniciarOpcoes();
        }

        private void txtCodigoProduto_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigoProduto.Text))
            {
                opcoes = "BuscaProduto";
                IniciarOpcoes();
            }
            else
            {
                txtCodigoProduto.Text = "";
            }
            
        }

        private void txtCodigoVendedor_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigoVendedor.Text))
            {
                opcoes = "BuscaVendedor";
                IniciarOpcoes();
            }
            else
            {
                txtCodigoProduto.Text = "";
            }
        }

        private void txtBuscaCliente_Enter(object sender, EventArgs e)
        {
            MessageBox.Show("Por favor, para buscar os dados do Cliente, insira o CPF!");
        }

        private void txtQuantidade_Leave(object sender, EventArgs e)
        {
            CaulculaPrecoTotal();
        }

        private void txtPreco_TextChanged(object sender, EventArgs e)
        {
            CaulculaPrecoTotal();
        }

        private void GridVendas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoVenda.Text = GridVendas.CurrentRow.Cells[0].Value.ToString();
            txtCodigoCliente.Text = GridVendas.CurrentRow.Cells[1].Value.ToString();
            txtNomeCliente.Text = GridVendas.CurrentRow.Cells[2].Value.ToString();
            txtCreditoLoja.Text = GridVendas.CurrentRow.Cells[3].Value.ToString();
            txtCodigoProduto.Text = GridVendas.CurrentRow.Cells[4].Value.ToString();
            txtNomeProduto.Text = GridVendas.CurrentRow.Cells[5].Value.ToString();
            txtEmbalagem.Text = GridVendas.CurrentRow.Cells[6].Value.ToString();
            txtTamanho.Text = GridVendas.CurrentRow.Cells[7].Value.ToString();
            txtSabor.Text = GridVendas.CurrentRow.Cells[8].Value.ToString();
            txtQuantidade.Text = GridVendas.CurrentRow.Cells[9].Value.ToString();
            txtPreco.Text = GridVendas.CurrentRow.Cells[10].Value.ToString();
            txtPrecoTotal.Text = GridVendas.CurrentRow.Cells[11].Value.ToString();
            txtCodigoVendedor.Text = GridVendas.CurrentRow.Cells[12].Value.ToString();
            txtNomeVendedor.Text = GridVendas.CurrentRow.Cells[13].Value.ToString();

            HabilitarCampos();

            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
        }

        private void btnBuscaCliente_Click(object sender, EventArgs e)
        {
            opcoes = "BuscaCliente";
            IniciarOpcoes();
        }

        private void btnControleEstoque_Click(object sender, EventArgs e)
        {
            FormCadProdutoEstoque form = new FormCadProdutoEstoque();
            this.Hide();
            form.Show();
        }

        private void btnCadastroClientes_Click(object sender, EventArgs e)
        {
            FormCadClientes form = new FormCadClientes();
            this.Hide();
            form.Show();
        }
    }
}
