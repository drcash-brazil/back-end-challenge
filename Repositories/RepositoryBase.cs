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
            public class RepositoryBase<T> : IRepositoryBase<T> where T : Base
            {
                        private readonly BackEndContext _context;
                        public RepositoryBase(BackEndContext context)
                        {
                                    _context = context;
                        }
                        public async Task<Response> add(T model)
                        {
                                    try
                                    {
                                                _context.Add(model);
                                                await _context.SaveChangesAsync();
                                                return new Response { data = model, status = true, message = "registered data!" };

                                    }
                                    catch (Exception ex)
                                    {
                                                return new Response { errors = new List<string> { ex.InnerException.Message }, data = null, status = false, message = "data not registered!" };
                                    }
                        }
                        public async Task<Response> update(T model)
                        {
                                    try
                                    {
                                                _context.Entry(model).State = EntityState.Modified;
                                                await _context.SaveChangesAsync();
                                                return new Response { data = model, status = true, message = "updated data!" };
                                    }
                                    catch (Exception ex)
                                    {
                                                return new Response { errors = new List<string> { ex.InnerException.Message }, data = null, status = false, message = "data not updated!" };
                                    }
                        }
                        public async Task<Response> delete(string id)
                        {
                                    try
                                    {
                                                var obj = await get(id);
                                                if (obj != null)
                                                {
                                                            _context.Remove(obj);
                                                            await _context.SaveChangesAsync();
                                                }
                                                return new Response { data = null, status = true, message = "deleted data!" };
                                    }
                                    catch (Exception ex)
                                    {
                                                return new Response { errors = new List<string> { ex.InnerException.Message }, data = null, status = false, message = "undeleted data!" };
                                    }

                        }
                        public async Task<List<T>> get()
                        {
                                    return await _context.Set<T>()
                                             .AsNoTracking()
                                             .ToListAsync();
                        }
                        public async Task<T> get(string id)
                        {
                                    var obj = await get();
                                    return obj.Where(r => r.id == id).FirstOrDefault();
                        }
                        public async Task<ResponseView> get(int page = 0, int limit = 0)
                        {
                                    var data = await _context.Set<T>().AsNoTracking().ToListAsync(); ;
                                    var result = limit != 0 ? data.Skip(page).Take(limit) : data;
                                    return new ResponseView { data = result, total = data.Count, page = page, limit = limit, totalPage = limit != 0 ? data.Count / limit : 1 };
                        }
                        public async Task<ResponseView> search(string search, int page = 0, int limit = 0)
                        {
                                    var data = await get();
                                    var dataSearch = data.Where(r => r.ContainValue(search)).ToList();
                                    var result = limit != 0 ? dataSearch.Skip(page).Take(limit).ToList() : dataSearch.ToList();
                                    return new ResponseView { data = result, total = dataSearch.Count, page = page, limit = limit, totalPage = limit != 0 ? dataSearch.Count / limit : 1 };
                        }
                         public async Task<List<T>> search(string search)
                        {
                                    var data = await get();
                                    return data.Where(r => r.ContainValue(search)).ToList();
                        }
                        

            }
}