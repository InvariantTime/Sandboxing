FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ./src/ .
RUN dotnet publish ./Sandboxing.Api/Sandboxing.Api.csproj -c Release -o /.out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /.out .
EXPOSE 8080
EXPOSE 8081
ENTRYPOINT ["dotnet", "Sandboxing.Api.dll"]