# Here, we include the dotnet core SDK as the base to build our app
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

# We copy the .csproj of our app to root and 
# restore the dependencies of the project.
WORKDIR /src
COPY Frontend/BlazingPizza.Portal/BlazingPizza.Portal.csproj Frontend/BlazingPizza.Portal/BlazingPizza.Portal.csproj
WORKDIR /src/Frontend/BlazingPizza.Portal
RUN dotnet restore "BlazingPizza.Portal.csproj"

# We proceed by copying all the contents in
# the main project folder to root and build it
WORKDIR /src
COPY Frontend/BlazingPizza.Portal/. Frontend/BlazingPizza.Portal/.
COPY Backend/BlazingPizza.API/swagger.json Backend/BlazingPizza.API/swagger.json
WORKDIR /src/Frontend/BlazingPizza.Portal
RUN dotnet build "BlazingPizza.Portal.csproj" -c Release -o /build --no-restore

# Once we're done building, we'll publish the project
# to the publish folder 
FROM build-env AS publish
RUN dotnet publish "BlazingPizza.Portal.csproj" -c Release -o /publish

# We then get the base image for Nginx and set the 
# work directory 
FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html

# We'll copy all the contents from wwwroot in the publish
# folder into nginx/html for nginx to serve. The destination
# should be the same as what you set in the nginx.conf.
ENV BACKEND_URL 0.0.0.0
ENV PORT 80
COPY --from=publish /publish/wwwroot/. /usr/share/nginx/html/.
COPY Frontend/BlazingPizza.Portal/nginx.conf.template nginx.conf.template
CMD ["/bin/sh" , "-c" , "envsubst < nginx.conf.template > /etc/nginx/nginx.conf && exec nginx -g 'daemon off;'"]