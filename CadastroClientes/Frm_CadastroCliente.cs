using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using DisciplinaLP1;
using VerificaForcaSenha;
using MySql.Data.MySqlClient;
using MySql.Data.MySqlClient.Memcached;
using MySqlX.XDevAPI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CadastroClientes
{
    public partial class Frm_CadastroCliente : Form
    {
        private MySqlConnection Obj_Conn = new MySqlConnection();
        private MySqlCommand Obj_CmdSQL = new MySqlCommand();
        private MySqlDataReader DadosCarregados;
        int op = 0;

        public Frm_CadastroCliente()
        {
            InitializeComponent();
        }        

        void MostrarDados()
        {
            byte[] rawData;

            Obj_CmdSQL.CommandText = "SELECT * FROM clientes WHERE cod_cliente = " + Txt_Codigo.Value.ToString();

            DadosCarregados = Obj_CmdSQL.ExecuteReader();
            if (DadosCarregados.HasRows)
            {
                DadosCarregados.Read();

                //Txt_Codigo.Value = Convert.ToDecimal(DadosCarregados["cod_cliente"]);
                Txt_Nome.Text = DadosCarregados["nome"].ToString();
                Txt_RG.Text = DadosCarregados["rg"].ToString();
                Txt_CPF.Text = DadosCarregados["cpf"].ToString();
                Txt_Senha.Text = DadosCarregados["senha"].ToString();
                Txt_Celular.Text = DadosCarregados["cel"].ToString();
                Txt_TelAlternativo.Text = DadosCarregados["tel_alt"].ToString();
                string sexo = DadosCarregados["sexo"].ToString();
                if (sexo == "masculino")
                    Rdo_Masculino.Checked = true;
                else
                    Rdo_Feminino.Checked = true;
                Txt_CEP.Text = DadosCarregados["cep"].ToString();
                Txt_Logadouro.Text = DadosCarregados["longadouro"].ToString();
                Txt_Numero.Text = DadosCarregados["numero"].ToString();
                Txt_Bairro.Text = DadosCarregados["bairro"].ToString();
                Txt_Cidade.Text = DadosCarregados["cidade"].ToString();
                Cbo_Estado.Text = DadosCarregados["estado"].ToString();
                Txt_Email.Text = DadosCarregados["email"].ToString();
                Txt_Facebook.Text = DadosCarregados["facebook"].ToString();
                Txt_Twitter.Text = DadosCarregados["twitter"].ToString();
                Txt_Linkedin.Text = DadosCarregados["linkedin"].ToString();

                //Verificar se imagem não é nula
                //(https://learn.microsoft.com/pt-br/dotnet/api/system.data.sqlclient.sqldatareader.isdbnull?view=netframework-4.8.1)
                if (!DadosCarregados.IsDBNull(DadosCarregados.GetOrdinal("imagem")))
                {
                    //Carregar imagem
                    rawData = (byte[])DadosCarregados["imagem"];
                    MemoryStream Imagem = new MemoryStream(rawData);
                    Pcb_Foto.Image = Image.FromStream(Imagem);
                }
                else
                    Pcb_Foto.Image = null;
            }
            else
                Btn_Limpar.PerformClick();

            if (!DadosCarregados.IsClosed)
                DadosCarregados.Close();
        }

        void EsconderDados() {
            byte[] rawData;

            Txt_CPF.Mask = "";
            Txt_Celular.Mask = "";

            Obj_CmdSQL.CommandText = "SELECT * FROM clientes WHERE cod_cliente = " + Txt_Codigo.Value.ToString();

            DadosCarregados = Obj_CmdSQL.ExecuteReader();
            if (DadosCarregados.HasRows) {
                DadosCarregados.Read();

                // Exibir os dados mascarados
                Txt_Nome.Text = DadosCarregados["nome"].ToString();
                Txt_RG.Text = MascararValor((DadosCarregados["rg"].ToString()), 2, 2, false);
                Txt_CPF.Text = MascararValor((DadosCarregados["cpf"].ToString()), 3, 2, false);
                Txt_Senha.Text = MascararValor((DadosCarregados["senha"].ToString()), 3, 2, true);
                Txt_Celular.Text = MascararValor((DadosCarregados["cel"].ToString()), 3, 2, false);
                Txt_TelAlternativo.Text = MascararValor((DadosCarregados["tel_alt"].ToString()), 3, 2, false);
                Txt_CEP.Text = MascararValor((DadosCarregados["cep"].ToString()), 5, 0, false);

                string sexo = DadosCarregados["sexo"].ToString();
                if (sexo == "masculino")
                    Rdo_Masculino.Checked = true;
                else
                    Rdo_Feminino.Checked = true;

                Txt_Logadouro.Text = DadosCarregados["longadouro"].ToString();
                Txt_Numero.Text = DadosCarregados["numero"].ToString();
                Txt_Bairro.Text = DadosCarregados["bairro"].ToString();
                Txt_Cidade.Text = DadosCarregados["cidade"].ToString();
                Cbo_Estado.Text = DadosCarregados["estado"].ToString();
                Txt_Email.Text = DadosCarregados["email"].ToString();
                Txt_Facebook.Text = DadosCarregados["facebook"].ToString();
                Txt_Twitter.Text = DadosCarregados["twitter"].ToString();
                Txt_Linkedin.Text = DadosCarregados["linkedin"].ToString();

                if (!DadosCarregados.IsDBNull(DadosCarregados.GetOrdinal("imagem"))) {
                    rawData = (byte[])DadosCarregados["imagem"];
                    MemoryStream Imagem = new MemoryStream(rawData);
                    Pcb_Foto.Image = Image.FromStream(Imagem);
                }
                else
                    Pcb_Foto.Image = null;
            }
            else
                Btn_Limpar.PerformClick();

            if (!DadosCarregados.IsClosed)
                DadosCarregados.Close();
        }
    
        string MascararValor(string valor, int prefixo, int sufixo, bool isSenha) {
            if (string.IsNullOrEmpty(valor) || valor.Length <= (prefixo + sufixo))
                return valor; // Se o valor for curto demais, retorna sem mascarar

            if (isSenha)
                return new string('*', valor.Length);

            int mascararTamanho = valor.Length - (prefixo + sufixo);
            string mascarado = new string('*', mascararTamanho);

            return valor.Substring(0, prefixo) + mascarado + valor.Substring(valor.Length - sufixo);
        }

        void HabilitaEdicao()
        {
            Pnl_Comandos.Visible = false;
            Pnl_SalvarCancelar.Visible = true;
            Txt_Codigo.Visible = false;
            Txt_Codigo_Phantom.Visible = true;
            Txt_Nome.ReadOnly = false;
            Txt_RG.ReadOnly = false;
            Txt_CPF.ReadOnly = false;
            Txt_Senha.ReadOnly = false;
            Txt_Celular.ReadOnly = false;
            Txt_TelAlternativo.ReadOnly = false;
            Rdo_Feminino.Enabled = true;
            Rdo_Masculino.Enabled = true;
            Txt_CEP.ReadOnly = false;
            Txt_Logadouro.ReadOnly = false;
            Txt_Numero.ReadOnly = false;
            Txt_Bairro.ReadOnly = false;
            Txt_Cidade.ReadOnly = false;
            Cbo_Estado.Enabled = true;
            Txt_Email.ReadOnly = false;
            Txt_Facebook.ReadOnly = false;
            Txt_Twitter.ReadOnly = false;
            Txt_Linkedin.ReadOnly = false;
            Btn_CarregarImagem.Enabled = true;
            Btn_LimparImagem.Enabled = true;

        }

        void DesabilitaEdicao()
        {
            Pnl_Comandos.Visible = true;
            Pnl_SalvarCancelar.Visible = false;
            Txt_Codigo.Visible = true;
            Txt_Codigo_Phantom.Visible = false;
            Txt_Nome.ReadOnly = true;
            Txt_RG.ReadOnly = true;
            Txt_CPF.ReadOnly = true;
            Txt_Senha.ReadOnly = true;
            Txt_Celular.ReadOnly = true;
            Txt_TelAlternativo.ReadOnly = true;
            Rdo_Feminino.Enabled = false;
            Rdo_Masculino.Enabled = false;
            Txt_CEP.ReadOnly = true;
            Txt_Logadouro.ReadOnly = true;
            Txt_Numero.ReadOnly = true;
            Txt_Bairro.ReadOnly = true;
            Txt_Cidade.ReadOnly = true;
            Cbo_Estado.Enabled = false;
            Txt_Email.ReadOnly = true;
            Txt_Facebook.ReadOnly = true;
            Txt_Twitter.ReadOnly = true;
            Txt_Linkedin.ReadOnly = true;
            Btn_CarregarImagem.Enabled = false;
            Btn_LimparImagem.Enabled = false;
        }

        private void Frm_CadastroCliente_Load(object sender, EventArgs e)
        {
            try
            {
                // String de conexão para o banco de dados local de vocês
                Obj_Conn.ConnectionString = "Server=localhost;Database=db_clientes;User=root;Pwd=2205";

                
                Obj_Conn.Open();
                Obj_CmdSQL.Connection = Obj_Conn;
            }
            catch (Exception Erro)
            {
                MessageBox.Show("Erro: " + Erro.Message, "Erro de Conexão ADO",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Sair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btn_Limpar_Click(object sender, EventArgs e)
        {
            Txt_Bairro.Clear();
            Txt_Celular.Clear();
            Txt_CEP.Clear();
            Txt_Cidade.Clear();
            Txt_CPF.Clear();
            Txt_Senha.Clear();
            Txt_Email.Clear();
            Txt_Facebook.Clear();
            Txt_Linkedin.Clear();
            Txt_Logadouro.Clear();
            Txt_Nome.Clear();
            Txt_Numero.Clear();
            Txt_RG.Clear();
            Txt_TelAlternativo.Clear();
            Txt_Twitter.Clear();
            Rdo_Feminino.Checked = false;
            Rdo_Masculino.Checked = false;
            Cbo_Estado.SelectedIndex = -1;
            Txt_Codigo.Focus();
            Pcb_Foto.Image = null;

        }

        private void Btn_LimparImagem_Click(object sender, EventArgs e)
        {
            Pcb_Foto.Image = null;
        }

        private void Btn_CarregarImagem_Click(object sender, EventArgs e)
        {
            if (Ofd_CarregaImagem.ShowDialog() == DialogResult.OK)
            {
                Pcb_Foto.Load(Ofd_CarregaImagem.FileName);
            }
        }

        private void Txt_Codigo_ValueChanged(object sender, EventArgs e)
        {
            EsconderDados();
        }

        private void Btn_Incluir_Click(object sender, EventArgs e)
        {
            //incluir = 0
            op = 0;

            HabilitaEdicao();
            Btn_Limpar.PerformClick();

            //Seleciona a última linha (maior código) da Tabela clientes
            Obj_CmdSQL.CommandText = "SELECT MAX(cod_cliente) FROM clientes";

            DadosCarregados = Obj_CmdSQL.ExecuteReader();
            if (DadosCarregados.HasRows)
            {
                try
                {
                    DadosCarregados.Read();
                    //Gambiarra para não alterar o valor do Txt_Codigo original
                    //E por consequência não reabrir o DataReader
                    Txt_Codigo_Phantom.Value = Convert.ToDecimal(DadosCarregados[0]) + 1;
                }
                catch (Exception)
                {
                    Txt_Codigo_Phantom.Value = 1;
                }
            }
            if (!DadosCarregados.IsClosed)
                DadosCarregados.Close();
        }

        private void Btn_Salvar_Click(object sender, EventArgs e) {

            string query = "";
            byte[] rawData = null; // Dados binários da imagem

            string cpf = Txt_CPF.Text.Replace(".", "").Replace("-", "");
            string email = Txt_Email.Text;
            string facebookUrl = Txt_Facebook.Text;
            string twitterUrl = Txt_Twitter.Text;
            string linkedinUrl = Txt_Linkedin.Text;
            string senha = Txt_Senha.Text;

            bool cpfValido = Cls_Validacoes.ValidaCPF(cpf);

            // Instancia a classe de verificação de força de senha
            ChecaForcaSenha checador = new ChecaForcaSenha();
            // Obtém a força da senha
            ForcaDaSenha forca = checador.GetForcaDaSenha(senha);

            // Exibe a mensagem conforme a força da senha
            switch (forca) {
                case ForcaDaSenha.Nenhuma:
                    MessageBox.Show("O campo senha é obrigatorio!", 
                                    "Força da senha",
                                     MessageBoxButtons.OK, 
                                     MessageBoxIcon.Warning);
                    Txt_Senha.Focus();
                    return;


                case ForcaDaSenha.Inaceitavel:
                    MessageBox.Show("A senha é muito fraca! Por favor, escolha uma senha mais forte.",
                                    "Força da Senha",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    Txt_Senha.Focus();
                    return;
                    

                case ForcaDaSenha.Fraca:
                    MessageBox.Show("A senha é fraca. Considere adicionar mais caracteres e diversificar os tipos de caracteres.",
                                    "Força da Senha",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    Txt_Senha.Focus();
                    return;

                case ForcaDaSenha.Aceitavel:
                    MessageBox.Show("A senha é aceitável, mas pode ser mais segura com mais diversidade de caracteres.",
                                    "Força da Senha",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;

                case ForcaDaSenha.Forte:
                    MessageBox.Show("A senha é forte, mas pode ser ainda mais segura com mais caracteres especiais.",
                                    "Força da Senha",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    
                    break;

                case ForcaDaSenha.Segura:
                    MessageBox.Show("A senha é muito segura! Parabéns por escolher uma senha robusta.",
                                    "Força da Senha",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;

                default:
                    MessageBox.Show("Erro ao verificar a força da senha. Tente novamente.",
                                    "Erro",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    break;
            }

            if (op == 0) // Inserção
            {
                if (!VerificarCamposPreenchidos())
                    return;

                if (VerificaCpfDuplicado(cpf)) {
                    MessageBox.Show("CPF já cadastrado! Insira outro CPF.", "Erro de Duplicidade", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Txt_CPF.Focus();
                    return;
                }

                if (!Cls_Validacoes.ValidaEmail(email)) {
                    MessageBox.Show("O email usado é invalido! Por favor, corrija-o.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Txt_Email.Focus();
                    return;
                }

                // Verifica a URL do Facebook apenas se ela foi preenchida
                if (!string.IsNullOrWhiteSpace(facebookUrl) && !Cls_Validacoes.ValidaFacebook(facebookUrl)) {
                    MessageBox.Show("A URL inserida para o Facebook é inválida. Por favor, corrija-a.",
                                    "Erro de Validação",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                // Verifica a URL do Twitter apenas se ela foi preenchida
                if (!string.IsNullOrWhiteSpace(twitterUrl) && !Cls_Validacoes.ValidaTwitter(twitterUrl)) {
                    MessageBox.Show("A URL inserida para o Twitter é inválida. Por favor, corrija-a.",
                                    "Erro de Validação",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                // Verifica a URL do LinkedIn apenas se ela foi preenchida
                if (!string.IsNullOrWhiteSpace(linkedinUrl) && !Cls_Validacoes.ValidaLinkedin(linkedinUrl)) {
                    MessageBox.Show("A URL inserida para o LinkedIn é inválida. Por favor, corrija-a.",
                                    "Erro de Validação",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                query = @"INSERT INTO clientes (cod_cliente, nome, rg, cpf, senha, cel, tel_alt, sexo, cep,
                  longadouro, numero, bairro, cidade, estado, email, facebook, twitter, linkedin, imagem)
                  VALUES(@CodCliente, @Nome, @Rg, @Cpf, @senha, @Cel, @TelAlt, @Sexo, @Cep,
                  @Logradouro, @Numero, @Bairro, @Cidade, @Estado, @Email, @Facebook, @Twitter, @Linkedin, @Imagem)";
            }
            else if (op == 1) // Atualização
            {
                if (!VerificarCamposPreenchidos())
                    return;

                if (VerificaCpfDuplicado(cpf)) {
                    MessageBox.Show("CPF já cadastrado! Insira outro CPF.", "Erro de Duplicidade", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Txt_CPF.Focus();
                    return;
                }
                
                if (!Cls_Validacoes.ValidaEmail(email)) {
                    MessageBox.Show("O email usado é invalido! Por favor, corrija-o.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Txt_Email.Focus();
                    return;
                }

                // Verifica a URL do Facebook apenas se ela foi preenchida
                if (!string.IsNullOrWhiteSpace(facebookUrl) && !Cls_Validacoes.ValidaFacebook(facebookUrl)) {
                    MessageBox.Show("A URL inserida para o Facebook é inválida. Por favor, corrija-a.",
                                    "Erro de Validação",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                // Verifica a URL do Twitter apenas se ela foi preenchida
                if (!string.IsNullOrWhiteSpace(twitterUrl) && !Cls_Validacoes.ValidaTwitter(twitterUrl)) {
                    MessageBox.Show("A URL inserida para o Twitter é inválida. Por favor, corrija-a.",
                                    "Erro de Validação",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                // Verifica a URL do LinkedIn apenas se ela foi preenchida
                if (!string.IsNullOrWhiteSpace(linkedinUrl) && !Cls_Validacoes.ValidaLinkedin(linkedinUrl)) {
                    MessageBox.Show("A URL inserida para o LinkedIn é inválida. Por favor, corrija-a.",
                                    "Erro de Validação",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                query = @"UPDATE clientes SET nome = @Nome, rg = @Rg, cpf = @Cpf, senha = @senha, cel = @Cel, tel_alt = @TelAlt,
                  sexo = @Sexo, cep = @Cep, longadouro = @Logradouro, numero = @Numero, bairro = @Bairro,
                  cidade = @Cidade, estado = @Estado, email = @Email, facebook = @Facebook, twitter = @Twitter,
                  linkedin = @Linkedin, imagem = @Imagem WHERE cod_cliente = @CodCliente";
                Txt_Codigo.Enabled = Txt_Codigo_Phantom.Enabled = true;
            }
            else if (op == 2) // Exclusão
            {
                query = "DELETE FROM clientes WHERE cod_cliente = @CodCliente";
                Btn_Limpar.PerformClick();
            }

            // Processar imagem, se houver
            if (Pcb_Foto.Image != null) {
                using (var streamFoto = new MemoryStream()) {
                    Pcb_Foto.Image.Save(streamFoto, Pcb_Foto.Image.RawFormat);
                    rawData = streamFoto.ToArray();
                }
            }
             
            try {
                Obj_CmdSQL.CommandText = query;
                Obj_CmdSQL.Parameters.Clear(); // Limpa parâmetros antigos

                // Adiciona parâmetros básicos
                Obj_CmdSQL.Parameters.AddWithValue("@CodCliente", Txt_Codigo_Phantom.Value.ToString());
                Obj_CmdSQL.Parameters.AddWithValue("@Nome", Txt_Nome.Text);
                Obj_CmdSQL.Parameters.AddWithValue("@Rg", Txt_RG.Text);
                Obj_CmdSQL.Parameters.AddWithValue("@Cpf", Txt_CPF.Text.Replace(".", "").Replace("-", ""));
                Obj_CmdSQL.Parameters.AddWithValue("@senha", Txt_Senha.Text);
                Txt_Celular.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;   
                Obj_CmdSQL.Parameters.AddWithValue("@Cel", Txt_Celular.Text);
                Obj_CmdSQL.Parameters.AddWithValue("@TelAlt", Txt_TelAlternativo.Text);

                // Determina o sexo selecionado
                var sexo = Rdo_Masculino.Checked ? "masculino" : "feminino";
                Obj_CmdSQL.Parameters.AddWithValue("@Sexo", sexo);

                // Outros parâmetros de texto
                Obj_CmdSQL.Parameters.AddWithValue("@Cep", Txt_CEP.Text);
                Obj_CmdSQL.Parameters.AddWithValue("@Logradouro", Txt_Logadouro.Text);
                Obj_CmdSQL.Parameters.AddWithValue("@Numero", Txt_Numero.Text);
                Obj_CmdSQL.Parameters.AddWithValue("@Bairro", Txt_Bairro.Text);
                Obj_CmdSQL.Parameters.AddWithValue("@Cidade", Txt_Cidade.Text);
                Obj_CmdSQL.Parameters.AddWithValue("@Estado", Cbo_Estado.Text);
                Obj_CmdSQL.Parameters.AddWithValue("@Email", Txt_Email.Text);
                Obj_CmdSQL.Parameters.AddWithValue("@Facebook", Txt_Facebook.Text);
                Obj_CmdSQL.Parameters.AddWithValue("@Twitter", Txt_Twitter.Text);
                Obj_CmdSQL.Parameters.AddWithValue("@Linkedin", Txt_Linkedin.Text);
                Obj_CmdSQL.Parameters.AddWithValue("@Imagem", rawData ); 

                Obj_CmdSQL.ExecuteNonQuery(); // Executa a consulta
            }
            catch (Exception ex) {
                MessageBox.Show($"Erro: {ex.Message}", "Erro ao Salvar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                Txt_Codigo.Value = Txt_Codigo_Phantom.Value;
                Obj_CmdSQL.Parameters.Clear(); // Sempre limpa os parâmetros
            }

            DesabilitaEdicao(); // Finaliza a edição
            EsconderDados();
        }

        private bool VerificaCpfDuplicado(string cpf) {
            string query = "SELECT COUNT(*) FROM clientes WHERE cpf = @Cpf";
            if (op == 1) {
                // Caso seja uma atualização, ignorar o CPF do cliente atual
                query += " AND cod_cliente <> @CodCliente";
            }

            try {
                Obj_CmdSQL.CommandText = query;
                Obj_CmdSQL.Parameters.Clear();
                Obj_CmdSQL.Parameters.AddWithValue("@Cpf", cpf);

                if (op == 1) {
                    Obj_CmdSQL.Parameters.AddWithValue("@CodCliente", Txt_Codigo_Phantom.Value.ToString());
                }

                int count = Convert.ToInt32(Obj_CmdSQL.ExecuteScalar()); // Retorna a contagem
                return count > 0; // Se count > 0, o CPF já existe
            }
            catch (Exception ex) {
                MessageBox.Show($"Erro ao verificar duplicidade: {ex.Message}", "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool VerificarCamposPreenchidos() {
            bool camposValidos = true;

            string cpf = Txt_CPF.Text.Replace(".", "").Replace("-", "");
            bool cpfValido = Cls_Validacoes.ValidaCPF(cpf);

            string celular = Txt_Celular.Text.Replace("(", "").Replace(")", "").Replace("-", "");

            string sexo = null;

            if (Rdo_Masculino.Checked) {
                sexo = Rdo_Masculino.Text; // "Masculino"
            }
            else if (Rdo_Feminino.Checked) {
                sexo = Rdo_Feminino.Text; // "Feminino"
            }

            // Valida o campo Nome
            if (string.IsNullOrWhiteSpace(Txt_Nome.Text)) {
                MessageBox.Show("O campo 'Nome' é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (camposValidos) Txt_Nome.Focus();
                camposValidos = false;
            }

            // Valida o campo CPF
            if (string.IsNullOrWhiteSpace(Txt_CPF.Text)) {
                MessageBox.Show("O campo 'CPF' é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (camposValidos) Txt_CPF.Focus();
                camposValidos = false;
            }
            else if (!cpfValido) {
                MessageBox.Show("O CPF informado é inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (camposValidos) Txt_CPF.Focus();
                camposValidos = false;
            }

            // Valida o campo Número de Telefone
            if (string.IsNullOrWhiteSpace(celular)) {
                MessageBox.Show("O campo 'Celular' é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (camposValidos) Txt_Celular.Focus();
                camposValidos = false;
            }

            if (sexo == null) {
                MessageBox.Show("O campo 'Sexo' é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (camposValidos) Grb_Sexo.Focus();
                camposValidos = false;
            }


            return camposValidos;
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            Btn_Limpar.PerformClick();
            DesabilitaEdicao();
            EsconderDados();
        }

        private void Txt_Celular_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Txt_CPF_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
         
        }

        private void Btn_Excluir_Click(object sender, EventArgs e)
        {
            HabilitaEdicao();
            Txt_Codigo_Phantom.Value = Convert.ToDecimal(Txt_Codigo.Value);  // pega o código do cliente
            op = 2;
        }

        private void Btn_Consultar_Click(object sender, EventArgs e)
        {
            Frm_Consulta Obj_Frm_Consulta = new Frm_Consulta();
            Obj_Frm_Consulta.ShowDialog();
        }

        private void Txt_Codigo_Phantom_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Btn_Alterar_Click(object sender, EventArgs e) {

            op = 1;

            MostrarDados();
            HabilitaEdicao();

            Txt_Codigo.Enabled = false;
            Txt_Codigo_Phantom.Enabled = false;
            Txt_Codigo_Phantom.Value = Convert.ToDecimal(Txt_Codigo.Value);
        }

        private void Pnl_SalvarCancelar_Paint(object sender, PaintEventArgs e) {

        }

    }
}
