# 蜂巢

## 环境说明
- Visual Studio 2017
- .NET Core 2.0
- Windows 10 v1803
- Docker Version 18.03.1-ce-win65 

## 相关开源项目
- [Ocelot](https://github.com/ThreeMammals/Ocelot)
- [Consul](https://github.com/hashicorp/consul)
	- [Winton.Extensions.Configuration.Consul](https://github.com/wintoncode/Winton.Extensions.Configuration.Consul)
    - [安装](/env/consul/readme.md)
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
    - [安装](/env/elk/readme.md)
- [Quartz.NET](https://github.com/quartznet/quartznet)
	- [Documents](https://www.quartz-scheduler.net/documentation/index.html)
- [skywalking](https://github.com/apache/incubator-skywalking)
	- [Client:dotnetcore](https://github.com/OpenSkywalking/skywalking-netcore)
- [Redis](https://github.com/antirez/redis)
	- [StackExchange.Redis](https://github.com/StackExchange/StackExchange.Redis/)
    - [安装](/env/redis/readme.md)
- [Sonarqube](/devops/sonarqube/readme.md)
- [Jenkins](/devops/jenkins/readme.md)

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
	- 添加Redis缓存

## 已验证功能
- Ocelot:
	1. 路由 
	1. 服务质量
	1. 使用限制
	1. 服务发现,使用consul
- Consul
	1. K/V存储
	1. Dotnetcore 配置提供程序
	1. 服务注册
	1. 健康检查
- IdentityServer:
	1. 使用IdentityServer4.EntityFramework存储数据到数据库
	1. 自定义用户模型
- Serilog:
	1. ASP.NET Core 2.x使用Serilog记录日志
	1. 输出日志到控制台
	1. 输出日志到文件
	1. 输出日志到Elasticsearch
- ELK:
	1. 使用ELK Docker Compose快速构建环境
	1. 输出日志到Elk
	1. 创建基本索引和查询
- Quartz.NET:
	1. 构建简单的计划任务，重复有限次数和无限次重复
	1. 和Serilog协同工作
	1. 使用控制台运行
- Skywalking
	1. ASP.NET Core 的APM和应用程序拓扑图
- Redis
	1. 基本操作：连接，添加字符串，读取字符串