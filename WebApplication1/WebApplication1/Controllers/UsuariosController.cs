using WebApplication1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Dapper;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IConfiguration _Config;
        public UsuariosController(IConfiguration config)
        {
            _Config = config;
        }
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetUsuario()
        {
            using var conexion = new SqlConnection(_Config.GetConnectionString("Mybase"));
            conexion.Open();
            var oUsuario = conexion.Query<Usuario>("ObtenerUsuarios", commandType: System.Data.CommandType.StoredProcedure);
            return Ok (oUsuario);
        }
    }
}
