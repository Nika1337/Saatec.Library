﻿

using Nika1337.Library.Domain.Entities;
using System;

namespace Nika1337.Library.Application.DataTransferObjects.Library.Publishers;

public record PublisherDetailedResponse
{
    public required int Id { get; init; }
    public required int PublisherName { get; init; }
    public required ContactInformation ContactInformation { get; init; }
    public required string? WebsiteAddress { get; init; }
    public required int PublishedBookEditionsCount { get; init; }
    public required DateTime? DeletedDate { get; init; }
}