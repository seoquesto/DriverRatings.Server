# docker build -f Dockerfile -t driver-ratings-client .
# docker run -p 5000:5000 driver-ratings-client
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /dotnetapp
COPY ./bin/Docker .
ENV ASPNETCORE_URLS http://*:5000
ENV ASPNETCORE_ENVIRONMENT docker
ENTRYPOINT dotnet DriverRatings.Server.Api.dll
