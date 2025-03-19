using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmacySystem.controller;

namespace FarmacySystem.view
{
    public class SupllierForm : Form
    {
        private MainForm mainForm;
        public SupllierForm(MainForm mainform)
        {
            this.mainForm = mainform;
            InitializeComponents();
            ConfigureScreen();
        }

        private void InitializeComponents()
        {
            this.Text = "Fornecedores - DigiMed Pharmacy";
            this.Size = new Size(600, 700);
            this.MinimumSize = new Size(500, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(180, 180, 251);
        }

        private void ConfigureScreen()
        {

        }
    }
}