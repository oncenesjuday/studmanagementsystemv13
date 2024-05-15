using System.Linq.Expressions;
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

        public bool UpdateStudent(Students students)
        {
            try
            {
                _mySqlConnection.Open();
                MySqlCommand sqlcommand = new MySqlCommand(

                    @"UPDATE studentform SET Lname = @Lname, Fname = @Fname, Mname = @Mname, Suffix = @Suffix, StreetAdd = @StreetAdd, City = @City, Province = @Province, 
 BDate = @BDate, Gender = @Gender, Pnumber = @Pnumber, EmailAdd = @EmailAdd, Yearlevel = @Yearlevel, Degree = @Degree WHERE StudentID = @StudentID", _mySqlConnection);

                sqlcommand.Parameters.AddWithValue("@StudentID", students.ID);
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
        public bool DeleteStudent(int id)
        {
            try
            {
                _mySqlConnection.Open();
                MySqlCommand sqlcommand = new MySqlCommand("DELETE FROM studentform WHERE StudentID = @StudentID ", _mySqlConnection);
                sqlcommand.Parameters.AddWithValue("@StudentID", id);
                int rowAffected = sqlcommand.ExecuteNonQuery();
                return rowAffected > 0;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error deleting student: {ex.Message}");
                return false;
            }
        }
            
        public Students GetStudentsById(int id)
        {
            Students students = null;
            _mySqlConnection.Open();
            MySqlCommand command = new MySqlCommand("SELECT * FROM studentform WHERE StudentID = @id", _mySqlConnection);
            command.Parameters.AddWithValue("id", id);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    students = new Students 
                    {
                        ID = reader.GetInt32("StudentID"),
                        Lname = reader.GetString("Lname"),
                        Fname = reader.GetString("Fname"),
                        Mname = reader.GetString("Mname"),
                        Suffix = reader.GetString("Suffix"),
                        StreetAdd = reader.GetString("StreetAdd"),
                        City = reader.GetString("City"),
                        Province = reader.GetString("province"),
                        BDate = reader.GetDateTime("BDate"),
                        Gender = reader.GetString("Gender"),
                        Pnumber = reader.GetInt32("Pnumber"),
                        EmailAdd = reader.GetString("EmailAdd"),
                        Yearlevel = reader.GetString("Yearlevel"),
                        Degree = reader.GetString("Degree")
                    };
                }
            }
            return students;
        }
        public List<Students> GetStudents()
        {
            List<Students> studentList= new List<Students>();
            _mySqlConnection.Open();
            MySqlCommand command = new MySqlCommand(
                "SELECT * FROM studentform", _mySqlConnection);
            using (MySqlDataReader reader = command.ExecuteReader())
            { 
                while (reader.Read())
                {
                    studentList.Add(new Students
                    {
                        ID = reader.GetInt32("StudentID"),
                        Lname = reader.GetString("Lname"),
                        Fname = reader.GetString("Fname"),
                        Mname = reader.GetString("Mname"),
                        Suffix = reader.GetString("Suffix"),
                        Gender = reader.GetString("Gender"),
                        Yearlevel = reader.GetString("Yearlevel"),
                        Degree = reader.GetString("Degree")
                    });
                }
            }
            return studentList;
        }
        public bool InsertStudent(Students students)
        {
            try
            {
                _mySqlConnection.Open();
                MySqlCommand sqlcommand = new MySqlCommand(

                    @"INSERT INTO studenttableni (studentname)
                        VALUES(@studentname)", _mySqlConnection);
                sqlcommand.Parameters.AddWithValue("@studentname", students.Lname);

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
       
    }
}
