using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ImageDatabase.Models
{
    public class DBcontext
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        //to view data
        public List<ImageModel> GetData()
        {
            List<ImageModel> students_data = new List<ImageModel>();
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Getimg", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ImageModel stu = new ImageModel();
                stu.ImageId = Convert.ToInt32(dr.GetValue(0).ToString());
                byte[] imageData = (byte[])dr.GetValue(1);
                stu.ImageData = imageData;
                students_data.Add(stu);
            }
            conn.Close();
            return students_data;
        }
        //to insert image
        public bool createData(ImageModel stu)
        {
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("InsertImgData", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ImgData", stu.ImageData);
            
            conn.Open();
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}