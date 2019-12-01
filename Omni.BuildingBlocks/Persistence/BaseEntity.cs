namespace Omni.BuildingBlocks.Persistence
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}