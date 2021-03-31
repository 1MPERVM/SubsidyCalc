using System;
using ClassLibrary1;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forBars
{
    class Test : ISubsidyCalculation
    {
        public event EventHandler<string> OnNotify;
        public event EventHandler<Tuple<string, Exception>> OnException;
        public  Charge CalculateSubsidy(Volume volumes, Tariff tariff)
        {
            Charge charge = new Charge();

            Test test = new Test();
            OnNotify?.Invoke(this, $"Расчет начат в: {DateTime.Now}");
            
               if (volumes.ServiceId != tariff.ServiceId)
               {
                   OnException?.Invoke(this, new Tuple<string, Exception>("ServiseId Error", new Exception("ServiseId не совпадают!")));
                   throw new Exception("GG");
               }
               if (volumes.HouseId != tariff.HouseId)
               {
                   OnException?.Invoke(this, new Tuple<string, Exception>("HouseID Error", new Exception("HouseID не совпадают!")));
                   throw new Exception("GG");
               }
               if (volumes.Month > tariff.PeriodEnd || volumes.Month < tariff.PeriodBegin)
               {
                   OnException?.Invoke(this, new Tuple<string, Exception>("Period Error", new Exception("Period Error")));
                   throw new Exception("GG");
               }

                var value = volumes.Value * tariff.Value;
                charge.Value = value;
                charge.Month = volumes.Month;
                charge.HouseId = volumes.HouseId;
                charge.ServiceId = volumes.ServiceId;

                OnNotify?.Invoke(this, $"Расчет окончен в: {DateTime.Now}");
                
                return charge;  

        }
        private void OnNotBeg()
        {
            Console.WriteLine($"Расчет окончен в: {DateTime.Now}");
        }

        
    }
}
