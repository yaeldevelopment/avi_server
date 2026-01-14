using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApplication14.Models;

namespace WebApplication14.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class apartmentController : Controller
    {
        private readonly MongoDBManager<apartment> _managQuery;
        public apartmentController(IConfiguration configuration)
        {
            _managQuery = new MongoDBManager<apartment>(configuration, "Apartment");
        }
        
       
[HttpGet]
        public ActionResult<List<apartment>> Get()
        {
            var collection = _managQuery.GetCollectionByName<apartment>();
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
        public async Task<IActionResult> Insert_row([FromBody]apartment apartment)
        {
            try
            {
                apartment.Id = null; // MongoDB will generate the Id automatically
                await _managQuery.InsertAsync(apartment);
                return CreatedAtAction(nameof(GetById), new { id = apartment.Id }, apartment);

               
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("updateById/{id}")]
        public async Task<IActionResult> Update_row([FromBody] apartment apartment)
        {
            try
            {
              

                await _managQuery.UpdateAsync(apartment.Id,apartment);
                return NoContent(); // Return 204 No Content to indicate success
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
