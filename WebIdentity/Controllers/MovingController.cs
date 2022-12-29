using System;
using System.Threading.Tasks;
using Application.Features.InternalFeatures.Commands;
using Application.Features.InternalFeatures.Queries;
using Application.Features.MovingFeatures.Commands;
using Application.Features.MovingFeatures.Queries;
using Application.Features.ProductFeatures.Queries;
using Application.Features.WarehouseFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebIdentity.Controllers
{
    [Route("[controller]")]
    public class MovingController : Controller
    {
        public IMediator _mediator;
        //ApplicationDbContext db = new ApplicationDbContext();

        public MovingController(IMediator mediator)
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

            SelectList warehouseFrom = new SelectList(model1, "Id", "Name");
            ViewBag.WarehousesFrom = warehouseFrom;

            SelectList warehouseTo = new SelectList(model1, "Id", "Name");
            ViewBag.WarehousesTo = warehouseTo;

            return View();
        }
        /// <summary>
        /// Creates a New Product.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateMovingCommand command, CreateInternalCommand com)
        {
            var model = await _mediator.Send(command);

            var model4 = await _mediator.Send(new GetAllInternalQuery());
            int N = 0;
            foreach (var mod in model4)
            {
                if ((mod.Products == model.Products) && (mod.Warehouses.Id == command.WarehousesFrom) && (mod.Operation.Id == 1))
                {
                    N = N + Convert.ToInt32(mod.Quantity);
                }
                else if ((mod.Products == model.Products) && (mod.Warehouses.Id == command.WarehousesFrom) && (mod.Operation.Id == 2))
                {
                    N = N - Convert.ToInt32(mod.Quantity);
                }
            }
            if (N >= Convert.ToInt32(model.Quantity))
            {
                com.Warehouses = model.WarehousesFrom;
                com.Products = model.Products;
                com.Quantity = model.Quantity;
                com.Operation = 2; //расход
                await _mediator.Send(com);

                com.Warehouses = model.WarehousesTo;
                com.Products = model.Products;
                com.Quantity = model.Quantity;
                com.Operation = 1; //приход
                await _mediator.Send(com);

                return RedirectToActionPermanent("Index");
            }
            else
            {
                await _mediator.Send(new DeleteMovingByIdCommand { Id = model.Id });
                return RedirectToActionPermanent("Index");
            }

        }
        /// <summary>
        /// Gets all Products.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = (await _mediator.Send(new GetAllMovingQuery()));
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

            var model = (await _mediator.Send(new GetMovingByIdQuery { Id = id }));

            SelectList prod = new SelectList(await _mediator.Send(new GetAllProductQuery()), "Id", "Name", model.Products);
            ViewBag.Products = prod;

            SelectList warehouseTo = new SelectList(await _mediator.Send(new GetAllWarehouseQuery()), "Id", "Name", model.WarehousesTo);
            ViewBag.WarehousesTo = warehouseTo;

            SelectList warehouseFrom = new SelectList(await _mediator.Send(new GetAllWarehouseQuery()), "Id", "Name", model.WarehousesFrom);
            ViewBag.WarehousesFrom = warehouseFrom;

            return View(model);
        }
        /// <summary>
        /// Updates the Product Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Update/{id}")]
        public async Task<IActionResult> Update(int id, UpdateMovingCommand command)
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