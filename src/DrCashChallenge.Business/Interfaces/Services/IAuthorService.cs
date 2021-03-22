using DrCashChallenge.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrCashChallenge.Business.Interfaces.Services
{
    public interface IAuthorService : IDisposable
    {
        Task Create(Author author);
    }
}
