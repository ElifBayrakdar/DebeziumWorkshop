# DebeziumWorkshop
A project for Debezium with SQL Server with readme descriptions to use it.

# How to use it?
In the docker-compose.yml directory, run below command:

* docker-compose up

Your kafka cluster, debezium and sql server is up now. Well, let's connect the local database server that we created:
	
* Host: localhost
* User: sa
* Password: Pass12&=

If the connection is successful, run the commands in debezium.sql.
Now our database, table, data of the table and debezium tracking of the table stuffs are ready.

Now we can connect our debezium connector that we created with the docker-compose file. The URl is: 
* http://localhost:8083/connectors

Go this url with postman or another tool and POST the data in body in the connector-config file:

![image](https://user-images.githubusercontent.com/2387879/145723637-9eb8ff5c-5112-419e-8534-141978c1f192.png)


Yes, everything is ready to use the stock consumer. Now start the application and do Insert/Update/Delete on the table and the application will consume the tracked changes and write the changes to the console with their before-after values.

Thank you for being here in my repository!
