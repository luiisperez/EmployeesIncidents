# EmployeesIncidences

A continuación, tenéis la solución al enunciado que me habéis enviado por correo, la API es funcional haciendo uso de información cargada en memoria al iniciar el servicio. Las instrucciones de uso serán las siguientes:

1.	Clonarse el repositorio.
2.	Ejecutar el servicio web en la modalidad ISS Express.
3.	Al iniciar la ejecución podéis ver mediante Swagger los distintos servicios que ofrece la API con los datos y la forma en que se deben introducir para ejecutar alguno de ellos.


La conexión a la base de datos no está realizada tal y como dice en el enunciado, pero si fuese una aplicación real crearía una interfaz que contenga los datos y métodos comunes para que las clases especificas de acceso a datos de cada objeto herede de ella y los implemente como sea conveniente en cada caso, esto sería basado en el patrón de diseño DAO.
En el directorio script se encuentra el diagrama E/R de la aplicación junto a los scripts de creación de la base de datos y la consulta SQL que está en el punto 1.3 del enunciado. Me gustaría explicar un poco el diagrama ya que en mi modelo he creado una tabla llamada Assignment que se encarga de almacenar las tareas y las incidencias, pero haciendo uso de una columna llamada a_type que es básicamente una columna check que solo permite los valores Tarea e Incidencia.

Este proyecto tiene también un proyecto de test unitarios que se ha hecho sobre los métodos principales que se pidieron exponer en la API. Por último, aquí os dejo las respuestas las preguntas de los puntos 1.2 y 1.4 del enunciado:

  1.2.    Para notificar las otras partes del sistema sobre la inserción en la base de datos de una incidencia se podría tener un trigger en la base de datos que ejecute las acciones necesarias de notificación luego de finalizar la inserción.

  1.4.    De tener que desplegar esta API en un servidor público la mejor forma de proteger que tenga solicitudes indeseadas sería a través de tokens de acceso para así asegurar que la persona/sistema que intenta consumir estos servicios este autorizado.


