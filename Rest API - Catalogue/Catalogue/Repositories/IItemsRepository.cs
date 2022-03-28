﻿using Catalogue.Entities;
using System;
using System.Collections.Generic;

namespace Catalogue.Repositories
{
    public interface IItemsRepository
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
        void CreateItem(Item item);

    }
}