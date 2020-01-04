using System.Collections.Generic;

namespace TikTok.ApiClient
{
    public interface IWrapper<TEntity> where TEntity : IApiEntity
    {
        List<TEntity> List { get; set; }
    }
}
