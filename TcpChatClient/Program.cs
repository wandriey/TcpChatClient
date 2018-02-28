using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpChatClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dette er vores Client


            // Localhost kunne også have være en IP-adresse, hvis man ville kommunikere med andre
            //men vi ønsker bare at kunne snakke med vores egen computer, så derfor skriver vi bare localhost

            //Gør serveren istand til at læse beskeder.
            TcpClient clientSocket = new TcpClient("localhost", 6789);

            Stream ns = clientSocket.GetStream();

            for (int i = 0; i < 5; i++)
            {
                StreamWriter streamWriter = new StreamWriter(ns);
                streamWriter.AutoFlush = true;

                string message = Console.ReadLine();
                streamWriter.WriteLine(message);


                //Vi gør vores client kan "read" hvad vores server sender tilbage.
                StreamReader streamReader = new StreamReader(ns);
                string messageTilbage = streamReader.ReadLine();

                Console.WriteLine($"Client: {messageTilbage}");
            }

            //holder programmet 
            Console.ReadLine();            
        }
    }
}
