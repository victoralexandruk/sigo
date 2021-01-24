FROM mcr.microsoft.com/mssql/server:2019-CU8-ubuntu-16.04
EXPOSE 1433

USER root

ENV ACCEPT_EULA Y
ENV SA_PASSWORD cGxUH2s2tPKv4aLQ
ENV MSSQL_PID Express

COPY MSSQLServer/setup.sql setup.sql
COPY MSSQLServer/run-initialization.sh run-initialization.sh
COPY MSSQLServer/entrypoint.sh entrypoint.sh

RUN chmod +x entrypoint.sh

CMD /bin/bash ./entrypoint.sh