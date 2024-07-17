
using Microsoft.AspNetCore.Mvc;
using prueba_solucion.Controllers.Crear;
using prueba_solucion.Models.Services;
using System.Diagnostics;

namespace VerClientesVierModel
{
    [Route("clientes")]
    [ApiController]
    public class VerclientesController : ControllerBase
    {
        private readonly ClientesServices _clientesServices;

        public VerclientesController(ClientesServices clientesServices)
        {
            _clientesServices = clientesServices;
        }

        [HttpGet]//podemos usar parametros cuando deseemos filtrar los datos
        public IActionResult Get()
        {
            try
            {
                var response = _clientesServices.VerClientes();//llamamos el servicio podriamos enviarle un parametro para filtrar
                //capturamos la respuesta de el servicio
                dynamic dynamicResponse = response;
                var status = (int)dynamicResponse.status;
                var code = (int)dynamicResponse.code;
                var msm = (string)dynamicResponse.msm;
                var data = dynamicResponse.data;

                return StatusCode(status, new { code, msm, data });

            }
            catch (Exception error)
            {
                Debug.WriteLine($"Error controlador Crear: {error}");
                return StatusCode(500, new { code = 130, msm = "Hubo un error" });
            }
        }
    }
}
