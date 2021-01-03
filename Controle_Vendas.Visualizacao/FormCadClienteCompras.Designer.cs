
namespace Controle_Vendas.Visualizacao
{
    partial class FormCadClienteCompras
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
            this.GridClienteCompras = new System.Windows.Forms.DataGridView();
            this.codigoCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creditoLoja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GridClienteCompras)).BeginInit();
            this.SuspendLayout();
            // 
            // GridClienteCompras
            // 
            this.GridClienteCompras.AllowUserToAddRows = false;
            this.GridClienteCompras.AllowUserToDeleteRows = false;
            this.GridClienteCompras.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridClienteCompras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridClienteCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridClienteCompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigoCompra,
            this.codigoProduto,
            this.nomeProduto,
            this.quantidade,
            this.creditoLoja,
            this.preco,
            this.precoTotal,
            this.dataHora});
            this.GridClienteCompras.Location = new System.Drawing.Point(13, 57);
            this.GridClienteCompras.Name = "GridClienteCompras";
            this.GridClienteCompras.ReadOnly = true;
            this.GridClienteCompras.Size = new System.Drawing.Size(956, 197);
            this.GridClienteCompras.TabIndex = 0;
            // 
            // codigoCompra
            // 
            this.codigoCompra.DataPropertyName = "CodigoCompra";
            this.codigoCompra.HeaderText = "Código da Compra";
            this.codigoCompra.Name = "codigoCompra";
            this.codigoCompra.ReadOnly = true;
            // 
            // codigoProduto
            // 
            this.codigoProduto.DataPropertyName = "CodigoProduto";
            this.codigoProduto.HeaderText = "Código do Produto";
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
            // quantidade
            // 
            this.quantidade.DataPropertyName = "Quantidade";
            this.quantidade.HeaderText = "Quantidade";
            this.quantidade.Name = "quantidade";
            this.quantidade.ReadOnly = true;
            // 
            // creditoLoja
            // 
            this.creditoLoja.DataPropertyName = "CreditoLoja";
            this.creditoLoja.HeaderText = "Crédito Loja";
            this.creditoLoja.Name = "creditoLoja";
            this.creditoLoja.ReadOnly = true;
            // 
            // preco
            // 
            this.preco.DataPropertyName = "Preco";
            this.preco.HeaderText = "Preço";
            this.preco.Name = "preco";
            this.preco.ReadOnly = true;
            // 
            // precoTotal
            // 
            this.precoTotal.DataPropertyName = "PrecoTotal";
            this.precoTotal.HeaderText = "Preço Total";
            this.precoTotal.Name = "precoTotal";
            this.precoTotal.ReadOnly = true;
            // 
            // dataHora
            // 
            this.dataHora.DataPropertyName = "DataHora";
            this.dataHora.HeaderText = "Data/Hora";
            this.dataHora.Name = "dataHora";
            this.dataHora.ReadOnly = true;
            // 
            // FormCadClienteCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 266);
            this.Controls.Add(this.GridClienteCompras);
            this.Name = "FormCadClienteCompras";
            this.Text = "Lista de Compras";
            this.Load += new System.EventHandler(this.FormCadClienteCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridClienteCompras)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn codigoCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn creditoLoja;
        private System.Windows.Forms.DataGridViewTextBoxColumn preco;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataHora;
        private System.Windows.Forms.DataGridView GridClienteCompras;
    }
}