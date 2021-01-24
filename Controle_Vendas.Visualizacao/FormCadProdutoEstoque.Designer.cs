
namespace Controle_Vendas.Visualizacao
{
    partial class FormCadProdutoEstoque
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GridProdutoEstoque = new System.Windows.Forms.DataGridView();
            this.btnCadastroVendas = new System.Windows.Forms.Button();
            this.codigoEstoque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.embalagem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tamanho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sabor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidadeEstoque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GridProdutoEstoque)).BeginInit();
            this.SuspendLayout();
            // 
            // GridProdutoEstoque
            // 
            this.GridProdutoEstoque.AllowUserToAddRows = false;
            this.GridProdutoEstoque.AllowUserToDeleteRows = false;
            this.GridProdutoEstoque.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridProdutoEstoque.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridProdutoEstoque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridProdutoEstoque.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigoEstoque,
            this.codigoProduto,
            this.nomeProduto,
            this.embalagem,
            this.tamanho,
            this.sabor,
            this.quantidadeEstoque});
            this.GridProdutoEstoque.Location = new System.Drawing.Point(14, 63);
            this.GridProdutoEstoque.Name = "GridProdutoEstoque";
            this.GridProdutoEstoque.ReadOnly = true;
            this.GridProdutoEstoque.Size = new System.Drawing.Size(1071, 240);
            this.GridProdutoEstoque.TabIndex = 1;
            // 
            // btnCadastroVendas
            // 
            this.btnCadastroVendas.Location = new System.Drawing.Point(14, 29);
            this.btnCadastroVendas.Name = "btnCadastroVendas";
            this.btnCadastroVendas.Size = new System.Drawing.Size(124, 28);
            this.btnCadastroVendas.TabIndex = 61;
            this.btnCadastroVendas.Text = "Cadastro de Vendas";
            this.btnCadastroVendas.UseVisualStyleBackColor = true;
            this.btnCadastroVendas.Click += new System.EventHandler(this.btnCadastroVendas_Click);
            // 
            // codigoEstoque
            // 
            this.codigoEstoque.DataPropertyName = "CodigoEstoque";
            this.codigoEstoque.FillWeight = 80F;
            this.codigoEstoque.HeaderText = "ID de Estoque";
            this.codigoEstoque.Name = "codigoEstoque";
            this.codigoEstoque.ReadOnly = true;
            // 
            // codigoProduto
            // 
            this.codigoProduto.DataPropertyName = "CodigoProduto";
            this.codigoProduto.HeaderText = "ID do Produto";
            this.codigoProduto.Name = "codigoProduto";
            this.codigoProduto.ReadOnly = true;
            // 
            // nomeProduto
            // 
            this.nomeProduto.DataPropertyName = "NomeProduto";
            this.nomeProduto.HeaderText = "Nome do Produto";
            this.nomeProduto.Name = "nomeProduto";
            this.nomeProduto.ReadOnly = true;
            // 
            // embalagem
            // 
            this.embalagem.DataPropertyName = "Embalagem";
            this.embalagem.HeaderText = "Embalagem";
            this.embalagem.Name = "embalagem";
            this.embalagem.ReadOnly = true;
            // 
            // tamanho
            // 
            this.tamanho.DataPropertyName = "Tamanho";
            this.tamanho.HeaderText = "Tamanho";
            this.tamanho.Name = "tamanho";
            this.tamanho.ReadOnly = true;
            // 
            // sabor
            // 
            this.sabor.DataPropertyName = "Sabor";
            this.sabor.HeaderText = "Sabor";
            this.sabor.Name = "sabor";
            this.sabor.ReadOnly = true;
            // 
            // quantidadeEstoque
            // 
            this.quantidadeEstoque.DataPropertyName = "QuantidadeEstoque";
            this.quantidadeEstoque.HeaderText = "Quantidade em Estoque";
            this.quantidadeEstoque.Name = "quantidadeEstoque";
            this.quantidadeEstoque.ReadOnly = true;
            // 
            // FormCadProdutoEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 315);
            this.Controls.Add(this.btnCadastroVendas);
            this.Controls.Add(this.GridProdutoEstoque);
            this.Name = "FormCadProdutoEstoque";
            this.Text = "Controle de Estoque";
            this.Load += new System.EventHandler(this.FormCadProdutoEstoque_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridProdutoEstoque)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GridProdutoEstoque;
        private System.Windows.Forms.Button btnCadastroVendas;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoEstoque;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn embalagem;
        private System.Windows.Forms.DataGridViewTextBoxColumn tamanho;
        private System.Windows.Forms.DataGridViewTextBoxColumn sabor;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidadeEstoque;
    }
}