using Microsoft.AspNetCore.Mvc;
using prueba_solucion.Models.Services;
using System.Diagnostics;

namespace prueba_solucion.Controllers.Eliminar
{
    [Route("eliminar_cliente")]
    [ApiController]
    public class EliminarController : ControllerBase
    {
        private readonly ClientesServices _clientesServices;

        public EliminarController(ClientesServices clientesServices)
        {
            _clientesServices = clientesServices;
        }

        [HttpDelete("{id}")]//podemos usar parametros cuando deseemos filtrar los datos
        public IActionResult Delete(int id)
        {
            try
            {
                var response = _clientesServices.EliminarCliente(id);//llamamos el servicio podriamos enviarle un parametro para filtrar
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
}
