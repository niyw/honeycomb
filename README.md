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