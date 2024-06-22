using Movies.Application.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Services.Core;
public interface IMoviesService
{
    Task<QueryResultResource<MovieResource>> GetMoviesAsync(int page,string searchQuery);
}
