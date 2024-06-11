﻿

using System;
using System.ComponentModel.DataAnnotations;

namespace Nika1337.Library.Presentation.Models.Genres;

public class GenreViewModel
{
    public int Id { get; set; }

    public required string Name { get; set; }
    public required string Description { get; set; }
    public required DateTime? DeletedDate { get; set; }
}
