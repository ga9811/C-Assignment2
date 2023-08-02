using FruitsRestSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;


namespace FruitsRestSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitsController : Controller
    {
        private readonly IConfiguration _configuration;

        public FruitsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("AddFruit")]
        public Response AddFruit(Fruits fruit)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("fruitConnection").ToString());
            Response response = new Response();
            Applications app = new Applications();
           response = app.AddFruit(con, fruit);
            return response;
        }

        [HttpGet]
        [Route("GetAllFruits")]
        public Response GetAllFruit()
        {
            Response response = new Response();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("fruitConnection").ToString());
            
            Applications app = new Applications();
            response = app.GetAllFruits(con);
            return response;
        }

        [HttpGet]
        [Route("GetFruitByProductID/{ProductID}")]
        public Response GetFruitByProductID(int ProductID)
        {
            Response response = new Response();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("fruitConnection").ToString());

            Applications app = new Applications();
            response = app.GetFruitByProductID(con,ProductID);
            return response;
        }

        [HttpPut]
        [Route("GetFruitUpdateByProductID")]
        public Response GetFruitUpdateByProductID(Fruits fruit)
        {
            Response response = new Response();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("fruitConnection").ToString());

            Applications app = new Applications();
            response = app.GetFruitUpdateByProductID(con,fruit);
            return response;
        }
        [HttpDelete]
        [Route("DeleteFruitByProductID/{ProductID}")]
        public Response DeleteFruitByProductID(int ProductID)
        {
            Response response = new Response();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("fruitConnection").ToString());

            Applications app = new Applications();
            response = app.DeleteFruitByProductID(con,  ProductID);
            return response;
        }

        [HttpGet]
        [Route("GetFruitSaleByProductIDAndWeight/{ProductID}/{Weight}")]
        public Response GetFruitSaleByProductIDAndWeight(int ProductID,decimal Weight)
        {
            Response response = new Response();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("fruitConnection").ToString());

            Applications app = new Applications();
            response = app.GetFruitSaleByProductIDAndWeight(con, ProductID,Weight);
            return response;
        }
    }
}
