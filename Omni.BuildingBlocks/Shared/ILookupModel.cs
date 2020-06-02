namespace Omni.BuildingBlocks.Shared
{
    public interface ILookupModel
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
    }
}
