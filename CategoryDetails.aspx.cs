using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace de1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCourseList();
            }
        }

        private void BindCourseList()
        {
            int categoryId = Convert.ToInt32(Request.QueryString["CategoryId"]);
            string connectionString = ConfigurationManager.ConnectionStrings["QLKhoaHoc_WP001ConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                ID,
                Name, 
                ImageFilePath, 
                Duration 
            FROM 
                Course 
            WHERE 
                CatID = @CategoryId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CategoryId", categoryId);

                connection.Open();

                // Use DataTable to store the data
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                CourseListView.DataSource = dataTable;
                CourseListView.DataBind();
            }
        }
    }
}