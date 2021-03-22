using DrCashChallenge.Business.Interfaces.Repositories;
using DrCashChallenge.Business.Models;
using DrCashChallenge.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrCashChallenge.Data.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(DrCashChallengeContext context) : base(context) { }
    }
}
