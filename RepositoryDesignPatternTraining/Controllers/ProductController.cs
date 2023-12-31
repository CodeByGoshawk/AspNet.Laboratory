﻿using Microsoft.AspNetCore.Mvc;
using RepositoryDesignPatternTraining.Models.DomainModels.PersonAggregates;
using RepositoryDesignPatternTraining.Models.DomainModels.ProductAggregates;
using RepositoryDesignPatternTraining.Models.Services.Contracts;
using RepositoryDesignPatternTraining.Models.Services.Repositories;
using System;

namespace RepositoryDesignPatternTraining.Controllers;

public class ProductController : Controller
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public IActionResult Index()
    {
        if (_productRepository is not null)
        {
            var products = _productRepository.SelectAll();
            return View(products);
        }
        else
        {
            return Problem("Entity set 'TrainingProjectDbContext.Person'  is null.");
        }
    }

    public IActionResult Details(Guid id)
    {
        if (_productRepository is null) return Problem("Entity set 'TrainingProjectDbContext.Person' is null.");

        var product = _productRepository.SelectById(id);
        if (product is not null) return View(product);
        TempData["Index"] = "Product not found";
        return RedirectToAction(nameof(Index));
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Product product)
    {
        if (_productRepository is null) return Problem("Entity set 'TrainingProjectDbContext.Person' is null.");

        var existingProduct = _productRepository.SelectByProductCode(product.ProductCode);
        if (ModelState.IsValid && existingProduct is null)
        {
            _productRepository.Insert(product);
            _productRepository.Save();
            TempData["Index"] = "New product created";
            return RedirectToAction(nameof(Index));
        }
        else if (ModelState.IsValid && existingProduct is not null)
        {
            TempData["Create"] = $"Product with ProductCode : {product.ProductCode} already exist";
            return View();
        }
        else
        {
            return View();
        }
    }

    public IActionResult Update(Guid Id)
    {
        if (_productRepository is null) return Problem("Entity set 'TrainingProjectDbContext.Person' is null.");

        var person = _productRepository.SelectById(Id);
        if (person is null)
        {
            TempData["Index"] = "Product does not exist";
            return RedirectToAction(nameof(Index));
        }
        return View(person);
    }

    [HttpPost]
    public IActionResult Update(Product product)//, Guid Id) what is id ? 
    {
        if (_productRepository is null) return Problem("Entity set 'TrainingProjectDbContext.Person' is null.");

        //if (Id != person.Id) return NotFound(); // Why ???????? 
        var existingProduct = _productRepository.SelectByProductCode(product.ProductCode);
        bool updateCondition = (existingProduct is not null && existingProduct.Id == product.Id) ||
                                existingProduct is null ?
        true : false;

        if (ModelState.IsValid && updateCondition)
        {
            var updatedProduct = _productRepository.SelectById(product.Id);
            updatedProduct.Title = product.Title;
            updatedProduct.Quantity = product.Quantity;
            updatedProduct.UnitPrice = product.UnitPrice;
            updatedProduct.ProductCode = product.ProductCode;
            _productRepository.Update(updatedProduct);
            _productRepository.Save();
            TempData["Index"] = "Update Successful";
            return RedirectToAction(nameof(Index));
        }
        else if (ModelState.IsValid && !updateCondition)
        {
            TempData["Update"] = $"Product with ProductCode : {product.ProductCode} already exist";
            return View(product);
        }
        else
        {
            return View();
        }
    }

    public IActionResult Delete(Guid Id)
    {
        if (_productRepository is null) return Problem("Entity set 'TrainingProjectDbContext.Person' is null.");

        var person = _productRepository.SelectById(Id);
        if (person is null)
        {
            TempData["Index"] = "Product does not exist";
            return RedirectToAction(nameof(Index));
        }
        return View(person);
    }

    [HttpPost]
    public IActionResult Delete(Product product)
    {
        if (_productRepository is null) return Problem("Entity set 'TrainingProjectDbContext.Person' is null.");

        _productRepository.Delete(product);
        _productRepository.Save();

        TempData["Index"] = "Product deleted";
        return RedirectToAction(nameof(Index));
    }
}
