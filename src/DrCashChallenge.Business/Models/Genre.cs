using System.Collections.Generic;

namespace DrCashChallenge.Business.Models
{
    public class Genre : Entity
    {
        public string Name { get; set; }

        #region Navigations Properties
        public ICollection<Book> Books { get; set; }
        #endregion
    }
}
