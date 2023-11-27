using Microsoft.AspNetCore.Mvc;
using SupplyLink.Application.InputModels;
using SupplyLink.Application.Services.Interfaces;
using SupplyLink.Core.Enums;

namespace SupplyLink.API.Controllers
{
    [Route("api/Suppliers")]
    public class SuppliersController : ControllerBase
    {

        private readonly ISupplierService _supplierService;
        public SuppliersController(ISupplierService SupplierService)
        {
            _supplierService = SupplierService;
        }

        [HttpGet]
        public IActionResult GetSuppliers(string query)
        {

            var Suppliers = _supplierService.GetAll(query);
            if (Suppliers == null) return NotFound();
            return Ok(Suppliers);
        }

        [HttpGet("id")]
        public IActionResult GetSupplierById(int id)
        {
            var Supplier = _supplierService.GetById(id);
            if (Supplier == null)
            {
                return NotFound();
            }
            return Ok(Supplier);
        }
        [HttpPost]
        public IActionResult CreateSupplier([FromBody] NewSupplierInputModel inputModel)
        {
            if (inputModel.Name.Length < 4)
            {
                return BadRequest();
            }
            var id = _supplierService.Create(inputModel);


            return CreatedAtAction(nameof(GetSupplierById), new { id = id }, inputModel);
        }
        [HttpPut("{id}")]
        public IActionResult UpadateSupplier(int id, [FromBody] UpdateSupplierInputModel inputModel)
        {
            if (inputModel.Id == null)
            {
                return BadRequest();
            }
            _supplierService.Update(inputModel);
            return Ok();
        }

        [HttpDelete("id")]
        public IActionResult DeleteSupplier(int id)
        {
            var supplier = _supplierService.Delete;

            return NoContent();
        }
    }
}
