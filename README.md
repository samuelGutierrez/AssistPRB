# AssistPRB

Pasos para su respectiva instalación

El proyecto se encuentra separado en dos capas una de backend con toda la logica de negocio y conexión a la base de datos
Y otra que es del front con todo lo respectivo a la interfaz de usuario.

# Configuración Base de datos

* El primer paso a realizar es crear una base de datos en el servidor de SQL con el nombre que deseen dar pero dejarlo vacio
* El segundo paso es ir al appsettings.json y poner la cadena de conexión de su base de datos
* El tercer paso es eliminar la carpeta llamada Migrations que esta en Back-Assist.Data
* El cuarto paso es descomentar desde las lineas 68 hasta la 72 en el archivo program.cs
  ![image](https://github.com/samuelGutierrez/AssistPRB/assets/25890975/00ab3698-be47-46d9-8843-0b43f37dcc1c)

* El quinto paso es abrir la consola de administrador de paquetes y ejecutar el comando (**Add-Migration InitDB**) teniendo en cuenta la siguiente imagen:
  ![image](https://github.com/samuelGutierrez/AssistPRB/assets/25890975/3e0f3786-d495-4b57-b06b-78cbc623c75b)

  Esto es lo necesario para tener el backend listo para correr y ejecutarse

  # Iniciar proyecto Front

  * El primer paso es correr el npm install para tener instaladas todas las dependencias necesarias
  * Ejecutar el comando (**npm start**) para así poder ejecutar el Front
  * Modificar el puerto donde se esta ejecutando el backend en el archivo enviroment.ts
    ![image](https://github.com/samuelGutierrez/AssistPRB/assets/25890975/1295fb16-5efe-4029-bc53-ab598604f487)

