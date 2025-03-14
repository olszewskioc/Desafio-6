using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmacySystem.view
{
    public partial class SalesmanForm : Form
{
    public SalesmanForm()
    {
        ConfigurarTela();
    }

    private void ConfigurarTela()
    {
        this.Text = "Atendente";
        this.Size = new Size(400, 300);

        Label lbl = new Label
        {
            Text = "Bem-vindo, Atendente!",
            AutoSize = true,
            Location = new Point(50, 50),
            Font = new Font("Arial", 14, FontStyle.Bold)
        };

        this.Controls.Add(lbl);
    }
}

}