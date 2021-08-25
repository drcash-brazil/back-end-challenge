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
            public class MovementRepository : RepositoryBase<Movement>, IMovementRepository
            {

                        private readonly IBookRepository _book;
                        private readonly BackEndContext _context;
                        public MovementRepository(BackEndContext context, IBookRepository book) : base(context)
                        {
                                    _book = book;
                                    _context = context;
                        }
                        public async Task<ResponseView> Sales(int page = 0, int limit = 0)
                        {
                                    var data = await _context.movement
                                                          .Include(e => e.book.authors)
                                                          .Include(e => e.book.generous)
                                                          .AsNoTracking()
                                                          .ToListAsync();
                                    var result = limit != 0 ? data.Where(e=>e.operation=="sale").Skip(page).Take(limit).ToList() : data.Where(e=>e.operation=="").ToList();
                                    return new ResponseView { data = result, total = data.Count, page = page, limit = limit, totalPage = limit != 0 ? data.Count / limit : 1 };

                        }
                        public async Task<ResponseView> SearchSales(string search, int page = 0, int limit = 0)
                        {
                                    var data = await _context.movement
                                                          .Include(e => e.book.authors)
                                                          .Include(e => e.book.generous)
                                                          .AsNoTracking()
                                                          .ToListAsync();
                                    var dataSearch = data.Where(e => e.ContainValue(search) && e.operation=="sale").ToList();
                                    var result = limit != 0 ? dataSearch.Skip(page).Take(limit).ToList() : dataSearch.ToList();
                                    return new ResponseView { data = result, total = dataSearch.Count, page = page, limit = limit, totalPage = limit != 0 ? dataSearch.Count / limit : 1 };
                        }
                        public async Task<ResponseView> Deposits(int page = 0, int limit = 0)
                        {
                                    var data = await _context.movement
                                                          .Include(e => e.book.authors)
                                                          .Include(e => e.book.generous)
                                                          .AsNoTracking()
                                                          .ToListAsync();
                                    var result = limit != 0 ? data.Where(e=>e.operation=="deposit").Skip(page).Take(limit).ToList() : data.Where(e=>e.operation=="").ToList();
                                    return new ResponseView { data = result, total = data.Count, page = page, limit = limit, totalPage = limit != 0 ? data.Count / limit : 1 };

                        }
                        public async Task<ResponseView> SearchDeposits(string search, int page = 0, int limit = 0)
                        {
                                    var data = await _context.movement
                                                          .Include(e => e.book.authors)
                                                          .Include(e => e.book.generous)
                                                          .AsNoTracking()
                                                          .ToListAsync();
                                    var dataSearch = data.Where(e => e.ContainValue(search) && e.operation=="deposit").ToList();
                                    var result = limit != 0 ? dataSearch.Skip(page).Take(limit).ToList() : dataSearch.ToList();
                                    return new ResponseView { data = result, total = dataSearch.Count, page = page, limit = limit, totalPage = limit != 0 ? dataSearch.Count / limit : 1 };
                        }

                        public async Task<Response> AddSale(Movement obj)
                        {
                                    var book = await _book.get(obj.bookId);
                                    if (obj.quantity < 0)
                                                return new Response { data = null, errors = new List<string> { "value step in the amount invalidates!" }, status = false };

                                    if (book != null)
                                    {
                                                book.quantity = book.quantity - obj.quantity;
                                                obj.operation = "sale";
                                                var insertResult = await add(obj);
                                                if (insertResult.data != null)
                                                            await _book.update(book);
                                                return insertResult;
                                    }
                                    else
                                                return new Response { data = null, errors = new List<string> { "Book does not exist!" }, status = false };
                        }
            }
}