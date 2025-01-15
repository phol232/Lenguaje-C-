using System;
using System.IO;

public class EjemplosExcepciones
{
    public static void Main()
    {
        // 1. Try-Catch básico
        try
        {
            Console.WriteLine("División entre números:");
            int numerador = 10;
            int denominador = 0;
            int resultado = numerador / denominador;
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Error de división: {ex.Message}");
        }

        // 2. Múltiples catch
        try
        {
            string[] array = new string[3];
            array[5] = "Test"; // Generará excepción
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine($"Error de índice: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error general: {ex.Message}");
        }

        // 3. Finally
        FileStream archivo = null;
        try
        {
            archivo = File.Open("archivo.txt", FileMode.Open);
            // Código que trabaja con el archivo
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"No se encontró el archivo: {ex.Message}");
        }
        finally
        {
            if (archivo != null)
                archivo.Dispose();
        }

        // 4. Throw y excepciones personalizadas
        try
        {
            ValidarEdad(-5);
        }
        catch (EdadInvalidaException ex)
        {
            Console.WriteLine($"Error de validación: {ex.Message}");
        }

        // 5. Using statement (manejo automático de recursos)
        try
        {
            using (StreamWriter writer = new StreamWriter("test.txt"))
            {
                writer.WriteLine("Prueba");
            } // Se cierra automáticamente
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error de E/S: {ex.Message}");
        }

        // 6. Exception filtering (C# 6+)
        try
        {
            throw new Exception("Error con código 404");
        }
        catch (Exception ex) when (ex.Message.Contains("404"))
        {
            Console.WriteLine("Error 404 capturado");
        }

        // 7. Nested try-catch
        try
        {
            try
            {
                throw new ArgumentException("Error en argumento");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Capturado en bloque interno");
                throw; // Re-throw
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Capturado en bloque externo");
        }
    }

    // Excepción personalizada
    public class EdadInvalidaException : Exception
    {
        public EdadInvalidaException() : base() { }
        public EdadInvalidaException(string message) : base(message) { }
        public EdadInvalidaException(string message, Exception inner) 
            : base(message, inner) { }
    }

    // Método que lanza excepción personalizada
    public static void ValidarEdad(int edad)
    {
        if (edad < 0)
            throw new EdadInvalidaException("La edad no puede ser negativa");
    }
}
