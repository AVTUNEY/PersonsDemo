# TBC Demo Api

Api to manage persons

## Installation

It is important to install [Docker](https://www.docker.com/products/docker-desktop/).

Depending on which OS you use, you will need to run these scripts.

Windows

```bash
dotnet dev-certs https -ep %USERPROFILE%\.aspnet\https\aspnetapp.pfx -p password
dotnet dev-certs https --trust
```
macOS
```bash
dotnet dev-certs https -ep ${HOME}/.aspnet/https/aspnetapp.pfx -p password
dotnet dev-certs https --trust
```



Open Terminal or Command prompt and run 
```bash
docker compose up -d
```

And you are ready to go.

## Usage

Application by default is hosted at http://localhost:80

to use swagger use http://localhost:80/swagger

### MSSQL Database credentials
```
Host: localhost,18001

User: sa

Password: Admin123
```
