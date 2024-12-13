# ElasticSearch_ELK_NEST

Elasticsearch is a distributed and scalable open-source search and analysis engine. It is a highly flexible tool that enables you to analyze and visualize large volumes of data quickly and in real time. Elasticsearch offers a variety of powerful search features, including sorting, filtering, and text analysis. Additionally, it integrates easily into your code, providing comprehensive client libraries for languages like Java, JavaScript, Ruby, Go, and .NET.

In this demo, I’m utilizing the NEST NuGet package to interact with Elasticsearch. NEST provides seamless integration by allowing direct mapping of .NET objects to Elasticsearch document types.

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

You can view services in the brower 

Elastic search
http://localhost:9200/

Logstash
http://localhost:9600/

Kibana
http://localhost:5601/

# ElasticSearch_ELK_NEST project 
This standard .NET MVC project showcases the New York City Airbnb Open Data. The sample CSV data is ingested into Elasticsearch using Logstash during the initial setup of the dependencies, ensuring that the index and sample data are ready for use in this demo application. 

When you run the project, it will display a list of sample data retrieved from Elasticsearch.

<img width="1777" alt="image" src="https://github.com/user-attachments/assets/229e0779-8e47-48a9-bf36-aade960b5c0e" />

You can search by name 

<img width="1758" alt="image" src="https://github.com/user-attachments/assets/80b4cdef-d235-48b1-b504-e000734c32aa" />
