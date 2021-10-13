using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing
{
    class csBlotter
    {
        private csConnection cs = new csConnection();

        public void InsertData()
        {
            try
            {
                cs.conn.Open();
                MySqlCommand cmd = cs.conn.CreateCommand();
                MySqlTransaction trans = cs.conn.BeginTransaction();
                cmd.Connection = cs.conn;
                cmd.Transaction = trans;

                try
                {

                    String query = " INSERT INTO " + cs.DBname() + ".tbl_blotterinfo(Compliant, id_assailant_resident, id_assailant_nonresident, Witness, Respondent, Details, Date,Time, Status, Type, Location) " +
                        "VALUES(@com, (SELECT COALESCE(MAX(d.id_assailant_resident), 1)+1 FROM tbl_blotterinfo AS d), (SELECT COALESCE(MAX(c.id_assailant_nonresident), 1)+1 FROM tbl_blotterinfo AS c), @wit, @res, @det, @dat, @tim, @stat, @type, @location )";

                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@com", Compliant);
                    cmd.Parameters.AddWithValue("@wit", Witness);
                    cmd.Parameters.AddWithValue("@res", Respondent);
                    cmd.Parameters.AddWithValue("@det", Details);
                    cmd.Parameters.AddWithValue("@dat", Date);
                    cmd.Parameters.AddWithValue("@tim", Time);
                    cmd.Parameters.AddWithValue("@stat", Status);
                    cmd.Parameters.AddWithValue("@type", Type);
                    cmd.Parameters.AddWithValue("@location", Location);
                    cmd.ExecuteNonQuery();

                    foreach (var str in GetArrAssailant())
                    {
                        cmd.Parameters.Clear();
                        if (str.id !=0) {
                            String query2 = "INSERT INTO " + cs.DBname() + ".tbl_assailantresident (id_assailant_resident,id_resident) " +
                                                "VALUES((SELECT MAX(id_assailant_resident) FROM tbl_blotterinfo), @idres)";
                            cmd.CommandText = query2;
                            cmd.Parameters.AddWithValue("@idres", str.id);
                        }
                        else
                        {
                            String query2 = "INSERT INTO " + cs.DBname() + ".tbl_assailantnonresident(id_assailant_nonresident,Name) " +
                                "VALUES((SELECT MAX(id_assailant_nonresident) FROM tbl_blotterinfo), @name)";
                            cmd.CommandText = query2;
                            cmd.Parameters.AddWithValue("@name", str.name);
                        }
                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                    Message = "Inserted Successfully";
                }
                catch (Exception e)
                {
                    try
                    {
                        trans.Rollback();
                        Message = e.Message;
                    }
                    catch (MySqlException ex)
                    {
                        Message = ex.Message;
                    }
                }

                cmd.Dispose();
                cs.conn.Close();

            }
            catch (Exception e)
            {
                Message = e.Message;
            }
        }

        public void UpdateData()
        {
            try
            {
                cs.conn.Open();
                cs.command = cs.conn.CreateCommand();
                MySqlTransaction trans = cs.conn.BeginTransaction();
                cs.command.Connection = cs.conn;
                cs.command.Transaction = trans;

                try
                {
                    String query = "UPDATE " + cs.DBname() + ".tbl_blotterinfo " +
                        "SET Compliant = @com, Witness = @wit , Respondent = @res, Details = @det, Date =@dat, Time=@tim, Status= @stat, Type= @type, Location=@location " +
                        "WHERE id_blotter = @id";


                    cs.command.CommandText = query;
                    cs.command.Parameters.AddWithValue("@com", Compliant);
                    cs.command.Parameters.AddWithValue("@wit", Witness);
                    cs.command.Parameters.AddWithValue("@res", Respondent);
                    cs.command.Parameters.AddWithValue("@det", Details);
                    cs.command.Parameters.AddWithValue("@dat", Date);
                    cs.command.Parameters.AddWithValue("@tim", Time);
                    cs.command.Parameters.AddWithValue("@stat", Status);
                    cs.command.Parameters.AddWithValue("@type", Type);
                    cs.command.Parameters.AddWithValue("@location", Location);
                    cs.command.Parameters.AddWithValue("@id", ID);
                    cs.command.ExecuteNonQuery();


                    cs.command.CommandText = "UPDATE "+ cs.DBname() +".tbl_assailantresident " +
                        "SET Deleted = 1 " +
                        "WHERE id_assailant_resident = @asskey";
                    cs.command.Parameters.AddWithValue("@asskey", KeyIDResident);
                    cs.command.ExecuteNonQuery();

                    cs.command.CommandText = "UPDATE " + cs.DBname() + ".tbl_assailantnonresident " +
                        "SET Deleted = 1 " +
                        "WHERE id_assailant_nonresident = @nonasskey";
                    cs.command.Parameters.AddWithValue("@nonasskey", KeyIDNonResident);
                    cs.command.ExecuteNonQuery();

                    foreach (var str in GetArrAssailant2())
                    {
                        cs.command.Parameters.Clear();
                        if (str.from == "resident")
                        {
                            String query2 = "UPDATE "+cs.DBname()+".tbl_assailantresident " +
                                "SET Deleted = 0 " +
                                "WHERE id =@primekey AND id_assailant_resident =@asskey";

                            cs.command.CommandText = query2;
                            cs.command.Parameters.AddWithValue("@primekey", str.id);
                            cs.command.Parameters.AddWithValue("@asskey", KeyIDResident);
                        }
                        else if(str.from == "nonresident")
                        {
                            String query2 = "UPDATE "+cs.DBname()+".tbl_assailantnonresident " +
                                "SET Deleted = 0 " +
                                "WHERE id=@primekey AND id_assailant_nonresident = @nonasskey";

                            cs.command.CommandText = query2;
                            cs.command.Parameters.AddWithValue("@primekey", str.id);
                            cs.command.Parameters.AddWithValue("@nonasskey", KeyIDNonResident);
                        }
                        else if (str.from == "insertresident")
                        {
                            String query2 = "INSERT INTO " + cs.DBname() + ".tbl_assailantresident (id_assailant_resident,id_resident) " +
                                "VALUES( @asskey, @idres)";

                            cs.command.CommandText = query2;
                            cs.command.Parameters.AddWithValue("@asskey", KeyIDResident);
                            cs.command.Parameters.AddWithValue("@idres", str.id);
                        }
                        else if (str.from == "insertnonresident")
                        {
                            String query2 = "INSERT INTO " + cs.DBname() + ".tbl_assailantnonresident(id_assailant_nonresident,Name) " +
                                "VALUES(@nonasskey , @name)";

                            cs.command.CommandText = query2;
                            cs.command.Parameters.AddWithValue("@nonasskey", KeyIDNonResident);
                            cs.command.Parameters.AddWithValue("@name", str.name);
                        }
                        cs.command.ExecuteNonQuery();
                    }

                    trans.Commit();
                    Message = "Updated Successfully";

                    cs.command.Dispose();
                    cs.conn.Close();
                }catch(Exception es)
                {
                    try
                    {
                        trans.Rollback();
                        Message = es.Message;
                    }
                    catch (MySqlException ex)
                    {
                        Message = ex.Message;
                    }
                }
            }
            catch (Exception e)
            {
                Message = e.Message;
            }
        }

        public void RetrieveData()
        {
            try
            {
                String query = "SELECT Compliant, id_assailant_resident, id_assailant_nonresident, Witness, Respondent, Details, DATE_FORMAT(Date,'%Y-%m-%d') ,DATE_FORMAT(Time ,'%H:%i:%S'), Status, Type, Location FROM tbl_blotterinfo WHERE id_blotter = @id";
                cs.conn.Open();
                cs.command = new MySqlCommand();
                cs.command.CommandText = query;
                cs.command.Parameters.AddWithValue("@id",ID);
                cs.command.Connection = cs.conn;
                MySqlDataReader rdr = cs.command.ExecuteReader();

                if (rdr.Read())
                {

                    Compliant = rdr[0].ToString();
                    KeyIDResident = rdr[1].ToString();
                    KeyIDNonResident = rdr[2].ToString();
                    Witness = rdr[3].ToString();
                    Respondent = rdr[4].ToString();
                    Details = rdr[5].ToString();
                    Date = rdr[6].ToString();
                    Time = rdr[7].ToString();
                    Status = rdr[8].ToString();
                    Type = rdr[9].ToString();
                    Location = rdr[10].ToString();
                }
                rdr.Close();

                // Logical error

                cs.command.CommandText = "SELECT a.id, a.id_resident, r.Fname, r.Mname, r.Lname, r.Sname FROM tbl_assailantresident AS a " +
                    "LEFT JOIN tbl_residentinfo AS r ON r.id_resident = a.id_resident " +
                    "WHERE a.id_assailant_resident = @keyid AND Deleted = 0";
                cs.command.Parameters.AddWithValue("@keyid", KeyIDResident);
                rdr = cs.command.ExecuteReader();

                while (rdr.Read())
                {
                    int intID = Int32.Parse(rdr[0].ToString());
                    int intIDResident = Int32.Parse(rdr[1].ToString());
                    String fullname = rdr[2].ToString() + " " + rdr[3].ToString() + " " + rdr[4].ToString() + " " + rdr[5].ToString();
                    AddAssailant2(new AssailantRes2() { from = "resident", id = intID, idresident= intIDResident, name = fullname });
                    Console.WriteLine(intID  +" = resident = "+ fullname);
                }
                rdr.Close();

                cs.command.CommandText = "SELECT id, Name FROM tbl_assailantnonresident WHERE id_assailant_nonresident = @keyid2 AND Deleted = 0";
                cs.command.Parameters.AddWithValue("@keyid2", KeyIDNonResident);
                rdr = cs.command.ExecuteReader();

                while (rdr.Read())
                {
                    int intID = Int32.Parse(rdr[0].ToString());
                    String fullname = rdr[1].ToString();
                    AddAssailant2(new AssailantRes2() { from = "nonresident", id = intID, name = fullname });
                    Console.WriteLine(intID + " = nonresident = " + fullname);
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                Message = e.Message;
            }
            finally
            {
                cs.command.Dispose();
                cs.conn.Close();
            }
        }


        public void RetrieveData2()
        {
            try
            {
                String query = "SELECT b.Compliant, b.Witness , r.id_resident, r.Fname, r.Mname, r.Lname, r.Sname, aa.Name, b.Respondent , b.Details , DATE_FORMAT(b.Date,'%Y-%m-%d') ,DATE_FORMAT(b.Time ,'%H:%i:%S'),  b.Status, b.Type, b.Location " +
                    "FROM tbl_blotterinfo AS b " +
                    "LEFT JOIN tbl_assailantresident AS a ON a.id_assailant_resident = b.id_assailant_resident " +
                    "LEFT JOIN tbl_residentinfo AS r ON r.id_resident = a.id_resident " +
                    "LEFT JOIN tbl_assailantnonresident AS aa ON aa.id_assailant_nonresident = b.id_assailant_nonresident " +
                    "WHERE id_blotter = @id";

                cs.conn.Open();
                cs.command = new MySqlCommand();
                cs.command.CommandText = query;
                cs.command.Parameters.AddWithValue("@id", ID);

                cs.command.Connection = cs.conn;
                MySqlDataReader rdr = cs.command.ExecuteReader();

                while (rdr.Read())
                {

                    Compliant = rdr[0].ToString();
                    Witness = rdr[1].ToString();
                    Respondent = rdr[8].ToString();
                    Details = rdr[9].ToString();
                    Date = rdr[10].ToString();
                    Time = rdr[11].ToString();
                    Status = rdr[12].ToString();
                    Type = rdr[13].ToString();
                    Location = rdr[14].ToString();

                    int intID = Int32.Parse(rdr[2].ToString());
                    String fullname = rdr[3].ToString() + " " + rdr[4].ToString() + " " + rdr[5].ToString() + " " + rdr[6].ToString();


                    bool exist = false;
                    foreach (var str in GetArrAssailant())
                    {
                        if (str.id == intID && str.name == fullname)
                        {
                            exist = true;
                        }
                    }

                    if (exist == false)
                    {
                        AddAssailant(new AssailantRes() { id = intID, name = fullname });
                    }
                }

                rdr.Close();
                cs.command.Dispose();
                cs.conn.Close();
            }
            catch (Exception e)
            {
                Message = e.Message;
            }
        }

        public void Reset()
        {
            ID = "";
            Message = "";
            Compliant = "";
            KeyIDResident = "";
            KeyIDNonResident = "";
            Witness = "";
            Respondent = "";
            Details = "";
            Date = "";
            Time = "";
            Status = "";
            Type = "";
            Location = "";
            AssRes.Clear();
            AssRes2.Clear();
        }
        public static string ID;

        public void GetID(String Id)
        {
            ID = Id;
        }

        public string Message { get; private set; }
        public string Compliant { get; set; }
        public string Witness { get; set; }
        public string KeyIDResident { get; private set; }
        public string KeyIDNonResident { get; private set; }
        public string Respondent { get; set; }
        public string Details { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }

        //Setters Getters
        private static List<AssailantRes> AssRes = new List<AssailantRes>();
        public void AddAssailant(AssailantRes a)
        {
            AssRes.Add(a);
        }

        public void RemoveAssailant(AssailantRes b)
        {
            AssRes.RemoveAll(a => a.id == b.id && a.name == b.name);
        }
        public List<AssailantRes> GetArrAssailant()
        {
            return AssRes;
        }

        //
        private static List<AssailantRes2> AssRes2 = new List<AssailantRes2>();
        public void AddAssailant2(AssailantRes2 a)
        {
            AssRes2.Add(a);
        }

        public void RemoveAssailant2(AssailantRes2 b)
        {
            AssRes2.RemoveAll(a => a.id == b.id && a.name == b.name);
        }
        public void ResetAssailant()
        {
            AssRes2 = new List<AssailantRes2>();
            AssRes = new List<AssailantRes>();
        }

        public List<AssailantRes2> GetArrAssailant2()
        {
            return AssRes2;
        }
    }

    public class AssailantRes
    {
        public int id { get; set; }
        public string name { get; set; }

    }


    public class AssailantRes2
    {
        public string from { get; set; }
        public int id { get; set; }
        public int idresident { get; set; }
        public string name { get; set; }

    }
}
