﻿using System;
using System.Threading.Tasks;
using Messaging;
using Transport;
using static System.Console;

namespace Server
{
    class Server
    {
        static async Task Main(string[] args)
        {
            var listener = new CQRSListener(new SerializerImpl());

            listener.CommandReceived += async (sender, args) =>
            {
                if (args.Command is MyCommand cmd)
                {
                    WriteLine($"{cmd.Port}  {cmd.Name}");
                }

                await Task.Yield();
            };

            WriteLine($"Server is running");

            while(ReadKey().Key != ConsoleKey.Escape);
            WriteLine("Good bye!");
        }
    }
}