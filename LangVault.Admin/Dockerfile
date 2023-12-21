FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
RUN ls -la
COPY ["LangVault.Admin/LangVault.Admin.csproj", "LangVault.Admin/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Infrastructure.Migrations/Infrastructure.Migrations.csproj", "Infrastructure.Migrations/"]
RUN dotnet restore "./LangVault.Admin/./LangVault.Admin.csproj"
COPY . .
WORKDIR "/src/LangVault.Admin"
RUN dotnet build "./LangVault.Admin.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./LangVault.Admin.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LangVault.Admin.dll"]