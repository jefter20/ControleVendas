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
    public partial class LoginCliente : Form
    {
        public LoginCliente()
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

                ClienteDominio objCliente = new ClienteDominio();
                objCliente.Usuario = txtUsuario.Text;
                objCliente.Senha = txtSenha.Text;

                objCliente = new ClienteNegocios().Login(objCliente);

                if (objCliente.Usuario == null)
                {
                    lblMensagem.Text = "Usuário ou senha incorretos!";
                    lblMensagem.ForeColor = Color.Red;
                    return;
                }

                FormCadClienteCompras form = new FormCadClienteCompras();
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
