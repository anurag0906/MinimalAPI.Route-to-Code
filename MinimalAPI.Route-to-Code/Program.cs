using Carter;
using MinimalAPI.Route_to_Code;
using MinimalAPI.Route_to_Code.Model;

var builder = WebApplication.CreateBuilder(args);

//configure service
builder.Services.AddScoped<MyModel>();
builder.Services.AddCarter();

var app = builder.Build();

#region Local method Minimal API

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


//with DI---   https://localhost:7159/test/11
app.MapGet("/test/{myid}", (string myid, IConfiguration config) => {

	var data = config.GetValue<string>("MyKey");

	var temp = "you entered- " + myid + ". Data from Config DI is- " + data;
	return temp;
});


//Difficult to Test
//Not good for Large complex operations
#endregion


#region 2. As Extn method
//From Extn method-
app.MinimapApiExtn();


#endregion

app.MapCarter();

app.Run();
