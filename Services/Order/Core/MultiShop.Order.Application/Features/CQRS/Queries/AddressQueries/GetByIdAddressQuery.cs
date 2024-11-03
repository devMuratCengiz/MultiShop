﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries
{
    public class GetByIdAddressQuery
    {
        public int Id { get; set; }

        public GetByIdAddressQuery(int id)
        {
            Id = id;
        }
    }
}
