using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteLabels.Sql
{
    public interface ISqlAccess
    {
        ISqlCommandWrapper CreateStoredProcedure(string sql);
        ISqlCommandWrapper CreateQuery(string sql);
    }
}
