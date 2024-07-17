# prueba_solucion

## Acontinuacion la documentacion y la funcion de cada controllador y servicio

### CrearUserController
#### Descripción
Este controlador gestiona las operaciones relacionadas con la creación de nuevos clientes.

#### Métodos
POST /crearcliente
Crea un nuevo cliente con los datos proporcionados en el cuerpo de la solicitud, validando que no exista un cliente con el mismo nit.

---

### VerclientesController
#### Descripción
Este controlador gestiona las operaciones relacionadas con la visualización de clientes, entrega los clientes que estan con estado activo.

#### Métodos
GET /clientes
Obtiene todos los clientes activos.

---

### EliminarController
#### Descripción
Este controlador gestiona las operaciones relacionadas con la eliminación de clientes.

#### Métodos
DELETE /eliminar_cliente/{id}
Elimina un cliente según el ID proporcionado, validando que exista.

---

## FRONTEND
El frontend se realizo usando plantillas de blazor y usando jquery oara manejo del DOM ya que viene por defecto importado y es compatible correctamente

- acontinuación las respectivas funciones de manejo de peticiones y DOM de las vistas

### VISTA INGRESAR CLIENTE

#### INGRESAR CLIENTE ' $("#btnSubmit").click("submit", function (event) { '

Esta funcion captura los datos del formulario valida la estructura de los datos y los envia al controllador de creación luego de esto recibe la respuesta y muestra en pantalla la respuesta del server.

---

#### VALIDAR NUMERICO EN INPUT TELEFONO ' $("#Telefono").on("input", function () { '

Esta funcion bloquea el ingreso de valores no numericos en el input (tambien se valida que sea un datos numerico en la funcion anterior pero por temas de interfaz en mejor no permitirlo para que sea mas facil para el usuario)

---

#### LIMPIAR INPUTS ' function limpiarInputs() ' 

Esta funcion hace la limpieza de los inputs cuando termina la operacion correctamente, esto para mejorar la experiencia de usuario y darle mas dinamismo al usuario que ingresa los datos

### VISTA VER TODO (INCLUYE OPERACION DE ELIMINAR DATO)

#### TRAER CLIENTES ' function getClientes() '

Esta funcion se activo justo cuando el DOM inicia, realiza la peticion al controllador Verclientes y recorre la data obtenida para agregarla al cuerpo de la tabla, ademas de generar los botones de eliminar cliente dinamicamente manejando la funcion que veremos acontinuacion.

---

#### Eliminar Cliente ' function Eliminar(id)  '

Esta funcion recibe un parametro id que se asigna dinamicamente al boton para realizar el eliminado del cliente que se selecciona en la tabla 'onClick=(Eliminar(${res.id})' hace la peticion al controlador eliminar pasando el mismo parametro id y cuando la respuesta es exitosa activa el alert que indica la realizacion correcta de la eliminarción y elimina de la tabla el dato para que el cliente tenga una tabla limpia y evite tener que refrescar, esto ayuda a que el usuario tenga una mejor experiencia.

---

