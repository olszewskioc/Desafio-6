using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmacySystem.view
{
    public partial class FarmaceuticForm : Form
{
    public FarmaceuticForm()
    {
        ConfigurarTela();
    }

    private void ConfigurarTela()
    {
        this.Text = "Farmacêutico";
        this.Size = new Size(400, 300);

        Label lbl = new Label
        {
            Text = "Bem-vindo, Farmacêutico!",
            AutoSize = true,
            Location = new Point(50, 50),
            Font = new Font("Arial", 14, FontStyle.Bold)
        };

        this.Controls.Add(lbl);
    }
}

}