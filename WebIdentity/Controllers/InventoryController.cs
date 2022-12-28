using System;
using System.Threading.Tasks;
using Application.Features.InventoryFeatures.Commands;
using Application.Features.InventoryFeatures.Queries;
using Application.Features.ProductFeatures.Queries;
using Application.Features.WarehouseFeatures.Queries;
using Application.Features.UnitFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebIdentity.Controllers
{
    [Route("[controller]")]
    public class InventoryController : Controller
    {
        public IMediator _mediator;

        //ApplicationDbContext db = new ApplicationDbContext();

        public InventoryController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            var model = await _mediator.Send(new GetAllProductQuery());
            var model1 = await _mediator.Send(new GetAllWarehouseQuery());

            SelectList prod = new SelectList(model, "Id", "Name");
            ViewBag.Products = prod;

            SelectList Warehouses = new SelectList(model1, "Id", "Name");
            ViewBag.Warehouses = Warehouses;

            return View();
        }
        /// <summary>
        /// Creates a New Product.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateInventoryCommand command)
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
            var model = (await _mediator.Send(new GetAllInventoryQuery()));
            return View(model);
        }
        /// <summary>
        /// Gets Product Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Update/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var model = (await _mediator.Send(new GetInventoryByIdQuery { Id = id }));

            SelectList product = new SelectList(await _mediator.Send(new GetAllProductQuery()), "Id", "Name", model.Products);
            ViewBag.Products = product;

            SelectList warehouse = new SelectList(await _mediator.Send(new GetAllWarehouseQuery()), "Id", "Name", model.Warehouses);
            ViewBag.Warehouses = warehouse;

            return View(model);
        }
        /// <summary>
        /// Updates the Product Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Update/{id}")]
        public async Task<IActionResult> Update(int id, UpdateInventoryCommand command)
        {

            if (id != command.Id)
            {
                return BadRequest();
            }
            var model = await _mediator.Send(command);

            return RedirectToActionPermanent("Index");
        }
    }
}
