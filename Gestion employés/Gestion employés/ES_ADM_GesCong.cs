using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_employés
{
    public partial class ES_ADM_GesCong : Form
    {
        string cnxString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\pc\Desktop\Gestion employés\Gestion employés\Entreprise.mdf"";Integrated Security=True";
        SqlConnection conn;
        public ES_ADM_GesCong()
        {
            InitializeComponent();
            getCongPrise();
            getCongDem();
        }

        public void getCongPrise()
        {
            conn = new SqlConnection(cnxString);
            conn.Open();

            string sql = "SELECT c.*, e.NomE, e.PrenomE, e.Statut, e.Poste " +
                         "FROM Conge c " +
                         "INNER JOIN Employe e ON c.IdE = e.IdE " +
                         "WHERE c.Decision = @d";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@d", "Accepter  ");
            SqlDataReader r = cmd.ExecuteReader();

            DGV1.Rows.Clear();

            while (r.Read())
            {
                // Accédez aux colonnes de la requête principale (Conge) et de la sous-requête (Employe)
                DGV1.Rows.Add(new object[] {
            r["NomE"], r["PrenomE"], r["Statut"], r["Poste"],
            r["Date_DbConge"], r["Nmbr_Jours"], r["Raison"]
        });
            }

            r.Close();
            conn.Close();
        }

        public void getCongDem()
        {
            conn = new SqlConnection(cnxString);
            conn.Open();

            string sql = "SELECT c.*, e.NomE, e.PrenomE, e.Statut, e.Poste " +
                         "FROM Conge c " +
                         "INNER JOIN Employe e ON c.IdE = e.IdE " +
                         "WHERE c.Decision IS NULL";

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader r = cmd.ExecuteReader();

            DGV2.Rows.Clear();

            while (r.Read())
            {
                // Accédez aux colonnes de la requête principale (Conge) et de la sous-requête (Employe)
                DateTime dateConge = (DateTime)r["Date_DbConge"];
                
                string dateCongeFormatted = dateConge.ToString("yyyy-MM-dd");
                DGV2.Rows.Add(new object[] {
            r["NomE"], r["PrenomE"], r["Statut"], r["Poste"],
            dateCongeFormatted, r["Nmbr_Jours"], r["Raison"],r["IdC"]
        });
            }

            r.Close();
            conn.Close();
        }



        private void E_Admin_GestionCong_Click(object sender, EventArgs e)
        {

        }

        private void ESP_employe_Click(object sender, EventArgs e)
        {
            Authentif_Emp f = new Authentif_Emp();
           
            f.Show();
            this.Close();
        }

        private void E_Admin_TableBord_Click(object sender, EventArgs e)
        {
            ES_ADM_TableBor f = new ES_ADM_TableBor();
         
            f.Show();
            this.Close();
        }

        private void E_Admin_GestionEmp_Click(object sender, EventArgs e)
        {
            ES_ADM_GesEmp  f = new ES_ADM_GesEmp();
            f .Show();
            this.Close();
        }

        private void DGV1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NomE.Text = DGV1.CurrentRow.Cells[0].Value.ToString().TrimEnd();
           PrenomE.Text = DGV1.CurrentRow.Cells[1].Value.ToString().TrimEnd();
            statut.Text = DGV1.CurrentRow.Cells[2].Value.ToString().TrimEnd();
            poste.Text = DGV1.CurrentRow.Cells[3].Value.ToString().TrimEnd();
            DD.Text = DGV1.CurrentRow.Cells[4].Value.ToString().TrimEnd();
            NJ.Text = DGV1.CurrentRow.Cells[5].Value.ToString().TrimEnd();
            Raison.Text = DGV1.CurrentRow.Cells[6].Value.ToString().TrimEnd();
          




        }
        int idC;
        private void DGV2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NomE.Text = DGV2.CurrentRow.Cells[0].Value.ToString().TrimEnd();
            PrenomE.Text = DGV2.CurrentRow.Cells[1].Value.ToString().TrimEnd();
            statut.Text = DGV2.CurrentRow.Cells[2].Value.ToString().TrimEnd();
            poste.Text = DGV2.CurrentRow.Cells[3].Value.ToString().TrimEnd();
            DD.Text = DGV2.CurrentRow.Cells[4].Value.ToString().TrimEnd();
            NJ.Text = DGV2.CurrentRow.Cells[5].Value.ToString().TrimEnd();
            Raison.Text = DGV2.CurrentRow.Cells[6].Value.ToString().TrimEnd();
           this.idC  = int.Parse(DGV2.CurrentRow.Cells[7].Value.ToString().TrimEnd());
        }

       
        private void AccepterCong_Click(object sender, EventArgs e)
        {
            if (NomE.Text.ToString().Equals(""))
            {
                MessageBox.Show("Veuillez selectionner une demande pour l'accepter !");
            }else
            {
                SqlConnection conn = new SqlConnection(cnxString);
                conn.Open();
                string sql = "UPDATE Conge SET Decision=@a WHERE IdC=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@a", "Accepter  ");
                cmd.Parameters.AddWithValue("@id", this.idC);
                cmd.ExecuteNonQuery();
                conn.Close();
                getCongDem();
                getCongPrise();
            }
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (NomE.Text.ToString().Equals(""))
            {
                MessageBox.Show("Veuillez selectionner une demande pour l'accepter !");
            }
            else
            {
                SqlConnection conn = new SqlConnection(cnxString);
                conn.Open();
                string sql = "UPDATE Conge SET Decision=@a WHERE IdC=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@a", "Refuser   ");
                cmd.Parameters.AddWithValue("@id", this.idC);
                cmd.ExecuteNonQuery();
                conn.Close();
                getCongDem();
                getCongPrise();
            }
        }
    }
}
