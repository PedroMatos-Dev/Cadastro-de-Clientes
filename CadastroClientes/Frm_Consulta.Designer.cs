namespace CadastroClientes
{
    partial class Frm_Consulta
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
            this.Tab_Consulta = new System.Windows.Forms.TabControl();
            this.Tab_Parametros = new System.Windows.Forms.TabPage();
            this.Tab_Resultados = new System.Windows.Forms.TabPage();
            this.Txt_Nome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_Consultar = new System.Windows.Forms.Button();
            this.Btn_Limpar = new System.Windows.Forms.Button();
            this.Dgv_ClientesConsulta = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Celular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Endereco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Btn_Sair = new System.Windows.Forms.Button();
            this.Txt_Cidade = new System.Windows.Forms.TextBox();
            this.Tab_Consulta.SuspendLayout();
            this.Tab_Parametros.SuspendLayout();
            this.Tab_Resultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_ClientesConsulta)).BeginInit();
            this.SuspendLayout();
            // 
            // Tab_Consulta
            // 
            this.Tab_Consulta.Controls.Add(this.Tab_Parametros);
            this.Tab_Consulta.Controls.Add(this.Tab_Resultados);
            this.Tab_Consulta.Location = new System.Drawing.Point(2, 2);
            this.Tab_Consulta.Name = "Tab_Consulta";
            this.Tab_Consulta.SelectedIndex = 0;
            this.Tab_Consulta.Size = new System.Drawing.Size(763, 399);
            this.Tab_Consulta.TabIndex = 0;
            // 
            // Tab_Parametros
            // 
            this.Tab_Parametros.Controls.Add(this.Txt_Cidade);
            this.Tab_Parametros.Controls.Add(this.Btn_Consultar);
            this.Tab_Parametros.Controls.Add(this.Btn_Limpar);
            this.Tab_Parametros.Controls.Add(this.Txt_Nome);
            this.Tab_Parametros.Controls.Add(this.label3);
            this.Tab_Parametros.Controls.Add(this.label2);
            this.Tab_Parametros.Location = new System.Drawing.Point(4, 22);
            this.Tab_Parametros.Name = "Tab_Parametros";
            this.Tab_Parametros.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Parametros.Size = new System.Drawing.Size(755, 373);
            this.Tab_Parametros.TabIndex = 0;
            this.Tab_Parametros.Text = "Parametros";
            this.Tab_Parametros.UseVisualStyleBackColor = true;
            // 
            // Tab_Resultados
            // 
            this.Tab_Resultados.Controls.Add(this.Dgv_ClientesConsulta);
            this.Tab_Resultados.Location = new System.Drawing.Point(4, 22);
            this.Tab_Resultados.Name = "Tab_Resultados";
            this.Tab_Resultados.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Resultados.Size = new System.Drawing.Size(755, 373);
            this.Tab_Resultados.TabIndex = 1;
            this.Tab_Resultados.Text = "Resultados";
            this.Tab_Resultados.UseVisualStyleBackColor = true;
            // 
            // Txt_Nome
            // 
            this.Txt_Nome.Location = new System.Drawing.Point(69, 48);
            this.Txt_Nome.Name = "Txt_Nome";
            this.Txt_Nome.Size = new System.Drawing.Size(395, 20);
            this.Txt_Nome.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Nome:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Cidade:";
            // 
            // Btn_Consultar
            // 
            this.Btn_Consultar.Location = new System.Drawing.Point(477, 265);
            this.Btn_Consultar.Name = "Btn_Consultar";
            this.Btn_Consultar.Size = new System.Drawing.Size(115, 70);
            this.Btn_Consultar.TabIndex = 31;
            this.Btn_Consultar.Text = "&Consultar";
            this.Btn_Consultar.UseVisualStyleBackColor = true;
            this.Btn_Consultar.Click += new System.EventHandler(this.Btn_Consultar_Click);
            // 
            // Btn_Limpar
            // 
            this.Btn_Limpar.Location = new System.Drawing.Point(617, 265);
            this.Btn_Limpar.Name = "Btn_Limpar";
            this.Btn_Limpar.Size = new System.Drawing.Size(115, 70);
            this.Btn_Limpar.TabIndex = 30;
            this.Btn_Limpar.Text = "&Limpar";
            this.Btn_Limpar.UseVisualStyleBackColor = true;
            this.Btn_Limpar.Click += new System.EventHandler(this.Btn_Limpar_Click);
            // 
            // Dgv_ClientesConsulta
            // 
            this.Dgv_ClientesConsulta.AllowUserToAddRows = false;
            this.Dgv_ClientesConsulta.AllowUserToDeleteRows = false;
            this.Dgv_ClientesConsulta.AllowUserToOrderColumns = true;
            this.Dgv_ClientesConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_ClientesConsulta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Nome,
            this.CPF,
            this.Celular,
            this.Email,
            this.Endereco,
            this.Cidade});
            this.Dgv_ClientesConsulta.Location = new System.Drawing.Point(6, 6);
            this.Dgv_ClientesConsulta.Name = "Dgv_ClientesConsulta";
            this.Dgv_ClientesConsulta.ReadOnly = true;
            this.Dgv_ClientesConsulta.Size = new System.Drawing.Size(746, 418);
            this.Dgv_ClientesConsulta.TabIndex = 0;
            // 
            // Codigo
            // 
            this.Codigo.Frozen = true;
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // Nome
            // 
            this.Nome.Frozen = true;
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            // 
            // CPF
            // 
            this.CPF.Frozen = true;
            this.CPF.HeaderText = "CPF";
            this.CPF.Name = "CPF";
            this.CPF.ReadOnly = true;
            // 
            // Celular
            // 
            this.Celular.Frozen = true;
            this.Celular.HeaderText = "Celular";
            this.Celular.Name = "Celular";
            this.Celular.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.Frozen = true;
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // Endereco
            // 
            this.Endereco.Frozen = true;
            this.Endereco.HeaderText = "Endereço";
            this.Endereco.Name = "Endereco";
            this.Endereco.ReadOnly = true;
            // 
            // Cidade
            // 
            this.Cidade.Frozen = true;
            this.Cidade.HeaderText = "Cidade";
            this.Cidade.Name = "Cidade";
            this.Cidade.ReadOnly = true;
            // 
            // Btn_Sair
            // 
            this.Btn_Sair.Location = new System.Drawing.Point(646, 407);
            this.Btn_Sair.Name = "Btn_Sair";
            this.Btn_Sair.Size = new System.Drawing.Size(115, 41);
            this.Btn_Sair.TabIndex = 31;
            this.Btn_Sair.Text = "&Sair";
            this.Btn_Sair.UseVisualStyleBackColor = true;
            this.Btn_Sair.Click += new System.EventHandler(this.Btn_Sair_Click);
            // 
            // Txt_Cidade
            // 
            this.Txt_Cidade.Location = new System.Drawing.Point(69, 22);
            this.Txt_Cidade.Name = "Txt_Cidade";
            this.Txt_Cidade.Size = new System.Drawing.Size(395, 20);
            this.Txt_Cidade.TabIndex = 32;
            // 
            // Frm_Consulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 460);
            this.Controls.Add(this.Btn_Sair);
            this.Controls.Add(this.Tab_Consulta);
            this.Name = "Frm_Consulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta";
            this.Load += new System.EventHandler(this.Frm_Consulta_Load);
            this.Tab_Consulta.ResumeLayout(false);
            this.Tab_Parametros.ResumeLayout(false);
            this.Tab_Parametros.PerformLayout();
            this.Tab_Resultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_ClientesConsulta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Tab_Consulta;
        private System.Windows.Forms.TabPage Tab_Parametros;
        private System.Windows.Forms.TabPage Tab_Resultados;
        private System.Windows.Forms.TextBox Txt_Nome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_Consultar;
        private System.Windows.Forms.Button Btn_Limpar;
        private System.Windows.Forms.DataGridView Dgv_ClientesConsulta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPF;
        private System.Windows.Forms.DataGridViewTextBoxColumn Celular;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Endereco;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cidade;
        private System.Windows.Forms.Button Btn_Sair;
        private System.Windows.Forms.TextBox Txt_Cidade;
    }
}