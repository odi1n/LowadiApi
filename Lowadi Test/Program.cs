using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lowadi;

namespace Lowadi_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Work();
            Console.ReadKey();
        }

        static async void Work()
        {
            var openData = File.ReadAllText("data.txt").Split(':');

            LowadiApi lowApi = new LowadiApi();
            var info = await lowApi.Login(openData[0], openData[1]);
            var data = await lowApi.Horse.Sale.GetHorses();
            foreach (var horse in data)
            {
                var test = await lowApi.Horse.Sale.Buy(horse.LinkBuy);
                if (test.Error.Errors != null)
                    break;
                LowadiApi.Equus -= horse.Price;
                Console.WriteLine(LowadiApi.Equus);
            }

            Console.WriteLine(data);
        }
    }
}