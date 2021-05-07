using StackExchange.Redis;
using System;

namespace EmailServiceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var redis = ConnectionMultiplexer.Connect("localhost:6379");
            var pubsub = redis.GetSubscriber();
            pubsub.Subscribe("codehaks", (channel, message) => MessageAction(message));
        }

        private static void MessageAction(RedisValue message)
        {
            Console.WriteLine(message + " just registered.");
        }
    }
}
