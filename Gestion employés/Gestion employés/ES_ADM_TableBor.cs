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
using System.Windows.Forms.DataVisualization.Charting;

namespace Gestion_employés
{
    public partial class ES_ADM_TableBor : Form
    {
        string cnxString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\pc\Desktop\Gestion employés\Gestion employés\Entreprise.mdf"";Integrated Security=True";
     
        public ES_ADM_TableBor()
        {
            InitializeComponent();
           GetStatis();
        }

        private void ESP_admin_Click(object sender, EventArgs e)
        {

        }
        public void GetStatis()
        {
            int totalEmp = 0;
            // Première connexion pour récupérer le nombre total d'employés
            using (SqlConnection conn = new SqlConnection(cnxString))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM Employe ";

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader r = cmd.ExecuteReader();
                r.Read();
                TotEmp.Text = r[0].ToString();
                totalEmp = int.Parse(r[0].ToString());
                r.Close();
            } // La première connexion est automatiquement fermée ici.

            //-----------------------

            int congésEnCours = 0;

            // Deuxième connexion pour récupérer le nombre de congés en cours
            using (SqlConnection conn2 = new SqlConnection(cnxString))
            {
                conn2.Open();

                string sql2 = "SELECT Date_DbConge, Nmbr_Jours FROM Conge WHERE Decision=@d";

                using (SqlCommand cmd2 = new SqlCommand(sql2, conn2))
                {
                    cmd2.Parameters.AddWithValue("@d", "Accepter  ");
                    using (SqlDataReader reader = cmd2.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime dateDebut = reader.GetDateTime(0);
                            int nombreJours = reader.GetInt32(1);

                            DateTime dateFin = dateDebut.AddDays(nombreJours);

                            // Comparer avec la date actuelle pour déterminer si le congé est en cours
                            if (dateFin >= DateTime.Now)
                            {
                                congésEnCours++;
                            }
                        }
                    }
                }
            } // La deuxième connexion est automatiquement fermée ici.

            CC.Text = congésEnCours.ToString();
            //--------------------------------------------------------------------------
            int nouveauxEmployes = 0;

            // Deuxième connexion pour récupérer le nombre de nouveaux employés
            using (SqlConnection conn2 = new SqlConnection(cnxString))
            {
                conn2.Open();

                // Utilisation de la fonction DATEDIFF pour comparer les dates
                string sqlNouveaux = "SELECT COUNT(*) FROM Employe WHERE DATEDIFF(DAY, Date_DbTravail, GETDATE()) <= 30";

                SqlCommand cmdNouveaux = new SqlCommand(sqlNouveaux, conn2);
                nouveauxEmployes = (int)cmdNouveaux.ExecuteScalar();
            } // La deuxième connexion est automatiquement fermée ici.

            NE.Text = nouveauxEmployes.ToString();
            //---------------------------------------------------------------------
         double pourcentageNouveaux = (double)nouveauxEmployes / totalEmp * 100;

          
            C2.Series["NE"].Points.Clear();
           C2.Series["NE"].Points.AddXY("Nouvelles embauches", pourcentageNouveaux);
            C2.Series["NE"].Points.AddXY("Ancienes employés", 100 - pourcentageNouveaux);
          C2.Series["NE"].IsValueShownAsLabel = true;
           C2.Series["NE"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
          C2.Series["NE"]["PieLabelStyle"] = "Outside";

            //------------------------------------------------
            double pourcentageConge = (double)congésEnCours / totalEmp * 100;
            C1.Series["CC"].Points.Clear();
            C1.Series["CC"].Points.AddXY("Congé en cours", pourcentageConge);
            C1.Series["CC"].Points.AddXY("Employés en travail", 100 - pourcentageConge);
            C1.Series["CC"].IsValueShownAsLabel = true;
            C1.Series["CC"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            C1.Series["CC"]["PieLabelStyle"] = "Outside";
        }

        private void E_Admin_GestionEmp_Click(object sender, EventArgs e)
        {
            ES_ADM_GesEmp ES_ADM_GesEmp = new ES_ADM_GesEmp();
    
            ES_ADM_GesEmp.Show();
            this.Close();
            // Utilisez ShowDialog() pour bloquer l'accès à la fenêtre actuelle


        }

        private void E_Admin_TableBord_Click(object sender, EventArgs e)
        {
           
          
        }

        private void E_Admin_GestionCong_Click(object sender, EventArgs e)
        {
            ES_ADM_GesCong f = new ES_ADM_GesCong();
           
            f.Show();
            this.Close();
        }

        private void E_Admin_Rapp_Click(object sender, EventArgs e)
        {
          
        }

        private void ESP_employe_Click(object sender, EventArgs e)
        {
            Authentif_Emp f = new Authentif_Emp();
       
            f.Show();
            this.Close();
        }

        private void C2_Click(object sender, EventArgs e)
        {

        }
    }
}
