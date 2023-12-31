﻿using Entities.Concrete;

namespace WebUI.Models;

public class ProductListViewModel
{
    public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();

    public Pagination Pagination { get; set; } = new();

    public int TotalCount => Products.Count();

    public int SelectedColorId { get; set; }

}