using MinimalAPI.Route_to_Code.Model;

var builder = WebApplication.CreateBuilder(args);

//configure service
builder.Services.AddScoped<MyModel>();


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//my GET
app.MapGet("/{myid}", (string myid)=> { 

	var temp = "you entered- " + myid;
	return temp;
});

//my POST
app.MapPost("/", async mycontext =>
{

	var data = mycontext.RequestServices.GetService<MyModel>();

	//return
	mycontext.Response.StatusCode = 200;
	await mycontext.Response.WriteAsJsonAsync(data.GetMyData());
	return;

});


//PUT with parameters
app.MapPut("/{somepara}", async (mycontext) =>
{

	var data = mycontext.RequestServices.GetService<MyModel>();

	MyModel result = data.GetMyData();
	result.Name = result.Name + "- "+ mycontext.Request.RouteValues["somepara"];

	//return
	mycontext.Response.StatusCode = 200;
	await mycontext.Response.WriteAsJsonAsync(result);
	return;

});

//DELETE

app.Run();
