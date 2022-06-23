using ConsoleTables;
using ecom;
using System;
using System.Collections.Generic;
using System.Linq;

public class eCommerce
{
    private const decimal deliverCharges = 10.00M;
    private List<Customer> validCustomers;
    private List<OrderDetails> shoppingCart;
    private List<OrderDetails2> shoppingCart2;
    private List<OrderDetails3> shoppingCart3;
    private List<Product> productList;
    private List<Product2> productList2;
    private List<Product3> productList3;

    public eCommerce()
    {
        InitializeCustomerList();
        InitializeProductList();
        InitializeProductList2();
        InitializeProductList3();
        shoppingCart = new List<OrderDetails>();
        shoppingCart2 = new List<OrderDetails2>();
        shoppingCart3 = new List<OrderDetails3>();
        Console.Title = "Andrew's TechTree Store";
    }
    //Console execution method
    public void Execute()
    {
        var valid_Customer = Login();

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Login as {valid_Customer.FullName}");
            Console.WriteLine("\nAndrew's TechTree Store");
            Console.WriteLine("1. Browse product list 1");
            Console.WriteLine("2. Browse Product list 2");
            Console.WriteLine("3. Browse Product list 3");
            Console.WriteLine("4. View shopping cart");
            Console.WriteLine("5. Logout");
            Console.Write("Enter your option: ");
            string opt = Console.ReadLine();
            switch (opt)
            {
                case "1":
                    BrowseProducts();
                    AddShoppingCart(valid_Customer);
                    break;
                case "2":
                    BrowseProducts2();
                    AddShoppingCart2(valid_Customer);
                    break;
                case "3":
                    BrowseProducts3();
                    AddShoppingCart3(valid_Customer);
                    break;
                case "4":
                    ViewShoppingCart(valid_Customer);
                    break;
                case "5":
                    Utility.printDotAnimation();
                    valid_Customer = null;
                    shoppingCart.Clear();
                    Execute();
                    break;
                default:
                    Utility.PrintMessage("Invalid option.", ConsoleColor.Red);
                    break;
            }
            Console.ReadKey();
        }
    }
    //Initial Login sequence
    private Customer Login()
    {
        while (true)
        {
            var userInput = new Customer();
            Console.Clear();
            Console.Write("Username: ");
            userInput.Username = Console.ReadLine();

            Console.Write("Password: ");
            userInput.Password = Utility.ReadPassword();

            var validCustomer = validCustomers
            .Where(c => c.Username.Equals(userInput.Username))
            .Where(c => c.Password.Equals(userInput.Password))
            .FirstOrDefault();

            if (validCustomer != null)
            {
                Utility.printDotAnimation();
                return validCustomer;
            }


            Utility.PrintMessage("\nInvalid username or password.", ConsoleColor.Red);
            Console.ReadKey();
        }
    }
    //Customer List
    private void InitializeCustomerList()
    {
        validCustomers = new List<Customer>(){
                new Customer(){
                CustomerId = 1,
                Username = "Andrew",
                Password = "andrew123",
                FullName = "Andrew Tate",
                Email = "andrewtate@gmail.com",
                Address = "14, Dec Road, 1986, Romania."
                },
                new Customer(){
                CustomerId = 2,
                Username = "Bruce",
                Password = "brucelee",
                FullName = "Bruce Lee",
                Email = "brucelee@gmail.com",
                Address = "27, June Avenue, 1973, San Fran."
                }
        };
    }
    //Product lists
    private void InitializeProductList()
    {
        productList = new List<Product>() {
            new Product(){ Id = 2, ProductName = "Lenovo Legion RTX 3050 Ti Gaming Laptop 15.6' ", UnitPrice = 2999.00M},
            new Product(){ Id = 5, ProductName = "MSI GF63 Thin GTX1650 Max Q Gaming Laptop 15.6' ", UnitPrice = 1298.00M},
            new Product(){ Id = 12, ProductName = "Asus TUF GTX 1650 Gaming Laptop 15.6' ", UnitPrice = 1328.00M},
            new Product(){ Id = 13, ProductName = "Razor Blade Advanced RTX3060 Gaming Laptop 15.6' ", UnitPrice = 4447.00M},
            new Product(){ Id = 16, ProductName = "Razor Blade RTX 3080 Ti Gaming Laptop 17.3' ", UnitPrice = 8173.00M}
        };
    }
    private void InitializeProductList2()
    {
        productList2 = new List<Product2>() {
            new Product2(){ Id2 = 3, ProductName2 = "Titan Army 27' Curved Monitor", UnitPrice2 = 327.00M},
            new Product2(){ Id2 = 6, ProductName2 = "Samsung Odyssey 27' QLED Curved Monitor", UnitPrice2 = 849.00M},
            new Product2(){ Id2 = 11, ProductName2 = "Razor Deathadder v2 Mouse", UnitPrice2 = 87.00M},
            new Product2(){ Id2 = 14, ProductName2 = "Razor Huntsman Mechanical Keyboard", UnitPrice2 = 144.00M},
            new Product2(){ Id2 = 15, ProductName2 = "Samsung T5 Portable SSD 2tb", UnitPrice2 = 70.00M},
        };
    }
    private void InitializeProductList3()
    {
        productList3 = new List<Product3>() {
            new Product3(){ Id3 = 4, ProductName3 = "GGPC RTX 3050 Gaming PC i5, 16gb RAM, 500GB SSD ", UnitPrice3 = 1598.00M},
            new Product3(){ Id3 = 7, ProductName3 = "Dell Alienware Aurora R13 RTX 3090 Gaming Desktop, 32gb RAM, 1tb HDD ", UnitPrice3 = 8365.00M},
            new Product3(){ Id3 = 10, ProductName3 = "GGPC RX 6650 XT Gaming PC AMD Ryzen, 16GB 3200Mhz RAM, 1TB NVMe SSD ", UnitPrice3 = 2199.00M},
            new Product3(){ Id3 = 17, ProductName3 = "GGPC RTX 3060 Gaming PC, 16GB RGB RAM, 1TB NVMe SSD ", UnitPrice3 = 2781.00M},
            new Product3(){ Id3 = 18, ProductName3 = "Corsair ONE RTX 3080 Gaming PC Liquid-Cooled, 64GB RAM, 2tb SSD ", UnitPrice3 = 7999.00M},
        };
    }
    //Browsing Control
    private void BrowseProducts()
    {
        Console.Clear();

        var table = new ConsoleTable("Product Id", "Product Name", "Unit Price");

        foreach (var product in productList)
            table.AddRow(product.Id, product.ProductName, Utility.FormatAmount(product.UnitPrice));


        table.Write();
    }
    private void BrowseProducts2()
    {
        Console.Clear();

        var table = new ConsoleTable("Product Id2", "Product Name2", "Unit Price2");

        foreach (var product2 in productList2)
            table.AddRow(product2.Id2, product2.ProductName2, Utility.FormatAmount(product2.UnitPrice2));


        table.Write();
    }
    private void BrowseProducts3()
    {
        Console.Clear();

        var table = new ConsoleTable("Product Id3", "Product Name3", "Unit Price3");

        foreach (var product3 in productList3)
            table.AddRow(product3.Id3, product3.ProductName3, Utility.FormatAmount(product3.UnitPrice3));


        table.Write();
    }
    //Shopping Cart(s)
    private void AddShoppingCart(Customer valid_Customer)
    {
        Console.Write("Enter the product ID you want to buy: ");
        int productId = int.Parse(Console.ReadLine());

        var selectedProduct = productList.FirstOrDefault(p => p.Id == productId);

        if (selectedProduct == null)
        {
            Utility.PrintMessage("Product not found.", ConsoleColor.Red);
            return;
        }

        Console.Write("Enter quantity to buy: ");
        int quantity = int.Parse(Console.ReadLine());

        var order = new OrderDetails();
        order.Customer_Id = valid_Customer.CustomerId;
        order.ProductId = productId;
        order.QuantityOrder = quantity;
        order.TotalAmount = quantity * selectedProduct.UnitPrice;

        shoppingCart.Add(order);
        Utility.PrintMessage($"{selectedProduct.ProductName} added into shopping cart.", ConsoleColor.Yellow);
    }
    //ShoppingCart2
    private void AddShoppingCart2(Customer valid_Customer)
    {
        Console.Write("Enter the product ID you want to buy: ");
        int productId2 = int.Parse(Console.ReadLine());

        var selectedProduct = productList2.FirstOrDefault(p => p.Id2 == productId2);

        if (selectedProduct == null)
        {
            Utility.PrintMessage("Product not found.", ConsoleColor.Red);
            return;
        }

        Console.Write("Enter quantity to buy: ");
        int quantity = int.Parse(Console.ReadLine());

        var order2 = new OrderDetails2();
        order2.Customer_Id2 = valid_Customer.CustomerId;
        order2.ProductId2 = productId2;
        order2.QuantityOrder2 = quantity;
        order2.TotalAmount2 = quantity * selectedProduct.UnitPrice2;

        shoppingCart2.Add(order2);
        Utility.PrintMessage($"{selectedProduct.ProductName2} added into shopping cart.", ConsoleColor.Yellow);
    }
    //shoppingCart3
    private void AddShoppingCart3(Customer valid_Customer)
    {
        Console.Write("Enter the product ID you want to buy: ");
        int productId3 = int.Parse(Console.ReadLine());

        var selectedProduct = productList3.FirstOrDefault(p => p.Id3 == productId3);

        if (selectedProduct == null)
        {
            Utility.PrintMessage("Product not found.", ConsoleColor.Red);
            return;
        }

        Console.Write("Enter quantity to buy: ");
        int quantity = int.Parse(Console.ReadLine());

        var order3 = new OrderDetails3();
        order3.Customer_Id3 = valid_Customer.CustomerId;
        order3.ProductId3 = productId3;
        order3.QuantityOrder3 = quantity;
        order3.TotalAmount3 = quantity * selectedProduct.UnitPrice3;

        shoppingCart3.Add(order3);
        Utility.PrintMessage($"{selectedProduct.ProductName3} added into shopping cart.", ConsoleColor.Yellow);
    }

    private void ViewShoppingCart(Customer valid_Customer)
    {
        Console.Clear();

        // inner join orderdetail and product.
        var shoppingCart4 = from s in shoppingCart
                            join p in productList on s.ProductId equals p.Id
                            select new { p.ProductName, p.UnitPrice, s.QuantityOrder, s.TotalAmount };
        var totalOrderAmount = 0M;
        totalOrderAmount = shoppingCart.Sum(s => s.TotalAmount) + shoppingCart2.Sum(s => s.TotalAmount2) + shoppingCart3.Sum(s => s.TotalAmount3);
        var table = new ConsoleTable("Product Name ", "Price ", "Quantity ", "Total ");

        if (shoppingCart.ToList().Count == 0)
        {
            Utility.PrintMessage("Shopping cart is empty. Go to browse products.", ConsoleColor.Yellow);
            return;
        }

        Console.WriteLine("Total Items in Shopping Cart: " + shoppingCart.Count());
        foreach (var item in shoppingCart)
            table.AddRow(item.ProductName, Utility.FormatAmount(item.UnitPrice), item.QuantityOrder, Utility.FormatAmount(item.TotalAmount));

        var shoppingCart5 = from s in shoppingCart2
                            join p in productList2 on s.ProductId2 equals p.Id2
                            select new { p.ProductName2, p.UnitPrice2, s.QuantityOrder2, s.TotalAmount2 };

        foreach (var item in shoppingCart2)
            table.AddRow(item.ProductName2, Utility.FormatAmount(item.UnitPrice2), item.QuantityOrder2, Utility.FormatAmount(item.TotalAmount2));

        var shoppingCart6 = from s in shoppingCart3
                            join p in productList3 on s.ProductId3 equals p.Id3
                            select new { p.ProductName3, p.UnitPrice3, s.QuantityOrder3, s.TotalAmount3 };

        foreach (var item in shoppingCart3)
            table.AddRow(item.ProductName3, Utility.FormatAmount(item.UnitPrice3), item.QuantityOrder3, Utility.FormatAmount(item.TotalAmount3));

        table.Options.EnableCount = false;
        table.Write();

        Console.WriteLine("------------------------------------------");
        Console.WriteLine("Delivery charges: " + Utility.FormatAmount(deliverCharges));
        Console.WriteLine("Total Order Amount: " + Utility.FormatAmount(totalOrderAmount + deliverCharges));
        Console.WriteLine("------------------------------------------");
        Console.WriteLine("Delivery Address: " + valid_Customer.Address);

        Console.WriteLine("\n1. Confirm order and proceed to make payment.");
        Console.WriteLine("2. Clear shopping cart.");
        Console.WriteLine("3. Back.");
        Console.Write("Enter option: ");
        string opt2 = Console.ReadLine();
        switch (opt2)
        {
            case "1":
                Console.WriteLine("\nChoose payment method:");
                Console.WriteLine("1. Cash on delivery (COD)");
                Console.WriteLine("2. Credit Card");
                Console.WriteLine("3. Online eBanking");
                Console.Write("Enter option: ");
                Console.ReadKey();
                Console.WriteLine("\n\nRedirecting to payment gateway.");
                Utility.printDotAnimation();
                Console.WriteLine("Info: This E-Commerce simulation app ends here....");


                break;
            case "2":
                shoppingCart.Clear();
                Utility.PrintMessage("Shopping cart is empty. Go to browse products.", ConsoleColor.Yellow);
                break;
            case "3":
                break;
            default:
                Utility.PrintMessage("Invalid option.", ConsoleColor.Red);
                break;
        }

    }
}
    