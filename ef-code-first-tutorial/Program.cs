using ef_code_first_tutorial.Controllers;
using ef_code_first_tutorial.Models;

CustomersController customerController = new CustomersController();

Customer? customer = await customerController.GetCustomerWithOrders(1);

Console.WriteLine($"CUSTOMER: {customer.Name}");
foreach(var order in customer.Orders)
{
    Console.WriteLine($"- ORDER: Description {order.Description}");
    foreach(var orderLine in order.OrderLines)
    {
        Console.WriteLine($"-- ORDERLINE: Product: {orderLine.Item.Name}, Quantity: {orderLine.Quantity}, " +
            $"Price: {orderLine.Item.Price:C}, Line total: {orderLine.Quantity * orderLine.Item.Price:C}");
    }
}

//using static System.Console;
//using ef_code_first_tutorial;
//using Microsoft.EntityFrameworkCore;
//using ef_code_first_tutorial.Models;

//SalesDbContext _dbContext = new SalesDbContext();

//Order order = _dbContext.Orders
//                              .Include(order => order.OrderLines)
//                                .ThenInclude(orderline => orderline.Item)
//                              .Include(order => order.Customer)
//                              .Single(order => order.Id == 2);

//WriteLine($"ORDER: Description: {order.Description}");
//foreach(OrderLine orderLine in order.OrderLines)
//{
//    WriteLine($"ORDERLINE: Product: {orderLine.Item.Name}, Quantity: {orderLine.Quantity}, Price: {orderLine.Item.Price:C}, " +
//              $"Line total: {orderLine.Quantity * orderLine.Item.Price:C}");
//}
//decimal orderTotal = order.OrderLines.Sum(orderlines => orderlines.Item.Price * orderlines.Quantity);
//WriteLine($"Total: {orderTotal:C}");
//_dbContext.Customers.ToList().ForEach(c => WriteLine(c.Name));