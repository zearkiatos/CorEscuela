FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build

WORKDIR /app

COPY . /app

CMD dotnet build && \
    dotnet run

# RUN ["tail","-f", "/dev/null"]


# ENTRYPOINT ["dotnet", "/bin/Debug/netcoreapp2.2/CorEscuela.dll"]

