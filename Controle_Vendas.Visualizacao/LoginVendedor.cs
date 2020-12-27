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
    public partial class LoginVendedor : Form
    {
        public LoginVendedor()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsuario.Text == "")
                {
                    MessageBox.Show("Preencha o campo Usuário!");
                    txtUsuario.Focus();
                    return;
                }

                if (txtSenha.Text == "")
                {
                    MessageBox.Show("Preencha o campo Senha!");
                    txtSenha.Focus();
                    return;
                }

                VendedorDominio objVendedor = new VendedorDominio();
                objVendedor.Usuario = txtUsuario.Text;
                objVendedor.Senha = txtSenha.Text;

                objVendedor = new VendedorNegocios().Login(objVendedor);

                if (objVendedor.Usuario == null)
                {
                    lblMensagem.Text = "Usuário ou senha incorretos!";
                    lblMensagem.ForeColor = Color.Red;
                    return;
                }

                FormCadVendas form = new FormCadVendas();
                this.Hide();
                form.Show();
                form.ListarGrid();
            }

            catch (Exception ex)
            {

                MessageBox.Show("Erro ao logar" + ex.Message);
            }
        }
    }
}
