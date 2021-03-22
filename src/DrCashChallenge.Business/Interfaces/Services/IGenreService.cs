using DrCashChallenge.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrCashChallenge.Business.Interfaces.Services
{
    public interface IGenreService : IDisposable
    {
        Task Create(Genre genre);
    }
}
