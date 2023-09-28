#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM amazonlinux:2 AS base
WORKDIR /app
RUN rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
Run yum install -y aspnetcore-runtime-6.0
# requires for Amazon linux 2023
#RUN yum install -y libxcrypt-compat
RUN yum install -y libxml2-devel
RUN yum install -y pam-devel
ENV LD_LIBRARY_PATH="/app/clidriver/lib/:/app/clidriver/adm/:/app/bin/Debug/net6.0/clidriver/lib/"

FROM amazonlinux:2 AS build
WORKDIR /src
RUN rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
Run yum install -y dotnet-sdk-6.0
COPY . AmazonLnxApp1/
RUN ls -ltr
Run pwd
#COPY ["AmazonLnxApp1/AmazonLnxApp1.csproj", "AmazonLnxApp1/"]
RUN dotnet restore "AmazonLnxApp1/AmazonLnxApp1.csproj"
COPY . .
WORKDIR "/src/AmazonLnxApp1"
RUN dotnet build "AmazonLnxApp1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AmazonLnxApp1.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AmazonLnxApp1.dll"]