using System;
using System.Threading.Tasks;
using Application.Features.RealizationFeatures.Commands;
using Application.Features.RealizationFeatures.Queries;
using Application.Features.RealizationTypeFeatures.Queries;
using Application.Features.PartnerFeatures.Queries;
using Application.Features.ProductFeatures.Queries;
using Application.Features.WarehouseFeatures.Queries;
using Application.Features.OrderFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebIdentity.Controllers
{
    [Route("[controller]")]
    public class RealizationController : Controller
    {
        public IMediator _mediator;

        //ApplicationDbContext db = new ApplicationDbContext();

        public RealizationController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            var model2 = await _mediator.Send(new GetAllRealizationTypeQuery());

            SelectList type = new SelectList(model2, "Id", "Name");
            ViewBag.RealizationType = type;

            return View();
        }
        /// <summary>
        /// Creates a New Product.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateRealizationCommand command)
        {
            //await _mediator.Send(command);
            var model = await _mediator.Send(command);
            return RedirectToActionPermanent("Update", new { id = model.Id });

        }
        /// <summary>
        /// Gets all Products.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = (await _mediator.Send(new GetAllRealizationQuery()));


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
            var model = (await _mediator.Send(new GetRealizationByIdQuery { Id = id }));
            var model1 = (await _mediator.Send(new GetAllProductQuery()));
            if (model.RealizationType.Id==1)
            {
                var order = await _mediator.Send(new GetAllOrderByIdQuery { Id = 1 });
                SelectList orders = new SelectList(order, "Id", "Id", model.Order);
                ViewBag.Order = orders;
            }
            if (model.RealizationType.Id == 2)
            {
                var order = await _mediator.Send(new GetAllOrderByIdQuery { Id = 2 });
                SelectList orders = new SelectList(order, "Id", "Id", model.Order);
                ViewBag.Order = orders;
            }

            SelectList warehouse = new SelectList((await _mediator.Send(new GetAllWarehouseQuery())), "Id", "Name", model.Warehouses);
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
        public async Task<IActionResult> Update(int id, UpdateRealizationCommand command)
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
