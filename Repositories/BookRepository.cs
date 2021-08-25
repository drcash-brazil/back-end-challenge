using System;
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
                        private readonly IRepositoryBase<Movement> _movement;   
                        private readonly BackEndContext _context;
                        public BookRepository(BackEndContext context,IRepositoryBase<Movement> movement) : base(context)
                        {
                                    _movement=movement;
                                    _context = context;
                        }
                        public async Task<ResponseView> Books(string _search,int page=0,int limit =0)
                        {
                            var dataRep=await _context.books
                                                  .Include(e=>e.authors)
                                                  .Include(e=>e.generous)
                                                  .AsNoTracking()
                                                  .ToListAsync();
                            var data=_search=="null"?dataRep:dataRep.Where(e=>e.ContainValue(_search)).ToList();
                            var result=limit!=0?data.Skip(page).Take(limit).ToList():data.ToList();         
                            return new ResponseView { data = result, total = data.Count, page = page, limit = limit, totalPage = limit != 0 ? data.Count / limit : 1 };
       
                        }
                       
                        
                        public async Task<Response> AddBook(Books obj)
                        {
                            var data=await get();
                            var book= data.Where(e=>e.genreId==obj.genreId && e.title==obj.title && e.authorId==obj.authorId).FirstOrDefault(); 
                            if(obj.quantity<0)
                                return new Response{data=null,errors=new List<string>{"value step in the amount invalidates!"},status=false};
                            if(obj.price<0 && obj.price==0)
                                return new Response{data=null,errors=new List<string>{"value step in the amount invalidates!"},status=false};    
                            if(book!=null)
                            {  
                                book.quantity=book.quantity+obj.quantity;
                                var updateResult =await update(book);
                                if(updateResult.data!=null)
                                 await _movement.add(new Movement(){operation="deposit", dateCreated=DateTime.Now,quantity=obj.quantity,bookId=updateResult.data.id});
                                return updateResult;
                            }
                            else
                            {
                                var insertResult=await  add(obj); 
                                if(insertResult.data!=null)
                                 await _movement.add(new Movement(){dateCreated=DateTime.Now,quantity=obj.quantity,bookId=insertResult.data.id});
                                return insertResult;
                            }
                                                          
                        }
                        
            }
}