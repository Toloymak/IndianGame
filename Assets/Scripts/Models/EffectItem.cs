namespace Components
{
    public class EffectItem
    {
        public string Name { get; set; }
        
        public int Stability { get; set; }
        public int Danger { get; set; }
        public int Gold { get; set; }

        public EffectItem(string name)
        {
            Name = name;
        }
    }
}