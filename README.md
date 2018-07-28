# honeycomb

## Requirements
- Visual Studio 2017
- .NET Core 2.0
- Windows 10 v1803
- Docker Version 18.03.1-ce-win65 

## Open Source Projects
- [Ocelot](https://github.com/ThreeMammals/Ocelot)
- [Consul](https://github.com/hashicorp/consul)
	- [Winton.Extensions.Configuration.Consul](https://github.com/wintoncode/Winton.Extensions.Configuration.Consul)
    - [Setup](/env/consul/readme.md)
- [IdentityServer4](https://github.com/IdentityServer/IdentityServer4)
	- [IdentityServer4.EntityFramework](https://github.com/IdentityServer/IdentityServer4.EntityFramework)
- [Serilog](https://github.com/serilog)
	- [Serilog.Serilog](https://github.com/serilog/serilog)
	- [Serilog-aspnetcore](https://github.com/serilog/serilog-aspnetcore)
	- [serilog-sinks-file](https://github.com/serilog/serilog-sinks-file)
	- [serilog-sinks-console](https://github.com/serilog/serilog-sinks-console)
	- [serilog-sinks-elasticsearch](https://github.com/serilog/serilog-sinks-elasticsearch)
- [ELK](https://github.com/elastic/)    
	- [elasticsearch](https://github.com/elastic/elasticsearch)
	- [logstash](https://github.com/elastic/logstash)
	- [kibana](https://github.com/elastic/kibana)
    - [Setup](/env/elk/readme.md)
- [Quartz.NET](https://github.com/quartznet/quartznet)
	- [Documents](https://www.quartz-scheduler.net/documentation/index.html)
- [skywalking](https://github.com/apache/incubator-skywalking)
	- [Client:dotnetcore](https://github.com/OpenSkywalking/skywalking-netcore)
- [Redis](https://github.com/antirez/redis)
	- [StackExchange.Redis](https://github.com/StackExchange/StackExchange.Redis/)
    - [Setup](/env/redis/readme.md)
- [Sonarqube](/devops/sonarqube/readme.md)
- [Jenkins](/devops/jenkins/readme.md)

## Projects Illustrate
- Nyw.ApiGateway：
	- ApiGatewat service, base **Ocelot** and load configuration from **Consul**
- Nyw.Employee：Web API Test Project
	- Consul as configuration source provider
	- Register itself to consul as a service when lunch
- Nyw.Vendor：Web API Test Project
	- Consul as configuration source provider
	- Register itself to consul as a service when lunch
	- Using serilog,write log to Console, File, Elasticsearch
- Nyw.AppExtensions：Class Library
	- .et core middlerware, Consul extension，the app could registry itself to Consul when lunch
- Nyw.IdentityServer：Web API Project for IdentityServer
	- Persisent data to sqlserver using IdentityServer4.EntityFramework
	- Using customize user model
- Nyw.ExchangeRateTask：Console app as Schedule Task, mock to query Exchange Rage Schdulely
	- Use serilog to output log
	- Build simple schedule task using Quartz.NET
	- Quartz.NET work with Serilog
- Nyw.Portal:Customzie USer Protal, plan to consum API
	- add skywalking netcore
	- add redis cache

## Proofed Functions
- Ocelot:
	1. Rounting 
	1. Quality of Service
	1. Rate Limiting
	1. Service Discovery, work with consul
- Consul
	1. Key/Value
	1. Dotnetcore Configuration Provider
	1. Service Registry
	1. Health Check
- IdentityServer:
	1. IdentityServer4.EntityFramework
	1. Customize User Model
- Serilog:
	1. ASP.NET Core 2.x log using Serilog
	1. Output log to console
	1. Output log to file
	1. Output log to Elasticsearch
- ELK:
	1. ELK Docker Compose build quickly
	1. Write log to Elk
	1. Basicly create index and search
- Quartz.NET:
	1. Simple Schedule with Repeat Count or Forever
	1. Work with Serilog
	1. Console host
- Skywalking
	1. Basicly .net core apm and application topology map
- Redis
	1. Basic Usage:connect, add string, read string