# Local Docker Services - Connection Details

This document contains connection details and application examples for services running locally using Docker Compose.

---

# Services Connection Details

| Service | Docker Image | Host | Port | Database / Service | Username | Password | Connection String |
|---|---|---|---|---|---|---|---|
| PostgreSQL | `postgres:16-alpine` | localhost | 5432 | mydatabase | root | password | `postgresql://root:password@localhost:5432/mydatabase` |
| MySQL | `mysql:8.4` | localhost | 3306 | mydatabase | root | password | `mysql://root:password@localhost:3306/mydatabase` |
| MongoDB | `mongo:7` | localhost | 27017 | admin | root | password | `mongodb://root:password@localhost:27017` |
| Redis | `redis:7-alpine` | localhost | 6379 | Cache | - | - | `redis://localhost:6379` |
| RabbitMQ | `rabbitmq:3-management-alpine` | localhost | 5672 | Message Queue | guest | guest | `amqp://guest:guest@localhost:5672` |
| RabbitMQ UI | `rabbitmq:3-management-alpine` | localhost | 15672 | Web Console | guest | guest | http://localhost:15672 |
| SQL Server | `mcr.microsoft.com/mssql/server:2022-latest` | localhost | 1433 | master | sa | YourSecurePassword123! | SQL Server Connection String |

---

# 1. PostgreSQL

## Connection Details

```
Host: localhost
Port: 5432
Database: mydatabase
Username: root
Password: password
```

Connection String:

```
Host=localhost;
Port=5432;
Database=mydatabase;
Username=root;
Password=password;
```

---

## Python Example

Install:

```bash
pip install psycopg2-binary
```

Code:

```python
import psycopg2

connection = psycopg2.connect(
    host="localhost",
    port=5432,
    database="mydatabase",
    user="root",
    password="password"
)

cursor = connection.cursor()

cursor.execute(
    "SELECT version();"
)

print(cursor.fetchone())

connection.close()
```

---

## C# Example (.NET)

Install:

```bash
dotnet add package Npgsql
```

Code:

```csharp
using Npgsql;

var connectionString =
    "Host=localhost;" +
    "Port=5432;" +
    "Database=mydatabase;" +
    "Username=root;" +
    "Password=password;";


using var connection = new NpgsqlConnection(connectionString);

connection.Open();

var command = new NpgsqlCommand(
    "SELECT version();",
    connection
);

var result = command.ExecuteScalar();

Console.WriteLine(result);
```

---

# 2. MySQL

## Connection Details

```
Host: localhost
Port: 3306
Database: mydatabase
Username: root
Password: password
```

---

## Python Example

Install:

```bash
pip install mysql-connector-python
```

```python
import mysql.connector

connection = mysql.connector.connect(
    host="localhost",
    port=3306,
    database="mydatabase",
    user="root",
    password="password"
)

cursor = connection.cursor()

cursor.execute(
    "SELECT VERSION();"
)

print(cursor.fetchone())

connection.close()
```

---

## C# Example (.NET)

Install:

```bash
dotnet add package MySql.Data
```

```csharp
using MySql.Data.MySqlClient;


string connectionString =
    "Server=localhost;" +
    "Port=3306;" +
    "Database=mydatabase;" +
    "Uid=root;" +
    "Pwd=password;";


using var connection =
    new MySqlConnection(connectionString);


connection.Open();


var command =
    new MySqlCommand(
        "SELECT VERSION();",
        connection
    );


var result =
    command.ExecuteScalar();


Console.WriteLine(result);
```

---

# 3. MongoDB

## Connection String

```
mongodb://root:password@localhost:27017
```

---

## Python Example

Install:

```bash
pip install pymongo
```

```python
from pymongo import MongoClient


client = MongoClient(
    "mongodb://root:password@localhost:27017"
)


database = client["mydatabase"]

collection = database["customers"]


collection.insert_one(
    {
        "name": "John",
        "city": "Dallas"
    }
)


print(
    collection.find_one()
)
```

---

## C# Example (.NET)

Install:

```bash
dotnet add package MongoDB.Driver
```

```csharp
using MongoDB.Driver;
using MongoDB.Bson;


var client =
    new MongoClient(
        "mongodb://root:password@localhost:27017"
    );


var database =
    client.GetDatabase("mydatabase");


var collection =
    database.GetCollection<BsonDocument>(
        "customers"
    );


var document =
    new BsonDocument
    {
        {"name","John"},
        {"city","Dallas"}
    };


collection.InsertOne(document);


var result =
    collection.Find(
        new BsonDocument()
    ).First();


Console.WriteLine(result);
```

---

# 4. Redis

## Connection

```
Host: localhost
Port: 6379
```

---

## Python Example

Install:

```bash
pip install redis
```

```python
import redis


client = redis.Redis(
    host="localhost",
    port=6379
)


client.set(
    "customer",
    "John"
)


print(
    client.get("customer")
)
```

---

## C# Example (.NET)

Install:

```bash
dotnet add package StackExchange.Redis
```

```csharp
using StackExchange.Redis;


var redis =
    ConnectionMultiplexer.Connect(
        "localhost:6379"
    );


var database =
    redis.GetDatabase();


database.StringSet(
    "customer",
    "John"
);


Console.WriteLine(
    database.StringGet("customer")
);
```

---

# 5. RabbitMQ

## Connection

```
Host: localhost
Port: 5672

Username:
guest

Password:
guest
```

---

## Python Producer Example

Install:

```bash
pip install pika
```

```python
import pika


connection = pika.BlockingConnection(
    pika.ConnectionParameters(
        "localhost"
    )
)


channel = connection.channel()


channel.queue_declare(
    queue="orders"
)


channel.basic_publish(
    exchange="",
    routing_key="orders",
    body="Order Created"
)


connection.close()
```

---

## C# Producer Example

Install:

```bash
dotnet add package RabbitMQ.Client
```

```csharp
using RabbitMQ.Client;
using System.Text;


var factory =
    new ConnectionFactory()
    {
        HostName="localhost",
        Port=5672,
        UserName="guest",
        Password="guest"
    };


using var connection =
    factory.CreateConnection();


using var channel =
    connection.CreateModel();


channel.QueueDeclare(
    queue:"orders",
    durable:false,
    exclusive:false,
    autoDelete:false
);


var message =
    "Order Created";


var body =
    Encoding.UTF8.GetBytes(message);


channel.BasicPublish(
    exchange:"",
    routingKey:"orders",
    body:body
);
```

---

# 6. SQL Server

## Connection Details

```
Server:
localhost,1433

Database:
master

Username:
sa

Password:
YourSecurePassword123!
```

---

## Python Example

Install:

```bash
pip install pyodbc
```

```python
import pyodbc


connection = pyodbc.connect(
    """
    Driver={ODBC Driver 18 for SQL Server};
    Server=localhost,1433;
    Database=master;
    UID=sa;
    PWD=YourSecurePassword123!;
    TrustServerCertificate=yes;
    """
)


cursor = connection.cursor()

cursor.execute(
    "SELECT @@VERSION"
)


print(cursor.fetchone())


connection.close()
```

---

## C# Example (.NET)

Install:

```bash
dotnet add package Microsoft.Data.SqlClient
```

```csharp
using Microsoft.Data.SqlClient;


string connectionString =
"""
Server=localhost,1433;
Database=master;
User Id=sa;
Password=YourSecurePassword123!;
TrustServerCertificate=True;
""";


using var connection =
    new SqlConnection(connectionString);


connection.Open();


var command =
    new SqlCommand(
        "SELECT @@VERSION",
        connection
    );


var result =
    command.ExecuteScalar();


Console.WriteLine(result);
```

---

# Docker Commands

| Action | Command |
|---|---|
| Start services | `docker compose up -d` |
| Stop services | `docker compose down` |
| Remove data | `docker compose down -v` |
| Check containers | `docker ps` |
| View logs | `docker compose logs -f` |

---

# Data Engineering Local Architecture

```
                Applications
                     |
                     |
        -----------------------------
        |            |              |
    PostgreSQL     MongoDB       SQL Server
        |
        |
    RabbitMQ / Kafka
        |
        |
     Spark Processing
        |
        |
     Data Lake / Delta
        |
        |
     Analytics Layer
```

---

# Recommended Next Additions

- Apache Kafka
- Apache Spark
- Jupyter Notebook
- Apache Airflow
- MinIO (S3 / ADLS simulation)
- dbt
- Trino
- Great Expectations