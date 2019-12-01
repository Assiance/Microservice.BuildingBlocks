namespace Omni.BuildingBlocks.Http.CorrelationId
{
    public interface ICorrelationIdProvider
    {
        string EnsureCorrelationIdPresent();
    }
}