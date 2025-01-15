using System;
using System.Collections.Generic;
using System.Linq;

public class EjemplosLINQ
{
    public static void Main()
    {
        // Datos de ejemplo
        List<Producto> productos = new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Laptop", Precio = 1200, Categoria = "Electrónica" },
            new Producto { Id = 2, Nombre = "Smartphone", Precio = 800, Categoria = "Electrónica" },
            new Producto { Id = 3, Nombre = "Mesa", Precio = 200, Categoria = "Muebles" },
            new Producto { Id = 4, Nombre = "Silla", Precio = 100, Categoria = "Muebles" },
            new Producto { Id = 5, Nombre = "Tablet", Precio = 300, Categoria = "Electrónica" }
        };

        // 1. Filtrado básico (Where)
        var productosCaros = productos.Where(p => p.Precio > 500);
        Console.WriteLine("Productos caros:");
        foreach (var p in productosCaros)
            Console.WriteLine($"{p.Nombre}: ${p.Precio}");

        // 2. Ordenamiento (OrderBy, ThenBy)
        var productosOrdenados = productos
            .OrderBy(p => p.Categoria)
            .ThenByDescending(p => p.Precio);
        Console.WriteLine("\nProductos ordenados por categoría y precio:");
        foreach (var p in productosOrdenados)
            Console.WriteLine($"{p.Categoria} - {p.Nombre}: ${p.Precio}");

        // 3. Selección (Select)
        var nombresProductos = productos.Select(p => p.Nombre);
        Console.WriteLine("\nNombres de productos:");
        foreach (var nombre in nombresProductos)
            Console.WriteLine(nombre);

        // 4. Agrupación (GroupBy)
        var gruposPorCategoria = productos.GroupBy(p => p.Categoria);
        Console.WriteLine("\nProductos agrupados por categoría:");
        foreach (var grupo in gruposPorCategoria)
        {
            Console.WriteLine($"\nCategoría: {grupo.Key}");
            foreach (var p in grupo)
                Console.WriteLine($"  {p.Nombre}: ${p.Precio}");
        }

        // 5. Agregación (Count, Sum, Average, Min, Max)
        var totalProductos = productos.Count();
        var precioTotal = productos.Sum(p => p.Precio);
        var precioPromedio = productos.Average(p => p.Precio);
        var precioMinimo = productos.Min(p => p.Precio);
        var precioMaximo = productos.Max(p => p.Precio);

        Console.WriteLine("\nEstadísticas:");
        Console.WriteLine($"Total productos: {totalProductos}");
        Console.WriteLine($"Precio total: ${precioTotal}");
        Console.WriteLine($"Precio promedio: ${precioPromedio:F2}");
        Console.WriteLine($"Precio mínimo: ${precioMinimo}");
        Console.WriteLine($"Precio máximo: ${precioMaximo}");

        // 6. First, Single, Any, All
        var primerElectronico = productos.First(p => p.Categoria == "Electrónica");
        var existenMuebles = productos.Any(p => p.Categoria == "Muebles");
        var todosSonCaros = productos.All(p => p.Precio > 1000);

        Console.WriteLine($"\nPrimer producto electrónico: {primerElectronico.Nombre}");
        Console.WriteLine($"¿Existen muebles?: {existenMuebles}");
        Console.WriteLine($"¿Todos son caros?: {todosSonCaros}");

        // 7. Take, Skip, Take While
        var primerosTres = productos.Take(3);
        var saltarDos = productos.Skip(2);
        var takeWhile = productos.TakeWhile(p => p.Precio > 300);

        // 8. Join
        List<Categoria> categorias = new List<Categoria>
        {
            new Categoria { Id = 1, Nombre = "Electrónica" },
            new Categoria { Id = 2, Nombre = "Muebles" }
        };

        var join = productos.Join(
            categorias,
            producto => producto.Categoria,
            categoria => categoria.Nombre,
            (producto, categoria) => new { 
                ProductoNombre = producto.Nombre, 
                CategoriaNombre = categoria.Nombre 
            });

        Console.WriteLine("\nJoin de productos y categorías:");
        foreach (var item in join)
            Console.WriteLine($"{item.ProductoNombre} - {item.CategoriaNombre}");

        // 9. Let y Into (Query Syntax)
        var queryConLet = from p in productos
                         let precioConImpuesto = p.Precio * 1.16m
                         where precioConImpuesto > 500
                         select new { 
                             p.Nombre, 
                             PrecioOriginal = p.Precio, 
                             PrecioConImpuesto = precioConImpuesto 
                         };

        Console.WriteLine("\nPrecios con impuesto:");
        foreach (var item in queryConLet)
            Console.WriteLine($"{item.Nombre}: ${item.PrecioOriginal} -> ${item.PrecioConImpuesto:F2}");
    }
}

public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public string Categoria { get; set; }
}

public class Categoria
{
    public int Id { get; set; }
    public string Nombre { get; set; }
}
