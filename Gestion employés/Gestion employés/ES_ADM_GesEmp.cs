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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;

namespace Gestion_employés
{
    public partial class ES_ADM_GesEmp : Form
    {
        string cnxString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\pc\Desktop\Gestion employés\Gestion employés\Entreprise.mdf"";Integrated Security=True";
        SqlConnection conn;
        public ES_ADM_GesEmp()
        {
            InitializeComponent();
            GetEmploye();
        }
        public void AjouterEmpl(string NomE,string PrenomE,string Password,DateTime dateNaissance,string Sexe,string Statut,string poste,int salaire,string mail , int tel )

        {
            conn = new SqlConnection(cnxString);
            conn.Open();
            string sql = "INSERT INTO Employe (NomE,PrenomE,Mot_PassE,Date_Naissance,Sexe,Date_DbTravail,Statut,Poste,Salaire,Email,Tel) VALUES (@n,@p,@Pass,@dn,@s,@dt,@st,@po,@sa,@e,@t)";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@n", NomE);
            cmd.Parameters.AddWithValue("@p", PrenomE);
            cmd.Parameters.AddWithValue("@Pass", Password);
            cmd.Parameters.AddWithValue("@dn", dateNaissance);
            cmd.Parameters.AddWithValue("@s", Sexe);
            cmd.Parameters.AddWithValue("@dt", DateTime.Now);
            cmd.Parameters.AddWithValue("@st", Statut);
            cmd.Parameters.AddWithValue("@po", poste);
            cmd.Parameters.AddWithValue("@sa", salaire);
            cmd.Parameters.AddWithValue("@e",mail);
            cmd.Parameters.AddWithValue("@t", tel);
            cmd.ExecuteNonQuery();
           
            conn.Close();
            GetEmploye();
        }
        public void SupprimerEmpl(string nom , string Prenom , string poste)
        {
            conn = new SqlConnection(cnxString);
            conn.Open();
            string sql0 = "DELETE FROM Conge WHERE IdE=(SELECT IdE FROM Employe WHERE NomE = @n AND PrenomE = @p AND Poste = @po )";
            SqlCommand cmd0 = new SqlCommand(sql0, conn);
            cmd0.Parameters.AddWithValue("@n", nom);
            cmd0.Parameters.AddWithValue("@p", Prenom);
            cmd0.Parameters.AddWithValue("@po", poste);
            cmd0.ExecuteNonQuery();
            conn.Close();
            //------------------------------------
            conn.Open();
            string sql = "DELETE FROM Employe WHERE NomE = @n AND PrenomE = @p AND Poste = @po;";


            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@n", nom);
            cmd.Parameters.AddWithValue("@p", Prenom);
            cmd.Parameters.AddWithValue("@po", poste);
            cmd.ExecuteNonQuery();
            conn.Close();
            GetEmploye();

        }
        public void ModifierEmpl(int id , string NomE, string PrenomE, string Password, DateTime dateNaissance, string Sexe, string Statut, string poste, int salaire, string mail, int tel)
        {
            
           
                conn.Open();
                string sql2 = "UPDATE Employe SET NomE=@nomE,PrenomE=@prenomE,Mot_PassE=@password,Date_Naissance=@dn,Sexe=@s,Statut=@st,Poste=@pos,Salaire=@sal,Email=@em,Tel=@t WHERE IdE=@id";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.AddWithValue("@nomE", NomE);
                cmd2.Parameters.AddWithValue("@prenomE", PrenomE);
                cmd2.Parameters.AddWithValue("@password", Password);
                cmd2.Parameters.AddWithValue("@dn",dateNaissance);
                cmd2.Parameters.AddWithValue("@s", Sexe);
                cmd2.Parameters.AddWithValue("@st", Statut);
                cmd2.Parameters.AddWithValue("@pos", poste);
                cmd2.Parameters.AddWithValue("@sal", salaire);
                cmd2.Parameters.AddWithValue("@em", mail);
                cmd2.Parameters.AddWithValue("@t",tel);
                cmd2.Parameters.AddWithValue("@id", id);
                cmd2.ExecuteNonQuery();
                conn.Close();
                GetEmploye();

            


        }
        public void GetEmploye()
        {
            conn = new SqlConnection(cnxString);
            conn.Open();
           
            string sql = "SELECT * FROM Employe";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader r = cmd.ExecuteReader();
            DGV.Rows.Clear();
            while (r.Read())
            {
                DGV.Rows.Add(new Object[] { r[1].ToString(), r[2].ToString(), r[4].ToString(), r[5].ToString(), r[7].ToString(), r[6].ToString(), r[8].ToString(), r[9].ToString(), r[10].ToString(), r[11].ToString(), r[0].ToString()  });
            }
            r.Close();
            conn.Close();
        }

        private void E_Admin_TableBord_Click(object sender, EventArgs e)
        {
            ES_ADM_TableBor f = new ES_ADM_TableBor();
          
            f.Show();
            this.Close();
        }

        private void E_Admin_GestionCong_Click(object sender, EventArgs e)
        {
            ES_ADM_GesCong f = new ES_ADM_GesCong();
         
            f.Show();
            this.Close();
        }

        private void ESP_employe_Click(object sender, EventArgs e)
        {
            Authentif_Emp f = new Authentif_Emp();
           
            f.Show();
            this.Close();
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
                NomE.Text = DGV.CurrentRow.Cells[0].Value.ToString();
                PrenomE.Text = DGV.CurrentRow.Cells[1].Value.ToString();
               DateNaissanceE.Value= DateTime.Parse( DGV.CurrentRow.Cells[2].Value.ToString());
            DateDbTravail.Text =DGV.CurrentRow.Cells[5].Value.ToString();
                Sexe.Text = DGV.CurrentRow.Cells[3].Value.ToString();
             Sexe.Text = DGV.CurrentRow.Cells[3].Value.ToString();
            Statut.Text = DGV.CurrentRow.Cells[4].Value.ToString();
            post.Text = DGV.CurrentRow.Cells[6].Value.ToString();
                Salaire.Text = DGV.CurrentRow.Cells[7].Value.ToString();
                emai.Text = DGV.CurrentRow.Cells[8].Value.ToString();
               tel.Text = DGV.CurrentRow.Cells[9].Value.ToString();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(NomE.Text.Equals("") ||PrenomE.Text.Equals("") || DateNaissanceE.Equals("") || Sexe.Text.Equals("") || Statut.Text.Equals("")|| post.Text.Equals("") || Salaire.Text.Equals("")||emai.Text.Equals("")||tel.Text.Equals(""))
            {
                MessageBox.Show("Veuillez remplir tout les champs !");
            }
            else {
                AjouterEmpl(NomE.Text.ToString(), PrenomE.Text.ToString(), "1", DateTime.Parse(DateNaissanceE.Value.ToString()), Sexe.Text.ToString(), Statut.Text.ToString(), post.Text.ToString(), int.Parse(Salaire.Text.ToString()),emai.Text.ToString(), int.Parse(tel.Text.ToString())); ;
            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (NomE.Text.Equals("") || PrenomE.Text.Equals("") || post.Text.Equals("")) {
                MessageBox.Show("Veuillez remplir tout les champs !");
            }
            else
            {
                SupprimerEmpl(NomE.Text.ToString(), PrenomE.Text.ToString(), post.Text.ToString());
                GetEmploye();
            }
        }

        private void Modifier_Click(object sender, EventArgs e)
        {
            if (NomE.Text.Equals("") || PrenomE.Text.Equals("") || DateNaissanceE.Equals("") || Sexe.Text.Equals("") || Statut.Text.Equals("") || post.Text.Equals("") || Salaire.Text.Equals("") || emai.Text.Equals("") || tel.Text.Equals(""))
            {
                MessageBox.Show("Veuillez remplir tout les champs !");
            }else
            {
                if (DGV.CurrentRow.Cells[10].Value.ToString().Equals(""))
                {
                    MessageBox.Show("Veuillez Selectionner un employé pour le modifier !");
                }
                else { 
                int id = int.Parse(DGV.CurrentRow.Cells[10].Value.ToString());
                ModifierEmpl(id, NomE.Text.ToString(), PrenomE.Text.ToString(), "1", DateTime.Parse(DateNaissanceE.Value.ToString()), Sexe.Text.ToString(), Statut.Text.ToString(), post.Text.ToString(), int.Parse(Salaire.Text.ToString()), emai.Text.ToString(), int.Parse(tel.Text.ToString()));
                }

            }
        }
    }
}
