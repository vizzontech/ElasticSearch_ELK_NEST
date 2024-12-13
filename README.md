# ElasticSearch_ELK_NEST

Elasticsearch is a distributed and scalable open-source search and analysis engine. It is a highly flexible tool that enables you to analyze and visualize large volumes of data quickly and in real time. Elasticsearch offers a variety of powerful search features, including sorting, filtering, and text analysis. Additionally, it can be easily integrated into your code because it provides extensive client libraries for languages such as Java, JavaScript, Ruby, Go, and .NET.


I am using the NEST NuGet Package in this demo to interact with Elasticsearch. NEST offers flexible integration with Elasticsearch as it can directly map .NET objects to document types.


# Dependencies 
This project has dependencies of the ELK stack running in the docker environment. To deploy the ELK stack clone repository https://github.com/vizzontech/ELK_Docker 

Open the code in VS code, click terminal, and run the docker-compose command 

```
docker-compose up

```
Check if services are running 
```
docker ps --filter "name=elasticsearch" --filter "name=kibana" --filter "name=logstash"

```

