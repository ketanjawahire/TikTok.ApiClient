using Newtonsoft.Json;

namespace TikTok.ApiClient
{
    public class RootObject<TWrapper, TEntity> : IRootObject<TWrapper, TEntity>
        where TWrapper : IWrapper<TEntity>
        where TEntity : IApiEntity
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("code")]
        public string code { get; set; }

        [JsonProperty("data")]
        public TWrapper Data { get; set; }
    }
}
