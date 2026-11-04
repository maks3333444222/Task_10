using System;

namespace Practice10
{
    public partial class SpaceShuttle
    {
        public void ExecuteOrbitalBurn(double burnTimeSeconds, double thrustPower)
        {
            if (!double.IsFinite(burnTimeSeconds) || !double.IsFinite(thrustPower) ||
                burnTimeSeconds < 0 || thrustPower < 0)
                throw new ArgumentOutOfRangeException(nameof(burnTimeSeconds));

            if (!IsOperational)
            {
                Console.WriteLine("Манёвр отменён: шаттл неработоспособен.");
                return;
            }
            double consumption = burnTimeSeconds * thrustPower * 2.5;
            if (!double.IsFinite(consumption) || consumption > _fuelKg)
            {
                Console.WriteLine($"Манёвр отменён: требуется {consumption:F1} кг, доступно {_fuelKg:F1} кг.");
                return;
            }
            _fuelKg -= consumption;
            // 1% за каждые ПОЛНЫЕ 10 секунд; сначала ограничиваем износ.
            int wear = (int)Math.Min(100, Math.Floor(burnTimeSeconds / 10));
            HullIntegrity -= wear;
            Console.WriteLine($"Импульс {burnTimeSeconds:F0} с: расход {consumption:F1} кг, износ {wear}%.");
        }

        public void PerformAtmosphericEntry()
        {
            if (!IsOperational)
            {
                Console.WriteLine("Вход в атмосферу отменён: шаттл неработоспособен.");
                return;
            }
            int damage = Random.Shared.Next(10, 26); // Верхняя граница не включается.
            HullIntegrity -= damage;
            OxygenHours -= 1.5;
            Console.WriteLine($"Вход в атмосферу: повреждение {damage}%, кислород -1,5 ч.");
        }
    }
}
