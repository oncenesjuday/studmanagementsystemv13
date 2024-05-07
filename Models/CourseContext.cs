using MySql.Data.MySqlClient;
using studmanagementsystemv13.Models;

namespace studmanagementsystemv13.Models
{
    public class CourseContext
    {
        private readonly MySqlConnection _mySqlConnection;

        public CourseContext(string connectionString)
        {
            _mySqlConnection = new MySqlConnection(connectionString);
        }

        public bool InsertCourse(Course course)
        {
            try
            {
                _mySqlConnection.Open();
                MySqlCommand sqlcommand = new MySqlCommand(

                    @"INSERT INTO course (code, title, lecture, laboratory, description)
                        VALUES(@code, @title,@lecture, @laboratory, @description)", _mySqlConnection);
                sqlcommand.Parameters.AddWithValue("code", course.Code);
                sqlcommand.Parameters.AddWithValue("title", course.Title);
                sqlcommand.Parameters.AddWithValue("lecture", course.Lecture);
                sqlcommand.Parameters.AddWithValue("laboratory", course.Laboratory);
                sqlcommand.Parameters.AddWithValue("description", course.Description);

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
