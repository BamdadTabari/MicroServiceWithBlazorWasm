using Illegible_Cms_V2.Server.Application.Interfaces;
using Illegible_Cms_V2.Server.Application.Interfaces.Repositories.Weblog;
using Illegible_Cms_V2.Server.Persistence.Repositories.Weblog;

namespace Illegible_Cms_V2.Server.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IWeblogPostRepository WeblogPost { get; }
       
        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            WeblogPost = new WeblogPostRepository(_context);
        }

        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
