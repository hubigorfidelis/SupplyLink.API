using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SupplyLink.Application.InputModels;
using SupplyLink.Application.Services.Interfaces;
using SupplyLink.Core.Enums;

namespace SupplyLink.API.Controllers
{
    [Route("api/clients")]
    [Authorize]
    public class ClientsController : ControllerBase
    {

        private readonly IClientService _clientService;
        public ClientsController(IClientService clientService) 
        {
            _clientService = clientService;
        }

        [HttpGet]
        public IActionResult GetClients(string query ) 
        {
            
            var clients = _clientService.GetAll(query);
            if ( clients == null ) return NotFound();
            return Ok(clients);
        }

        [HttpGet("id")]
        public IActionResult GetClientById(int id) 
        {
            var client= _clientService.GetById(id); 
            if (client == null) 
            {
                return NotFound();
            }
            return Ok(client);
        }
        [HttpPost]
        public IActionResult CreateClient([FromBody] NewClientInputModel inputModel)
        {
            if (inputModel.Name.Length < 4) 
            {
                return BadRequest();
            }
            var id =_clientService.Create(inputModel);

           
            return CreatedAtAction(nameof(GetClientById),new {id = id}, inputModel);
        }
        [HttpPut("{id}")]
        public IActionResult UpadateClient(int id ,[FromBody] UpdateClientInputModel inputModel) 
        {
            if (inputModel.Id == null) 
            {
                return BadRequest();
            }
            _clientService.Update(inputModel);
            return Ok();
        }

        [HttpDelete("id")]
        public IActionResult DeleteClient(int id) 
        {
            var client = _clientService.Delete;

            return NoContent();
        }
    }
}
