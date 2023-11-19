using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_employés
{
    public partial class Authentif_Admin : Form
    {
        string cnxString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\pc\Desktop\Gestion employés\Gestion employés\Entreprise.mdf"";Integrated Security=True";
        SqlConnection conn;
        public Authentif_Admin()
        {
            InitializeComponent();
        }

        
        private void Authentif_Admin_KeyDown(object sender, KeyEventArgs e)
        {
            // Si la touche "Entrée" est pressée, déclenchez le clic sur le bouton
            if (e.KeyCode == Keys.Enter)
            {
                Conn_Adm.PerformClick(); // Déclenche le clic sur le bouton
                e.Handled = true; // Indique que la touche a été traitée pour éviter le traitement par défaut
            }
        }

        private void Conn_Adm_Click(object sender, EventArgs e)
        {
            if (UserName.Text.Equals("") || Password.Text.Equals(""))
            {
                MessageBox.Show("Veuillez remplire tout les champs");
            }
            else
            {
                conn = new SqlConnection(cnxString);
                conn.Open();
                string sql = "SELECT * FROM Admin WHERE NomA = @n AND Mot_PasseA=@pass";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@n", UserName.Text.ToString());
                cmd.Parameters.AddWithValue("@pass", Password.Text.ToString());
                SqlDataReader r = cmd.ExecuteReader();
                if (r.HasRows)
                {
                    ES_ADM_TableBor f = new ES_ADM_TableBor();

                    //---------------------

                    //-----------------------

                    f.Show();
                    r.Close();
                    conn.Close();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Nom d'utilsateur ou mot de passe incorrect ! ");
                }



            }
        }

        private void ESP_employe_Click(object sender, EventArgs e)
        {
           
            Authentif_Emp f = new Authentif_Emp();

            f.Show();
           this.Close();


        }

        private void ESP_admin_Click(object sender, EventArgs e)
        {

        }
    }
}
