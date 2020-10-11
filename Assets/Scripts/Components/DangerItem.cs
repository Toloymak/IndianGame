namespace Components
{
    public class DangerItem
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public DangerItem(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }
}