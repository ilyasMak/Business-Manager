using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_employés
{
    public partial class ES_EMP_DmCong : Form
    {
        string NomE;
        string Mot_PassE;
        string cnxString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\pc\Desktop\Gestion employés\Gestion employés\Entreprise.mdf"";Integrated Security=True";
        SqlConnection conn;
        public ES_EMP_DmCong(string nom , string password)
        {
            InitializeComponent();
            this.NomE = nom; 
            this.Mot_PassE = password;
           getCong();


        }
        public int  getIdEmp()
        {
            conn = new SqlConnection(cnxString);
            conn.Open();
            string sql = "SELECT IdE FROM Employe WHERE NomE = @n AND Mot_PassE = @p";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@n", this.NomE);
            cmd.Parameters.AddWithValue("@p", this.Mot_PassE);
            SqlDataReader r = cmd.ExecuteReader();
            r.Read();
            int id = int.Parse(r[0].ToString());
            r.Close();
            conn.Close();
            return id; 
        }

        public void getCong()
        {
            int id = getIdEmp();
            //---------------------------------------
            conn.Open();
            string sql2 = "SELECT * FROM Conge WHERE IdE =@id";
            SqlCommand cmd2 = new SqlCommand( sql2, conn);
            cmd2.Parameters.AddWithValue("@id", id);
            SqlDataReader r2 = cmd2.ExecuteReader();
            DGV.Rows.Clear();
            while (r2.Read())
            {
               
                int rowIndex = DGV.Rows.Add(new Object[] { r2[2].ToString(), r2[3].ToString(), r2[4].ToString(), r2[5].ToString() });
             //   MessageBox.Show(r2[5].ToString().Trim().Equals("Accepter").ToString());
                if (r2[5].ToString().Trim().Equals("Accepter"))
                {
                 
                    DGV.Rows[rowIndex].DefaultCellStyle.BackColor = Color.PaleGreen;
                }
                else if (r2[5].ToString().Trim().Equals("Refuser")) 
                {

                    DGV.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                }
               else
                {
                    DGV.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Tan;
                }
            }
            r2.Close();
            conn.Close();


        }

        private void ESP_admin_Click(object sender, EventArgs e)
        {
            Authentif_Admin f = new Authentif_Admin();
           
            f.Show();
            this.Close();
        }

        private void EspEmp_infos_Click(object sender, EventArgs e)
        {
            ES_EMP_Infos f = new ES_EMP_Infos(this.NomE,this.Mot_PassE);
      
            f.Show();
            this.Close();
        }

        private void DemC_Click(object sender, EventArgs e)
        {
            if(DBC.Value.ToString().Equals("") || NBJ.Text.ToString().Equals("") || Raisons.Text.ToString().Equals(""))
            {
                MessageBox.Show("Veuillez remplire tout les champs ");
            }else if (DBC.Value < DateTime.Now)
            {
                MessageBox.Show("Cette date est déja passer");
            }
            else{
                DemanderConge(DBC.Value, int.Parse(NBJ.Text.ToString()), Raisons.Text.ToString());
            }
            
        }

        public void DemanderConge(DateTime dbC,int nmbrJ,string raisons)
        {
            conn = new SqlConnection(cnxString);
            conn.Open();
            string sql = "INSERT INTO Conge (IdE,Date_DbConge,Nmbr_Jours,Raison) VALUES (@id,@d,@n,@r)";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", getIdEmp());
            cmd.Parameters.AddWithValue("@d", dbC);
            cmd.Parameters.AddWithValue("@n", nmbrJ);
            cmd.Parameters.AddWithValue("@r", raisons);

            cmd.ExecuteNonQuery();
            conn.Close();
            getCong();
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
                DBC.Value = DateTime.Parse(DGV.CurrentRow.Cells[0].Value.ToString());
                NBJ.Text = "  "+DGV.CurrentRow.Cells[1].Value.ToString();
                Raisons.Text= DGV.CurrentRow.Cells[2].Value.ToString().TrimEnd();
            


            
        }

        private void EspEmp_cong_Click(object sender, EventArgs e)
        {

        }
    }
}
