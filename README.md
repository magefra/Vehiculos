# Vehiculos
Sistema de administrador para utilizar las tecnología de MVC, con roles, sistemas de usuarios, conexión de uno a muchos, muchos a muchos, etc.


# Empezar
 
 1. Agregar la cadena de conexión en el archivo appsetting.json
 ``
 "ConnectionStrings": {
  "DefaultConnection": "<Copia tu conexión aquí>"
}
``

2. Hacer la migración y actualizar la base de datos.
``
add-migration Initial
update-database
``

# Libreriás
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer