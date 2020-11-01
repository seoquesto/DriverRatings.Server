# docker build -f Dockerfile -t app .
# docker run -p 5000:5000 app
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /dotnetapp
COPY ./bin/Release/netcoreapp3.1 .
ENV ASPNETCORE_URLS http://*:5000
ENV ASPNETCORE_ENVIRONMENT Release
ENTRYPOINT dotnet DriverRatings.Api.dll
