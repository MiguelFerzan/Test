using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;

namespace Attendance.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] int userID)
        {
            string datetime = DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm:ss");
            //string dateTime = logDate.ToString("yyyy’-‘MM’-‘dd’ ’HH’:’mm’:’ss");
            Console.WriteLine(datetime);
            string connectionString = "server=localhost;user id=root;password=2441998;database=attendance";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand command = con.CreateCommand();
            command.Parameters.AddWithValue("@uid", userID);
            command.Parameters.AddWithValue("@datetime", datetime);
            command.CommandText = "INSERT INTO attendancelog (AttendanceID,UserID,LogDate) Values (default, @uid, @datetime) ";
            con.Close();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
