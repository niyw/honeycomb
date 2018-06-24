using Quartz;
using Quartz.Impl;
using Serilog;
using System;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace Nyw.ExchangeRateTask {
    class Program {
        static void Main(string[] args) {

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs\\log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Hello, world!");

            RunTask().GetAwaiter().GetResult();

            Console.WriteLine("Press any key to close the application");
            Console.ReadKey();
        }
        private static async Task RunTask() {
            try {
                //NameValueCollection props = new NameValueCollection {
                //    { "quartz.serializer.type", "binary" }
                //};
                //StdSchedulerFactory factory = new StdSchedulerFactory(props);                
                //IScheduler scheduler = await factory.GetScheduler();

                IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
                await scheduler.Start();

                IJobDetail jobDetail = JobBuilder.Create<HelloJob>()
                    .WithIdentity("helloJob1","group1")
                    .Build();
                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("trigger1", "group1")
                    .StartNow()
                    .WithSimpleSchedule(x => x
                        .WithIntervalInSeconds(10)
                        .WithRepeatCount(5)
                        //.RepeatForever()
                        )
                    .Build();

                await scheduler.ScheduleJob(jobDetail,trigger);

                await Task.Delay(TimeSpan.FromSeconds(60));
                await scheduler.Shutdown();
            }
            catch (SchedulerException sex) {
                await Console.Error.WriteLineAsync(sex.ToString());
            }
            catch (Exception ex) {
                await Console.Error.WriteLineAsync(ex.ToString());
            }
        }
    }
    public class HelloJob : IJob {
        public async Task Execute(IJobExecutionContext context) {
            await Console.Out.WriteLineAsync("Greetings from Hello Job.");
        }
    }
}
