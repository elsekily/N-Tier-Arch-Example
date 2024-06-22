using AutoMapper;
using Movies.Application.Resources;
using Movies.Core.Entities;

namespace Movies.Application.MappingProfiles;
public class MoviesProfile : Profile
{
    public MoviesProfile()
    {
        CreateMap<Movie, MovieResource>();
        CreateMap(typeof(QueryResult<>), typeof(QueryResultResource<>));
    }
}