using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PsicoApp.Data;
using System.Net.NetworkInformation;
using System.Net;

namespace PsicoApp.Controllers
{
    public class ConsultaController : Controller
    {
        private readonly IConfiguration _configuration;

        public ConsultaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult Index()
        {
            string conexion = _configuration.GetConnectionString("CadenaSQL").ToString();
            using (var con = new SqlConnection(conexion))
            {

                con.Open();
                var ListaPacientes = $"Select * from PACIENTES";
                var consulta = con.Query<Paciente>(ListaPacientes).ToList();
                return View(consulta);
            }
        }

        [HttpGet]
        public IActionResult AddConsulta()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddConsulta([FromBody] Paciente paciente)
        {
            string conexion = _configuration.GetConnectionString("CadenaSQL").ToString();
            using (var con = new SqlConnection(conexion))
            {

                con.Open();
                var queryusuario = $"Insert into PACIENTES(Nombre,Telefono,DNI,Email,Tipo,Estatus,Fecha) " +
                $"values('{paciente.Nombre}','{paciente.Telefono}','{paciente.Dni}','{paciente.Email}','{paciente.Tipo}','{paciente.Estatus}', GETDATE())";

                if (queryusuario == null)
                {
                    return View();
                }


                var ConsultaInsertada = con.Execute(queryusuario);
                return View(ConsultaInsertada);
            }

        }
        [HttpGet]
        public IActionResult EditConsultabyDNI()
        {
            return View();
        }


        [HttpPost]
        public IActionResult EditConsultabyDNI(string dni, string estatus)
        {
            string conexion = _configuration.GetConnectionString("CadenaSQL").ToString();
            using (var con = new SqlConnection(conexion))
            {

                con.Open();
                var updateQuery = $"Update PACIENTES set Estatus='{estatus}' where Dni='{dni}' ";
                var consultaPorStatus = con.Execute(updateQuery);
                return View(consultaPorStatus);
            }

        }
  
        [HttpPost]
        public IActionResult DeleteConsultabyDNI(string dni)
        {
            string conexion = _configuration.GetConnectionString("CadenaSQL").ToString();
            using (var con = new SqlConnection(conexion))
            {
                con.Open();
                var deleteQuery = $"DELETE FROM PACIENTES WHERE Dni = '{dni}'";
                var registrosEliminados = con.Execute(deleteQuery);
                return View(registrosEliminados);
            }


        }
    }
}
