FROM mcr.microsoft.com/dotnet/core/sdk:latest AS build
WORKDIR /app
EXPOSE 80

# copy csproj and restore as distinct layers
COPY *.props .
COPY *.sln .

COPY BLL.App/*.csproj ./BLL.App/
COPY BLL.App.DTO/*.csproj ./BLL.App.DTO/
COPY BLL.Base/*.csproj ./BLL.Base/
COPY Contracts.BLL.App/*.csproj ./Contracts.BLL.App/
COPY Contracts.DAL.App/*.csproj ./Contracts.DAL.App/

COPY DAL.App.DTO/*.csproj ./DAL.App.DTO/
COPY DAL.App.EF/*.csproj ./DAL.App.EF/
COPY DAL.Base.EF/*.csproj ./DAL.Base.EF/

COPY Domain.App/*.csproj ./Domain.App/
COPY Extensions/*.csproj ./Extensions/

COPY PublicApi.DTO.V1/*.csproj ./PublicApi.DTO.V1/
COPY Resources/*.csproj ./Resources/
COPY WebApplication/*.csproj ./WebApplication/

RUN dotnet restore

# copy everything else and build app
COPY BLL.App/. ./BLL.App/
COPY BLL.App.DTO/. ./BLL.App.DTO/
COPY BLL.Base/. ./BLL.Base/
COPY Contracts.BLL.App/. ./Contracts.BLL.App/

COPY Contracts.DAL.App/. ./Contracts.DAL.App/
COPY DAL.App.DTO/. ./DAL.App.DTO/
COPY DAL.App.EF/. ./DAL.App.EF/
COPY DAL.Base.EF/. ./DAL.Base.EF/

COPY Domain.App/. ./Domain.App/

COPY Extensions/. ./Extensions/

COPY PublicApi.DTO.V1/. ./PublicApi.DTO.V1/
COPY Resources/. ./Resources/

COPY WebApplication/. ./WebApplication/

WORKDIR /app/WebApplication
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:latest AS runtime
WORKDIR /app
EXPOSE 80
COPY --from=build /app/WebApplication/out ./
ENTRYPOINT ["dotnet", "WebApplication.dll"]

