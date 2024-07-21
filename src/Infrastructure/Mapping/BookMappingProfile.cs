﻿
using AutoMapper;
using Nika1337.Library.Application.DataTransferObjects.Library;
using Nika1337.Library.Application.DataTransferObjects.Library.Books;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Specifications.Books.Results;
using System.Linq;

namespace Nika1337.Library.Infrastructure.Mapping;

public class BookMappingProfile : Profile
{
    public BookMappingProfile()
    {
        CreateMap<BookCreateRequest, Book>()
            .ForMember(b => b.OriginalLanguage, opts => opts.Ignore())
            .ForMember(b => b.Genres, opts => opts.Ignore())
            .ForMember(b => b.Authors, opts => opts.Ignore())
            .ForMember(b => b.Editions, opts => opts.Ignore());


        CreateMap<BookUpdateRequest, Book>()
            .ForMember(b => b.OriginalLanguage, opts => opts.Ignore())
            .ForMember(b => b.Genres, opts => opts.Ignore())
            .ForMember(b => b.Authors, opts => opts.Ignore())
            .ForMember(b => b.Editions, opts => opts.Ignore());


        CreateMap<Book, BookDetailedResponse>()
            .ForMember(bdr => bdr.GenreIds, opts => opts.MapFrom(b => b.Genres.Select(genre => genre.Id)))
            .ForMember(bdr => bdr.AuthorIds, opts => opts.MapFrom(b => b.Authors.Select(author => author.Id)))
            .ForMember(bdr => bdr.OriginalLanguageId, opts => opts.MapFrom(b => b.OriginalLanguage.Id));

        CreateMap<BookPreviewResult, BookPreviewResponse>();

        CreateMap<AvaliableBookResult, PrimitiveResponse>()
            .ForMember(pr => pr.Name, opts => opts.MapFrom(abr => abr.Title + " By " + string.Join(", ", abr.AuthorNames)));

    }
}
