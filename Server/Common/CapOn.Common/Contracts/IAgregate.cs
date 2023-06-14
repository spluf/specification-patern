
namespace CapOn.Common.Contracts
{
    public interface IAgregate
    {
        List<IBaseEvent> Processed { get; }
        List<IBaseEvent> Pending { get; }
        int Version { get; }
        void Rebuild(List<ISavedEvent> events);
    }
}
