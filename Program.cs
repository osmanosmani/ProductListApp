using System;
using System.Collections.Generic;
using System.Linq;

// Stores all added products
List<Product> products = new List<Product>();

AddProducts();

while (true)
{
    DisplayProducts();
    ShowOptionsMenu();
}

void AddProducts()
{
    Console.Clear();

    while (true)
    {
        ShowAddHeader();

        Console.Write("Enter a Category: ");
        string categoryInput = (Console.ReadLine() ?? "").Trim();

        // Stop adding products when the user enters Q
        if (categoryInput.Equals("q", StringComparison.OrdinalIgnoreCase))
        {
            break;
        }

        if (string.IsNullOrWhiteSpace(categoryInput))
        {
            ShowError("Category cannot be empty.");
            continue;
        }

        Console.Write("Enter a Product Name: ");
        string productName = (Console.ReadLine() ?? "").Trim();

        if (string.IsNullOrWhiteSpace(productName))
        {
            ShowError("Product name cannot be empty.");
            continue;
        }

        Console.Write("Enter a Price: ");
        string priceInput = (Console.ReadLine() ?? "").Trim();

        // Validates that price is a number and not negative
        if (!decimal.TryParse(priceInput, out decimal price) || price < 0)
        {
            ShowError("Invalid price. Please enter a valid positive number.");
            continue;
        }

        Category category = new Category(categoryInput);
        Product product = new Product(productName, price, category);

        products.Add(product);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("The product was successfully added!");
        Console.ResetColor();

        PrintLine();
    }
}

void DisplayProducts(List<Product>? highlightedProducts = null)
{
    Console.Clear();

    if (products.Count == 0)
    {
        ShowError("No products have been added yet.");
        return;
    }

    // Sort products from lowest price to highest and calculate total
    var sortedProducts = products.OrderBy(p => p.Price).ToList();
    decimal totalAmount = sortedProducts.Sum(p => p.Price);

    PrintTableHeader();
    PrintLine();

    foreach (var product in sortedProducts)
    {
        bool isHighlighted = highlightedProducts != null &&
                             highlightedProducts.Any(p =>
                                 p.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase) &&
                                 p.Category.Name.Equals(product.Category.Name, StringComparison.OrdinalIgnoreCase) &&
                                 p.Price == product.Price);

        PrintProductRow(product, isHighlighted);
    }

    Console.WriteLine();
    Console.ResetColor();
    Console.WriteLine("{0,-25}{1,10}", "Total amount:", totalAmount);
    PrintLine();
}

void PrintTableHeader()
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("Category".PadRight(15));
    Console.Write("Product".PadRight(15));
    Console.WriteLine("Price".PadLeft(10));
    Console.ResetColor();
}

void PrintProductRow(Product product, bool isHighlighted)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write(product.Category.Name.PadRight(15));

    // Highlight searched product name
    Console.ForegroundColor = isHighlighted ? ConsoleColor.Magenta : ConsoleColor.Gray;
    Console.Write(product.Name.PadRight(15));

    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine(product.Price.ToString().PadLeft(10));

    Console.ResetColor();
}

void ShowOptionsMenu()
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("To enter a new product - enter: \"P\" | To search for a product - enter: \"S\" | To quit - enter: \"Q\"");
    Console.ResetColor();

    Console.Write("Choose an option: ");
    string option = (Console.ReadLine() ?? "").Trim().ToLower();

    switch (option)
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
            ShowError("Invalid option.");
            Pause();
            break;
    }
}

void SearchProduct()
{
    Console.Write("Enter a Product Name: ");
    string searchInput = (Console.ReadLine() ?? "").Trim();

    if (string.IsNullOrWhiteSpace(searchInput))
    {
        ShowError("Product name cannot be empty.");
        Pause();
        return;
    }

    // Finds matching products ignoring uppercase/lowercase differences
    var foundProducts = products
        .Where(p => p.Name.Equals(searchInput, StringComparison.OrdinalIgnoreCase))
        .ToList();

    if (!foundProducts.Any())
    {
        ShowError("Product not found.");
        Pause();
        return;
    }

    DisplayProducts(foundProducts);
    Pause();
}

void ShowAddHeader()
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("To enter a new product - follow the steps | To quit - enter: \"Q\"");
    Console.ResetColor();
}

void ShowError(string message)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(message);
    Console.ResetColor();
}

void PrintLine()
{
    Console.WriteLine("---------------------------------------------");
}

void Pause()
{
    Console.WriteLine();
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}