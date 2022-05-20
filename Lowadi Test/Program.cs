using System;
using System.IO;
using System.Linq;
using Lowadi;
using Lowadi.Interface;
using Lowadi.Interface.Methods;
using Lowadi.Models;

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

            ILowadiApi lowApi = new LowadiApi();
            var info = await lowApi.Login(openData[0], openData[1]);
            if (info.Errors.Count > 0)
            {
                Console.WriteLine("не удалось авторизоваться");
                return;
            }

            //
            // for (int i = 0; i < 5; i++)
            // {
            //     var data = await lowApi.Horse.Sale.GetHorses();
            //     foreach (var horse in data)
            //     {
            //         var test = await lowApi.Horse.Sale.Buy(horse.LinkBuy);
            //         if (test.Error.Errors != null)
            //             break;
            //         LowadiApi.Equus -= horse.Price;
            //         Console.WriteLine(LowadiApi.Equus);
            //     }
            // }

            // var factories = await lowApi.Horse.GetFactory();
            // var page = await lowApi.Horse.GetAllHorse(factories.Last().Id);

            // var horse = page.Horses.First(x=>x.Id == 52763688);
            await lowApi.Horse.GetHorseInfo(56436614);
            var doSuckle = await lowApi.Horse.DoSuckle();
            doSuckle = await lowApi.Horse.DoCentreMission(56381122);
            doSuckle = await lowApi.Horse.DoEat();
            // doSuckle = await lowApi.Horse.DoDrink();
            // doSuckle = await lowApi.Horse.DoStroke();
            // doSuckle = await lowApi.Horse.DoGroom();
            // doSuckle = await lowApi.Horse.DoEatTreat();
            doSuckle = await lowApi.Horse.DoNight();
            // doSuckle = await lowApi.Horse.DoAge();
            Console.WriteLine("OK");
        }
    }
}