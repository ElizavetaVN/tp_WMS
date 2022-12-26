using System;
using System.Threading.Tasks;
using Application.Features.OrderFeatures.Commands;
using Application.Features.OrderFeatures.Queries;
using Application.Features.OrderStatusFeatures.Queries;
using Application.Features.OrderTypeFeatures.Queries;
using Application.Features.PartnerFeatures.Queries;
using Application.Features.ProductFeatures.Queries;
using Application.Features.WarehouseFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebIdentity.Controllers
{
    [Route("[controller]")]
    public class OrdersController : Controller
    {
        public IMediator _mediator;

        //ApplicationDbContext db = new ApplicationDbContext();

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            //var model = await _mediator.Send(new GetAllProductQuery());
            //var model1 = await _mediator.Send(new GetAllOrderStatusQuery());
            var model2 = await _mediator.Send(new GetAllOrderTypeQuery());
            //var model3 = await _mediator.Send(new GetAllWarehouseQuery());
            //var model4 = await _mediator.Send(new GetAllPartnerQuery());


            //SelectList product = new SelectList(model, "Id", "Name");
            //ViewBag.Products = product;
            //SelectList status = new SelectList(model1, "Id", "Name");
            //ViewBag.OrderStatus = status;
            SelectList type = new SelectList(model2, "Id", "Name");
            ViewBag.OrderType = type;
            //SelectList warehouse = new SelectList(model3, "Id", "Name");
            //ViewBag.Warehouses = warehouse;
            //SelectList partner = new SelectList(model4, "Id", "Name");
            //ViewBag.Partner = partner;

            return View();
        }
        /// <summary>
        /// Creates a New Product.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateOrderCommand command)
        {
            await _mediator.Send(command);
            var model = await _mediator.Send(command);
            //int id = model;
            return RedirectToActionPermanent("Update", new { id = model });

        }
        /// <summary>
        /// Gets all Products.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = (await _mediator.Send(new GetAllOrderQuery()));

              
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
            var model = (await _mediator.Send(new GetOrderByIdQuery { Id = id }));

            SelectList product = new SelectList(await _mediator.Send(new GetAllProductQuery()), "Id", "Name", model.Products);
            ViewBag.Product = product;

            SelectList status = new SelectList(await _mediator.Send(new GetAllOrderStatusQuery()), "Id", "Name", model.OrderStatus);
            ViewBag.OrderStatus = status;

            SelectList warehouse = new SelectList(await _mediator.Send(new GetAllWarehouseQuery()), "Id", "Name", model.Warehouses);
            ViewBag.Warehouses = warehouse;

            SelectList partner = new SelectList(await _mediator.Send(new GetAllPartnerQuery()), "Id", "Name", model.Partners);
            ViewBag.Partners = partner;
            
            return View(model);
        }
        /// <summary>
        /// Updates the Product Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Update/{id}")]
        public async Task<IActionResult> Update(int id, UpdateOrderCommand command)
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
