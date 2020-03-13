using System.Collections.Generic;

namespace TikTok.ApiClient.Entities
{
    public interface IWrapper<TEntity> where TEntity : IApiEntity
    {
        List<TEntity> List { get; set; }

        PageInfo PageInfo { get; set; }
    }
}
