using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;

namespace Nyw.AppExtensions {
    public static class ConsulExtensions {
        public static IApplicationBuilder RegisterConsulService(this IApplicationBuilder app, IApplicationLifetime lifetime, ConsulServiceOptions options) {
            //Action<ServiceEntity> tt = null;

            var consulClient = new ConsulClient(x => x.Address = new Uri($"http://{options.ConsulAddress}:{options.ConsulPort}"));//请求注册的 Consul 地址
            // Register service with consul
            var registration = new AgentServiceRegistration() {
                Checks = new[] {
                    new AgentServiceCheck() {
                        DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),//服务启动多久后注册
                        Interval = TimeSpan.FromSeconds(10),//健康检查时间间隔，或者称为心跳间隔
                        HTTP = $"http://{options.Address}:{options.Port}/api/health",//健康检查地址
                        Timeout = TimeSpan.FromSeconds(5)
                    } },
                ID = Guid.NewGuid().ToString(),
                Name = options.Service,
                Address = options.Address,
                Port = options.Port,
                Tags = new[] { $"urlprefix-/{options.Service}" }//添加 urlprefix-/servicename 格式的 tag 标签，以便 Fabio 识别
            };

            consulClient.Agent.ServiceRegister(registration).Wait();//服务启动时注册，内部实现其实就是使用 Consul API 进行注册（HttpClient发起）
            lifetime.ApplicationStopping.Register(() => {
                consulClient.Agent.ServiceDeregister(registration.ID).Wait();//服务停止时取消注册
            });

            return app;
        }
    }
}