# Product List Console App

## Overview
This project was built as part of a C# learning program and demonstrates practical use of object-oriented programming, LINQ, and console-based UI design.

It is a C# Console Application that allows users to manage a list of products by adding, viewing, sorting, and searching products in a structured way.

## Features

### Add Products
Users can enter:
- Category
- Product Name
- Price  

Input continues until the user enters **"Q"**.

### Product List
- Products are displayed in a clean table format  
- Sorted from lowest to highest price using LINQ  
- Total price is shown at the bottom  

### Search Function (Extra)
- Users can search for a product by name  
- Matching products are highlighted in the list  

### Error Handling
- Invalid price inputs are handled using `TryParse`  
- Prevents crashes and ensures valid input  

### LINQ Usage
- Sorting: `OrderBy()`
- Summing: `Sum()`
- Searching: `Where()`

## Project Status
- Completed core requirements (Level 1–3)  
- Extended with additional features (Level 4: search & highlight)  
- Built with clean structure and LINQ usage  

## Example Output
Below is an example of how the application looks when displaying products in the console.

*(Add your screenshot here if needed)*

## Technologies Used
- C#
- .NET Console Application
- LINQ

## Project Structure
- `Program.cs` – Main application logic  
- `Product.cs` – Product class  
- `Category.cs` – Category class  

## How to Run
1. Open the project in Visual Studio  
2. Build and run the application  
3. Follow the instructions in the console  

## Author
Osman Osmani
