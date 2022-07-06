# Managely

## Requisitos
- ASP .NET 6.0 SDK
- Docker + Docker-Compose

## Setup
1. Clonar el repositorio y pullear los ultimos cambios
2. En el `root` correr el siguiente comando: 
```
docker-compose up -d
```
3. Correr las migraciones ejecutando
```
update-database
```
4. Iniciar el proyecto desde `http://localhost:<port>/swagger` para la API





