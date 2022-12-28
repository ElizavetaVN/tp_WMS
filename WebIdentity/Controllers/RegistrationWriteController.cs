using System.Threading.Tasks;
using Application.Features.RegistrationWriteFeatures.Commands;
using Application.Features.RegistrationWriteFeatures.Queries;
using Application.Features.RegistrationWriteTypeFeatures.Queries;
using Application.Features.InventoryFeatures.Queries;
using Application.Features.ProductFeatures.Queries;
using Application.Features.WarehouseFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebIdentity.Controllers
{
    [Route("[controller]")]
    public class RegistrationWriteController : Controller
    {
        public IMediator _mediator;

        //ApplicationDbContext db = new ApplicationDbContext();

        public RegistrationWriteController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            var model2 = await _mediator.Send(new GetAllRegistrationWriteTypeQuery());

            SelectList type = new SelectList(model2, "Id", "Name");
            ViewBag.RegistrationWriteType = type;

            return View();
        }
        /// <summary>
        /// Creates a New Product.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateRegistrationWriteCommand command)
        {
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
            var model = (await _mediator.Send(new GetAllRegistrationWriteQuery()));
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
            var model = (await _mediator.Send(new GetRegistrationWriteByIdQuery { Id = id }));

            SelectList product = new SelectList(await _mediator.Send(new GetAllProductQuery()), "Id", "Name", model.Products);
            ViewBag.Product = product;

            SelectList Inventory = new SelectList(await _mediator.Send(new GetAllInventoryQuery()), "Id", "Id", model.Inventory);
            ViewBag.Inventory = Inventory;

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
        public async Task<IActionResult> Update(int id, UpdateRegistrationWriteCommand command)
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