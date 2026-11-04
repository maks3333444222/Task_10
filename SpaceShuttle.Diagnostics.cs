using System;

namespace Practice10
{
    public partial class SpaceShuttle
    {
        // По условию и объявление, и реализация находятся в Diagnostics.cs.
        partial void OnCriticalSystemAlert(string systemName, string message);

        partial void OnCriticalSystemAlert(string systemName, string message)
        {
            ConsoleColor previous = Console.ForegroundColor;
            if (!Console.IsOutputRedirected) Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ТРЕВОГА БК] {systemName}: {message}");
            if (!Console.IsOutputRedirected) Console.ForegroundColor = previous;
        }

        public void CheckSystems()
        {
            Console.WriteLine("Диагностика бортовых систем...");
            if (_fuelKg < 500)
                OnCriticalSystemAlert("Топливная система", "Критический остаток топлива!");
            if (_hullIntegrity < 25)
                OnCriticalSystemAlert("Контур обшивки", "Опасность разрушения корпуса!");
            if (_oxygenHours <= 0)
                OnCriticalSystemAlert("Жизнеобеспечение", "Запас кислорода исчерпан!");
        }

        public void PrintTelemetry()
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine($"Шаттл:        {ShuttleName}");
            Console.WriteLine($"Топливо:      {_fuelKg,8:F1} кг");
            Console.WriteLine($"Кислород:     {_oxygenHours,8:F1} ч");
            Console.WriteLine($"Корпус:       {_hullIntegrity,8}%");
            Console.WriteLine($"Работоспособен: {IsOperational}");
            Console.WriteLine("--------------------------------------------");
        }
    }
}
