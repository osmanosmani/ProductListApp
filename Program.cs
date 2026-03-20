using System;
using System.Collections.Generic;
using System.Linq;

// List to store all added products
List<Product> products = new List<Product>();

// Start by asking the user to add products
AddProducts();

// Keep the program running until the user chooses to quit
while (true)
{
    DisplayProducts();
    ShowOptionsMenu();
}

void AddProducts()
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("To enter a new product - follow the steps | To quit - enter: \"Q\"");
        Console.Write("Enter a Category: ");
        string categoryInput = Console.ReadLine() ?? "";

        // Stop adding products when the user enters Q
        if (categoryInput.Trim().ToLower() == "q")
        {
            break;
        }

        Console.Write("Enter a Product Name: ");
        string productName = Console.ReadLine() ?? "";

        Console.Write("Enter a Price: ");
        string priceInput = Console.ReadLine() ?? "";

        // Validate price input
        if (!decimal.TryParse(priceInput, out decimal price))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid price. Please enter a valid number.");
            Console.ResetColor();
            Pause();
            continue;
        }

        // Create category and product objects
        Category category = new Category(categoryInput);
        Product product = new Product(productName, price, category);

        // Add the product to the list
        products.Add(product);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("The product was successfully added!");
        Console.ResetColor();
        Pause();
    }
}

void DisplayProducts(string? highlightProductName = null)
{
    Console.Clear();

    if (products.Count == 0)
    {
        Console.WriteLine("No products have been added yet.");
        return;
    }

    // Sort products by price from low to high using LINQ
    var sortedProducts = products.OrderBy(p => p.Price).ToList();

    // Calculate total price using LINQ
    decimal totalAmount = sortedProducts.Sum(p => p.Price);

    Console.WriteLine("Category\tProduct\t\tPrice");
    Console.WriteLine("--------------------------------------------------");

    foreach (var product in sortedProducts)
    {
        bool isHighlighted = !string.IsNullOrWhiteSpace(highlightProductName) &&
                             product.Name.Equals(highlightProductName, StringComparison.OrdinalIgnoreCase);

        if (isHighlighted)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
        }

        Console.WriteLine($"{product.Category.Name}\t\t{product.Name}\t\t{product.Price}");

        if (isHighlighted)
        {
            Console.ResetColor();
        }
    }

    Console.WriteLine("--------------------------------------------------");
    Console.WriteLine($"Total amount:\t\t\t{totalAmount}");
    Console.WriteLine("--------------------------------------------------");
}

void ShowOptionsMenu()
{
    Console.WriteLine();
    Console.WriteLine("To enter a new product - enter: \"P\" | To search for a product - enter: \"S\" | To quit - enter: \"Q\"");
    Console.Write("Choose an option: ");
    string option = Console.ReadLine() ?? "";

    switch (option.Trim().ToLower())
    {
        case "p":
            AddProducts();
            break;

        case "s":
            SearchProduct();
            break;

        case "q":
            Environment.Exit(0);
            break;

        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid option.");
            Console.ResetColor();
            Pause();
            break;
    }
}

void SearchProduct()
{
    Console.Write("Enter a Product Name: ");
    string searchInput = Console.ReadLine() ?? "";

    var foundProduct = products
        .FirstOrDefault(p => p.Name.Equals(searchInput, StringComparison.OrdinalIgnoreCase));

    if (foundProduct == null)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Product not found.");
        Console.ResetColor();
        Pause();
        return;
    }

    DisplayProducts(foundProduct.Name);
    Pause();
}

void Pause()
{
    Console.WriteLine();
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}