# Wait to be sure that SQL Server came up
sleep 10s

# Run the setup script to create the DB and the schema in the DB
# Note: make sure that your password matches what is in the Dockerfile
for i in {1..50};
do
    /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P cGxUH2s2tPKv4aLQ -d master -i setup.sql
    if [ $? -eq 0 ]
    then
        echo "setup.sql completed"
        break
    else
        echo "not ready yet..."
        sleep 5
    fi
done