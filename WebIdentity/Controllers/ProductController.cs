﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.ProductFeatures.Commands;
using Application.Features.ProductFeatures.Queries;
using Application.Features.UnitFeatures.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace WebIdentity.Controllers
{

    [Route("[controller]")]
    public class ProductController : Controller
    {
        public IMediator _mediator;

        //ApplicationDbContext db = new ApplicationDbContext();

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet ("Create")]
        public async Task<IActionResult> Create()
        {
            var model = await _mediator.Send(new GetAllUnitsQuery());

            SelectList teams = new SelectList(model, "Id", "Name");
            ViewBag.Units = teams;

            //ViewBag.Units  = new SelectList(model, "Id", "Name");
            //var users = Units.Include(u => u.Company).ToList();
            return View();
        }
        /// <summary>
        /// Creates a New Product.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            
            await _mediator.Send(command);
            
            return RedirectToActionPermanent("Index");

        }
        /// <summary>
        /// Gets all Products.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = (await _mediator.Send(new GetAllProductQuery()));
            return View(model);

        }
        /// <summary>
        /// Gets Product Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>


        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = (await _mediator.Send(new GetProductByIdQuery { Id = id }));
            return View(model);
        }
        /// <summary>
        /// Deletes Product Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> Delete1(int id)
        {
            await _mediator.Send(new DeleteProductByIdCommand { Id = id });
            return RedirectToActionPermanent( "Index");
        }


        [HttpGet("Update/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var model = (await _mediator.Send(new GetProductByIdQuery { Id = id }));
            return View(model);
        }
        /// <summary>
        /// Updates the Product Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Update/{id}")]
        public async Task<IActionResult> Update(int id, UpdateProductCommand command)
        {
            
            if (id != command.Id)
            {
                return BadRequest();
            }
            await _mediator.Send(command);
            return RedirectToActionPermanent("Index");
        }
    }
}