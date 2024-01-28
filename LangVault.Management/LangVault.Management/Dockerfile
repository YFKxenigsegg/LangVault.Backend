FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["LangVault.Management/LangVault.Management/LangVault.Management.csproj", "LangVault.Management/LangVault.Management/"]
COPY ["LangVault.Management/LangVault.Management.Application/LangVault.Management.Application.csproj", "LangVault.Management/LangVault.Management.Application/"]
COPY ["LangVault.Management/LangVault.Management.Infrastructure/LangVault.Management.Infrastructure.csproj", "LangVault.Management/LangVault.Management.Infrastructure/"]
COPY ["LangVault.Management/LangVault.Management.Domain/LangVault.Management.Domain.csproj", "LangVault.Management/LangVault.Management.Domain/"]
COPY ["LangVault.Management/LangVault.Management.Infrastructure.Migrations/LangVault.Management.Infrastructure.Migrations.csproj", "LangVault.Management/LangVault.Management.Infrastructure.Migrations/"]
RUN dotnet restore "LangVault.Management/LangVault.Management/LangVault.Management.csproj"
COPY . .
WORKDIR "/src/LangVault.Management/LangVault.Management"
RUN dotnet build "LangVault.Management.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LangVault.Management.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LangVault.Management.dll"]