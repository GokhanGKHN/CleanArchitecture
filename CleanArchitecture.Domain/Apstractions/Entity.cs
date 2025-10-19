namespace CleanArchitecture.Domain.Apstractions;

public abstract class Entity
{
    protected Entity()
    {
        Id = Guid.NewGuid().ToString(); 
    }

    public string Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
}
