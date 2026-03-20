# Product List Console App

## Overview
This is a C# Console Application that allows users to manage a list of products.

Users can:
- Add products with category, name, and price
- View all products sorted by price
- See the total price of all products
- Search for a product
- Highlight searched results

---

## Features

### Add Products
- Users can enter:
  - Category
  - Product Name
  - Price
- Input continues until the user enters **"Q"**

### Product List
- Products are displayed in a table format
- Sorted from lowest price to highest
- Total price is shown at the bottom

### Search Function (Extra)
- Users can search for a product by name
- The searched product is highlighted in the list

### Error Handling
- Invalid price inputs are handled safely using `TryParse`

### LINQ Usage
- Sorting: `OrderBy`
- Summing: `Sum`
- Searching: `FirstOrDefault`

---

## Example Usage

The user can:
- Add multiple products
- Stop input with "Q"
- View sorted product list
- See total price
- Search and highlight a product

---

## Technologies Used

- C#
- .NET Console Application
- LINQ

---

## Project Structure

- `Program.cs` – Main application logic  
- `Product.cs` – Product class  
- `Category.cs` – Category class  

---

## How to Run

1. Open the project in Visual Studio  
2. Run the application  
3. Follow the instructions in the console  

---

## Author

Osman Osmani
