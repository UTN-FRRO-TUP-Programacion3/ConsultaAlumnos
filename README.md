# Pasos para crear el proyecto
- Crear repositorio en Github.
- Crear carpeta local ConsultaAlumnosClean.
- En la consola de comando, dentro de la carpeta ConsultaAlumnosClear
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


