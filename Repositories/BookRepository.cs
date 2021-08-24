using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.DbConfig;
using BackEnd.Helper;
using BackEnd.Interface;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Repositories
{
            public class BookRepository : RepositoryBase<Books>, IBookRepository
            {
                        private readonly BackEndContext _context;
                        public BookRepository(BackEndContext context) : base(context)
                        {
                                    _context = context;
                        }
                        public async Task<ResponseView> Books(int page=0,int limit =0)
                        {
                            var data=await _context.books
                                                  .Include(e=>e.authors)
                                                  .Include(e=>e.generous)
                                                  .AsNoTracking()
                                                  .ToListAsync();
                            var result=limit!=0?data.Skip(page).Take(limit).ToList():data.ToList();         
                            return new ResponseView { data = result, total = data.Count, page = page, limit = limit, totalPage = limit != 0 ? data.Count / limit : 1 };
       
                        }
                        public async Task<ResponseView> SearchBooks(string search,int page=0,int limit =0)
                        {
                            var data=await _context.books
                                                  .Include(e=>e.authors)
                                                  .Include(e=>e.generous)
                                                  .AsNoTracking()
                                                  .ToListAsync();
                            var dataSearch=data.Where(e=>e.ContainValue(search)).ToList();
                            var result=limit!=0?dataSearch.Skip(page).Take(limit).ToList():dataSearch.ToList();         
                            return new ResponseView { data = result, total = dataSearch.Count, page = page, limit = limit, totalPage = limit != 0 ? dataSearch.Count / limit : 1 };
                        }
            }
}