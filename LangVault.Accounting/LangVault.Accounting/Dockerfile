FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["LangVault.Accounting/LangVault.Accounting/LangVault.Accounting.csproj", "LangVault.Accounting/LangVault.Accounting/"]
RUN dotnet restore "LangVault.Accounting/LangVault.Accounting/LangVault.Accounting.csproj"
COPY . .
WORKDIR "/src/LangVault.Accounting/LangVault.Accounting"
RUN dotnet build "LangVault.Accounting.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LangVault.Accounting.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LangVault.Accounting.dll"]
