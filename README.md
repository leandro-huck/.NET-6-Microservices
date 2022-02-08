# .NET-6-Microservices
Code for Les Jackson's .NET Microservices Course
> https://www.youtube.com/watch?v=DgVjEo3OGBI

![Kubernetes Architecture](kubernetes-architecture.png)

## platform-service
Track all the platforms / systems of a company

###### DB Context
- Development: InMem database
- Production: MSSQL database 

###### Sync Data Services
- Http POST to test inbound connection to CommandService
- gRPC Service responds with all platforms

###### Async Data Services
- RabbitMQ: new platforms are published on the message bus

## command-service
Function as a command line repository for given platforms and systems

###### DB Context
- InMem database

###### Sync Data Services
- gRPC client gets all platforms from PlatformService on startup 

###### Async Data Services
- RabbitMQ: message bus subscription (Published_Platform event)

## K8S
Contains yaml files to apply in Kubernetes
