﻿using System;
using System.Collections.Generic;

namespace Nika1337.Library.ApplicationCore.Entities;
public class Book : BaseModel
{
    public required string Title { get; set; }
    public string? Summary { get; set; }
    public DateTime? OriginalReleaseDate { get; set; }
    public int? MinimumAge { get; set; }
    public required Language OriginalLanguage { get; set; }
    public ICollection<Genre> Genres { get; } = [];
    public ICollection<Author> Authors { get; } = [];
    public ICollection<BookEdition> Editions { get; } = [];
}