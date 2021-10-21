namespace Dal.Models
{
    public class BaseEntity<TId>
    {
        public TId ID { get; set; }
    }
}
