using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace de1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int courseId;
                if (int.TryParse(Request.QueryString["Courses"], out courseId))
                {
                    LoadCourseDetails(courseId);
                }
                else
                {
                    Response.Write("Invalid Course ID.");
                }
            }
        }

        private void LoadCourseDetails(int courseId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["QLKhoaHoc_WP001ConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Name, ImageFilePath, Description, Duration, CatID, NumViews FROM Course WHERE ID = @CourseID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CourseID", courseId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    CourseName.InnerText = reader["Name"].ToString();
                    CourseImage.Src = "images/Courses/" + reader["ImageFilePath"].ToString();
                    CourseDescription.InnerText = reader["Description"].ToString();
                    CourseDuration.InnerText = reader["Duration"].ToString();
                    CourseCategory.InnerText = reader["CatID"].ToString();
                    CourseViews.InnerText = reader["NumViews"].ToString();
                }
                else
                {
                    Response.Write("Course not found.");
                }
            }
        }
    }
}