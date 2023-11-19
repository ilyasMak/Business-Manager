using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_employés
{
    public partial class GestionEntreprise : Form
    {
        public GestionEntreprise()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Authentif_Emp f = new Authentif_Emp();

            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Authentif_Admin f = new Authentif_Admin();

            f.Show();
        }
    }
}
