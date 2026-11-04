using System;
using System.Globalization;
using System.Text;

namespace Practice10
{
    public class Program
    {
        public static void Main()
        {
     
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("ru-RU");
            Console.WriteLine("ПРАКТИЧЕСКАЯ №10 • ЧАСТИЧНЫЙ КЛАСС ШАТТЛА");
            SpaceShuttle shuttle = new SpaceShuttle("Буран-Next", 2400.0, 48.0, 100);
            shuttle.PrintTelemetry();
            shuttle.ExecuteOrbitalBurn(15, 8.0);
            shuttle.CheckSystems();
            shuttle.ExecuteOrbitalBurn(60, 15.0);
            shuttle.PerformAtmosphericEntry();
            shuttle.CheckSystems();
            shuttle.PrintTelemetry();
        }
    }
}
