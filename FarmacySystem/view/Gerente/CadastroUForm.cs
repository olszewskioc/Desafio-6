using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using FarmacySystem.controller;

namespace FarmacySystem.view
{
    public partial class FormCadastro : Form
    {
        private MainForm mainForm;
        private CrudUser crudUser;
        private Panel panelCadastro, panelUsuarios;
        private DataGridView dgvUsuarios;
        private Button btnVoltar, btnEnviar, btnAtualizar, btnDeletar;
        private TextBox txtNome, txtLogin, txtSenha;
        private ComboBox cmbCargo;
        private TableLayoutPanel tableLayoutPanel;

        public FormCadastro(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.crudUser = new CrudUser();
            CarregarUsuarios();
        }

        private void InitializeComponent()
        {
            this.Text = "Usuários - DigiMed Pharmacy";
            this.Size = new Size(800, 700);
            this.MinimumSize = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(180, 180, 251);

            // Criar o TableLayoutPanel
            tableLayoutPanel = new TableLayoutPanel
            {
                RowCount = 1,
                ColumnCount = 2,
                Dock = DockStyle.Fill,
                Padding = new Padding(10),
                AutoSize = true
            };

            // Definir o comportamento das colunas
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            // Criar os painéis
            panelCadastro = new Panel { Dock = DockStyle.Fill };
            panelUsuarios = new Panel { Dock = DockStyle.Fill, Margin = new Padding(10) };

            // Componentes do Formulário - Panel Cadastro
            panelCadastro.Controls.AddRange(new Control[] {
                CreateLabel("Nome", new Point(20, 20)), txtNome = CreateTextBox(new Point(20, 50)),
                CreateLabel("Cargo", new Point(20, 90)), cmbCargo = CreateComboBox(new Point(20, 120)),
                CreateLabel("Login (CPF)", new Point(20, 160)), txtLogin = CreateTextBox(new Point(20, 190)),
                CreateLabel("Senha", new Point(20, 230)), txtSenha = CreateTextBox(new Point(20, 260)),
                btnVoltar = CreateButton("Voltar", Color.FromArgb(255, 102, 102), (s, e) => mainForm.TrocarTela(new ManagerForm(mainForm))),
                btnEnviar = CreateButton("Enviar", Color.FromArgb(75, 0, 110), (s, e) => EnviarUsuario()),
                btnAtualizar = CreateButton("Atualizar", Color.FromArgb(255, 165, 0), (s, e) => AtualizarUsuario()),
            btnDeletar = CreateButton("Deletar", Color.FromArgb(255, 0, 0), (s, e) => DeletarUsuario())
            });
            btnVoltar.Location = new Point(20, 310);
            btnEnviar.Location = new Point(150, 310);
            btnAtualizar.Location = new Point(20, 390);
            btnDeletar.Location = new Point(150, 390);
            cmbCargo.Items.AddRange(["Gerente", "Farmaceutico", "Atendente"]);
            txtSenha.PasswordChar = '*';

            // DataGridView para listar usuários - Panel Usuarios
            dgvUsuarios = new DataGridView { Size = new Size(360, 450), Location = new Point(10, 10), ReadOnly = true, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, Dock = DockStyle.Fill };
            dgvUsuarios.SelectionChanged += (s, e) => PreencherFormulario();

            panelUsuarios.Controls.AddRange([dgvUsuarios]);

            // Adicionar painéis ao TableLayoutPanel
            tableLayoutPanel.Controls.Add(panelCadastro, 0, 0); // Primeira coluna
            tableLayoutPanel.Controls.Add(panelUsuarios, 1, 0); // Segunda coluna

            // Adicionar o TableLayoutPanel ao Form
            this.Controls.Add(tableLayoutPanel);
        }

        private Label CreateLabel(string text, Point location) => new Label { Text = text, Font = new Font("Segoe UI", 12F, FontStyle.Bold), AutoSize = true, Location = location };

        private TextBox CreateTextBox(Point location) => new TextBox { Size = new Size(250, 30), Location = location, Font = new Font("Segoe UI", 12F) };

        private ComboBox CreateComboBox(Point location) => new ComboBox { Size = new Size(250, 30), Location = location, Font = new Font("Segoe UI", 12F), DropDownStyle = ComboBoxStyle.DropDownList };

        private Button CreateButton(string text, Color color, EventHandler onClick)
        {
            var button = new Button { Text = text, Size = new Size(120, 40), BackColor = color, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 12F, FontStyle.Bold), Cursor = Cursors.Hand };
            button.Click += onClick;
            return button;
        }

        private void CarregarUsuarios()
        {
            var users = crudUser.ListUser();
            var sortedUsuarios = users.OrderBy(user => user.Id).ToList();
            dgvUsuarios.DataSource = sortedUsuarios;
        }

        private void PreencherFormulario()
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvUsuarios.SelectedRows[0];
                txtNome.Text = row.Cells["Name"].Value.ToString();
                cmbCargo.Text = row.Cells["Role"].Value.ToString();
                txtLogin.Text = row.Cells["Cpf"].Value.ToString();
                txtSenha.Text = ""; // Por segurança, senha não é preenchida
            }
        }

        private void EnviarUsuario()
        {
            try
            {
                crudUser.InsertUser(txtNome.Text, cmbCargo.Text, txtLogin.Text, txtSenha.Text);
                MessageBox.Show("Cadastro efetuado com sucesso!", "Sucesso");
                CarregarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha no cadastro!\n{ex.Message}", "Erro");
            }
        }

        private void AtualizarUsuario()
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvUsuarios.SelectedRows[0];
                int userId = Convert.ToInt32(row.Cells["Id"].Value);
                crudUser.UpdateUser(userId, txtNome.Text, cmbCargo.Text, txtSenha.Text);
                MessageBox.Show("Usuário atualizado com sucesso!", "Sucesso");
                CarregarUsuarios();
            }
        }

        private void DeletarUsuario()
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvUsuarios.SelectedRows[0];
                int userId = Convert.ToInt32(row.Cells["Id"].Value);
                crudUser.DeleteUser(userId);
                MessageBox.Show("Usuário deletado com sucesso!", "Sucesso");
                CarregarUsuarios();
            }
        }
    }
}
