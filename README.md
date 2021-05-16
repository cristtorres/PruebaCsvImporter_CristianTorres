# CSVImporter

CvsImporter es una aplicacion de consola en c#, basicamente para realizar la carga de datos de archivo csv a una DB sql.

## Comenzando 🚀

Clonar la branch Main desde el repositorio [pulse aqui](https://github.com/cristiantorres/PruebaCsvImporter_CristianTorres) 


### Pre-requisitos 📋

instalar net.core 3.1 o superior

### Instalación y ejecucion 🔧
Luego de clonar la solucion desde Github abrir con Visual Studio:
- Compilar la solucion
- Ejecutar via consola dotnet run

A continuacion ya deberia estar disponible la consola para ingresar la ruta del archivo a procesar
Luego de terminar de ejecutar la aplicacion, chequear en la base de datos  adjunta en el proyecto (DBImport.mdf) abrir la tabla Stock
Dicha carpeta se encuentra en la carpeta "..\CsvImporter\Data"

## Ejecutando las pruebas ⚙️

las pruebas automatizadas se generaron con Git Actions para cada push sobre el branch "Main"
Para visualizarlas y ejecutarlas ir a la seccion "Actions" dentro del repositorio [ver build and test](https://github.com/cristiantorres/PruebaCsvImporter_CristianTorres/actions)
Las acciones estan descriptas en el archivo .github/workflows/push.yml
 
## Construido con 🛠️

 
* [Net.core](https://docs.microsoft.com/aspnet/core/) - El framework usado
* [Nuget](https://www.nuget.org/) - Manejador de dependencias
* [Sql Server](https://docs.microsoft.com/en-us/sql/sql-server/) - Usado como DBMS
* [Dapper](https://dapper-tutorial.net/dapper) - Usado como ORM para insertar en la DB

* [EntityFrameworkCore](https://docs.microsoft.com/en-us/ef/core/) - Usado como ORM para la generacion de las tablas involucradas por medio de la Estrategia "Code First"
 
 

## Versionado 📌

Se utilizó [Github](http://semver.org/) para el versionado. Para todas las versiones disponibles,  

## Autores ✒️
 
* **Cristian Torres** - *Desarrollo y testing* -  
 

## Licencia 📄

Este proyecto está bajo la Licencia MIT

 



---
 
