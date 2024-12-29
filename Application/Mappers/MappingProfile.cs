using AutoMapper;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using MvcCleanArch.Application.DTOs.GenreDtos;
using MvcCleanArch.Application.DTOs.MovieDtos;
using MvcCleanArch.Application.DTOs.UserDtos;
using MvcCleanArch.Domain.Models;

namespace MvcCleanArch.Application.Mappers
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<AppUser, UserDto>();
      CreateMap<UserDto, AppUser>();
      CreateMap<CreateUserDto, AppUser>();
      CreateMap<UpdateUserDto, AppUser>();


      // Map Movie Entity to MovieDto and vice versa
      CreateMap<Movie, MovieDto>();
      CreateMap<MovieDto, Movie>();
      CreateMap<CreateMovieDto, Movie>();
      CreateMap<UpdateMovieDto, Movie>();


      CreateMap<Genre, GenreDto>();
      CreateMap<GenreDto, Genre>();
      CreateMap<CreateGenreDto, Genre>();
      CreateMap<UpdateGenreDto, Genre>();


      // Map MovieUser Entity to MovieUserDto and vice versa
      CreateMap<MovieUser, MovieUserDto>();
      CreateMap<MovieUserDto, MovieUser>();
    }
  }

}