﻿using System;

namespace Nika1337.Library.Domain.Specifications.Books.Results;

public class BookPreviewResult
{
    public required int Id { get; init; }
    public required string Title { get; init; }
    public required DateTime OriginalReleaseDate { get; init; }
    public required byte? MinimumAge { get; init; }
    public required int EditionsCount { get; init; }
    public required string OriginalLanguageName { get; init; }
    public required string[] AuthorNames { get; init; }
    public required DateTime? DeletedDate { get; init; }
}
