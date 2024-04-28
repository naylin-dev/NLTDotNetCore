FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["NLTDotNetCore.RestApi/NLTDotNetCore.RestApi.csproj", "NLTDotNetCore.RestApi/"]
RUN dotnet restore "NLTDotNetCore.RestApi/NLTDotNetCore.RestApi.csproj"
COPY . .
WORKDIR "/src/NLTDotNetCore.RestApi"
RUN dotnet build "NLTDotNetCore.RestApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NLTDotNetCore.RestApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NLTDotNetCore.RestApi.dll"]
