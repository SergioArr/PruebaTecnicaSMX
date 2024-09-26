using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaSMX.Models;

namespace PruebaTecnicaSMX.Controllers
{
    [ApiController]
    [Route("smx/[controller]")]
    public class UsuariosController : ControllerBase
    {

        private static List<Usuario> usuarios = new List<Usuario>
        {
            new Usuario { Id = 1, Nombre = "Juan Pérez", CorreoElectronico = "juan.perez@gmail.com", FechaRegistro = new DateTime(2023, 1, 10) },
            new Usuario { Id = 2, Nombre = "Ana Gómez", CorreoElectronico = "ana.gomez@yahoo.com", FechaRegistro = new DateTime(2023, 2, 15) },
            new Usuario { Id = 3, Nombre = "Carlos Sánchez", CorreoElectronico = "carlos.sanchez@hotmail.com", FechaRegistro = new DateTime(2023, 3, 20) },
            new Usuario { Id = 4, Nombre = "María Fernández", CorreoElectronico = "maria.fernandez@outlook.com", FechaRegistro = new DateTime(2023, 4, 25) },
            new Usuario { Id = 5, Nombre = "Luis Rodríguez", CorreoElectronico = "luis.rodriguez@gmail.com", FechaRegistro = new DateTime(2023, 5, 30) }
        };

        // GET: smx/usuarios
        [HttpGet]
        public IActionResult GetUsuarios()
        {
            try
            {
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
                

        // GET: smx/usuarios/{id}
        [HttpGet("{id}")]
        public IActionResult GetUsuario(int id)
        {
            try
            {
                var usuario = usuarios.FirstOrDefault(u => u.Id == id);
                if (usuario == null)
                {
                    return NotFound();
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: smx/usuarios
        [HttpPost]
        public IActionResult AddUsuario([FromBody] Usuario nuevoUsuario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                nuevoUsuario.FechaRegistro = DateTime.Now;
                usuarios.Add(nuevoUsuario);
                return CreatedAtAction(nameof(GetUsuario), new { id = nuevoUsuario.Id }, nuevoUsuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: smx/usuarios/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateUsuario(int id, [FromBody] Usuario usuarioActualizado)
        {
            try
            {
                var usuario = usuarios.FirstOrDefault(u => u.Id == id);
                if (usuario == null)
                {
                    return NotFound();
                }

                usuario.Nombre = usuarioActualizado.Nombre;
                usuario.CorreoElectronico = usuarioActualizado.CorreoElectronico;
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: smx/usuarios/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteUsuario(int id)
        {
            try
            {
                var usuario = usuarios.FirstOrDefault(u => u.Id == id);
                if (usuario == null)
                {
                    return NotFound();
                }

                usuarios.Remove(usuario);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: smx/filtrar/{dominio}
        [HttpGet("filtrar/{dominio}")]
        public IActionResult FiltrarUsuariosPorDominio(string dominio)
        {
            try
            {
                var usuariosFiltrados = Helpers.FiltroUsuario.FiltrarUsuariosPorDominio(usuarios, dominio);

                if (usuariosFiltrados.Count == 0)
                {
                    return NotFound($"No se encontraron usuarios con el dominio '{dominio}'.");
                }

                return Ok(usuariosFiltrados);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
