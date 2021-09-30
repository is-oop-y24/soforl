namespace Shops.Classes
{
    public class GenerateId
    {
        private int _id = 0;
        public GenerateId()
        {
            Id = ++_id;
        }

        public int Id { get; }
    }
}