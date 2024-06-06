using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

IProductService productService = new ProductManager(new EfProductDal());
ICategoryService categoryService = new CategoryManager(new EfCategoryDal());

IOrderService orderService = new OrderManager(new EfOrderDal());

ProductTests1(productService);
//ProductTests2(productService);
//ProductTests3(productService);

//ProductTestsPrivate(productService);

CategoryTests1(categoryService);

//CategoryTests2(categoryService);

//OrderTests1(orderService);
//OrderTests2(orderService);
//OrderTests3(orderService);

#region Methods
static void CategoryTests1(ICategoryService categoryService)
{
    foreach (var category in categoryService.GetAll().Data)
    {
        Console.WriteLine(category.CategoryName);
    }
    Console.WriteLine("--------------------------------");
    Console.WriteLine(categoryService.GetAll().Message);
}
static void CategoryTests2(ICategoryService categoryService)
{
    Console.WriteLine(categoryService.GetById(1).Data.CategoryName);
}

static void OrderTests1(IOrderService orderService)
{
    foreach (var order in orderService.GetByEmployeeId(4))
    {
        Console.WriteLine(order.OrderID + "-" + order.CustomerID + "-" + order.EmployeeID + "-" + order.ShipCity + "-" + order.OrderDate);
    }
}

static void OrderTests2(IOrderService orderService)
{
    foreach (var order in orderService.GetByCustomerId("VINET"))
    {
        Console.WriteLine(order.OrderID + "-" + order.CustomerID + "-" + order.EmployeeID + "-" + order.ShipCity + "-" + order.OrderDate);
    }
}

static void OrderTests3(IOrderService orderService)
{

    Console.WriteLine(orderService.GetById(4).ShipCity + "/" + orderService.GetById(4).CustomerID);

}
static void ProductTests1(IProductService productService)
{
    foreach (var product in productService.GetByUnitPrice(90, 7500).Data)
    {
        Console.WriteLine(product.ProductName + "/" + product.UnitPrice);
    }
    Console.WriteLine("--------------------------------");
    Console.WriteLine(productService.GetByUnitPrice(90,7500).Message);
}
static void ProductTests2(IProductService productService)
{
    foreach (var product in productService.GetAll().Data)
    {
        Console.WriteLine(product.ProductName);
    }
    Console.WriteLine("");
}
static void ProductTests3(IProductService productService)
{
    foreach (var product in productService.GetAllByCategoryId(2).Data)
    {
        Console.WriteLine(product.ProductName);
    }
    Console.WriteLine("");
}

static void ProductTestsPrivate(IProductService productService)
{
    foreach (var product in productService.GetProductDetails().Data)
    {
        Console.WriteLine(product.ProductName + " - " + product.CategoryName);
    }
}
#endregion