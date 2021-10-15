using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UdpMulticastTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var server = new UdpClient();
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse("239.192.0.5"), 60005);
            server.JoinMulticastGroup(IPAddress.Parse("239.192.0.5"));

            string message = "GGA,GG,124.0,4505.35,234,0,0*65";
            while (true)
            {
                await server.SendAsync(Encoding.ASCII.GetBytes(message), message.Length, endpoint);
                Console.WriteLine("Sending data....");
                await Task.Delay(2000);
            }
        }
        
        // RUN THE BELOW IN A SEPARATE PROJECT!
        // private static readonly UdpClient _listener = new UdpClient(60005);
        //
        // static async Task Main(string[] args)
        // {
        //     _listener.JoinMulticastGroup(IPAddress.Parse("239.192.0.5"));
        //     while (true)
        //     {
        //         var result = await _listener.ReceiveAsync();
        //         Console.WriteLine("Message received! " + Encoding.ASCII.GetString(result.Buffer));
        //     }
        // }
    }
}