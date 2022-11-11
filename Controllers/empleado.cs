using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;
using WebAppPIA.Models;

namespace WebAppPIA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class empleado : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public empleado(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("registerEmpleado")]
        public string registration(empleados empleado)
        {
            SqlConnection con = new(_configuration.GetConnectionString("ConsultorioApp").ToString());
            SqlCommand cmd = new("INSERT INTO empleado(name_empleado,email_empleado,phone_empleado,password_empleado,id_ciudadEmpFK,id_turno,id_puesto, id_consul)VALUES('"+empleado.name_empleado+"','"+empleado.email_empleado+"','"+empleado.phone_empleado+"','"+empleado.password_empleado+"','"+empleado.id_ciudadEmpFK+"','"+empleado.id_turno+"','"+empleado.id_puesto+"','"+empleado.id_consul+"')", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            response response = new response();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.ErrorMessage = "Success";
                response.body = null;
                return JsonConvert.SerializeObject(response);
            }
            else
            {
                response.StatusCode = 100;
                response.ErrorMessage = "Error";
                response.body = null;
                return JsonConvert.SerializeObject(response);
            }
        }

        [HttpGet]
        [Route("getAllEmpleado/userID/{userID}")]
        public string GetConsultorio(string userID)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ConsultorioApp").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * from empleado where(id_consul = '"+ userID +"')", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<empleados> consulList = new List<empleados>();
            response response = new response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    empleados empleados = new empleados();
                    empleados.id_empleado = Convert.ToInt32(dt.Rows[i]["id_empleado"]);
                    empleados.name_empleado = Convert.ToString(dt.Rows[i]["name_empleado"]);
                    empleados.email_empleado = Convert.ToString(dt.Rows[i]["email_empleado"]);
                    empleados.phone_empleado = Convert.ToString(dt.Rows[i]["phone_empleado"]);
                    empleados.created_at = Convert.ToDateTime(dt.Rows[i]["created_at"]);
                    empleados.password_empleado = Convert.ToString(dt.Rows[i]["password_empleado"]);
                    empleados.id_ciudadEmpFK = Convert.ToInt32(dt.Rows[i]["id_ciudadEmpFK"]);
                    empleados.id_turno = Convert.ToInt32(dt.Rows[i]["id_turno"]);
                    empleados.id_puesto = Convert.ToInt32(dt.Rows[i]["id_puesto"]);
                    consulList.Add(empleados);
                }
            }
            if (consulList.Count > 0)
            {
                return JsonConvert.SerializeObject(consulList);
            }
            else
            {
                response.StatusCode = 100;
                response.ErrorMessage = "No hay informacion almacenada";
                return JsonConvert.SerializeObject(response);
            }
        }

        [HttpDelete]
        [Route("delete/userID/{userID}/")]
        public string deleteEmp(int userID)
        {
            SqlConnection con = new(_configuration.GetConnectionString("ConsultorioApp").ToString());
            SqlCommand cmd = new("DELETE FROM EMPLEADO WHERE id_empleado='" + userID + "'", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            response response = new response();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.ErrorMessage = "Success";
                response.body = null;
                return JsonConvert.SerializeObject(response);
            }
            else
            {
                response.StatusCode = 100;
                response.ErrorMessage = "Error";
                response.body = null;
                return JsonConvert.SerializeObject(response);
            }
        }

        [HttpPost]
        [Route("edit/userID/{userID}")]
        public string editEmp(empleados empleado, int userID)
        {
            SqlConnection con = new(_configuration.GetConnectionString("ConsultorioApp").ToString());
            SqlCommand cmd = new("UPDATE empleado SET name_empleado='" + empleado.name_empleado + "', email_empleado='" + empleado.email_empleado + "',phone_empleado='" + empleado.phone_empleado + "',password_empleado='" + empleado.password_empleado + "',id_ciudadEmpFK='" + empleado.id_ciudadEmpFK + "',id_turno='" + empleado.id_turno + "',id_puesto='" + empleado.id_puesto + "'WHERE id_empleado='"+ userID +"'", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            response response = new response();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.ErrorMessage = "Success";
                response.body = null;
                return JsonConvert.SerializeObject(response);
            }
            else
            {
                response.StatusCode = 100;
                response.ErrorMessage = "Error";
                response.body = null;
                return JsonConvert.SerializeObject(response);
            }
        }
    }
}
