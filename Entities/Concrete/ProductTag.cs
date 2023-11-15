﻿using Core.Entities;

namespace Entities.Concrete;

public class ProductTag :IEntity
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int TagId { get; set; }

    public virtual Product Product { get; set; }

    public virtual Tag Tag { get; set; }
}