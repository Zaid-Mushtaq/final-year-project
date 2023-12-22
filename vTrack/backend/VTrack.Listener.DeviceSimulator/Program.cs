using System;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using VTrack.Listener.Helpers;

namespace VTrack.Listener.DeviceSimulator;

class Program
{
    static void Main(string[] args)
    {
        SimulateMeitrack();
    }


    private static void SimulateMeitrack()
    {
        TcpClient tcpClient = new();
        tcpClient.Connect(IPAddress.Loopback, 3004);
        NetworkStream networkStream = tcpClient.GetStream();


        while (true)
        {
            string date = DateTime.UtcNow.ToString("yyyyMMddHHmmss");

            var location = GetRandomLocation();

            var text =
                $"861983055813336,{date},{location.Item2.ToString("0.000000")},{location.Item1.ToString("0.000000")},0,0,1077,0";

            networkStream.Write(Encoding.UTF8.GetBytes(text));

            Thread.Sleep(5000);
        }
    }

    private static (double, double) GetRandomLocation()
    {
        Random rand = new Random();

        double lat = rand.NextDouble() * 0.0119 + 34.3268451;

        double lon = rand.NextDouble() * 0.0266 + 73.2058907;

        return (lat, lon);
    }
}