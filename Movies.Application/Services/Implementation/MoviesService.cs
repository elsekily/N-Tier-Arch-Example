using AutoMapper;
using Azure;
using Movies.Application.Resources;
using Movies.Application.Services.Core;
using Movies.Core.Entities;
using Movies.DataAccess.Repositories.Core;
using Movies.DataAccess.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Services.Implementation;
public class MoviesService : IMoviesService
{
    private readonly IMapper mapper;
    private readonly IMoviesRepository repository;
    private const int pageSize = 10;
    public MoviesService(IMapper mapper, IMoviesRepository repository)
    {
        this.mapper = mapper;
        this.repository = repository;
    }
    public async Task<QueryResultResource<MovieResource>> GetMoviesAsync(int page, string searchQuery)
    {
        var data = await repository.GetMoviesAsync(page - 1, pageSize,SpecificationFactory(searchQuery));
        var result = mapper.Map<QueryResult<Movie>, QueryResultResource<MovieResource>>(data);
        
        result.Page = page;
        result.TotalPages = data.TotalQueryCount / pageSize + 1;


        return result;
    }
    private ISpecification<Movie> SpecificationFactory(string searchQuery)
    {
        if (searchQuery == null)
            return new Specification<Movie>(null);
        
        
        return new MovieSearchSpecification(searchQuery);
    }

}
