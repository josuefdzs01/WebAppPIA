using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Data;
using WebAppPIA.Models;

namespace WebAppPIA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class pacienteAPI : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public pacienteAPI(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("registerPaciente")]
        public string registration(paciente pacientes)
        {
            SqlConnection con = new(_configuration.GetConnectionString("ConsultorioApp").ToString());
            SqlCommand cmd = new("INSERT INTO paciente(name_paciente,email_paciente,phone_paciente,fechaNac_paciente,id_ciudadPacFK,id_contacto,id_empleado)VALUES('" + pacientes.name_paciente + "','" + pacientes.email_paciente + "','" + pacientes.phone_paciente + "','" + pacientes.fechaNac_paciente + "','" + pacientes.id_ciudadPacFK + "','" + pacientes.id_contacto + "','" + pacientes.id_empleado + "')", con);
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
        [Route("registerContacto")]
        public string registerContacto(contactoEmerg contacto)
        {
            SqlConnection con = new(_configuration.GetConnectionString("ConsultorioApp").ToString());
            SqlCommand cmd = new("INSERT INTO contacto_pac(name_contacto,email_contacto,phone_contacto,id_ciudadContFK)VALUES('" + contacto.name_contacto + "','" + contacto.email_contacto + "','" + contacto.phone_contacto + "','" + contacto.id_ciudadContFK +"')", con);
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
        [Route("getAllPaciente/userID/{userID}")]
        public string GetPacientes(string userID)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ConsultorioApp").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * from paciente where(id_paciente = '" + userID + "')", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<paciente> consulList = new List<paciente>();
            response response = new response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    paciente pacientes = new paciente();
                    pacientes.id_paciente = Convert.ToInt32(dt.Rows[i]["id_paciente"]);
                    pacientes.name_paciente = Convert.ToString(dt.Rows[i]["name_paciente"]);
                    pacientes.email_paciente = Convert.ToString(dt.Rows[i]["email_paciente"]);
                    pacientes.phone_paciente = Convert.ToString(dt.Rows[i]["phone_paciente"]);
                    pacientes.created_At = Convert.ToDateTime(dt.Rows[i]["created_at"]);
                    pacientes.id_ciudadPacFK = Convert.ToInt32(dt.Rows[i]["id_ciudadPacFK"]);
                    pacientes.id_contacto = Convert.ToInt32(dt.Rows[i]["id_contacto"]);
                    pacientes.id_empleado = Convert.ToInt32(dt.Rows[i]["id_empleado"]);
                    consulList.Add(pacientes);
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
        [Route("delete/pacienteID/{pacienteID}/")]
        public string deleteEmp(int pacienteID)
        {
            SqlConnection con = new(_configuration.GetConnectionString("ConsultorioApp").ToString());
            SqlCommand cmd = new("DELETE FROM paciente WHERE id_paciente='" + pacienteID + "'", con);
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
        [Route("edit/pacienteID/{pacienteID}")]
        public string editEmp(paciente pac, int pacienteID)
        {
            SqlConnection con = new(_configuration.GetConnectionString("ConsultorioApp").ToString());
            SqlCommand cmd = new("UPDATE paciente SET name_paciente='" + pac.name_paciente + "', email_paciente='" + pac.email_paciente + "', phone_paciente='" + pac.phone_paciente + "', fechaNac_paciente='" + pac.fechaNac_paciente + "', id_ciudadPacFK='" + pac.id_ciudadPacFK + "', id_contacto='" + pac.id_contacto + "', id_empleado='" + pac.id_empleado + "'WHERE id_paciente='" + pacienteID + "'", con);
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
