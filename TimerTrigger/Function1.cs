using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace TimerTrigger
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([TimerTrigger("%IntervalTime%",RunOnStartup =true)]TimerInfo myTimer,
            [Queue("timequeue"), StorageAccount("AzureWebJobsStorage")] ICollector<string> msg,
            ILogger log)
        {
            msg.Add("pk");

            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
