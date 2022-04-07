﻿using Catalogue;
using Catalogue.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogue
{
    public static  class Extensions
    {
        public static ItemDto AsDto(this Item item) 
        {
            return new ItemDto(item.Id, item.Name, item.Description, item.Price, item.CreatedDate);
        }
    }
}
