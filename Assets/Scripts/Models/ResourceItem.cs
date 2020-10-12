namespace Components
{
    public class ResourceItem
    {
        public string Name { get; set; }
        
        public int Stability { get; set; }
        public int Danger { get; set; }
        public int Gold { get; set; }

        public ResourceItem(string name)
        {
            Name = name;
        }
    }
}