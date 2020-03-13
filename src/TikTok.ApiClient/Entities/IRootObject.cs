namespace TikTok.ApiClient.Entities
{
    public interface IRootObject<TWrapper, TEntity> where TWrapper : IWrapper<TEntity> where TEntity : IApiEntity
    {
        string Message { get; set; }
        long code { get; set; }
        TWrapper Data { get; set; }
    }
}
