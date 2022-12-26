using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.ProductFeatures.Commands;
using Application.Features.ProductFeatures.Queries;
using Application.Features.UnitFeatures.Commands;
using Application.Features.UnitFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    [Route("[controller]")]
    public class UnitsController : Controller
    {
        public IMediator _mediator;

        public UnitsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        /// <summary>
        /// Creates a New Product.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateUnitCommand command)
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
            var model = (await _mediator.Send(new GetAllUnitsQuery()));
            
            return View(model);
        }
        /// <summary>
        /// Gets Units Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>


        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = (await _mediator.Send(new GetUnitByIdQuery { Id = id }));

            if (model.Status == true)
            {
                return RedirectToActionPermanent("Index");
            }
            else
            {
                return View(model);
            }

        }
        /// <summary>
        /// Deletes Units Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> Delete1(int id)
        {
            await _mediator.Send(new DeleteUnitByIdCommand { Id = id });
            return RedirectToActionPermanent("Index");
        }


        [HttpGet("Update/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var model = (await _mediator.Send(new GetUnitByIdQuery { Id = id }));
            return View(model);
        }
        /// <summary>
        /// Updates the Product Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Update/{id}")]
        public async Task<IActionResult> Update(int id, UpdateUnitCommand command)
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