namespace SweetNest.Services.OrderAPI.Service.IService
{
    public interface IGoogleCloudPubService
    {
        Task PublishMessage(object message, string messageType);
    }
}
