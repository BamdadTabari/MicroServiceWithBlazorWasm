﻿using Illegible_Cms_V2.Server.Application.Interfaces.Repositories.Weblog;

namespace Illegible_Cms_V2.Server.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IWeblogPostRepository WeblogPost { get; }
        Task<bool> CommitAsync();
    }
}
