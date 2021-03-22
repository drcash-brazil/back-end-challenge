using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrCashChallenge.Business.Models
{
    public class Genre : Entity
    {
        public string Description { get; set; }

        #region Navigations Properties
        public ICollection<Book> Books { get; set; }
        #endregion
    }
}
