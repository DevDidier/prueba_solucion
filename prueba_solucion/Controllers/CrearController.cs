using Microsoft.AspNetCore.Mvc;
using prueba_solucion.Models.Services;
using System.Diagnostics;

namespace prueba_solucion.Controllers.Crear
{
    [Route("crearcliente")]
    [ApiController]
    public class CrearUserController : ControllerBase
    {
        private readonly ClientesServices _clientesServices;

        public CrearUserController(ClientesServices clientesServices)
        {
            _clientesServices = clientesServices;
        }

        [HttpPost]
        public IActionResult Post([FromBody] UsuarioRequest request)
        {
            try
            {
                //validamos algunos datos que necesitamos para corregir errores posibles de la vista
                if (request == null || string.IsNullOrEmpty(request.Nombre) || string.IsNullOrEmpty(request.Telefono) ||
                    string.IsNullOrEmpty(request.Correo) || string.IsNullOrEmpty(request.Nit))
                {
                    return StatusCode(404, new { code = 120, msm = "Todos los campos son requeridos" });
                }

                //aqui invocamos el service que contiene la logica que le deseamos agregar para que el controlador solamente sirva para servir los datos a la vista
                var response = _clientesServices.CrearCliente(
                    request.Nombre,
                    request.Telefono,
                    request.Correo,
                    request.Nit,
                    request.Direccion,
                    request.FechaNacimiento
                );
                //capturamos la respuesta de el servicio
                dynamic dynamicResponse = response;
                var status = (int)dynamicResponse.status;
                var code = (int)dynamicResponse.code;
                var msm = (string)dynamicResponse.msm;

                return StatusCode(status, new { code, msm });

            }
            catch (Exception error)
            {
                Debug.WriteLine($"Error controlador Crear: {error}");
                return StatusCode(500, new { code = 130, msm = "Hubo un error" });
            }
        }
    }

    public class UsuarioRequest
    {
        public string ? Nombre { get; set; }
        public string ? Telefono { get; set; }
        public string ? Correo { get; set; }
        public string ? Nit { get; set; }
        public string ? Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}