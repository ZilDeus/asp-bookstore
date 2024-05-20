using AutoMapper;
using BookStoreApi.Dto;
using BookStoreApi.Entities;
namespace BookStoreApi
{
  public class MappingConfig
  {
    public static Mapper InitializeAutomapper()
    {
      var config = new MapperConfiguration(cfg =>
      {
        cfg.CreateMap<Book, BookDto>()
        .ForMember(dto => dto.Author, act => act.MapFrom(book => book.Author.Name))
        .ForMember(dto => dto.Reviews, act => act
            .MapFrom(book => book.Reviews.Select(r => r.Content))
            )
        .ForMember(dto => dto.Reports, act => act
            .MapFrom(book => book.Reports.Select(r => r.Content))
            );

        cfg.CreateMap<Author, AuthorDto>()
        .ForMember(dto => dto.Reviews, act => act
            .MapFrom(author => author.Reviews.Select(r => r.Content))
            )
        .ForMember(dto => dto.Books, act => act
            .MapFrom(author => author.Books.Select(r => r.Title))
            )
        .ForMember(dto => dto.Reports, act => act
            .MapFrom(author => author.Reports.Select(r => r.Content))
            );

        cfg.CreateMap<AppUser, UserDto>()
        .ForMember(dto => dto.Reviews, act => act
            .MapFrom(user => user.Reviews.Select(r => r.Content))
            )
        .ForMember(dto => dto.Books, act => act
            .MapFrom(user => user.Books.Select(r => r.Title))
            )
        .ForMember(dto => dto.Reports, act => act
            .MapFrom(user => user.Reports.Select(r => r.Content))
            );
        cfg.CreateMap<Report, ReportDto>();
        cfg.CreateMap<Review, ReviewDto>();

      });

      var mapper = new Mapper(config);
      return mapper;
    }
  }
}
