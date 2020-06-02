namespace Omni.BuildingBlocks.Persistence
{
    public interface ILookup<T>
    {
        T Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
    }
}
