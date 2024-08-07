﻿using System.Collections.Generic;

namespace Nika1337.Library.Domain.Entities;

public class BookCopy : BaseModel
{
    public required BookEdition BookEdition { get; set; }
    public ICollection<BookCopyCheckout> BookCopyCheckouts { get; set; } = [];
}