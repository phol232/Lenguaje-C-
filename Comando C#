using System;

class EstructurasControl
{
    static void Main()
    {
        // 1. IF-ELSE
        Console.WriteLine("--- Ejemplo IF-ELSE ---");
        int edad = 18;
        
        if (edad >= 18) {
            Console.WriteLine("Es mayor de edad");
        } else if (edad >= 13) {
            Console.WriteLine("Es adolescente");
        } else {
            Console.WriteLine("Es menor de edad");
        }

        // 2. SWITCH
        Console.WriteLine("\n--- Ejemplo SWITCH ---");
        string diaSemana = "Lunes";
        switch (diaSemana)
        {
            case "Lunes":
                Console.WriteLine("Inicio de semana");
                break;
            case "Viernes":
                Console.WriteLine("¡Fin de semana!");
                break;
            default:
                Console.WriteLine("Día entre semana");
                break;
        }

        // 3. FOR
        Console.WriteLine("\n--- Ejemplo FOR ---");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Iteración número: {i}");
        }

        // 4. WHILE
        Console.WriteLine("\n--- Ejemplo WHILE ---");
        int contador = 0;
        while (contador < 3)
        {
            Console.WriteLine($"Contador está en: {contador}");
            contador++;
        }

        // 5. DO-WHILE
        Console.WriteLine("\n--- Ejemplo DO-WHILE ---");
        int numero = 1;
        do
        {
            Console.WriteLine($"El número es: {numero}");
            numero *= 2;
        } while (numero <= 8);

        // 6. FOREACH
        Console.WriteLine("\n--- Ejemplo FOREACH ---");
        string[] frutas = { "Manzana", "Banana", "Naranja" };
        foreach (string fruta in frutas)
        {
            Console.WriteLine($"Fruta: {fruta}");
        }

        // 7. CONTINUE y BREAK
        Console.WriteLine("\n--- Ejemplo CONTINUE y BREAK ---");
        for (int i = 0; i < 5; i++)
        {
            if (i == 2) continue; // Salta la iteración cuando i es 2
            if (i == 4) break;    // Termina el ciclo cuando i es 4
            Console.WriteLine($"Número: {i}");
        }

        // 8. Estructura de control anidada
        Console.WriteLine("\n--- Ejemplo Estructuras Anidadas ---");
        for (int i = 1; i <= 3; i++)
        {
            for (int j = 1; j <= 3; j++)
            {
                if (i == j)
                {
                    Console.WriteLine($"i y j son iguales: {i}");
                }
            }
        }

        // 9. Switch con pattern matching (C# moderno)
        Console.WriteLine("\n--- Ejemplo Switch con Pattern Matching ---");
        object item = 123;
        switch (item)
        {
            case int n when n > 100:
                Console.WriteLine($"Número mayor que 100: {n}");
                break;
            case string s:
                Console.WriteLine($"Es una cadena: {s}");
                break;
            case null:
                Console.WriteLine("Es null");
                break;
            default:
                Console.WriteLine("Otro tipo");
                break;
        }

        // 10. Using statement (control de recursos)
        Console.WriteLine("\n--- Ejemplo Using ---");
        using (System.IO.StreamWriter writer = new System.IO.StreamWriter("test.txt"))
        {
            writer.WriteLine("Ejemplo de using");
        } // El archivo se cierra automáticamente
    }
}
