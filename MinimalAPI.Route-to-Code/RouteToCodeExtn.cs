namespace MinimalAPI.Route_to_Code
{
	public static class RouteToCodeExtn
	{
		public static void MinimapApiExtn(this IEndpointRouteBuilder app)
		{
			//GET-https://localhost:7159/GetData/123
			app.MapGet("/GetData/{id}", (string id) => {

				return $"Getting Data from Extn method for User -{id}";
			
			});

			//POST -https://localhost:7159/GetData/123
			app.MapPost("/GetData/{id}", (string id) => {

				return $"Posting data for User -{id}";

			});
		}
	}
}
