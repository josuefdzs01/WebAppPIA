using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;
using System.Text;
using WebAppPIA.Models;

namespace WebAppPIA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class auth : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public auth(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("registerConsul")]
        public string registration(register register)
        {
            SqlConnection con = new(_configuration.GetConnectionString("ConsultorioApp").ToString());
            SqlCommand cmd = new("INSERT INTO consultorio(name_consul,email_consul,phone_consul,password_consul, id_ciudadFK)VALUES('" + register.name_consul+"','"+register.email_consul+"','"+register.phone_consul+"','"+register.password_consul+"','"+register.id_ciudadFK+"')", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            response response = new response();
            if (i> 0)
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
        [Route("loginConsul/user/{user}/password/{password}")]
        public string login(string user, string password)
        {
            SqlConnection con = new(_configuration.GetConnectionString("ConsultorioApp").ToString());
            SqlDataAdapter da = new("SELECT * FROM consultorio WHERE (email_consul = '"+ user +"' AND  password_consul = '"+ password +"')", con);
            DataTable dt = new DataTable();
            response response = new response();
            da.Fill(dt);
            List<consultorio> consulList = new List<consultorio>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    consultorio consul = new consultorio();
                    consul.id_consul = Convert.ToInt32(dt.Rows[i]["id_consul"]);
                    consul.name_consul = Convert.ToString(dt.Rows[i]["name_consul"]);
                    consul.email_consul = Convert.ToString(dt.Rows[i]["email_consul"]);
                    consul.phone_consul = Convert.ToString(dt.Rows[i]["phone_consul"]);
                    consul.created_at = Convert.ToDateTime(dt.Rows[i]["created_at"]);
                    consul.password_consul = Convert.ToString(dt.Rows[i]["password_consul"]);
                    consul.id_ciudadFK = Convert.ToInt32(dt.Rows[i]["id_ciudadFK"]);
                    consulList.Add(consul);
                }
                response.StatusCode = 200;
                response.ErrorMessage = "Success";
                response.body = JsonConvert.SerializeObject(consulList);
                if (consulList.Count > 0)
                {
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
            else
            {
                response.StatusCode = 100;
                response.ErrorMessage = "Error";
                response.body = null;
                return JsonConvert.SerializeObject(response);
            }
        }

        [HttpGet]
        [Route("loginEmpleado/user/{user}/password/{password}")]
        public string loginEmp(string user, string password)
        {
            SqlConnection con = new(_configuration.GetConnectionString("ConsultorioApp").ToString());
            SqlDataAdapter da = new("SELECT * FROM empleado WHERE (email_empleado = '" + user + "' AND  password_empleado = '" + password + "')", con);
            DataTable dt = new DataTable();
            response response = new response();
            da.Fill(dt);
            List<empleados> consulList = new List<empleados>();
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
                response.StatusCode = 200;
                response.ErrorMessage = "Success";
                response.body = JsonConvert.SerializeObject(consulList);
                if (consulList.Count > 0)
                {
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
