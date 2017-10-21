using Models.Domains;
using Models.Requests;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AppointmentService
    {
        public List<Appointment> GetAll()
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ViaDB"].ConnectionString))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = "dbo.Appointments_SelectAll";
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    var results = new List<Appointment>();
                    while (reader.Read())
                    {
                        results.Add(new Appointment
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            Phone = (string)reader["Phone"],
                            Email = (string)reader["Email"],
                            Address = (string)reader["Address"],
                            Date = (DateTime)reader["Date"],
                            Notes = (string)reader["Notes"].ToString(),
                            Device = (string)reader["Device"],
                            Repair = (string)reader["Repair"],
                            Total = (int)reader["Total"]

                        });
                    }
                    return results;
                }
            }
        }

        public Appointment GetById(int Id)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ViaDB"].ConnectionString))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = "dbo.Appointments_SelectById";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", Id);

                using (var reader = cmd.ExecuteReader())
                {
                    var result = new Appointment();
                    while (reader.Read())
                    {
                        result.Id = (int)reader["Id"];
                        result.Name = (string)reader["Name"];
                        result.Phone = (string)reader["Phone"];
                        result.Email = (string)reader["Email"];
                        result.Address = (string)reader["Address"];
                        result.Date = (DateTime)reader["Date"];
                        result.Notes = (string)reader["Notes"].ToString();
                        result.Device = (string)reader["Device"];
                        result.Repair = (string)reader["Repair"];
                        result.Total = (int)reader["Total"];

                    }
                    return result;
                }
            }
        }

        public void Post(AppointmentAddRequest model)
        {
            using(var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ViaDB"].ConnectionString))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = "dbo.Appointments_Insert";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@Phone", model.Phone);
                cmd.Parameters.AddWithValue("@Email", model.Email);
                cmd.Parameters.AddWithValue("@Address", model.Address);
                cmd.Parameters.AddWithValue("@Date", model.Date);
                cmd.Parameters.AddWithValue("@Notes", model.Notes);
                cmd.Parameters.AddWithValue("@Device", model.Device);
                cmd.Parameters.AddWithValue("@Repair", model.Repair);
                cmd.Parameters.AddWithValue("@Total", model.Total);

                cmd.ExecuteNonQuery();
            }
        }

        public void Put(AppointmentUpdateRequest model)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ViaDB"].ConnectionString))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = "dbo.Appointments_Update";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", model.Id);
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@Phone", model.Phone);
                cmd.Parameters.AddWithValue("@Email", model.Email);
                cmd.Parameters.AddWithValue("@Address", model.Address);
                cmd.Parameters.AddWithValue("@Date", model.Date);
                cmd.Parameters.AddWithValue("@Notes", model.Notes);
                cmd.Parameters.AddWithValue("@Device", model.Device);
                cmd.Parameters.AddWithValue("@Repair", model.Repair);
                cmd.Parameters.AddWithValue("@Total", model.Total);

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int Id)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ViaDB"].ConnectionString))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = "dbo.Appointments_Delete";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", Id);

                cmd.ExecuteNonQuery();
            }

        }
    }
}
