using MySql.Data.MySqlClient;
using studmanagementsystemv13.Models;
using studmanagementsystemv13.Models;
using studmanagementsystemv13.Models;

namespace studmanagementsystemv13.Models
{
    public class InstructorContext
    {
        private readonly MySqlConnection _mySqlConnection;

        public InstructorContext(string connectionString)
        {
            _mySqlConnection = new MySqlConnection(connectionString);
        }
        public bool InsertInstructor(Instructor instructor)
        {
            try
            {
                _mySqlConnection.Open();
                MySqlCommand sqlcommand = new MySqlCommand(

                    @"INSERT INTO instructors (Lname, Fname, Mname, Suffix, StreetAdd, City, Province, BDate, Gender, Pnumber, EmailAdd)
                        VALUES(@Lname, @Fname, @Mname, @Suffix, @StreetAdd, @City, @Province, @BDate, @Gender, @Pnumber, @EmailAdd)", _mySqlConnection);
                sqlcommand.Parameters.AddWithValue("@Lname", instructor.Lname);
                sqlcommand.Parameters.AddWithValue("@Fname", instructor.Fname);
                sqlcommand.Parameters.AddWithValue("@Mname", instructor.Mname);
                sqlcommand.Parameters.AddWithValue("@Suffix", instructor.Suffix);
                sqlcommand.Parameters.AddWithValue("@StreetAdd", instructor.StreetAdd);
                sqlcommand.Parameters.AddWithValue("@City", instructor.City);
                sqlcommand.Parameters.AddWithValue("@Province", instructor.Province);
                sqlcommand.Parameters.AddWithValue("@BDate", instructor.BDate);
                sqlcommand.Parameters.AddWithValue("@Gender", instructor.Gender);
                sqlcommand.Parameters.AddWithValue("@Pnumber", instructor.Pnumber);
                sqlcommand.Parameters.AddWithValue("@EmailAdd", instructor.EmailAdd);

                int rowsAffected = sqlcommand.ExecuteNonQuery();
                _mySqlConnection.Close();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }

 }