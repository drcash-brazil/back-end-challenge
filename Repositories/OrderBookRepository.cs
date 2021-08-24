using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.DbConfig;
using BackEnd.Interface;
using BackEnd.Models;
namespace BackEnd.Repositories
{
            public class OrderBookRepository : RepositoryBase<OrderBooks>, IOrderBookRepository
            {
                        private readonly IBookRepository _book;
                        private readonly BackEndContext _context;
                        public OrderBookRepository(BackEndContext context,IBookRepository book) : base(context)
                        {
                            _book=book;
                                    _context = context;
                        }
                        public async Task<ResponseView> OrderBooks(int page,int limit)
                        {
                            var orders=await get();
                            var result=limit!=0?orders.Skip(page).Take(limit):orders;
                            return new ResponseView{data=result,page=page,limit=limit,totalPage=limit!=0?orders.Count/limit:1,total=orders.Count};
                        }
                        public async Task<Response> AddOrderBook(OrderBooks obj)
                        {
                                    var book = await _book.get(obj.bookId);
                                    if (book.quantity>obj.orderQuantity)
                                    {
                                                return await add(obj);
                                    }
                                    else
                                        return new Response{data=null,errors=new List<string>{"Quantity ordered exceeds quantity available in stock!"},status=false};

                        }
                        public async Task<Response> OrderBookProcess(string id)
                        {
                                    var order = await get(id);
                                    var book=await _book.get(order.bookId);
                                    if (order!=null)
                                    {
                                        order.status="Processed";
                                        book.quantity=book.quantity-order.orderQuantity;
                                               await _book.update(book);
                                              return await update(order);
                                    }
                                    else
                                        return new Response{data=null,errors=new List<string>{"Order does not exist!"},status=false};

                        }
                        public async Task<Response> CanceledOrder(string id)
                        {
                            var order=await get(id);
                            if(order!=null)
                            {
                               return await delete(id);
                            }
                            else
                              return new Response{data=null,errors=new List<string>{"Order does not exist!"},status=false};

                        }

            }
}