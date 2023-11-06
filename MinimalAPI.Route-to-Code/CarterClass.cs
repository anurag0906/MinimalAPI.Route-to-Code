
using Carter;

namespace MinimalAPI.Route_to_Code
{
	public class CarterClass : ICarterModule
	{
		public void AddRoutes(IEndpointRouteBuilder app)
		{
			//GET-https://localhost:7159/carter/GetData/456
			app.MapGet("Carter/GetData/{id}", (string id) => {

				return $"Getting Data from Carter module, for User -{id}";

			});

			//POST -https://localhost:7159/carter/GetData/456
			app.MapPost("carter/GetData/{id}", (string id) => {

				return $"Posting data via Carter module for User -{id}";

			});
		}
	}
}
