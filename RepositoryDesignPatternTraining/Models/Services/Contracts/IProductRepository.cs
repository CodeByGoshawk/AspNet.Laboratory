﻿using RepositoryDesignPatternTraining.Models.DomainModels.ProductAggregates;
using RepositoryDesignPatternTraining.Models.Services.Contracts.RepositoryFrameworks;

namespace RepositoryDesignPatternTraining.Models.Services.Contracts;

public interface IProductRepository : IRepository<Product>
{
    Product SelectByProductCode(string productCode);
}
