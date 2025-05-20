using Google.Cloud.PubSub.V1;
using Newtonsoft.Json;
using SweetNest.Services.OrderAPI.Service.IService;
using System;
using System.Threading.Tasks;

namespace SweetNest.Services.OrderAPI.Service
{
    public class GoogleCloudPubService : IGoogleCloudPubService
    {
        private readonly string _projectId;
        private readonly string _topicId;

        public GoogleCloudPubService(string projectId, string topicId)
        {
            _projectId = projectId;
            _topicId = topicId;
        }

        public async Task PublishMessage(object message, string messageType)
        {
            TopicName topicPath = TopicName.FromProjectTopic(_projectId, _topicId);
            PublisherClient publisher = await PublisherClient.CreateAsync(topicPath);

            var jsonMessage = JsonConvert.SerializeObject(message);
            PubsubMessage pubsubMessage = new PubsubMessage
            {
                Data = Google.Protobuf.ByteString.CopyFromUtf8(jsonMessage),
                Attributes =
                {
                    { "CorrelationId", Guid.NewGuid().ToString() },
                    { "message_type", messageType.ToLowerInvariant() }
                }
            };

            try
            {
                await publisher.PublishAsync(pubsubMessage);
                Console.WriteLine($"已發布 {messageType} 訊息到主題 {_topicId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"發布 {messageType} 訊息到主題 {_topicId} 時發生錯誤: {ex.Message}");
                // 視情況處理錯誤，例如重試、記錄等
            }
            finally
            {
                await publisher.ShutdownAsync(TimeSpan.FromSeconds(5));
            }
        }
    }
}