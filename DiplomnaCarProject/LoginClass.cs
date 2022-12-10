using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DiplomnaCarProject
{
    public interface LoginInterface
    {
        bool Log();

    }
    public class LoginClass
    {
       
       
            public bool Log(string username, string password)
            {


                using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
                {
                    bool flag = false;

                    try
                    {
                        string sql = " SELECT username , password from users WHERE username=@username and password=@password ";

                        MySqlCommand comand = new MySqlCommand(sql, mysqlCon); ;
                        comand.Parameters.Clear();
                        comand.Parameters.AddWithValue("@username", username);
                        comand.Parameters.AddWithValue("@password", password);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(comand);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {

                            flag = true;




                        }
                        else
                        {

                        }




                    }
                    catch (Exception e)
                    {
                        //MessageBox.Show(e.ToString());
                    }



                    return flag;
                }

            }
            public int getUserID(string username, string password)
            {
                using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
                {
                    int iduser = 0;

                    try
                    {
                        string sql = " SELECT idUsers from users WHERE username=@username and password=@password ";

                        MySqlCommand comand = new MySqlCommand(sql, mysqlCon); ;
                        comand.Parameters.Clear();
                        comand.Parameters.AddWithValue("@username", username);
                        comand.Parameters.AddWithValue("@password", password);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(comand);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);

                        iduser = Convert.ToInt32(ds.Tables[0].Rows[0]["idUsers"]);



                        //MessageBox.Show(iduser.ToString());






                    }
                    catch (Exception e)
                    {
                        //MessageBox.Show(e.ToString());
                    }


                    return iduser;
                }
            }
        public string getUsername(int id)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                string name = "";

                try
                {
                    mysqlCon.Open();
                    string sql = " SELECT name from users WHERE idUsers=@username";

                    MySqlCommand comand = new MySqlCommand(sql, mysqlCon); ;
                    comand.Parameters.Clear();
                    comand.Parameters.AddWithValue("@username", id);
                    
                    

                    MySqlDataReader dr = comand.ExecuteReader();
                    if (dr.Read())
                    {
                        name = dr["name"].ToString();
                    }
                    mysqlCon.Close();


                    //MessageBox.Show(iduser.ToString());






                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }


                return name;
            }
        }
        public string getRole(string username, string password)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                string role = "";

                try
                {
                    mysqlCon.Open();

                    string sql = " SELECT role from users WHERE username=@username and password=@password ";

                    MySqlCommand comand = new MySqlCommand(sql, mysqlCon); ;
                    comand.Parameters.Clear();
                    comand.Parameters.AddWithValue("@username", username);
                    comand.Parameters.AddWithValue("@password", password);


                    MySqlDataReader dr = comand.ExecuteReader();
                    if (dr.Read())
                    {
                        role = dr["role"].ToString();
                    }
                    mysqlCon.Close();


                    //MessageBox.Show(iduser.ToString());






                }
                catch (Exception e)
                {
                    //MessageBox.Show(e.ToString());
                }


                return role;
            }
        }



    }
}
