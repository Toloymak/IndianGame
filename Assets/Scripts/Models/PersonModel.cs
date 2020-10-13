using System.Diagnostics;

namespace Components
{
    public class PersonModel
    {
        private float _supplementation;
        private float _power;

        public float Supplementation
        {
            get => _supplementation;
            set
            {
                if (value < 0)
                    _supplementation = 0;
                
                if (value > 100)
                    _supplementation = 100;
                
                _supplementation = value;
            }
        }

        public float Power
        {
            get => _power;
            set => _power = value;
        }
    }
}