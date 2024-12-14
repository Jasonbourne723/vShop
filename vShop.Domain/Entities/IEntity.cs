namespace vShop.Domain.Entities
{
    public class Entity<T>
    {
        public T Id { get; set; }

        public bool Deleted { get; set; } = false;

        public DateTime CraeteTime { get; set; } = DateTime.Now;



        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }
    }

}
