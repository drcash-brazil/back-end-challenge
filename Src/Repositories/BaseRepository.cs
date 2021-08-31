using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace BibliotecaDrCash.Repository{
    public abstract class BaseRepository{
        protected readonly AppDbContext _context;
        protected readonly ILogger<BaseRepository> _logger;

        public BaseRepository(AppDbContext context,ILogger<BaseRepository> logger) {
            _context = context;
            _logger = logger;
        }
        
        protected async Task SaveAsync(){
            try{
                await _context.SaveChangesAsync();
            }catch(Exception e){
                    _logger.LogError($"[ERROR] {this.GetType().Name}:\n{e.Message}\n{e.StackTrace}");
            }
        }
    }
}