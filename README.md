# SIGO (Sistema Integrado de Gestão e Operação)
SIGO é um projeto resultado da especialização em Arquitetura de Software Distribuído.

### Tech
Este projeto utiliza as seguintes tecnologias:
* Docker
* NET Core 3.1 (LTS)
* jQuery


### Desenvolvimento local
Se desejar rodar o projeto localmente, é necessário os componentes a seguir:

Use o seguinte comando para rodar um container Docker com Microsoft SQL Server 2017 Express:
```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=cGxUH2s2tPKv4aLQ" -e "MSSQL_PID=Express" \
-p 1433:1433 \
-d mcr.microsoft.com/mssql/server:2017-latest-ubuntu
```