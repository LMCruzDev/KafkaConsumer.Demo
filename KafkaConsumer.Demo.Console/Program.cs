using System;
using Confluent.Kafka;
using static System.Console;

namespace KafkaConsumer.Demo.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Escreva o tópico que deseja ver as mensagens:");
            var topic = ReadLine();

            var config = new ConsumerConfig
            {
                GroupId = "gid-consumers",
                BootstrapServers = "localhost:9092"
            };

            using (var consumer = new ConsumerBuilder<Null,string>(config).Build())
            {
                consumer.Subscribe(topic);
                while(true)
                {
                    var cr = consumer.Consume();
                    WriteLine(cr.Message.Value);
                }
            }
        }
    }
}
