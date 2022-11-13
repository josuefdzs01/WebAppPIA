using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Microsoft.Data;
using WebAppPIA.Models;
using System.Data;

namespace WebAppPIA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultorioController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public ConsultorioController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpGet]
        [Route("getAllConsultorio")]
        public string GetConsultorio()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ConsultorioApp").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * from CscCity", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<consultorio> consulList = new List<consultorio>();
            response response = new response(); 
            if(dt.Rows.Count > 0)
            {
                for(int i=0; i < dt.Rows.Count; i++)
                {
                    consultorio consul = new consultorio();
                    consul.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    consul.Nombre = Convert.ToString(dt.Rows[i]["Nombre"]);
                    consul.Correo = Convert.ToString(dt.Rows[i]["Correo"]);
                    consul.Telefono = Convert.ToString(dt.Rows[i]["Telefono"]);
                    consul.Dado_Alta = Convert.ToDateTime(dt.Rows[i]["Dado_Alta"]);
                    consul.Contraseña = Convert.ToString(dt.Rows[i]["Contraseña"]);
                    consul.ID_Ciudad = Convert.ToInt32(dt.Rows[i]["ID_Ciudad"]);
                    consul.Ciudad = Convert.ToString(dt.Rows[i]["Ciudad"]);
                    consulList.Add(consul);
                }
            }
            if(consulList.Count > 0)
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
        [Route("getAllCiudad")]
        public string GetCiudad()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ConsultorioApp").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * from ciudad", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<ciudad> CiudadList = new List<ciudad>();
            response response = new response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ciudad ciudad = new ciudad();
                    ciudad.id_ciudad = Convert.ToInt32(dt.Rows[i]["id_ciudad"]);
                    ciudad.nombre = Convert.ToString(dt.Rows[i]["nombre"]);
                    CiudadList.Add(ciudad);
                }
            }
            if (CiudadList.Count > 0)
            {
                return JsonConvert.SerializeObject(CiudadList);
            }
            else
            {
                response.StatusCode = 100;
                response.ErrorMessage = "No hay informacion almacenada";
                return JsonConvert.SerializeObject(response);
            }
        }

        [HttpGet]
        [Route("getAllPuesto")]
        public string GetPuesto()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ConsultorioApp").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * from puesto", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<puestoEmp> PuestoList = new List<puestoEmp>();
            response response = new response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    puestoEmp puesto = new puestoEmp();
                    puesto.id_puesto = Convert.ToInt32(dt.Rows[i]["id_puesto"]);
                    puesto.name_puesto = Convert.ToString(dt.Rows[i]["name_puesto"]);
                    PuestoList.Add(puesto);
                }
            }
            if (PuestoList.Count > 0)
            {
                return JsonConvert.SerializeObject(PuestoList);
            }
            else
            {
                response.StatusCode = 100;
                response.ErrorMessage = "No hay informacion almacenada";
                return JsonConvert.SerializeObject(response);
            }
        }

        [HttpGet]
        [Route("getAllTurno")]
        public string GetTurno()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ConsultorioApp").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * from turno", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<turnoEmp> TurnoList = new List<turnoEmp>();
            response response = new response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    turnoEmp turno = new turnoEmp();
                    turno.id_turno = Convert.ToInt32(dt.Rows[i]["id_turno"]);
                    turno.horario_turno = Convert.ToString(dt.Rows[i]["horario_turno"]);
                    turno.horas_turno = Convert.ToString(dt.Rows[i]["horas_turno"]);
                    TurnoList.Add(turno);
                }
            }
            if (TurnoList.Count > 0)
            {
                return JsonConvert.SerializeObject(TurnoList);
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
