using DiplomnaCarProject.DialogWindows;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomnaCarProject
{
    public class SQL
    {
        Logger log = new Logger();
        int modelSQL = 0;











        public void addBrand(string brand)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                try
                {

                    mysqlCon.Open();
                    MySqlCommand mySqlCmd = new MySqlCommand("addBrand", mysqlCon);
                    mySqlCmd.CommandType = CommandType.StoredProcedure;
                    mySqlCmd.Parameters.AddWithValue("_brand", brand);


                    mySqlCmd.ExecuteNonQuery();

                    mysqlCon.Close();
                }
                catch (MySqlException m)
                {

                    log.Log(m.ToString());
                }
                catch (InvalidOperationException i)
                {
                    log.Log(i.ToString());
                }


            }
        }


        public void editBrand(int idedit, string brand)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                try
                {
                    mysqlCon.Open();
                    MySqlCommand mySqlCmd = new MySqlCommand("editBrand", mysqlCon);
                    mySqlCmd.CommandType = CommandType.StoredProcedure;

                    mySqlCmd.Parameters.AddWithValue("_idEdit", idedit);
                    mySqlCmd.Parameters.AddWithValue("_name", brand);


                    mySqlCmd.ExecuteNonQuery();

                    mysqlCon.Close();
                }
                catch (MySqlException m)
                {

                    log.Log(m.ToString());
                }
                catch (InvalidOperationException i)
                {
                    log.Log(i.ToString());
                }


            }
        }




        public void deleteBrand(int idDelete)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                try
                {

                    mysqlCon.Open();
                    MySqlCommand mySqlCmd = new MySqlCommand("deleteBrand", mysqlCon);
                    mySqlCmd.CommandType = CommandType.StoredProcedure;
                    mySqlCmd.Parameters.AddWithValue("_idDelete", idDelete);


                    mySqlCmd.ExecuteNonQuery();

                    mysqlCon.Close();
                }
                catch (MySqlException m)
                {

                    log.Log(m.ToString());
                    throw m;
                }
                catch (InvalidOperationException i)
                {
                    log.Log(i.ToString());
                }


            }
        }





        public void addModel(int brand , string model)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                try
                {

                    mysqlCon.Open();
                    MySqlCommand mySqlCmd = new MySqlCommand("addModel", mysqlCon);
                    mySqlCmd.CommandType = CommandType.StoredProcedure;
                    mySqlCmd.Parameters.AddWithValue("_brand", brand);
                    mySqlCmd.Parameters.AddWithValue("_model", model);


                    mySqlCmd.ExecuteNonQuery();

                    mysqlCon.Close();
                }
                catch (MySqlException m)
                {

                    log.Log(m.ToString());
                }
                catch (InvalidOperationException i)
                {
                    log.Log(i.ToString());
                }


            }
        }


        public void editModel(int idedit, int brand, string model)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                try
                {
                    mysqlCon.Open();
                    MySqlCommand mySqlCmd = new MySqlCommand("editModel", mysqlCon);
                    mySqlCmd.CommandType = CommandType.StoredProcedure;

                    mySqlCmd.Parameters.AddWithValue("_idEdit", idedit);
                    mySqlCmd.Parameters.AddWithValue("_brand", brand);
                    mySqlCmd.Parameters.AddWithValue("_model", model);


                    mySqlCmd.ExecuteNonQuery();

                    mysqlCon.Close();
                }
                catch (MySqlException m)
                {

                    log.Log(m.ToString());
                }
                catch (InvalidOperationException i)
                {
                    log.Log(i.ToString());
                }


            }
        }



        public void deleteModel(int idDelete)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                try
                {

                    mysqlCon.Open();
                    MySqlCommand mySqlCmd = new MySqlCommand("deleteModel", mysqlCon);
                    mySqlCmd.CommandType = CommandType.StoredProcedure;
                    mySqlCmd.Parameters.AddWithValue("_idDelete", idDelete);


                    mySqlCmd.ExecuteNonQuery();

                    mysqlCon.Close();
                }
                catch (MySqlException m)
                {
                    throw m;
                    log.Log(m.ToString());
                }
                catch (InvalidOperationException i)
                {
                    log.Log(i.ToString());
                }


            }
        }

        public void addFuel(string fuel)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                try
                {

                    mysqlCon.Open();
                    MySqlCommand mySqlCmd = new MySqlCommand("addFuel", mysqlCon);
                    mySqlCmd.CommandType = CommandType.StoredProcedure;
                    mySqlCmd.Parameters.AddWithValue("_fuel", fuel);


                    mySqlCmd.ExecuteNonQuery();

                    mysqlCon.Close();
                }
                catch (MySqlException m)
                {

                    log.Log(m.ToString());
                }
                catch (InvalidOperationException i)
                {
                    log.Log(i.ToString());
                }


            }
        }

        public void editFuel(int idedit, string fuel)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                try
                {
                    mysqlCon.Open();
                    MySqlCommand mySqlCmd = new MySqlCommand("editFuel", mysqlCon);
                    mySqlCmd.CommandType = CommandType.StoredProcedure;

                    mySqlCmd.Parameters.AddWithValue("_idEdit", idedit);
                    mySqlCmd.Parameters.AddWithValue("_fuel", fuel);


                    mySqlCmd.ExecuteNonQuery();

                    mysqlCon.Close();
                }
                catch (MySqlException m)
                {

                    log.Log(m.ToString());
                }
                catch (InvalidOperationException i)
                {
                    log.Log(i.ToString());
                }


            }
        }
        public void deleteFuel(int idDelete)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                try
                {

                    mysqlCon.Open();
                    MySqlCommand mySqlCmd = new MySqlCommand("deleteFuel", mysqlCon);
                    mySqlCmd.CommandType = CommandType.StoredProcedure;
                    mySqlCmd.Parameters.AddWithValue("_idDelete", idDelete);


                    mySqlCmd.ExecuteNonQuery();

                    mysqlCon.Close();
                }
                catch (MySqlException m)
                {
                    throw m;
                    log.Log(m.ToString());
                }
                catch (InvalidOperationException i)
                {
                    log.Log(i.ToString());
                }


            }
        }



        public void deleteCar(int idDelete)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                try
                {

                    mysqlCon.Open();
                    MySqlCommand mySqlCmd = new MySqlCommand("deleteCar", mysqlCon);
                    mySqlCmd.CommandType = CommandType.StoredProcedure;
                    mySqlCmd.Parameters.AddWithValue("_idDelete", idDelete);


                    mySqlCmd.ExecuteNonQuery();

                    mysqlCon.Close();
                }
                catch (MySqlException m)
                {
                    throw m;
                    log.Log(m.ToString());
                }
                catch (InvalidOperationException i)
                {
                    log.Log(i.ToString());
                }


            }
        }



        public byte[]  LoadImage(int carID )
        {
            byte[] img = null;
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {

                mysqlCon.Open();
                
              
                MySqlCommand cmd = new MySqlCommand("SELECT image FROM images WHERE cars_idcars = @carID", mysqlCon);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@carID", carID);
                
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (!DBNull.Value.Equals(dr["image"]))
                    {
                        img = (byte[])dr["image"];
                        
                    }
                    else
                    {
                        //carProfileForm.pictureBox1.Image = Properties.Resources.image1;
                    }
                }
                mysqlCon.Close();
                return img;
            }
        }


        public void addCar(int brand, int model, int fuel, string regNum ,string VIN , string color , string engineNum)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                try
                {
                    mysqlCon.Open();
                    MySqlCommand mySqlCmd = new MySqlCommand("addCar", mysqlCon);
                    mySqlCmd.CommandType = CommandType.StoredProcedure;

                    mySqlCmd.Parameters.AddWithValue("_brand", brand);
                    mySqlCmd.Parameters.AddWithValue("_model", model);
                    mySqlCmd.Parameters.AddWithValue("_fuel", fuel);
                    mySqlCmd.Parameters.AddWithValue("_regNum", regNum);
                    mySqlCmd.Parameters.AddWithValue("_VIN", VIN);
                    mySqlCmd.Parameters.AddWithValue("_color", color);
                    mySqlCmd.Parameters.AddWithValue("_engineNum", engineNum);


                    mySqlCmd.ExecuteNonQuery();

                    mysqlCon.Close();
                }
                catch (MySqlException m)
                {

                    log.Log(m.ToString());
                }
                catch (InvalidOperationException i)
                {
                    log.Log(i.ToString());
                }


            }
        }

        public void editCar(int brand, int model, int fuel, string regNum, string VIN, string color, string engineNum , int idEdit)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                try
                {
                    mysqlCon.Open();
                    MySqlCommand mySqlCmd = new MySqlCommand("editCar", mysqlCon);
                    mySqlCmd.CommandType = CommandType.StoredProcedure;

                    mySqlCmd.Parameters.AddWithValue("_brand", brand);
                    mySqlCmd.Parameters.AddWithValue("_model", model);
                    mySqlCmd.Parameters.AddWithValue("_fuel", fuel);
                    mySqlCmd.Parameters.AddWithValue("_regNum", regNum);
                    mySqlCmd.Parameters.AddWithValue("_VIN", VIN);
                    mySqlCmd.Parameters.AddWithValue("_color", color);
                    mySqlCmd.Parameters.AddWithValue("_engineNum", engineNum);
                    mySqlCmd.Parameters.AddWithValue("_idEdit", idEdit);


                    mySqlCmd.ExecuteNonQuery();

                    mysqlCon.Close();
                }
                catch (MySqlException m)
                {
                    throw m;
                    log.Log(m.ToString());
                }
                catch (InvalidOperationException i)
                {
                    log.Log(i.ToString());
                }


            }
        }


        public void addPicture(byte[] byteData, string imageExtension)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {

                int nextID = 0;



                mysqlCon.Open();
                
                string selectInsCar = "SELECT idcars FROM cars ORDER BY idcars DESC LIMIT 1";
                MySqlCommand cmm = new MySqlCommand(selectInsCar, mysqlCon);
                MySqlDataReader dr = cmm.ExecuteReader();
                if (dr.Read())
                {
                     nextID = Convert.ToInt32(dr["idcars"]);
                }
               
                
                mysqlCon.Close();
                mysqlCon.Open();
                string imgInsert = "INSERT into images(image, imageExtension, cars_idcars , profilePic) VALUES(@data, @imageExtension, @carID , @profilePic)";
                MySqlCommand com = new MySqlCommand(imgInsert, mysqlCon);
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@carID", nextID);
                com.Parameters.AddWithValue("@data", byteData);
                com.Parameters.AddWithValue("@imageExtension", imageExtension);
                com.Parameters.AddWithValue("@profilePic", 1);
                com.ExecuteNonQuery();
                mysqlCon.Close();
            }
        }

        public void addPictureWithCarID(byte[] byteData, string imageExtension , int carID)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {

               
                mysqlCon.Open();
                string imgInsert = "INSERT into images(image, imageExtension, cars_idcars , profilePic) VALUES(@data, @imageExtension, @carID , @profilePic)";
                MySqlCommand com = new MySqlCommand(imgInsert, mysqlCon);
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@carID", carID);
                com.Parameters.AddWithValue("@data", byteData);
                com.Parameters.AddWithValue("@imageExtension", imageExtension);
                com.Parameters.AddWithValue("@profilePic", 1);
                com.ExecuteNonQuery();
                mysqlCon.Close();
            }
        }



        public void editPicture(byte[] byteData, string imageExtension , int idEdit)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                try
                {

                    int idIMG = 0;

                    mysqlCon.Open();
                    MySqlCommand coms = new MySqlCommand("SELECT image, idImages FROM images WHERE cars_idcars = @carID AND profilePic = 1", mysqlCon);
                    coms.Parameters.Clear();
                    coms.Parameters.AddWithValue("@carID", idEdit);
                    MySqlDataReader drd = coms.ExecuteReader();
                    if (drd.Read())
                    {
                        idIMG = Convert.ToInt32(drd["idImages"]);

                    }
                    drd.Close();

                    if (idIMG == 0)
                    {
                        addPictureWithCarID(byteData, imageExtension, idEdit);
                    }
                    else
                    {





                        mysqlCon.Close();
                        mysqlCon.Open();
                        string imgInsert = "Update images SET image=@data, imageExtension=@imageExtension, cars_idcars=@carID , profilePic=@profilePic Where idImages=@idimg";
                        MySqlCommand com = new MySqlCommand(imgInsert, mysqlCon);
                        com.Parameters.Clear();
                        com.Parameters.AddWithValue("@idimg", idIMG);
                        com.Parameters.AddWithValue("@carID", idEdit);
                        com.Parameters.AddWithValue("@data", byteData);
                        com.Parameters.AddWithValue("@imageExtension", imageExtension);
                        com.Parameters.AddWithValue("@profilePic", 1);
                        com.ExecuteNonQuery();
                        mysqlCon.Close();
                    }


                    
                }
                catch(MySqlException ex)
                {
                    throw ex;
                }
            }
        }

        public void addMeasure(string measure)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                try
                {

                    mysqlCon.Open();
                    MySqlCommand mySqlCmd = new MySqlCommand("addConsumableMeasure", mysqlCon);
                    mySqlCmd.CommandType = CommandType.StoredProcedure;
                    mySqlCmd.Parameters.AddWithValue("_measure", measure);


                    mySqlCmd.ExecuteNonQuery();

                    mysqlCon.Close();
                }
                catch (MySqlException m)
                {

                    log.Log(m.ToString());
                }
                catch (InvalidOperationException i)
                {
                    log.Log(i.ToString());
                }


            }
        }

        public void editMeasure(int idedit, string measure)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                try
                {
                    mysqlCon.Open();
                    MySqlCommand mySqlCmd = new MySqlCommand("editConsumableMeasure", mysqlCon);
                    mySqlCmd.CommandType = CommandType.StoredProcedure;

                    mySqlCmd.Parameters.AddWithValue("_idEdit", idedit);
                    mySqlCmd.Parameters.AddWithValue("_measure", measure);


                    mySqlCmd.ExecuteNonQuery();

                    mysqlCon.Close();
                }
                catch (MySqlException m)
                {

                    log.Log(m.ToString());
                }
                catch (InvalidOperationException i)
                {
                    log.Log(i.ToString());
                }


            }
        }
        public void deleteMeasure(int idDelete)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                try
                {

                    mysqlCon.Open();
                    MySqlCommand mySqlCmd = new MySqlCommand("deleteMeasures", mysqlCon);
                    mySqlCmd.CommandType = CommandType.StoredProcedure;
                    mySqlCmd.Parameters.AddWithValue("_idDelete", idDelete);


                    mySqlCmd.ExecuteNonQuery();

                    mysqlCon.Close();
                }
                catch (MySqlException m)
                {
                    throw m;
                    log.Log(m.ToString());
                }
                catch (InvalidOperationException i)
                {
                    log.Log(i.ToString());
                }


            }
        }

        public void addType(string type)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                try
                {

                    mysqlCon.Open();
                    MySqlCommand mySqlCmd = new MySqlCommand("addConsumableType", mysqlCon);
                    mySqlCmd.CommandType = CommandType.StoredProcedure;
                    mySqlCmd.Parameters.AddWithValue("_type", type);


                    mySqlCmd.ExecuteNonQuery();

                    mysqlCon.Close();
                }
                catch (MySqlException m)
                {

                    log.Log(m.ToString());
                }
                catch (InvalidOperationException i)
                {
                    log.Log(i.ToString());
                }


            }
        }
        public void editType(int idedit, string type)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                try
                {
                    mysqlCon.Open();
                    MySqlCommand mySqlCmd = new MySqlCommand("editConsumableType", mysqlCon);
                    mySqlCmd.CommandType = CommandType.StoredProcedure;

                    mySqlCmd.Parameters.AddWithValue("_idEdit", idedit);
                    mySqlCmd.Parameters.AddWithValue("_type", type);


                    mySqlCmd.ExecuteNonQuery();

                    mysqlCon.Close();
                }
                catch (MySqlException m)
                {

                    log.Log(m.ToString());
                }
                catch (InvalidOperationException i)
                {
                    log.Log(i.ToString());
                }


            }
        }
        public void deleteType(int idDelete)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                try
                {

                    mysqlCon.Open();
                    MySqlCommand mySqlCmd = new MySqlCommand("deleteType", mysqlCon);
                    mySqlCmd.CommandType = CommandType.StoredProcedure;
                    mySqlCmd.Parameters.AddWithValue("_idDelete", idDelete);


                    mySqlCmd.ExecuteNonQuery();

                    mysqlCon.Close();
                }
                catch (MySqlException m)
                {
                    throw m;
                    log.Log(m.ToString());
                }
                catch (InvalidOperationException i)
                {
                    log.Log(i.ToString());
                }


            }
        }

        public void addConsumable(int type, int measure, string consumable, bool notify)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                try
                {
                    mysqlCon.Open();
                    MySqlCommand mySqlCmd = new MySqlCommand("addConsumable", mysqlCon);
                    mySqlCmd.CommandType = CommandType.StoredProcedure;

                    mySqlCmd.Parameters.AddWithValue("_name", consumable);
                    mySqlCmd.Parameters.AddWithValue("_type", type);
                    mySqlCmd.Parameters.AddWithValue("_measure", measure);
                    mySqlCmd.Parameters.AddWithValue("_notify", notify);
                    mySqlCmd.ExecuteNonQuery();

                    mysqlCon.Close();
                }
                catch (MySqlException m)
                {
                    throw m;
                    log.Log(m.ToString());
                }
                catch (InvalidOperationException i)
                {
                    log.Log(i.ToString());
                }


            }
        }
        public void editConsumable(int type, int measure, string consumable, bool notify, int idedit)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                try
                {

                    mysqlCon.Open();
                    MySqlCommand mySqlCmd = new MySqlCommand("editConsumable", mysqlCon);
                    mySqlCmd.CommandType = CommandType.StoredProcedure;

                    mySqlCmd.Parameters.AddWithValue("_idEdit", idedit);
                    mySqlCmd.Parameters.AddWithValue("_name", consumable);
                    mySqlCmd.Parameters.AddWithValue("_type", type);
                    mySqlCmd.Parameters.AddWithValue("_measure", measure);
                    mySqlCmd.Parameters.AddWithValue("_notify", notify);
                    mySqlCmd.ExecuteNonQuery();

                    mysqlCon.Close();
                }
                catch (MySqlException m)
                {
                    throw m;
                    log.Log(m.ToString());
                }
                catch (InvalidOperationException i)
                {
                    log.Log(i.ToString());
                }


            }
        }
        public void deleteConsumable(int idDelete)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                try
                {

                    mysqlCon.Open();
                    MySqlCommand mySqlCmd = new MySqlCommand("deleteConsumable", mysqlCon);
                    mySqlCmd.CommandType = CommandType.StoredProcedure;
                    mySqlCmd.Parameters.AddWithValue("_idDelete", idDelete);


                    mySqlCmd.ExecuteNonQuery();

                    mysqlCon.Close();
                }
                catch (MySqlException m)
                {
                    throw m;
                    log.Log(m.ToString());
                }
                catch (InvalidOperationException i)
                {
                    log.Log(i.ToString());
                }


            }
        }

        public bool ContractorNameCheck(string name)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {

                mysqlCon.Open();
                string contractorName = "SELECT name FROM contractors WHERE name = @name";
                MySqlCommand cmd = new MySqlCommand(contractorName, mysqlCon);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", name);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    mysqlCon.Close();
                    return true;
                }
                else
                {
                    mysqlCon.Close();
                    return false;
                }

            }
        }

        public bool ContractorEIKCheck(string eik)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {

                mysqlCon.Open();
                string bulstat = "SELECT BULSTAT FROM contractors WHERE BULSTAT = @eik";
                MySqlCommand cmd = new MySqlCommand(bulstat, mysqlCon);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@eik", eik);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr["BULSTAT"] == "")
                    {
                        mysqlCon.Close();
                        return false;
                    }
                    mysqlCon.Close();
                    return true;
                }
                else
                {
                    mysqlCon.Close();
                    return false;
                }
            }
        }
        public int GetMaxContragentID()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                mysqlCon.Open();
                int conMaxID = 0;
                MySqlCommand cmd = new MySqlCommand("SELECT idcontractors FROM contractors ORDER BY idcontractors DESC LIMIT 1", mysqlCon);

                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    conMaxID = Convert.ToInt32(dr["idcontractors"]);
                }
                mysqlCon.Close();
                return conMaxID;
            }
        }
        public void AddOfferedConsumable(int contractorID, int consumableID)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                mysqlCon.Open();
                string grajdanskaInsert = "INSERT into offeredconsumables(contractors_idcontractors, consumables_idConsumables) VALUES(@contractorID, @consumableID)";
                MySqlCommand cmd = new MySqlCommand(grajdanskaInsert, mysqlCon);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@contractorID", contractorID);
                cmd.Parameters.AddWithValue("@consumableID", consumableID);
                cmd.ExecuteNonQuery();
                mysqlCon.Close();
            }
        }
        public void addContragent(string BULSTAT, string name, string city, string address, string DDSnomer, string MOL)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                try
                {

                    mysqlCon.Open();
                    MySqlCommand mySqlCmd = new MySqlCommand("addContractors", mysqlCon);
                    mySqlCmd.CommandType = CommandType.StoredProcedure;
                    mySqlCmd.Parameters.AddWithValue("_BULSTAT", BULSTAT);
                    mySqlCmd.Parameters.AddWithValue("_name", name);
                    mySqlCmd.Parameters.AddWithValue("_city", city);
                    mySqlCmd.Parameters.AddWithValue("_address", address);
                    mySqlCmd.Parameters.AddWithValue("_DDSnomer", DDSnomer);
                    mySqlCmd.Parameters.AddWithValue("_MOL", MOL);


                    mySqlCmd.ExecuteNonQuery();

                    mysqlCon.Close();
                }
                catch (MySqlException m)
                {

                    log.Log(m.ToString());
                }
                catch (InvalidOperationException i)
                {
                    log.Log(i.ToString());
                }



            }
        }
        public void editContragent(int idedit, string BULSTAT, string name, string city, string address, string DDSnomer, string MOL)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                try
                {
                    mysqlCon.Open();
                    MySqlCommand mySqlCmd = new MySqlCommand("editContractors", mysqlCon);
                    mySqlCmd.CommandType = CommandType.StoredProcedure;
                    mySqlCmd.Parameters.AddWithValue("_idedit", idedit);
                    mySqlCmd.Parameters.AddWithValue("_BULSTAT", BULSTAT);
                    mySqlCmd.Parameters.AddWithValue("_name", name);
                    mySqlCmd.Parameters.AddWithValue("_city", city);
                    mySqlCmd.Parameters.AddWithValue("_address", address);
                    mySqlCmd.Parameters.AddWithValue("_DDSnomer", DDSnomer);
                    mySqlCmd.Parameters.AddWithValue("_MOL", MOL);


                    mySqlCmd.ExecuteNonQuery();

                    mysqlCon.Close();
                }
                catch (MySqlException m)
                {

                    log.Log(m.ToString());
                }
                catch (InvalidOperationException i)
                {
                    log.Log(i.ToString());
                }



            }
        }

        public void deleteContragent(int deleteid)
        {
            try
            {
                using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
                {
                    mysqlCon.Open();
                    MySqlCommand mySqlCmd = new MySqlCommand("deleteContragent", mysqlCon);
                    mySqlCmd.CommandType = CommandType.StoredProcedure;
                    mySqlCmd.Parameters.AddWithValue("_idDelete", deleteid);

                    mySqlCmd.ExecuteNonQuery();

                }
            }
            catch (MySqlException ex)
            {

                log.Log(ex.ToString());

                if (ex.Number == 1451)

                    throw ex;
            }
        }

        public void addDocType(string docType)
        {
            try
            {
                using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
                {
                    mysqlCon.Open();
                    MySqlCommand mySqlCmd = new MySqlCommand("addDocType", mysqlCon);
                    mySqlCmd.CommandType = CommandType.StoredProcedure;
                    mySqlCmd.Parameters.AddWithValue("_name", docType);


                    mySqlCmd.ExecuteNonQuery();

                    mysqlCon.Close();




                }
            }
            catch (MySqlException m)
            {

                log.Log(m.ToString());
            }
            catch (InvalidOperationException i)
            {
                log.Log(i.ToString());
            }


        }
        public void editDocType(int idedit, string name)
        {
            try
            {
                using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
                {
                    mysqlCon.Open();
                    MySqlCommand mySqlCmd = new MySqlCommand("editDocType", mysqlCon);
                    mySqlCmd.CommandType = CommandType.StoredProcedure;
                    mySqlCmd.Parameters.AddWithValue("_idEdit", idedit);
                    mySqlCmd.Parameters.AddWithValue("_name", name);


                    mySqlCmd.ExecuteNonQuery();

                    mysqlCon.Close();



                }
            }
            catch (MySqlException m)
            {

                log.Log(m.ToString());
            }
            catch (InvalidOperationException i)
            {
                log.Log(i.ToString());
            }
        }
        public void deleteDocType(int deleteid)
        {
            try
            {
                using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
                {
                    mysqlCon.Open();
                    MySqlCommand mySqlCmd = new MySqlCommand("deleteDocType", mysqlCon);
                    mySqlCmd.CommandType = CommandType.StoredProcedure;
                    mySqlCmd.Parameters.AddWithValue("_idDelete", deleteid);

                    mySqlCmd.ExecuteNonQuery();

                }
            }
            catch (MySqlException ex)
            {

                log.Log(ex.ToString());

                if (ex.Number == 1451)

                    throw ex;
            }
        }
        public bool documentNumberCheck(string nomer, int contragent)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                mysqlCon.Open();
                string docNumber = "SELECT nomer FROM documents WHERE nomer = @nomer && contractors_idcontractors = @contragent";
                MySqlCommand cmd = new MySqlCommand(docNumber, mysqlCon);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nomer", nomer);
                cmd.Parameters.AddWithValue("@contragent", contragent);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    mysqlCon.Close();
                    return true;
                }
                else
                {
                    mysqlCon.Close();
                    return false;
                }
            }
        }
        public void addDocuments(int userid, string date, string documentNumber, int contragent, int documentType, List<ClassDocumentDetails> list)
        {
            int document = 0;
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                try
                {
                    mysqlCon.Open();
                    MySqlTransaction transaction = mysqlCon.BeginTransaction();
                    MySqlCommand mySqlCmd = new MySqlCommand();
                    mySqlCmd.Transaction = transaction;
                    mySqlCmd = new MySqlCommand("addDocument", mysqlCon);
                    mySqlCmd.CommandType = CommandType.StoredProcedure;

                    //mySqlCmd.Parameters.AddWithValue("_idDocuments", 0);
                    mySqlCmd.Parameters.AddWithValue("_user", userid);
                    mySqlCmd.Parameters.AddWithValue("_Date", date);
                    mySqlCmd.Parameters.AddWithValue("_number", documentNumber);
                    mySqlCmd.Parameters.AddWithValue("_contractors_idcontractors", contragent);
                    mySqlCmd.Parameters.AddWithValue("_doctype_idDocType", documentType);


                    mySqlCmd.ExecuteNonQuery();






                    string sql = "SELECT idDocuments FROM documents WHERE idDocuments = (SELECT MAX(idDocuments) FROM documents)";
                    MySqlCommand comand = new MySqlCommand();
                    comand.Transaction = transaction;
                    comand = new MySqlCommand(sql, mysqlCon);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comand);

                    MySqlDataReader dr = comand.ExecuteReader();
                    while (dr.Read())
                    {
                        document = dr.GetInt32(0);
                    }
                    dr.Close();
                    //DataTable dt = new DataTable();
                    // DataSet ds = new DataSet();
                    //adapter.Fill(ds);

                    // document = Convert.ToInt32(ds.Tables[0].Rows[0]["idDocuments"]);
                    foreach (ClassDocumentDetails c in list)
                    {



                        MySqlCommand mySqlCmdd = new MySqlCommand();
                        mySqlCmdd.Transaction = transaction;
                        mySqlCmdd = new MySqlCommand("addDocDetails", mysqlCon);
                        mySqlCmdd.CommandType = CommandType.StoredProcedure;
                        //mySqlCmd.Parameters.AddWithValue("_idDocuments", 0);
                        mySqlCmdd.Parameters.AddWithValue("_bruto", c.bruto);
                        mySqlCmdd.Parameters.AddWithValue("_neto", c.neto);
                        mySqlCmdd.Parameters.AddWithValue("_document", document);

                        mySqlCmdd.Parameters.AddWithValue("_quantity", c.quantity);
                        mySqlCmdd.Parameters.AddWithValue("_consumable", c.consumable);


                        mySqlCmdd.ExecuteNonQuery();

                    }



                    transaction.Commit();
                    mysqlCon.Close();

                }
                catch (MySqlException m)
                {
                    throw m;
                    log.Log(m.ToString());
                }
                catch (InvalidOperationException i)
                {
                    log.Log(i.ToString());

                }

            }
        }

        public void deleteFaktura(int deleteid)
        {
            try
            {
                using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
                {
                    mysqlCon.Open();
                    MySqlCommand mySqlCmd = new MySqlCommand("deleteFaktura", mysqlCon);
                    mySqlCmd.CommandType = CommandType.StoredProcedure;
                    mySqlCmd.Parameters.AddWithValue("_idDelete", deleteid);

                    mySqlCmd.ExecuteNonQuery();

                }
            }
            catch (MySqlException ex)
            {

                log.Log(ex.ToString());

                if (ex.Number == 1451)

                    throw ex;
            }
        }

        public void editDocument(int idedit, int userid, string date, string documentNumber, int contragent, int documentType)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                try
                {

                    mysqlCon.Open();
                    MySqlCommand mySqlCmd = new MySqlCommand("editDocument", mysqlCon);
                    mySqlCmd.CommandType = CommandType.StoredProcedure;
                    mySqlCmd.Parameters.AddWithValue("_idEdit", idedit);
                    mySqlCmd.Parameters.AddWithValue("_user", userid);
                    mySqlCmd.Parameters.AddWithValue("_Date", date);
                    mySqlCmd.Parameters.AddWithValue("_number", documentNumber);
                    mySqlCmd.Parameters.AddWithValue("_contractors_idcontractors", contragent);
                    mySqlCmd.Parameters.AddWithValue("_doctype_idDocType", documentType);


                    mySqlCmd.ExecuteNonQuery();
                    //MessageBox.Show("Submitted Successfully!");
                    mysqlCon.Close();

                }
                catch (MySqlException m)
                {
                    throw m;

                    log.Log(m.ToString());
                }
                catch (InvalidOperationException i)
                {
                    log.Log(i.ToString());
                }
            }
        }

        public void editDocDetailsList(int idDocument, List<ClassDocumentDetails> editList)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                try
                {


                    mysqlCon.Open();

                    foreach (ClassDocumentDetails c in editList)
                    {
                        if (c.id != 0)
                        {



                            MySqlCommand mySqlCmd = new MySqlCommand("editDocDetails", mysqlCon);
                            mySqlCmd.CommandType = CommandType.StoredProcedure;
                            //mySqlCmd.Parameters.AddWithValue("_idDocuments", 0);
                            mySqlCmd.Parameters.AddWithValue("_idedit", c.id);
                            mySqlCmd.Parameters.AddWithValue("_bruto", c.bruto);
                            mySqlCmd.Parameters.AddWithValue("_neto", c.neto);

                            mySqlCmd.Parameters.AddWithValue("_document", idDocument);




                            mySqlCmd.Parameters.AddWithValue("_quantity", c.quantity);
                            mySqlCmd.Parameters.AddWithValue("_consumable", c.consumable);


                            mySqlCmd.ExecuteNonQuery();



                        }
                        else if (c.id == 0)
                        {
                            MySqlCommand mySqlCmd = new MySqlCommand("addDocDetails", mysqlCon);
                            mySqlCmd.CommandType = CommandType.StoredProcedure;
                            //mySqlCmd.Parameters.AddWithValue("_idDocuments", 0);
                            mySqlCmd.Parameters.AddWithValue("_bruto", c.bruto);
                            mySqlCmd.Parameters.AddWithValue("_neto", c.neto);
                            mySqlCmd.Parameters.AddWithValue("_document", idDocument);

                            mySqlCmd.Parameters.AddWithValue("_quantity", c.quantity);
                            mySqlCmd.Parameters.AddWithValue("_consumable", c.consumable);


                            mySqlCmd.ExecuteNonQuery();

                        }




                    }
                    mysqlCon.Close();
                }
                catch(MySqlException m)
                {
                    throw m;
                }



                //this.Close();
            }
        }
        public void deleteDocDetails(int deleteid)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("deleteDocDetails", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_idDelete", deleteid);

                mySqlCmd.ExecuteNonQuery();
            }
        }

        public void deleteConsumbaleBycarBYDOCDETAILSID(int deleteid)
        {
            try
            {
                using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
                {
                    mysqlCon.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM consumablebycar  WHERE docdetails_idDetails = @id", mysqlCon);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("id", deleteid);
                    cmd.ExecuteNonQuery();
                    mysqlCon.Close();

                }
            }
            catch (MySqlException ejx)
            {
                log.Log(ejx.ToString());

                if (ejx.Number == 1451)

                    throw ejx;

            }
        }
        public bool CheckIfConsumableIsUsed(int id)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                mysqlCon.Open();
                string bulstat = "SELECT * FROM car.consumablebycar where docdetails_idDetails = @id";
                MySqlCommand cmd = new MySqlCommand(bulstat, mysqlCon);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return true;
                }
                else
                {
                    mysqlCon.Close();
                    return false;
                }
            }
        }

        public bool DocumentNumberCheck(string nomer, int contragent)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                mysqlCon.Open();
                string docNumber = "SELECT nomer FROM documents WHERE nomer = @nomer && contractors_idcontractors = @contragent";
                MySqlCommand cmd = new MySqlCommand(docNumber, mysqlCon);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nomer", nomer);
                cmd.Parameters.AddWithValue("@contragent", contragent);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    mysqlCon.Close();
                    return true;
                }
                else
                {
                    mysqlCon.Close();
                    return false;
                }

            }
        }

        public int SelectDocDetailsID()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                int docDD = 0;
                string sql = "SELECT idDetails from docdetails ORDER BY idDetails DESC";

                MySqlCommand comand = new MySqlCommand(sql, mysqlCon);
                MySqlDataAdapter adapter = new MySqlDataAdapter(comand);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                docDD = Convert.ToInt32(ds.Tables[0].Rows[0]["idDetails"]);

                //MessageBox.Show(userid.ToString());
                return docDD;




            }
        }
        public DataTable ConsumableByCarComboboxClick()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                string sql = @"select c.`name`    , dd.idDetails , concat_ws(' ',c.`name`,' ','док.№:',doc.nomer ) as'concat' from docdetails dd
                    join consumables c on dd.Consumables_idConsumables = c.idConsumables
                    join documents doc on dd.Documents_idDocuments = doc.idDocuments

                    Where idDetails = @idDocument";
                MySqlCommand comand = new MySqlCommand(sql, mysqlCon); ;
                comand.Parameters.Clear();
                comand.Parameters.AddWithValue("@idDocument", Singletone.docDetails);
                MySqlDataAdapter adapter = new MySqlDataAdapter(comand);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                //MessageBox.Show(Singletone.docDetails.ToString());




                return dt;
                //comboBox2.DataSource = dt.Tables["Lang"].DefaultView;
            }
        }
        public decimal checkMaxQuantity(int id)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                decimal maxQ = 0;
                mysqlCon.Open();
                var model = "SELECT quantity FROM docdetails where idDetails = @id";
                MySqlCommand cmd = new MySqlCommand(model, mysqlCon);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);

                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    maxQ = Convert.ToDecimal(dr.GetInt32("quantity"));
                }
                mysqlCon.Close();
                return maxQ;
            }
        }
        public decimal checkUsedQuantity(int id)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                decimal maxQ = 0;
                mysqlCon.Open();
                var model = "SELECT SUM(quantity) as 'q' FROM consumablebycar where docdetails_idDetails = @id";
                MySqlCommand cmd = new MySqlCommand(model, mysqlCon);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);

                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (!DBNull.Value.Equals(dr["q"]))
                    {
                        maxQ = Convert.ToDecimal(dr.GetInt32("q"));
                    }
                    else
                    {

                    }

                }
                mysqlCon.Close();
                return maxQ;
            }
        }

        public void addConsumableByCar(int cars, int doc, decimal quantity)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("addConsumableByCar", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                //mySqlCmd.Parameters.AddWithValue("_idDocuments", 0);
                mySqlCmd.Parameters.AddWithValue("_cars_idcars", cars);
                mySqlCmd.Parameters.AddWithValue("_docdetails_idDetails", doc);
                mySqlCmd.Parameters.AddWithValue("_quantity", quantity);




                mySqlCmd.ExecuteNonQuery();
                //MessageBox.Show("Submitted Successfully!");
                mysqlCon.Close();
            }
        }

        public void editConsumableByCar(int cars, int doc, decimal quantity, int editId)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("editConsumableByCar", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                //mySqlCmd.Parameters.AddWithValue("_idDocuments", 0);
                mySqlCmd.Parameters.AddWithValue("_editId", editId);
                mySqlCmd.Parameters.AddWithValue("_cars_idcars", cars);
                mySqlCmd.Parameters.AddWithValue("_docdetails_idDetails", doc);
                mySqlCmd.Parameters.AddWithValue("_quantity", quantity);




                mySqlCmd.ExecuteNonQuery();
                //MessageBox.Show("Submitted Successfully!");
                mysqlCon.Close();
            }
        }
        public void deleteconsumableBycarQuerry(int deleteid)
        {
            try
            {
                using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
                {
                    mysqlCon.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM consumablebycar WHERE idConsumableByCar=@id;", mysqlCon);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("id", deleteid);
                    cmd.ExecuteNonQuery();
                    mysqlCon.Close();

                }
            }
            catch (MySqlException ejx)
            {
                log.Log(ejx.ToString());

                if (ejx.Number == 1451)

                    throw ejx;

            }
        }
        public void addPeople(string name, string email)
        {
            

            try
            {
                using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
                {
                    mysqlCon.Open();
                    MySqlCommand cmd = new MySqlCommand("INSERT into people(name, email) VALUES(@name, @email)", mysqlCon);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.ExecuteNonQuery();
                    mysqlCon.Close();

                }
            }
            catch (MySqlException ejx)
            {
                log.Log(ejx.ToString());

                if (ejx.Number == 1451)

                    throw ejx;

            }
        }
        public void editPeople(int personID, string name, string email)
        {
            

            try
            {
                using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
                {
                    mysqlCon.Open();
                    string personUpdate = "UPDATE people SET name = @name, email = @email WHERE idPeople = @personID";
                    MySqlCommand cmd = new MySqlCommand(personUpdate, mysqlCon);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@personID", personID);
                    cmd.ExecuteNonQuery();
                    mysqlCon.Close();

                }
            }
            catch (MySqlException ejx)
            {
                log.Log(ejx.ToString());

                if (ejx.Number == 1451)

                    throw ejx;

            }
        }

        public void deletePerson(int personID)
        {
            
            try
            {
                using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
                {
                    mysqlCon.Open();
                    string modelDel = "DELETE FROM people WHERE idPeople = @personID";
                    MySqlCommand cmd = new MySqlCommand(modelDel, mysqlCon);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@personID", personID);
                    cmd.ExecuteNonQuery();
                    mysqlCon.Close();

                }
            }
            catch (MySqlException ejx)
            {
                log.Log(ejx.ToString());

                if (ejx.Number == 1451)

                    throw ejx;

            }
        }
        public void NotificationInsert(int carID, int consumables, DateTime date)
        {
            
            try
            {
                using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
                {
                    mysqlCon.Open();
                    string notificationInsert = "INSERT into notifications(expiryDate, cars_idcars, consumables_idConsumables) VALUES(@date, @carID, @consumables)";
                    MySqlCommand cmd = new MySqlCommand(notificationInsert, mysqlCon);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@carID", carID);
                    cmd.Parameters.AddWithValue("@consumables", consumables);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.ExecuteNonQuery();
                    mysqlCon.Close();

                }
            }
            catch (MySqlException ejx)
            {
                log.Log(ejx.ToString());

                if (ejx.Number == 1451)

                    throw ejx;

            }
        }
        public int GetMaxNotificationID()
        {
            int notMaxID = 0;
            try
            {
                using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
                {
                    mysqlCon.Open();
                    
                    MySqlCommand cmd = new MySqlCommand("SELECT idNotifications FROM notifications ORDER BY idNotifications DESC LIMIT 1", mysqlCon);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        notMaxID = Convert.ToInt32(dr["idNotifications"]);
                    }
                    mysqlCon.Close();
                    

                }
            }
            catch (MySqlException ejx)
            {
                log.Log(ejx.ToString());

                if (ejx.Number == 1451)

                    throw ejx;

            }
            return notMaxID;
        }
        public void Notify(int notification, int person, int days)
        {
            
            try
            {
                using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
                {
                    mysqlCon.Open();
                    string notifyInsert = "INSERT into notify(Notifications_idNotifications, People_idPeople, days ,send) VALUES(@notification, @person, @days ,@send)";
                    MySqlCommand cmd = new MySqlCommand(notifyInsert, mysqlCon);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@notification", notification);
                    cmd.Parameters.AddWithValue("@person", person);
                    cmd.Parameters.AddWithValue("@days", days);
                    cmd.Parameters.AddWithValue("@send", 0);
                    cmd.ExecuteNonQuery();
                    mysqlCon.Close();


                }
            }
            catch (MySqlException ejx)
            {
                log.Log(ejx.ToString());

                if (ejx.Number == 1451)

                    throw ejx;

            }
        }

        public void PopulateCarProfile(int carID, AddEditCar carProfileForm)
        {
            
            try
            {
                using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
                {
                    mysqlCon.Open();
                    string str = "SELECT * FROM cars WHERE idcars = @carID ";
                    MySqlCommand cmd = new MySqlCommand(str, mysqlCon);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@carID", carID);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        carProfileForm.textBoxRegNum.Text = dr["regN"].ToString();
                        carProfileForm.textBoxColor.Text = dr["color"].ToString();
                        carProfileForm.textBoxVIN.Text = dr["VIN"].ToString();
                        carProfileForm.textBoxEngineNum.Text = dr["engineN"].ToString();
                        carProfileForm.cbFuel.SelectedValue = dr["Fuel_idFuel"].ToString();
                        
                        carProfileForm.cbModel.SelectedValue = dr["model_idmodel"].ToString();
                    }
                    mysqlCon.Close();


                }
            }
            catch (MySqlException ejx)
            {
                log.Log(ejx.ToString());

                if (ejx.Number == 1451)

                    throw ejx;

            }
        }

        public void CarModelJoin(int carID, AddEditCar carProfileForm)
        {
            
            try
            {
                using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
                {
                    mysqlCon.Open();
                    var model = "SELECT model.idmodel FROM cars INNER JOIN model ON cars.model_idmodel = model.idmodel WHERE cars.idcars = @carID";
                    MySqlCommand cmd = new MySqlCommand(model, mysqlCon);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@carID", carID);
                    cmd.Parameters.AddWithValue("@model", model);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        modelSQL = dr.GetInt32("idmodel");
                    }
                    mysqlCon.Close();
                    //return modelID;


                }
            }
            catch (MySqlException ejx)
            {
                log.Log(ejx.ToString());

                if (ejx.Number == 1451)

                    throw ejx;

            }
        }
        public void CarBrandJoin(int carID, AddEditCar carProfileForm)
        {

            try
            {
                using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
                {

                         mysqlCon.Open();
                        int model = modelSQL;
                        var innerJoinQuery = "SELECT brand.name FROM model INNER JOIN brand ON model.brand_idbrand = brand.idbrand WHERE model.idmodel = @model";
                        MySqlCommand cmd = new MySqlCommand(innerJoinQuery, mysqlCon);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@model", model);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            carProfileForm.cbBrand.Text = dr["name"].ToString();
                        }
                        mysqlCon.Close();
                    


                }
            }
            catch (MySqlException ejx)
            {
                log.Log(ejx.ToString());

                if (ejx.Number == 1451)

                    throw ejx;

            }
        }
        public int GetCarID()
        {
            int carID = 0;

            try
            {
                using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
                {


                    mysqlCon.Open();
                    string selectCarID = "SELECT MAX(idcars) FROM cars";
                    MySqlCommand cmd = new MySqlCommand(selectCarID, mysqlCon);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        carID = Convert.ToInt32(dr["MAX(idcars)"]);
                    }
                    mysqlCon.Close();
                    



                }
            }
            catch (MySqlException ejx)
            {
                log.Log(ejx.ToString());

                if (ejx.Number == 1451)

                    throw ejx;

            }
            return carID;
        }

    }
}





