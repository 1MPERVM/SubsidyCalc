using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forBars
{
    class Calculate
    {
        static void Main()
        {
            Test test = new Test();
            Volume volume = new Volume();
            Tariff tariff = new Tariff();

            volume.ServiceId = 1;
            tariff.ServiceId = 3;

            volume.HouseId = 1;
            tariff.HouseId = 1;

            volume.Month = DateTime.Now;
            tariff.PeriodBegin = new DateTime(2020, 11, 21);
            tariff.PeriodEnd = new DateTime(2021, 06, 24);

            volume.Value = 24;
            tariff.Value = 32;


            test.OnNotify += TestOnNotifyBegin;           
            test.OnException += Test_OnException;
            Charge charge = test.CalculateSubsidy(volume, tariff);
            test.OnNotify += TestOnNotifyBegin;
            Console.WriteLine($"{charge.Value}");
           
        }

        private static void Test_OnException(object sender, Tuple<string, Exception> e)
        {
            Console.WriteLine($"Ошибка {e}");
        }

        private static void TestOnNotifyBegin(object sender, string e)
        {
            Console.WriteLine($"Расчет начат-закончен в: {DateTime.Now}");
        }
       
    }
}
