using System;

public class EjemplosMetodos
{
    // 1. Método básico
    public void MetodoSimple()
    {
        Console.WriteLine("Método simple");
    }

    // 2. Método con parámetros
    public int Sumar(int a, int b)
    {
        return a + b;
    }

    // 3. Método con parámetros opcionales
    public string Saludar(string nombre, string saludo = "Hola")
    {
        return $"{saludo}, {nombre}!";
    }

    // 4. Método con parámetros por referencia
    public void Intercambiar(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    // 5. Método con parámetros de salida
    public bool DividirConResultado(int numerador, int denominador, out double resultado)
    {
        if (denominador != 0)
        {
            resultado = (double)numerador / denominador;
            return true;
        }
        resultado = 0;
        return false;
    }

    // 6. Método con número variable de argumentos
    public int Sumar(params int[] numeros)
    {
        int suma = 0;
        foreach (int num in numeros)
            suma += num;
        return suma;
    }

    // 7. Método genérico
    public T ObtenerPrimero<T>(T[] array)
    {
        if (array.Length > 0)
            return array[0];
        return default(T);
    }

    // 8. Método estático
    public static double CalcularArea(double radio)
    {
        return Math.PI * radio * radio;
    }

    // 9. Método de extensión
    public static class ExtensionMethods
    {
        public static int ContarPalabras(this string str)
        {
            return str.Split(new char[] { ' ' }, 
                           StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }

    // 10. Método asíncrono
    public async Task<string> ObtenerDatosAsync()
    {
        await Task.Delay(1000); // Simula operación asíncrona
        return "Datos obtenidos";
    }

    // Programa principal para demostrar el uso
    public static void Main()
    {
        var ejemplo = new EjemplosMetodos();

        // Uso de métodos básicos
        ejemplo.MetodoSimple();

        // Uso de método con parámetros
        Console.WriteLine($"Suma: {ejemplo.Sumar(5, 3)}");

        // Uso de método con parámetros opcionales
        Console.WriteLine(ejemplo.Saludar("Juan"));
        Console.WriteLine(ejemplo.Saludar("María", "Buenos días"));

        // Uso de parámetros por referencia
        int x = 1, y = 2;
        ejemplo.Intercambiar(ref x, ref y);
        Console.WriteLine($"Después de intercambiar: x={x}, y={y}");

        // Uso de parámetros de salida
        double resultado;
        if (ejemplo.DividirConResultado(10, 2, out resultado))
            Console.WriteLine($"Resultado: {resultado}");

        // Uso de params
        Console.WriteLine($"Suma total: {ejemplo.Sumar(1, 2, 3, 4, 5)}");

        // Uso de método genérico
        string[] nombres = { "Ana", "Juan", "Pedro" };
        Console.WriteLine($"Primer nombre: {ejemplo.ObtenerPrimero(nombres)}");

        // Uso de método estático
        Console.WriteLine($"Área del círculo: {CalcularArea(5)}");

        // Uso de método de extensión
        string texto = "Este es un ejemplo";
        Console.WriteLine($"Número de palabras: {texto.ContarPalabras()}");

        // Uso de método asíncrono
        var tarea = ejemplo.ObtenerDatosAsync();
        tarea.Wait();
        Console.WriteLine(tarea.Result);
    }
}
