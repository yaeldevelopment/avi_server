using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using WebApplication14.Models;

namespace WebApplication14.Controllers
{
    [ApiController]
        [Route("api/[controller]")]
    public class CustomersController : Controller
    {
       
    
            private readonly MongoDBManager<customer> _managQuery;
            public CustomersController(IConfiguration configuration)
            {
                _managQuery = new MongoDBManager<customer>(configuration, "Customers");
            }


            [HttpGet]
            public ActionResult<List<customer>> Get()
            {
                var collection = _managQuery.GetCollectionByName<customer>();
                return collection.Find(_ => true).ToList();
            }


            [HttpGet("getById/{id}")]
            public async Task<IActionResult> GetById(string id)
            {
                try
                {
                    var result = await _managQuery.QueryByIdAsync(id);
                    if (result == null)
                    {
                        return NotFound("Document not found");
                    }

                    // Return serializable object (e.g., a DTO or BsonDocument)
                    return Ok(result.ToJson());
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }


            [HttpDelete("deleteById/{id}")]
            public async Task<IActionResult> DeleteById(string id)
            {
                try
                {
                    var result = await _managQuery.DeleteByIdAsync(id);
                    if (result == null)
                    {
                        return NotFound("Document not found");
                    }

                    // Return serializable object (e.g., a DTO or BsonDocument)
                    return Ok(result.ToJson());
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }
            [HttpPost("insertById")]
            public async Task<IActionResult> Insert_row([FromBody] customer customer)
            {
                try
                {
                    customer.Id = null; // MongoDB will generate the Id automatically
                    await _managQuery.InsertAsync(customer);
                    return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);


                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }
            [HttpPut("updateById/{id}")]
            public async Task<IActionResult> Update_row([FromBody] customer customer)
            {
                try
                {


                    await _managQuery.UpdateAsync(customer.Id, customer);
                    return NoContent(); // Return 204 No Content to indicate success
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }
        }
    
}
