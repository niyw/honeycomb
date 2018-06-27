# honeycomb

## 环境说明
- Visual Studio 2017
- .NET Core 2.0
- Windows 10 v1803
- Docker Version 18.03.1-ce-win65 

## 相关开源项目
- [Ocelot](https://github.com/ThreeMammals/Ocelot)
- [Consul](https://github.com/hashicorp/consul)
- [Winton.Extensions.Configuration.Consul](https://github.com/wintoncode/Winton.Extensions.Configuration.Consul)
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
- [Quartz.NET](https://github.com/quartznet/quartznet)
	- [Documents](https://www.quartz-scheduler.net/documentation/index.html)
- [skywalking](https://github.com/apache/incubator-skywalking)
	- [Client:dotnetcore](https://github.com/OpenSkywalking/skywalking-netcore)

## 项目说明
- Nyw.ApiGateway：基于Ocelot构建的ApiGateway,配置从Consul获取
- Nyw.Employee：测试项目
	- Consul作为配置源
	- 启动时向Consul注册自己
- Nyw.Vendor：测试项目
	- Consul作为配置源
	- 启动时向Consul注册自己
	- 使用serilog,日志输出到Console, File, Elasticsearch
- Nyw.AppExtensions：扩展项目
	- Consul扩展，实现项目启动时自动向Consul注册服务
- Nyw.IdentityServer：认证服务项目
	- 使用IdentityServer4.EntityFramework保存数据到数据库中
	- 使用自定义用户模型
- Nyw.ExchangeRateTask：定期查询汇率任务(计划任务)
	- 控制台程序使用Serilog记录日志
	- 使用Quartz.NET构建计划任务
	- Quartz.NET和Serilog协同工作
- Nyw.Portal:定义门户，计划用于调用API
	- 添加skywalking netcore

## 已验证功能
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