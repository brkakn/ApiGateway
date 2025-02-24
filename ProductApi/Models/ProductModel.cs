﻿namespace ProductApi.Models;

public record ProductModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
}
