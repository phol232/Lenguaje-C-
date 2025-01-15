using System;
using System.Collections.Generic;

public class EjemplosColecciones
{
    public static void Main()
    {
        // 1. List<T>
        List<string> lista = new List<string>();
        lista.Add("Uno");
        lista.Add("Dos");
        lista.Add("Tres");
        Console.WriteLine("Lista:");
        lista.ForEach(item => Console.WriteLine(item));

        // 2. Dictionary<TKey, TValue>
        Dictionary<string, int> diccionario = new Dictionary<string, int>();
        diccionario.Add("Uno", 1);
        diccionario.Add("Dos", 2);
        Console.WriteLine("\nDiccionario:");
        foreach (var kvp in diccionario)
            Console.WriteLine($"Clave: {kvp.Key}, Valor: {kvp.Value}");

        // 3. HashSet<T>
        HashSet<int> conjunto = new HashSet<int>();
        conjunto.Add(1);
        conjunto.Add(2);
        conjunto.Add(1); // No se añade (duplicado)
        Console.WriteLine("\nHashSet:");
        foreach (var item in conjunto)
            Console.WriteLine(item);

        // 4. Queue<T>
        Queue<string> cola = new Queue<string>();
        cola.Enqueue("Primero");
        cola.Enqueue("Segundo");
        Console.WriteLine("\nCola:");
        while (cola.Count > 0)
            Console.WriteLine(cola.Dequeue());

        // 5. Stack<T>
        Stack<string> pila = new Stack<string>();
        pila.Push("Primero");
        pila.Push("Segundo");
        Console.WriteLine("\nPila:");
        while (pila.Count > 0)
            Console.WriteLine(pila.Pop());

        // 6. LinkedList<T>
        LinkedList<string> listaEnlazada = new LinkedList<string>();
        listaEnlazada.AddLast("Uno");
        listaEnlazada.AddLast("Dos");
        Console.WriteLine("\nLista Enlazada:");
        foreach (var item in listaEnlazada)
            Console.WriteLine(item);

        // 7. SortedList<TKey, TValue>
        SortedList<int, string> listaOrdenada = new SortedList<int, string>();
        listaOrdenada.Add(3, "Tres");
        listaOrdenada.Add(1, "Uno");
        listaOrdenada.Add(2, "Dos");
        Console.WriteLine("\nLista Ordenada:");
        foreach (var item in listaOrdenada)
            Console.WriteLine($"{item.Key}: {item.Value}");
    }
}
