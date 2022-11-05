using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Data.contracts
{
    public interface IDataContext
    {
        void SaveChanges();
    }
}
