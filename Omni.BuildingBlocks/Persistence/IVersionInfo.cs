namespace Omni.BuildingBlocks.Persistence
{
    public interface IVersionInfo
    {
        byte[] RowVersion { get; set; }
    }
}