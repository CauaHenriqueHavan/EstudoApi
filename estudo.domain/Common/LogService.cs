using estudo.domain.Common.Interfaces;
using estudo.domain.Enums;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace estudo.domain.Common
{
    public class LogService : ILogService
    {
        public async Task GravarLogAsync(short id, TipoEventoEnum tipoEvento)
        {
                LogRequestModel request = new( id, tipoEvento);
                string message = JsonConvert.SerializeObject(request);
                EnviarRabbitMq(message);
        }

        public static void EnviarRabbitMq(string log)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "20.72.109.174",
                UserName = "super-app-uuR0bHpHOBu04KCfflvONqrDpRCR4aDk",
                Password = "cz7t1qUkM4uxuiC7Ih63ul8xaGJThZHM0KH",
                VirtualHost = "/"
            };

            using IConnection connection = factory.CreateConnection();
            using IModel model = connection.CreateModel();
            model.QueueDeclarePassive("WebHook.log");
            byte[] bytes = Encoding.UTF8.GetBytes(log);
            model.BasicPublish("", "WebHook.log", null, bytes);
        }
    }
}
