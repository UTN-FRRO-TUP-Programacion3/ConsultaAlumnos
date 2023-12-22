# Pasos para crear el proyecto
- Crear repositorio en Github.
- Crear carpeta local ConsultaAlumnosClean.
- En la consola de comando, dentro de la carpeta ConsultaAlumnosClear
```
git init
git add README.md
git commit -m "first commit"
git branch -M main
git remote add origin https://github.com/efalabrini/ConsultaAlumnosClean.git
git push -u origin main
dotnet new gitignore
mkdir src
cd src
dotnet new webapi -n Web
dotnet new classlib -n "Domain"
dotnet new classlib -n "Application"
dotnet new classlib -n "Infrastructure"
cd ..
dotnet sln ConsultaAlumnosClean.sln add src/**/*.csproj
cd src
dotnet add Application/Application.csproj reference Domain/Domain.csproj
dotnet add Infrastructure/Infrastructure.csproj reference Application/Application.csproj
dotnet add Web/Web.csproj reference Application/Application.csproj
dotnet add Web/Web.csproj reference Infrastructure/Infrastructure.csproj
rm -r **/Class1.cs
```


# Arquitectura del proyecto
![Clear architecture](./docs/images/CleanArchLayers.webp)

Con Clean Architecture, las capas Domain y Application son el centro del diseño. Esto se conoce como el Core del sistema.

La capa Domain contiene la lógica empresarial y los tipos, y la capa Application contiene la lógica de negocio y los tipos. La diferencia es que la lógica empresarial se puede compartir entre varios sistemas, mientras que la lógica de negocio se usa generalmente solo dentro del sistema actual.

El Core no debe depender del acceso a datos ni de otras cuestiones de arquitectura, entonces esas dependencias se invierten. Esto se alcanza agregando interfaces o abstracciones dentro del Core, que son implementadas en las capas exteriores. Por ejemplo, si se quiere implementar el patrón Repositorio, esto se hace agregando la interface en el Core y haciendo la implementación en la capa Infrastructure.

Todas las dependencias fluyen hacia adentro, y el Core no tiene dependencia con ninguna otra capa. Las capas Infrastructure y Presentation dependen del Core, pero no estre ellas.

Fuente: [Clean Architecture with .NET Core: Getting Started](https://jasontaylor.dev/clean-architecture-getting-started/)