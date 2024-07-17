using prueba_solucion.Context;
using prueba_solucion.Models.Entities.Clientes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace prueba_solucion.Models.Services
{
    public class ClientesServices
    {
        private readonly AplicacionDbContext _context;

        public ClientesServices(AplicacionDbContext context)
        {
            _context = context;
        }

        public object CrearCliente(string nombre, string telefono, string correo, string nit, string direccion, DateTime fechaNacimiento)
        {
            try
            {
                if (_context.Clientes == null)
                {
                    //validamos posibles errores en contexto
                    return new { status = 500, code = 130, msm = "Error en el servidor: tabla no disponible" };
                }

                //buscamos que no exista un cliente con ese nit
                var clienteExistente = _context.Clientes.FirstOrDefault(c => c.Nit == nit);

                if (clienteExistente == null)
                {
                    var nuevoCliente = new ClientesEntity //ingresamos los datos a la entidad
                    {
                        Nombre = nombre,
                        Telefono = telefono,
                        Correo = correo,
                        Nit = nit,
                        Direccion = direccion,
                        FechaSys = DateTime.Now,
                        FechaNacimiento = fechaNacimiento,
                        Estatus = "activo" // Valor por defecto
                    };

                    _context.Clientes.Add(nuevoCliente);//agregamos
                    int result = _context.SaveChanges();//guardamos cambios

                    if (result > 0)
                    {
                        return new { status = 200, code = 100, msm = "Cliente creado correctamente" };
                    }
                    else
                    {
                        return new { status = 500, code = 130, msm = "No se pudo ingresar el cliente" };
                    }
                }
                else
                {
                    return new { status = 400, code = 110, msm = "Ya existe un cliente con este NIT" };
                }
            }
            catch (Exception error)
            {
                Console.WriteLine($"Error en service crear cliente: {error}");
                return new { status = 500, code = 130, msm = "Error en el servidor al crear el cliente" };
            }
        }

        public object VerClientes()
        {
            try
            {
                if (_context.Clientes == null)
                {
                    return new { status = 500, code = 130, msm = "Error en el servidor: tabla no disponible", data = new List<object>() };
                }
                //filtramos por los clientes activos (prefiero los clientes no eliminarlos sino usar estados para mantener la informacion para futuros usos)
                var clientes = _context.Clientes.Where(c => c.Estatus == "activo").ToList();

                if (clientes != null)
                {
                    return new { status = 200, code = 100, msm = "Ok", data = clientes };
                }
                else
                {
                    return new { status = 400, code = 110, msm = "No se encontraron clientes activos", data = new List<object>() };
                }
            }
            catch (Exception error)
            {
                Console.WriteLine($"Error en service crear cliente: {error}");
                return new { status = 500, code = 130, msm = "Error en el servidor", data = new List<object>() };
            }
        }

        public object EliminarCliente(int id)
        {
            try
            {
                if (_context.Clientes == null)
                {
                    return new { status = 500, code = 130, msm = "Error en el servidor: tabla no disponible", data = new List<object>() };
                }
                //buscamos que exista ese id en la tabla para evitar errores internos y posibles daños en los datos
                var clienteExistente = _context.Clientes.FirstOrDefault(c => c.Id == id);

                if (clienteExistente != null)//validamos que si exista el cliente
                {
                    _context.Clientes.Remove(clienteExistente); //eliminamos la fila
                    _context.SaveChanges(); // guarda los cambios en la base de datos

                    // valida si el cliente fue eliminado correctamente
                    var clienteEliminado = _context.Clientes.FirstOrDefault(c => c.Id == id);
                    if (clienteEliminado == null)//validamos que ya no exista en base de datos
                    {
                        return new { status = 200, code = 0, msm = "Cliente eliminado correctamente" };
                    }
                    else
                    {
                        return new { status = 500, code = 131, msm = "Error: El cliente no se eliminó correctamente" };
                    }
                }
                else
                {
                    return new { status = 404, code = 132, msm = "Error: Cliente no encontrado" };
                }
            }
            catch (Exception error)
            {
                Console.WriteLine($"Error en service crear cliente: {error}");
                return new { status = 500, code = 130, msm = "Error en el servidor al eliminar" };
            }
        }
    }
}
