FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app
# copiando csproj e restaurando como layers distintos
COPY src/*.sln .
COPY src/Espetaculo.Domain/*.csproj ./Espetaculo.Domain/
COPY src/Espetaculo.Shared/*.csproj ./Espetaculo.Shared/
COPY src/Espetaculo.ConsoleUI/*.csproj ./Espetaculo.ConsoleUI/
COPY src/Espetaculo.Tests/*.csproj ./Espetaculo.Tests/

RUN dotnet restore 

# copiando os arquivos para suas respectivas pastas
COPY src/Espetaculo.Domain/. ./Espetaculo.Domain/
COPY src/Espetaculo.Shared/. ./Espetaculo.Shared/
COPY src/Espetaculo.ConsoleUI/. ./Espetaculo.ConsoleUI/ 

WORKDIR /app/Espetaculo.ConsoleUI
RUN dotnet publish -c Release -o out
# copia os arquivos do build para a imagem do runtime
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/Espetaculo.ConsoleUI/out .
ENTRYPOINT ["dotnet", "Espetaculos.ConsoleUI.dll"]