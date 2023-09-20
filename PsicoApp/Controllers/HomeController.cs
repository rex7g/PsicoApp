using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PsicoApp.Data;
using PsicoApp.Models;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;

namespace PsicoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PSICOAPPContext _context;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger,PSICOAPPContext context, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
       
    }
}