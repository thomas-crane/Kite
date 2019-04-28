using LibKite;
using LibKite.GameData;
using System;
using System.Threading.Tasks;

namespace KiteTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(() =>
            {
                GameData.Load();
                Proxy proxy = new Proxy();
                proxy.Start();
            });
            Console.ReadLine();
        }
    }
}
