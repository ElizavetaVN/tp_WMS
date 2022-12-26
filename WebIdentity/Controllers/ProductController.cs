using System;
using System.Threading.Tasks;
using Application.Features.ProductFeatures.Commands;
using Application.Features.ProductFeatures.Queries;
using Application.Features.UnitFeatures.Queries;
using Application.Features.PartnerFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var model1 = await _mediator.Send(new GetAllPartnerQuery());

            SelectList unit = new SelectList(model, "Id", "Name");
            ViewBag.Units = unit;
            SelectList partner = new SelectList(model1, "Id", "Name");
            ViewBag.Partners = partner;

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
        /// Deletes Product Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> Delete1(int id)
        {
            await _mediator.Send(new DeleteProductByIdCommand { Id = id });
            return RedirectToActionPermanent("Index");
        }


        [HttpGet("Update/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var model = (await _mediator.Send(new GetProductByIdQuery { Id = id }));


            SelectList unit = new SelectList(await _mediator.Send(new GetAllUnitsQuery()), "Id", "Name", model.Units);
            ViewBag.Units = unit;

            SelectList partner = new SelectList(await _mediator.Send(new GetAllPartnerQuery()), "Id", "Name", model.Provider);
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