using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerData
{
    public interface IUnitOfWork
    {
        Task Commit();
        IDbContextTransaction BeginTransaction();
    }
}
