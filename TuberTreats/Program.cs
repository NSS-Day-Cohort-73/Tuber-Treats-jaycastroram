var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

/*
// Static lists to store data
List<Customer> customers = new() { new Customer { Id = 1, Name = "John Doe", Address = "123 Main St" } };
List<TuberOrder> orders = new() { new TuberOrder { Id = 1, CustomerId = 1, OrderPlacedOnDate = DateTime.Now } };
List<Topping> toppings = new() { new Topping { Id = 1, Name = "Cheese" } };
List<TuberTopping> tuberToppings = new();
List<TuberDriver> drivers = new() { new TuberDriver { Id = 1, Name = "Bob Smith" } };

// Customer endpoints
app.MapGet("/customers", () => customers);
app.MapGet("/customers/{id}", (int id) => {
    var customer = customers.FirstOrDefault(c => c.Id == id);
    if (customer == null) return Results.NotFound();
    customer.TuberOrders = orders.Where(o => o.CustomerId == id).ToList();
    return Results.Ok(customer);
});
app.MapPost("/customers", (Customer customer) => {
    customer.Id = customers.Any() ? customers.Max(c => c.Id) + 1 : 1;
    customers.Add(customer);
    return Results.Created($"/customers/{customer.Id}", customer);
});
app.MapDelete("/customers/{id}", (int id) => {
    var customer = customers.FirstOrDefault(c => c.Id == id);
    if (customer == null) return Results.NotFound();
    customers.Remove(customer);
    return Results.NoContent();
});

// Order endpoints
app.MapGet("/tuberorders", () => orders);
app.MapGet("/tuberorders/{id}", (int id) => {
    var order = orders.FirstOrDefault(o => o.Id == id);
    if (order == null) return Results.NotFound();
    var orderToppings = tuberToppings
        .Where(tt => tt.TuberOrderId == id)
        .Select(tt => toppings.FirstOrDefault(t => t.Id == tt.ToppingId))
        .Where(t => t != null)
        .ToList();
    order.Toppings = orderToppings;
    return Results.Ok(order);
});
app.MapPost("/tuberorders", (TuberOrder order) => {
    order.Id = orders.Any() ? orders.Max(o => o.Id) + 1 : 1;
    order.OrderPlacedOnDate = DateTime.Now;
    orders.Add(order);
    return Results.Created($"/tuberorders/{order.Id}", order);
});
app.MapPost("/tuberorders/{id}/complete", (int id) => {
    var order = orders.FirstOrDefault(o => o.Id == id);
    if (order == null) return Results.NotFound();
    order.DeliveredOnDate = DateTime.Now;
    return Results.NoContent();
});

// Topping endpoints
app.MapGet("/toppings", () => toppings);
app.MapGet("/toppings/{id}", (int id) => {
    var topping = toppings.FirstOrDefault(t => t.Id == id);
    return topping == null ? Results.NotFound() : Results.Ok(topping);
});

// TuberTopping endpoints
app.MapGet("/tubertoppings", () => tuberToppings);
app.MapPost("/tubertoppings", (TuberTopping tuberTopping) => {
    tuberTopping.Id = tuberToppings.Any() ? tuberToppings.Max(tt => tt.Id) + 1 : 1;
    tuberToppings.Add(tuberTopping);
    return Results.Created($"/tubertoppings/{tuberTopping.Id}", tuberTopping);
});
app.MapDelete("/tubertoppings/{id}", (int id) => {
    var tuberTopping = tuberToppings.FirstOrDefault(tt => tt.Id == id);
    if (tuberTopping == null) return Results.NotFound();
    tuberToppings.Remove(tuberTopping);
    return Results.NoContent();
});

// Driver endpoints
app.MapGet("/tuberdrivers", () => drivers);
app.MapGet("/tuberdrivers/{id}", (int id) => {
    var driver = drivers.FirstOrDefault(d => d.Id == id);
    if (driver == null) return Results.NotFound();
    driver.TuberDeliveries = orders.Where(o => o.TuberDriverId == id).ToList();
    return Results.Ok(driver);
});
*/

app.Run();

public partial class Program { }