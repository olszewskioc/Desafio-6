    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using FarmacySystem.controller;
    using System.Collections.Generic;
    using System.Linq;

    namespace FarmacySystem.view
    {
        public class FarmaceuticoForm : Form
        {
            private ListBox listBox;
            private TextBox searchBox;
            private CrudMedicine crud;

            public FarmaceuticoForm()
            {
                this.Text = "DigiMed Pharmacy";
                this.Size = new Size(800, 500);
                this.StartPosition = FormStartPosition.CenterScreen;
                this.BackColor = Color.MistyRose;

                crud = new CrudMedicine();

                Panel sidebar = new Panel();
                sidebar.Size = new Size(180, this.Height);
                sidebar.BackColor = Color.Purple;
                sidebar.Dock = DockStyle.Left;
                this.Controls.Add(sidebar);

                Button btnPesquisa = CreateMenuButton("Pesquisa e Consulta de Medicamentos", 1);
                Button btnRegistro = CreateMenuButton("Registro de Venda de Medicamentos Controlados", 80);
                sidebar.Controls.Add(btnPesquisa);
                sidebar.Controls.Add(btnRegistro);

                btnRegistro.Click += (sender, e) =>
                {
                    FormRegistroVendas formRegistro = new FormRegistroVendas();
                    formRegistro.ShowDialog();
                };

                Panel topBar = new Panel();
                topBar.Size = new Size(this.Width, 50);
                topBar.BackColor = Color.Purple;
                topBar.Dock = DockStyle.Top;
                this.Controls.Add(topBar);

                searchBox = new TextBox();
                searchBox.Size = new Size(500, 30);
                searchBox.Location = new Point(190, 80);
                this.Controls.Add(searchBox);

                Button bt = new Button();
                bt.Text = "Buscar";
                bt.Size = new Size(90, 25);
                bt.Location = new Point(700, 80);
                bt.BackColor = Color.Gray;
                bt.ForeColor = Color.White;
                this.Controls.Add(bt);

                bt.Click += ButtonPesquisar_Click;

                Panel displayArea = new Panel();
                displayArea.Size = new Size(610, 480);
                displayArea.Location = new Point(180, 50);
                displayArea.BackColor = Color.LightGray;
                this.Controls.Add(displayArea);

                listBox = new ListBox();
                listBox.Size = new Size(580, 300);
                listBox.Location = new Point(10, 90);
                displayArea.Controls.Add(listBox);

                ListarTodos();
            }

            private Button CreateMenuButton(string text, int top)
            {
                Button button = new Button();
                button.Text = text;
                button.Size = new Size(179, 60);
                button.Location = new Point(1, top);
                button.BackColor = Color.OrangeRed;
                button.ForeColor = Color.White;
                button.FlatStyle = FlatStyle.Flat;
                button.Font = new Font("Arial", 9, FontStyle.Bold);
                return button;
            }

            private void ButtonPesquisar_Click(object sender, EventArgs e)
            {
                try
                {
                    string termoPesquisa = searchBox.Text.Trim().ToLower();

                    if (string.IsNullOrEmpty(termoPesquisa))
                    {
                        ListarTodos();
                        return;
                    }

                    var medicamentosFiltrados = crud.ListMedicines()
                                                    .Where(m => m.ToLower().Contains(termoPesquisa))
                                                    .ToList();

                    listBox.Items.Clear();

                    if (medicamentosFiltrados.Count == 0)
                    {
                        MessageBox.Show("Nenhum medicamento encontrado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    foreach (var remedio in medicamentosFiltrados)
                    {
                        listBox.Items.Add(remedio);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao pesquisar medicamentos: " + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void ListarTodos()
            {
                try
                {
                    var medicamentos = crud.ListMedicines();
                    listBox.Items.Clear();

                    if (medicamentos.Count == 0)
                    {
                        MessageBox.Show("Nenhum medicamento encontrado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    foreach (var remedio in medicamentos)
                    {
                        listBox.Items.Add(remedio);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao listar medicamentos: " + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        class FormRegistroVendas : Form
        {
            private CrudSale crud;
            private TextBox txtNome, txtValor, txtCliente;
            private NumericUpDown numQtd, idVendedor;
            private DateTimePicker dtpData;

            public FormRegistroVendas()
            {
                this.Text = "Registro de Vendas - DigiMed Pharmacy";
                this.Size = new Size(800, 500);
                this.StartPosition = FormStartPosition.CenterScreen;
                this.BackColor = Color.MistyRose;

                crud = new CrudSale();

                Panel sidebar = new Panel();
                sidebar.Size = new Size(180, this.Height);
                sidebar.BackColor = Color.Purple;
                sidebar.Dock = DockStyle.Left;
                this.Controls.Add(sidebar);

                Button btnVoltar = new Button();
                btnVoltar.Text = "Voltar";
                btnVoltar.Size = new Size(160, 40);
                btnVoltar.Location = new Point(10, 30);
                btnVoltar.BackColor = Color.Gray;
                btnVoltar.ForeColor = Color.White;
                btnVoltar.Click += (sender, e) => { this.Close(); };
                sidebar.Controls.Add(btnVoltar);

                Panel topBar = new Panel();
                topBar.Size = new Size(this.Width, 50);
                topBar.BackColor = Color.Purple;
                topBar.Dock = DockStyle.Top;
                this.Controls.Add(topBar);

                Panel formPanel = new Panel();
                formPanel.Size = new Size(600, 350);
                formPanel.Location = new Point(190, 60);
                formPanel.BackColor = Color.LightGray;
                this.Controls.Add(formPanel);

                Label lblNome = new Label() { Text = "ID Remedio:", Location = new Point(20, 20) };
                txtNome = new TextBox() { Size = new Size(200, 30), Location = new Point(180, 20) };

                Label lblQtd = new Label() { Text = "Quantidade:", Location = new Point(20, 60) };
                numQtd = new NumericUpDown() { Size = new Size(100, 30), Location = new Point(180, 60) };

                Label lblValor = new Label() { Text = "Valor (R$):", Location = new Point(20, 100) };
                txtValor = new TextBox() { Size = new Size(100, 30), Location = new Point(180, 100) };

                Label lblCliente = new Label() { Text = "Nome do Cliente:", Location = new Point(20, 140) };
                txtCliente = new TextBox() { Size = new Size(200, 30), Location = new Point(180, 140) };

                Label lblData = new Label() { Text = "Data da Venda:", Location = new Point(20, 180) };
                dtpData = new DateTimePicker() { Location = new Point(180, 180) };

                Label lblCod = new Label() { Text = "ID Vendedor:", Location = new Point(20, 220) };
                idVendedor = new NumericUpDown() { Size = new Size(100, 30), Location = new Point(180, 220) };

                Button btnRegistrar = new Button();
                btnRegistrar.Text = "Registrar Venda";
                btnRegistrar.Size = new Size(150, 40);
                btnRegistrar.Location = new Point(20, 260);
                btnRegistrar.BackColor = Color.OrangeRed;
                btnRegistrar.ForeColor = Color.White;

                btnRegistrar.Click += new EventHandler(MbtnInserir_Click); // Evento ajustado

                formPanel.Controls.Add(lblNome);
                formPanel.Controls.Add(txtNome);
                formPanel.Controls.Add(lblQtd);
                formPanel.Controls.Add(numQtd);
                formPanel.Controls.Add(lblValor);
                formPanel.Controls.Add(txtValor);
                formPanel.Controls.Add(lblCliente);
                formPanel.Controls.Add(txtCliente);
                formPanel.Controls.Add(lblData);
                formPanel.Controls.Add(dtpData);
                formPanel.Controls.Add(lblCod);
                formPanel.Controls.Add(idVendedor);
                formPanel.Controls.Add(btnRegistrar);

            }

            private void MbtnInserir_Click(object sender, EventArgs e)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(txtNome.Text))
                    {
                        MessageBox.Show("Por favor, informe o ID do medicamento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (numQtd.Value <= 0)
                    {
                        MessageBox.Show("Por favor, informe uma quantidade válida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    decimal valor;
                    if (!decimal.TryParse(txtValor.Text, out valor) || valor <= 0)
                    {
                        MessageBox.Show("Por favor, informe um valor válido para o medicamento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(txtCliente.Text))
                    {
                        MessageBox.Show("Por favor, informe o nome do cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (idVendedor.Value <= 0)
                    {
                        MessageBox.Show("Por favor, informe um ID de vendedor válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (dtpData.Value > DateTime.Now)
                    {
                        MessageBox.Show("A data da venda não pode ser no futuro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    crud.InsertSales(txtCliente.Text, dtpData.Value, (decimal)valor, (int)idVendedor.Value);

                    MessageBox.Show("Venda registrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao registrar venda: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
