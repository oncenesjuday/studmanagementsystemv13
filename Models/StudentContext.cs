using MySql.Data.MySqlClient;

namespace studmanagementsystemv13.Models
{
    public class StudentContext
    {
        private readonly MySqlConnection _mySqlConnection;

        public StudentContext(string connectionString)
        {
            _mySqlConnection = new MySqlConnection(connectionString);
        }

        public bool InsertStudent(Students students)
        {
            try
            {
                _mySqlConnection.Open();
                MySqlCommand sqlcommand = new MySqlCommand(

                    @"INSERT INTO studenttableni (studentname)
                        VALUES(@studentname)", _mySqlConnection);
                sqlcommand.Parameters.AddWithValue("@studentname", students.Name);

                int rowsAffected = sqlcommand.ExecuteNonQuery();
                _mySqlConnection.Close();

                return rowsAffected > 0;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool InsertStudentLang(Students students)
        {
            try
            {
                _mySqlConnection.Open();
                MySqlCommand sqlcommand = new MySqlCommand(

                    @"INSERT INTO studentform (Lname, Fname, Mname, Suffix, StreetAdd, City, Province, BDate, Gender, Pnumber, EmailAdd, Yearlevel, Degree)
                        VALUES(@Lname, @Fname, @Mname, @Suffix, @StreetAdd, @City, @Province, @BDate, @Gender, @Pnumber, @EmailAdd, @Yearlevel, @Degree)", _mySqlConnection);
                sqlcommand.Parameters.AddWithValue("@Lname", students.Lname);
                sqlcommand.Parameters.AddWithValue("@Fname", students.Fname);
                sqlcommand.Parameters.AddWithValue("@Mname", students.Mname);
                sqlcommand.Parameters.AddWithValue("@Suffix", students.Suffix);
                sqlcommand.Parameters.AddWithValue("@StreetAdd", students.StreetAdd);
                sqlcommand.Parameters.AddWithValue("@City", students.City);
                sqlcommand.Parameters.AddWithValue("@Province", students.Province);
                sqlcommand.Parameters.AddWithValue("@BDate", students.BDate);
                sqlcommand.Parameters.AddWithValue("@Gender", students.Gender);
                sqlcommand.Parameters.AddWithValue("@Pnumber", students.Pnumber);
                sqlcommand.Parameters.AddWithValue("@EmailAdd", students.EmailAdd);
                sqlcommand.Parameters.AddWithValue("@Yearlevel", students.Yearlevel);
                sqlcommand.Parameters.AddWithValue("@Degree", students.Degree);
               
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
        public bool InsertStudentLangni(Students students)
        {
            try
            {
                _mySqlConnection.Open();
                MySqlCommand sqlcommand = new MySqlCommand(

                    @"INSERT INTO instructors (Lname, Fname, Mname, Suffix, StreetAdd, City, Province, BDate, Gender, Pnumber, EmailAdd, Yearlevel, Degree)
                        VALUES(@Lname, @Fname, @Mname, @Suffix, @StreetAdd, @City, @Province, @BDate, @Gender, @Pnumber, @EmailAdd, @Yearlevel, @Degree)", _mySqlConnection);
                sqlcommand.Parameters.AddWithValue("@Lname", students.Lname);
                sqlcommand.Parameters.AddWithValue("@Fname", students.Fname);
                sqlcommand.Parameters.AddWithValue("@Mname", students.Mname);
                sqlcommand.Parameters.AddWithValue("@Suffix", students.Suffix);
                sqlcommand.Parameters.AddWithValue("@StreetAdd", students.StreetAdd);
                sqlcommand.Parameters.AddWithValue("@City", students.City);
                sqlcommand.Parameters.AddWithValue("@Province", students.Province);
                sqlcommand.Parameters.AddWithValue("@BDate", students.BDate);
                sqlcommand.Parameters.AddWithValue("@Gender", students.Gender);
                sqlcommand.Parameters.AddWithValue("@Pnumber", students.Pnumber);
                sqlcommand.Parameters.AddWithValue("@EmailAdd", students.EmailAdd);

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
