using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CadastroClientes {
    public partial class Frm_Consulta : Form {
        private readonly MySqlConnection connection = new MySqlConnection();
        private readonly MySqlCommand command = new MySqlCommand();

        public Frm_Consulta() {
            InitializeComponent();
        }

        private void Btn_Consultar_Click(object sender, EventArgs e) {
            Dgv_ClientesConsulta.Rows.Clear();

            try {
                // Usar parâmetros para evitar SQL Injection
                string query = "SELECT * FROM clientes WHERE cidade LIKE @cidade AND nome LIKE @nome";

                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@cidade", $"%{Txt_Cidade.Text}%");
                command.Parameters.AddWithValue("@nome", $"%{Txt_Nome.Text}%");

                using (var reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        var codigo = reader["cod_cliente"].ToString();
                        var nome = reader["nome"].ToString();
                        var cpf = reader["cpf"].ToString().Replace(reader["cpf"].ToString().Substring(3, 6), new string('*', 6));
                        var celular = reader["cel"].ToString().Replace(reader["cel"].ToString().Substring(3, 6), new string('*', 6));
                        var cidade = reader["cidade"].ToString();
                        var email = reader["email"].ToString();
                        var endereco = reader["longadouro"].ToString();

                        Dgv_ClientesConsulta.Rows.Add(codigo, nome, cpf, celular, email, endereco, cidade);
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"Erro ao consultar clientes: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        string MascararValor(string valor, int prefixo, int sufixo) {
            if (string.IsNullOrEmpty(valor) || valor.Length <= (prefixo + sufixo))
                return valor; // Se o valor for curto demais, retorna sem mascarar

            int mascararTamanho = valor.Length - (prefixo + sufixo);
            string mascarado = new string('*', mascararTamanho);

            return valor.Substring(0, prefixo) + mascarado + valor.Substring(valor.Length - sufixo);
        }

        private void Btn_Limpar_Click(object sender, EventArgs e) {
            Txt_Cidade.Clear();
            Txt_Nome.Clear();
        }

        private void Btn_Sair_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Frm_Consulta_Load(object sender, EventArgs e) {
            try {
                connection.ConnectionString = "Server=localhost;Database=db_clientes;User=root;Pwd=2205";
                connection.Open();
                command.Connection = connection;
            }
            catch (Exception ex) {
                MessageBox.Show($"Erro: {ex.Message}", "Erro de Conexão ADO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
