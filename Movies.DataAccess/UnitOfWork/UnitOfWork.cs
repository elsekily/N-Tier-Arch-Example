using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Movies.Core.Common;
using Movies.DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DataAccess.UnitOfWork;
public class UnitOfWork
{
    private readonly MoviesDbContext context;

    public UnitOfWork(MoviesDbContext context)
    {
        this.context = context;
    }
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}
