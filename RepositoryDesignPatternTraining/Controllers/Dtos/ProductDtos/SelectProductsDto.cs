﻿namespace RepositoryDesignPatternTraining.Controllers.Dtos.ProductDtos;

public class SelectProductsDto
{
    public Guid Id { get; set; }

    public string ProductCode { get; set; }

    public string Title { get; set; }

    public decimal Quantity { get; set; }

    public decimal UnitPrice { get; set; }
}
