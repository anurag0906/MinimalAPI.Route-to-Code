namespace MinimalAPI.Route_to_Code.Model
{
	public class MyModel
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public MyModel GetMyData()
		{
			return new MyModel() { Id = 123, Name = "abc" };
		}
	}
}
