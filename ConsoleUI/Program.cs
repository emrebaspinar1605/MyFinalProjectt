using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

ProductManager productManager = new ProductManager(new EfProductDal());
CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

OrderManager orderManager = new OrderManager(new EfOrderDal());

//ProductTests(productManager);

//CategoryTests1(categoryManager);

//CategoryTests2(categoryManager);

//OrderTests1(orderManager);
//OrderTests2(orderManager);
foreach (var product in productManager.GetProductDetails())
{
    Console.WriteLine(product.ProductName + " - " + product.CategoryName);
}

#region Methods
static void CategoryTests1(CategoryManager categoryManager)
{
    foreach (var category in categoryManager.GetAll())
    {
        Console.WriteLine(category.CategoryName);
    }
}
static void CategoryTests2(CategoryManager categoryManager)
{
    Console.WriteLine(categoryManager.GetById(1).CategoryName);
}

static void OrderTests1(OrderManager orderManager)
{
    foreach (var order in orderManager.GetByEmployeeId(4))
    {
        Console.WriteLine(order.OrderID + "-" + order.CustomerID + "-" + order.EmployeeID + "-" + order.ShipCity + "-" + order.OrderDate);
    }
}

static void OrderTests2(OrderManager orderManager)
{
    foreach (var order in orderManager.GetByCustomerId("VINET"))
    {
        Console.WriteLine(order.OrderID + "-" + order.CustomerID + "-" + order.EmployeeID + "-" + order.ShipCity + "-" + order.OrderDate);
    }
}

static void OrderTests3(OrderManager orderManager)
{

    Console.WriteLine(orderManager.GetById(4).ShipCity + "/" + orderManager.GetById(4).CustomerID);

}
static void ProductTests(ProductManager productManager)
{
    foreach (var product in productManager.GetByUnitPrice(90, 7500))
    {
        Console.WriteLine(product.ProductName + "/" + product.UnitPrice);
    }
    Console.WriteLine("");
}
static void ProductTests2(ProductManager productManager)
{
    foreach (var product in productManager.GetAll())
    {
        Console.WriteLine(product.ProductName);
    }
    Console.WriteLine("");
}
static void ProductTests3(ProductManager productManager)
{
    foreach (var product in productManager.GetAllByCategoryId(2))
    {
        Console.WriteLine(product.ProductName);
    }
    Console.WriteLine("");
}
#endregion