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

        [HttpPost]
        [Route("registerCita")]
        public string registerCita(citaAgendar cita)
        {
            SqlConnection con = new(_configuration.GetConnectionString("ConsultorioApp").ToString());
            SqlCommand cmd = new("INSERT INTO consultas(id_pacConsulta, id_empConsulta, fechaCita, peso, altura, temperatura, padecimiento)VALUES('" + cita.id_pacConsulta + "','" + cita.id_empConsulta + "','" + cita.fechaCita + "','" + cita.peso + "','" + cita.altura + "','" + cita.temperatura + "','" + cita.padecimiento + "')", con);
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
            SqlDataAdapter da = new SqlDataAdapter("select * from DatPac where(id_emp = '" + userID + "')", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<DataPacFull> consulList = new List<DataPacFull>();
            response response = new response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataPacFull pacientes = new DataPacFull();
                    pacientes.id_paciente = Convert.ToInt32(dt.Rows[i]["id_paciente"]);
                    pacientes.nombre_pac = Convert.ToString(dt.Rows[i]["nombre_pac"]);
                    pacientes.email_pac = Convert.ToString(dt.Rows[i]["email_pac"]);
                    pacientes.phone_pac = Convert.ToString(dt.Rows[i]["phone_pac"]);
                    pacientes.fechaNac_pac = Convert.ToString(dt.Rows[i]["fechaNac_pac"]);
                    pacientes.dado_alta = Convert.ToString(dt.Rows[i]["dado_alta"]);
                    pacientes.id_ciudad = Convert.ToInt32(dt.Rows[i]["id_ciudad"]);
                    pacientes.name_city = Convert.ToString(dt.Rows[i]["name_city"]);
                    pacientes.id_contacto = Convert.ToInt32(dt.Rows[i]["id_contacto"]);
                    pacientes.name_cont = Convert.ToString(dt.Rows[i]["name_cont"]);
                    pacientes.email_cont = Convert.ToString(dt.Rows[i]["email_cont"]);
                    pacientes.phone_cont = Convert.ToString(dt.Rows[i]["phone_cont"]);
                    pacientes.dado_altaCont = Convert.ToString(dt.Rows[i]["dado_altaCont"]);
                    pacientes.id_ciudadCont = Convert.ToInt32(dt.Rows[i]["id_ciudadCont"]);
                    pacientes.name_cityCont = Convert.ToString(dt.Rows[i]["name_cityCont"]);
                    pacientes.id_emp = Convert.ToInt32(dt.Rows[i]["id_emp"]);
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

        [HttpGet]
        [Route("getFullPaciente/idConsul/{idConsul}")]
        public string GetFullPacientes(string idConsul)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ConsultorioApp").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * from DatPac where(id_consul = '"+idConsul+"')", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<DataPacFull> consulList = new List<DataPacFull>();
            response response = new response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataPacFull pacientes = new DataPacFull();
                    pacientes.id_paciente = Convert.ToInt32(dt.Rows[i]["id_paciente"]);
                    pacientes.nombre_pac = Convert.ToString(dt.Rows[i]["nombre_pac"]);
                    pacientes.email_pac = Convert.ToString(dt.Rows[i]["email_pac"]);
                    pacientes.phone_pac = Convert.ToString(dt.Rows[i]["phone_pac"]);
                    pacientes.fechaNac_pac = Convert.ToString(dt.Rows[i]["fechaNac_pac"]);
                    pacientes.dado_alta = Convert.ToString(dt.Rows[i]["dado_alta"]);
                    pacientes.id_ciudad = Convert.ToInt32(dt.Rows[i]["id_ciudad"]);
                    pacientes.name_city = Convert.ToString(dt.Rows[i]["name_city"]);
                    pacientes.id_contacto = Convert.ToInt32(dt.Rows[i]["id_contacto"]);
                    pacientes.name_cont = Convert.ToString(dt.Rows[i]["name_cont"]);
                    pacientes.email_cont = Convert.ToString(dt.Rows[i]["email_cont"]);
                    pacientes.phone_cont = Convert.ToString(dt.Rows[i]["phone_cont"]);
                    pacientes.dado_altaCont = Convert.ToString(dt.Rows[i]["dado_altaCont"]);
                    pacientes.id_ciudadCont = Convert.ToInt32(dt.Rows[i]["id_ciudadCont"]);
                    pacientes.name_cityCont = Convert.ToString(dt.Rows[i]["name_cityCont"]);
                    pacientes.id_emp = Convert.ToInt32(dt.Rows[i]["id_emp"]);
                    pacientes.nombre_emp = Convert.ToString(dt.Rows[i]["nombre_emp"]);
                    pacientes.email_emp = Convert.ToString(dt.Rows[i]["email_emp"]);
                    pacientes.phone_emp = Convert.ToString(dt.Rows[i]["phone_emp"]);
                    pacientes.id_emp = Convert.ToInt32(dt.Rows[i]["id_turno"]);
                    pacientes.name_horario = Convert.ToString(dt.Rows[i]["name_horario"]);
                    pacientes.horas = Convert.ToString(dt.Rows[i]["horas"]);
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

        [HttpGet]
        [Route("getAllContacto/emailCont/{email}")]
        public string GetContactoEmerg(string email)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ConsultorioApp").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * from contacto_pac where(email_contacto = '" + email + "')", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<contactoEmerg> consulList = new List<contactoEmerg>();
            response response = new response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    contactoEmerg contacto = new contactoEmerg();
                    contacto.id_contacto = Convert.ToInt32(dt.Rows[i]["id_contacto"]);
                    contacto.name_contacto = Convert.ToString(dt.Rows[i]["name_contacto"]);
                    contacto.email_contacto = Convert.ToString(dt.Rows[i]["email_contacto"]);
                    contacto.phone_contacto = Convert.ToString(dt.Rows[i]["phone_contacto"]);
                    contacto.created_At = Convert.ToDateTime(dt.Rows[i]["created_at"]);
                    contacto.id_ciudadContFK = Convert.ToInt32(dt.Rows[i]["id_ciudadContFK"]);
                    consulList.Add(contacto);
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

        [HttpGet]
        [Route("getPaciente/pacienteID/{email}")]
        public string GetPacienteRecent(string email)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ConsultorioApp").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * from paciente where(email_paciente = '" + email + "')", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<paciente> consulList = new List<paciente>();
            response response = new response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    paciente contacto = new paciente();
                    contacto.id_paciente = Convert.ToInt32(dt.Rows[i]["id_paciente"]);
                    contacto.name_paciente = Convert.ToString(dt.Rows[i]["name_paciente"]);
                    contacto.email_paciente = Convert.ToString(dt.Rows[i]["email_paciente"]);
                    contacto.phone_paciente = Convert.ToString(dt.Rows[i]["phone_paciente"]);
                    contacto.created_At = Convert.ToDateTime(dt.Rows[i]["created_at"]);
                    contacto.id_ciudadPacFK = Convert.ToInt32(dt.Rows[i]["id_ciudadPacFK"]);
                    consulList.Add(contacto);
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

        [HttpDelete]
        [Route("delete/contactoID/{contactoID}/")]
        public string deleteCont(int contactoID)
        {
            SqlConnection con = new(_configuration.GetConnectionString("ConsultorioApp").ToString());
            SqlCommand cmd = new("DELETE FROM contacto_pac WHERE id_contacto='" + contactoID + "'", con);
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

        [HttpDelete]
        [Route("delete/citaID/{citaID}/")]
        public string deleteCita(int citaID)
        {
            SqlConnection con = new(_configuration.GetConnectionString("ConsultorioApp").ToString());
            SqlCommand cmd = new("DELETE FROM consultas WHERE id_consulta='" + citaID + "'", con);
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
            SqlCommand cmd = new("UPDATE paciente SET name_paciente='" + pac.name_paciente + "', email_paciente='" + pac.email_paciente + "', phone_paciente='" + pac.phone_paciente + "', id_ciudadPacFK='" + pac.id_ciudadPacFK + "', id_contacto='" + pac.id_contacto + "', id_empleado='" + pac.id_empleado + "'WHERE id_paciente='" + pacienteID + "'", con);
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
        [Route("edit/contactoID/{id}")]
        public string editCont(contactoEmerg pac, string id)
        {
            SqlConnection con = new(_configuration.GetConnectionString("ConsultorioApp").ToString());
            SqlCommand cmd = new("UPDATE contacto_pac SET name_contacto='" + pac.name_contacto + "', email_contacto='" + pac.email_contacto + "', phone_contacto='" + pac.phone_contacto + "', id_ciudadContFK='" + pac.id_ciudadContFK + "'where id_contacto = '" + id + "'", con);
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
        [Route("edit/citaID/{id}")]
        public string editCita(citaAgendar cita, string id)
        {
            SqlConnection con = new(_configuration.GetConnectionString("ConsultorioApp").ToString());
            SqlCommand cmd = new("UPDATE consultas SET id_pacConsulta='" + cita.id_pacConsulta + "', id_empConsulta='" + cita.id_empConsulta + "', fechaCita='" + cita.fechaCita + "', peso='" + cita.peso + "', altura= '" + cita.altura + "',temperatura= '" + cita.temperatura + "', padecimiento= '" + cita.padecimiento + "', medicamento= '" + cita.medicamento + "' where id_pacConsulta = '" + id + "'", con);
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
        [Route("getConsultas/idConsul/{idConsul}/idDoctor/{idEmp}")]
        public string GetConsultas(string idConsul, string idEmp)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ConsultorioApp").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * from CitaInfo where(id_consul = '" + idConsul+"' and id_empleado = '"+idEmp+"')", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<citaData> citas = new List<citaData>();
            response response = new response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    citaData citasInfo = new citaData();
                    citasInfo.id_consulta = Convert.ToInt32(dt.Rows[i]["id_consulta"]);
                    citasInfo.id_pacConsulta = Convert.ToInt32(dt.Rows[i]["id_pacConsulta"]);
                    citasInfo.name_paciente = Convert.ToString(dt.Rows[i]["name_paciente"]);
                    citasInfo.email_paciente = Convert.ToString(dt.Rows[i]["email_paciente"]);
                    citasInfo.phone_paciente = Convert.ToString(dt.Rows[i]["phone_paciente"]);
                    citasInfo.fechaNac_paciente = Convert.ToString(dt.Rows[i]["fechaNac_paciente"]);
                    citasInfo.id_ciudadPaciente = Convert.ToInt32(dt.Rows[i]["id_ciudadPaciente"]);
                    citasInfo.name_pacCiudad = Convert.ToString(dt.Rows[i]["name_pacCiudad"]);
                    citasInfo.id_pacContacto = Convert.ToInt32(dt.Rows[i]["id_pacContacto"]);
                    citasInfo.name_pacContacto = Convert.ToString(dt.Rows[i]["name_pacContacto"]);
                    citasInfo.email_pacContacto = Convert.ToString(dt.Rows[i]["email_pacContacto"]);
                    citasInfo.phone_pacContacto = Convert.ToString(dt.Rows[i]["phone_pacContacto"]);
                    citasInfo.id_ciudadContFK = Convert.ToInt32(dt.Rows[i]["id_ciudadContFK"]);
                    citasInfo.ciudad_cont = Convert.ToString(dt.Rows[i]["ciudad_cont"]);
                    citasInfo.id_empleado = Convert.ToInt32(dt.Rows[i]["id_empleado"]);
                    citasInfo.name_empleado = Convert.ToString(dt.Rows[i]["name_empleado"]);
                    citasInfo.email_empleado = Convert.ToString(dt.Rows[i]["email_empleado"]);
                    citasInfo.phone_empleado = Convert.ToString(dt.Rows[i]["phone_empleado"]);
                    citasInfo.id_empTurno = Convert.ToInt32(dt.Rows[i]["id_empTurno"]);
                    citasInfo.horario_emp = Convert.ToString(dt.Rows[i]["horario_emp"]);
                    citasInfo.horas_emp = Convert.ToString(dt.Rows[i]["horas_emp"]);
                    citasInfo.id_empPuesto = Convert.ToInt32(dt.Rows[i]["id_empPuesto"]);
                    citasInfo.name_empPuesto = Convert.ToString(dt.Rows[i]["name_empPuesto"]);
                    citasInfo.fechaCita = Convert.ToString(dt.Rows[i]["fechaCita"]);
                    citasInfo.peso = Convert.ToString(dt.Rows[i]["peso"]);
                    citasInfo.altura = Convert.ToString(dt.Rows[i]["altura"]);
                    citasInfo.temperatura = Convert.ToString(dt.Rows[i]["temperatura"]);
                    citasInfo.padecimiento = Convert.ToString(dt.Rows[i]["padecimiento"]);
                    citasInfo.id_consul = Convert.ToInt32(dt.Rows[i]["id_consul"]);
                    citasInfo.name_consul = Convert.ToString(dt.Rows[i]["name_consul"]);
                    citasInfo.email_consul = Convert.ToString(dt.Rows[i]["email_consul"]);
                    citasInfo.phone_consul = Convert.ToString(dt.Rows[i]["phone_consul"]);
                    citas.Add(citasInfo);
                }
            }
            if (citas.Count > 0)
            {
                return JsonConvert.SerializeObject(citas);
            }
            else
            {
                response.StatusCode = 100;
                response.ErrorMessage = "No hay informacion almacenada";
                return JsonConvert.SerializeObject(response);
            }
        }

        [HttpGet]
        [Route("getFullConsultas/idConsul/{idConsul}")]
        public string GetFullConsultas(string idConsul)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ConsultorioApp").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * from CitaInfo where(id_consul = '" + idConsul + "')", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<citaData> citas = new List<citaData>();
            response response = new response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    citaData citasInfo = new citaData();
                    citasInfo.id_consulta = Convert.ToInt32(dt.Rows[i]["id_consulta"]);
                    citasInfo.id_pacConsulta = Convert.ToInt32(dt.Rows[i]["id_pacConsulta"]);
                    citasInfo.name_paciente = Convert.ToString(dt.Rows[i]["name_paciente"]);
                    citasInfo.email_paciente = Convert.ToString(dt.Rows[i]["email_paciente"]);
                    citasInfo.phone_paciente = Convert.ToString(dt.Rows[i]["phone_paciente"]);
                    citasInfo.fechaNac_paciente = Convert.ToString(dt.Rows[i]["fechaNac_paciente"]);
                    citasInfo.id_ciudadPaciente = Convert.ToInt32(dt.Rows[i]["id_ciudadPaciente"]);
                    citasInfo.name_pacCiudad = Convert.ToString(dt.Rows[i]["name_pacCiudad"]);
                    citasInfo.id_pacContacto = Convert.ToInt32(dt.Rows[i]["id_pacContacto"]);
                    citasInfo.name_pacContacto = Convert.ToString(dt.Rows[i]["name_pacContacto"]);
                    citasInfo.email_pacContacto = Convert.ToString(dt.Rows[i]["email_pacContacto"]);
                    citasInfo.phone_pacContacto = Convert.ToString(dt.Rows[i]["phone_pacContacto"]);
                    citasInfo.id_ciudadContFK = Convert.ToInt32(dt.Rows[i]["id_ciudadContFK"]);
                    citasInfo.ciudad_cont = Convert.ToString(dt.Rows[i]["ciudad_cont"]);
                    citasInfo.id_empleado = Convert.ToInt32(dt.Rows[i]["id_empleado"]);
                    citasInfo.name_empleado = Convert.ToString(dt.Rows[i]["name_empleado"]);
                    citasInfo.email_empleado = Convert.ToString(dt.Rows[i]["email_empleado"]);
                    citasInfo.phone_empleado = Convert.ToString(dt.Rows[i]["phone_empleado"]);
                    citasInfo.id_empTurno = Convert.ToInt32(dt.Rows[i]["id_empTurno"]);
                    citasInfo.horario_emp = Convert.ToString(dt.Rows[i]["horario_emp"]);
                    citasInfo.horas_emp = Convert.ToString(dt.Rows[i]["horas_emp"]);
                    citasInfo.id_empPuesto = Convert.ToInt32(dt.Rows[i]["id_empPuesto"]);
                    citasInfo.name_empPuesto = Convert.ToString(dt.Rows[i]["name_empPuesto"]);
                    citasInfo.fechaCita = Convert.ToString(dt.Rows[i]["fechaCita"]);
                    citasInfo.peso = Convert.ToString(dt.Rows[i]["peso"]);
                    citasInfo.altura = Convert.ToString(dt.Rows[i]["altura"]);
                    citasInfo.temperatura = Convert.ToString(dt.Rows[i]["temperatura"]);
                    citasInfo.padecimiento = Convert.ToString(dt.Rows[i]["padecimiento"]);
                    citasInfo.id_consul = Convert.ToInt32(dt.Rows[i]["id_consul"]);
                    citasInfo.name_consul = Convert.ToString(dt.Rows[i]["name_consul"]);
                    citasInfo.email_consul = Convert.ToString(dt.Rows[i]["email_consul"]);
                    citasInfo.phone_consul = Convert.ToString(dt.Rows[i]["phone_consul"]);
                    citas.Add(citasInfo);
                }
            }
            if (citas.Count > 0)
            {
                return JsonConvert.SerializeObject(citas);
            }
            else
            {
                response.StatusCode = 100;
                response.ErrorMessage = "No hay informacion almacenada";
                return JsonConvert.SerializeObject(response);
            }
        }
    }
}
