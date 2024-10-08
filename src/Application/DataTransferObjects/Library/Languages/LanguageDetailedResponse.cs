﻿using System;

namespace Nika1337.Library.Application.DataTransferObjects.Library.Languages;

public class LanguageDetailedResponse
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required DateTime? DeletedDate { get; init; }
}
