﻿using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.RequestFeatures;
using Nika1337.Library.Domain.Specifications.Rooms.Results;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Nika1337.Library.Domain.Specifications.Rooms;

public class RoomsSpecification : BaseModelsSpecification<Room, RoomResult>
{
    protected override Expression<Func<Room, string>>[] FieldSelectors => [room => room.RoomNumber];

    public RoomsSpecification(BaseModelSpecificationParameters<Room> parameters) : base(parameters)
    {

        Query.Select(room => new RoomResult
        {
            Id = room.Id,
            RoomNumber = room.RoomNumber,
            MaxCapacityOfPeople = room.MaxCapacityOfPeople,
            Floor = room.Floor,
            EditionsCount = room.BookEditions.Count(be => be.DeletedDate == null),
            IsActive = room.DeletedDate == null
        });
    }
}
