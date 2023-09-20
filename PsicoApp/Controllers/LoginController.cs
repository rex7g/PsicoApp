using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Dapper;
using PsicoApp.Data;

namespace PsicoApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration) {

            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost] 
        public IActionResult Index(string dni,string password)
        {
            if (string.IsNullOrEmpty(dni) && string.IsNullOrEmpty(password))
            {
                return View();
            }
            string conexion = _configuration.GetConnectionString("CadenaSQL").ToString();
           
            using (var con = new SqlConnection(conexion))
            {
               
                con.Open();
                var queryusuario = $"Select * from USUARIOS where DNI='{dni}'";
                var usuarioEncontrado = con.QueryFirstOrDefault<Usuario>(queryusuario);

                if (dni==usuarioEncontrado.Dni && password==usuarioEncontrado.Password)
                {
                    return RedirectToAction("Index", "Galeria");
                }
                con.Close();
            }
            return View();
                
            
            
        }
        [HttpGet]
        public IActionResult Registro()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Registro(string DNI, string password, string nombre)
        {
            string conexion = _configuration.GetConnectionString("CadenaSQL").ToString();

            using (var con = new SqlConnection(conexion))
            {

                con.Open();
                var queryusuario = $"Insert into USUARIOS(Nombre,Password,DNI) values('{nombre}','{password}','{DNI}')";
                var usuarioEncontrado = con.Execute(queryusuario);
            }

            return RedirectToAction("Index", "Login");
        }
    }
}
