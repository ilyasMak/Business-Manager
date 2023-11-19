using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_employés
{
    public partial class ES_EMP_Infos : Form
    {
        string cnxString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\pc\Desktop\Gestion employés\Gestion employés\Entreprise.mdf"";Integrated Security=True";
        SqlConnection conn;
        string NomE;
        string Mot_PassE;
        public ES_EMP_Infos(string nom ,string password)
        {
            InitializeComponent();
            this.NomE = nom; 
            this.Mot_PassE = password;
            GetEmpCompte(nom, password);
        }

        public void GetEmpCompte(string nom , string password )
        {
            conn = new SqlConnection(cnxString);
            conn.Open();
            string sql = "SELECT * FROM Employe WHERE NomE=@n AND Mot_PassE = @mp";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@n", nom);
            cmd.Parameters.AddWithValue("@mp", password);
            SqlDataReader r = cmd.ExecuteReader();
            r.Read();
            int id = int.Parse(r[0].ToString());
            NomPrenom.Text = r[1].ToString().TrimEnd() + " " + r[2].ToString().TrimEnd();
            statut.Text = r[7].ToString().TrimEnd();
            Poste.Text = r[8].ToString().TrimEnd();
            DDT.Text = ((DateTime)r[6]).ToString("dd/MM/yyyy");
            DateTime DateDebutTravail = ((DateTime)r[6]);

            // Calcul de l'âge en jours
            TimeSpan JoursTravail = DateTime.Now - DateDebutTravail;
            int totalDays =(int) JoursTravail.TotalDays;
            JT.Text = totalDays.ToString();

            // Afficher l'âge en jours
            Console.WriteLine("Âge en jours : " + totalDays);

            Salaire.Text = r[9].ToString().TrimEnd()+" MAD";
            e_mail.Text = r[10].ToString().TrimEnd();
            tel.Text = r[11].ToString().TrimEnd();
            r.Close();
            conn.Close();
            //-----------------------------------------
           conn.Open();
            string sql2 = "SELECT COUNT(*) FROM Conge WHERE IdE = @idEmploye AND Decision=@d";
            SqlCommand cmd2 = new SqlCommand(sql2, conn);
            cmd2.Parameters.AddWithValue("@idEmploye", id);
            cmd2.Parameters.AddWithValue("@d", "Accepter  ");
            SqlDataReader r2 = cmd2.ExecuteReader();
            r2.Read();
            NbrC.Text = r2[0].ToString();
            r2.Close();
            conn.Close() ;
          

        }

        private void ESP_admin_Click(object sender, EventArgs e)
        {
            Authentif_Admin f = new Authentif_Admin();
           
            f.Show();
            this.Close();
        }

        private void EspEmp_cong_Click(object sender, EventArgs e)
        {
            ES_EMP_DmCong f= new ES_EMP_DmCong(this.NomE,this.Mot_PassE);
        
            f.Show();
            this.Close();
        }

        private void ESP_employe_Click(object sender, EventArgs e)
        {

        }

        private void ESP_RH_Click(object sender, EventArgs e)
        {

        }
    }
}
