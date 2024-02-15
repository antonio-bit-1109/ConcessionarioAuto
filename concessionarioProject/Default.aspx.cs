using Microsoft.Ajax.Utilities;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace concessionarioProject
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            contenitoreCheckBox.Style["display"] = "none";

            if (prezzo.InnerHtml.IsNullOrWhiteSpace())
            {

                prezzo.Style["display"] = "none";
            }

            if (!IsPostBack)
            {
                contenitoreCheckBox.Style["display"] = "none";

                string StringaDiConnessione = ConfigurationManager.ConnectionStrings["STRING_CONNESSIONEDB"].ConnectionString;
                SqlConnection conn = new SqlConnection(StringaDiConnessione);

                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    cmd.CommandText = "SELECT idAuto , nomeMacchina from Concessionario";
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ListItem item = new ListItem();

                        int idAuto = reader.GetInt32(0);
                        string nomeMacchina = reader.GetString(1);

                        item.Value = idAuto.ToString();
                        item.Text = nomeMacchina;

                        ddlExample.Items.Add(item);
                        //string ID = ddlExample.SelectedValue;

                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Errore");
                    Response.Write(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }


        }

        protected void MostraDettagli_click(object sender, EventArgs e)
        {
            prezzo.Style["display"] = "flex";
            contenitoreCheckBox.Style["display"] = "block";

            string StringaDiConnessione = ConfigurationManager.ConnectionStrings["STRING_CONNESSIONEDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(StringaDiConnessione);

            string idauto = ddlExample.SelectedValue;

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = $"SELECT immagine , prezzobase from Concessionario where idauto = '{idauto}' ";
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    string immagine = reader.GetString(0);
                    decimal prezzoBaseAuto = reader.GetDecimal(1);
                    Image1.ImageUrl = immagine;
                    prezzo.InnerHtml = prezzoBaseAuto.ToString();
                }

            }
            catch (Exception ex)
            {
                Response.Write("Errore");
                Response.Write(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        protected void CheckBox_checked(object sender, EventArgs e)
        {
            contenitoreCheckBox.Style["display"] = "block";
            CheckBox clickedCheckbox = sender as CheckBox;

            string idauto = ddlExample.SelectedValue;
            double soldidaaggiungere;

            string StringaDiConnessione = ConfigurationManager.ConnectionStrings["STRING_CONNESSIONEDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(StringaDiConnessione);

            if (clickedCheckbox != null)
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                try
                {
                    if (CheckBox1.Checked)
                    {
                        //chiama la query e prendi valore 
                        cmd.CommandText = $" SELECT CerchiInLega from concessionario where idauto= '{idauto}'";
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {

                            double prezzoCerchi = reader.GetDouble(0);
                            soldidaaggiungere = prezzoCerchi;


                        }
                    }
                    if (CheckBox2.Checked)
                    {
                        //chiama la query e prendi valore 
                    }
                    if (CheckBox3.Checked)
                    {
                        //chiama la query e prendi valore 
                    }
                    if (CheckBox4.Checked)
                    {
                        //chiama la query e prendi valore 
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Errore");
                    Response.Write(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                // Ora hai accesso al checkbox che è stato cliccato



                // Puoi fare qualsiasi operazione necessaria in base al checkbox cliccato

            }


        }
    }
}