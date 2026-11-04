using System;

namespace Practice10
{
    public partial class SpaceShuttle
    {
        private double _fuelKg;
        private double _oxygenHours;
        private int _hullIntegrity;

        public string ShuttleName { get; set; }
        public double FuelKg
        {
            get { return _fuelKg; }
            set
            {
                if (!double.IsFinite(value)) throw new ArgumentOutOfRangeException(nameof(value));
                _fuelKg = Math.Max(0, value);
            }
        }

        public double OxygenHours
        {
            get { return _oxygenHours; }
            set
            {
                if (!double.IsFinite(value)) throw new ArgumentOutOfRangeException(nameof(value));
                _oxygenHours = Math.Max(0, value);
            }
        }

        public int HullIntegrity
        {
            get { return _hullIntegrity; }
            set { _hullIntegrity = Math.Clamp(value, 0, 100); }
        }

        public bool IsOperational => _hullIntegrity > 15 && _oxygenHours > 0;

        public SpaceShuttle(string name, double fuelKg, double oxygenHours, int hullIntegrity)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Нужно имя.", nameof(name));
            this.ShuttleName = name;
            this.FuelKg = fuelKg;
            this.OxygenHours = oxygenHours;
            this.HullIntegrity = hullIntegrity;
        }
    }
}
