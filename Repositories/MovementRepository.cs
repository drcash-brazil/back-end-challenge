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
                        public async Task<ResponseView> Sales(string _search=null,int page = 0, int limit = 0)
                        {
                                   var dataRep= await _context.movement
                                                          .Include(e => e.book.authors)
                                                          .Include(e => e.book.generous)
                                                          .AsNoTracking()
                                                          .ToListAsync();
                                    var data =_search=="null"? dataRep:dataRep.Where(e=>e.ContainValue(_search));
                                    var dataSale=data.Where(e=>e.operation=="sale").ToList();                       
                                    var result = limit != 0 ? dataSale.Skip(page).Take(limit).ToList() : dataSale.ToList();
                                    return new ResponseView { data = result, total = dataSale.Count, page = page, limit = limit, totalPage = limit != 0 ? dataSale.Count / limit : 1 };

                        }
                        public async Task<ResponseView> Deposits(string _search=null,int page = 0, int limit = 0)
                        {
                                    var dataRep= await _context.movement
                                                          .Include(e => e.book.authors)
                                                          .Include(e => e.book.generous)
                                                          .AsNoTracking()
                                                          .ToListAsync();
                                    var data =_search=="null"? dataRep:dataRep.Where(e=>e.ContainValue(_search));
                                    var dataDeposits=data.Where(e=>e.operation=="deposit").ToList();                      
                                    var result = limit != 0 ? dataDeposits.Skip(page).Take(limit).ToList() : dataDeposits.ToList();
                                    return new ResponseView { data = result, total = dataDeposits.Count, page = page, limit = limit, totalPage = limit != 0 ? dataDeposits.Count / limit : 1 };

                        }
                        public async Task<ResponseView> Movements(string _search=null,int page = 0, int limit = 0)
                        {
                                    var dataRep= await _context.movement
                                                          .Include(e => e.book.authors)
                                                          .Include(e => e.book.generous)
                                                          .AsNoTracking()
                                                          .ToListAsync();
                                    var data =_search=="null"? dataRep:dataRep.Where(e=>e.ContainValue(_search)).ToList();
                                    var result = limit != 0 ? data.Skip(page).Take(limit).ToList() : data.ToList();
                                    return new ResponseView { data = result, total = data.Count, page = page, limit = limit, totalPage = limit != 0 ? data.Count / limit : 1 };

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