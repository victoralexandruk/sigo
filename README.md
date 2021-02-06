# SIGO (Sistema Integrado de Gestão e Operação)
SIGO é um projeto resultado da especialização em Arquitetura de Software Distribuído.

### Tech
Este projeto utiliza as seguintes tecnologias:

##### Implantação
* Docker (Azure VMs)
* Microsoft SQL Server (Azure SaaS)

##### Web API
* NET Core 3.1 (LTS)

##### Web App
* Vue.js
* Bootstrap
* jQuery

##### Testes
* xUnit

##### CI/CD
* Azure DevOps


### Ambiente de Desenvolvimento
Se desejar rodar o projeto localmente, é necessário os componentes a seguir:

##### Banco de dados local
Crie um container Docker com Microsoft SQL Server 2019 Express e os databases necessários, através de um dos métodos a seguir:

**Dockerfile**
```bash
docker build -f MSSQLServer/Dockerfile -t sigo/mssqlserver:dev .
docker run -p 1433:1433 --name mssqlserver -d sigo/mssqlserver:dev
```

**Manualmente**
```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=cGxUH2s2tPKv4aLQ" -e "MSSQL_PID=Express" -p 1433:1433 --name mssqlserver -d mcr.microsoft.com/mssql/server:2019-CU8-ubuntu-16.04
docker exec -it mssqlserver /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "cGxUH2s2tPKv4aLQ" -Q "CREATE DATABASE DB_NORMAS"
docker exec -it mssqlserver /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "cGxUH2s2tPKv4aLQ" -Q "CREATE DATABASE DB_CONSULTORIAS"
```