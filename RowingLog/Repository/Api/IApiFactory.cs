using System;

namespace RowingLog.Repository.Api
{
    public interface IApiFactory
    {
        Lazy<T> Api<T>();
    }
}
