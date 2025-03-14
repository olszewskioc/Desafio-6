using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmacySystem.view
{
    public partial class ManagerForm : Form
{
    public ManagerForm()
    {
        ConfigurarTela();
    }

    private void ConfigurarTela()
    {
        this.Text = "Gerente";
        this.Size = new Size(400, 300);

        Label lbl = new Label
        {
            Text = "Bem-vindo, Gerente!",
            AutoSize = true,
            Location = new Point(50, 50),
            Font = new Font("Arial", 14, FontStyle.Bold)
        };

        this.Controls.Add(lbl);
    }
}
}