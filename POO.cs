using System;

// 1. Encapsulamiento
public class Persona
{
    // Campos privados
    private string _nombre;
    private int _edad;

    // Propiedades públicas
    public string Nombre
    {
        get { return _nombre; }
        set 
        { 
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("El nombre no puede estar vacío");
            _nombre = value;
        }
    }

    // Propiedad con sintaxis abreviada
    public string Apellido { get; set; }

    // Propiedad de solo lectura
    public int Edad
    {
        get { return _edad; }
        private set { _edad = value; }
    }

    // Constructor
    public Persona(string nombre, string apellido, int edad)
    {
        Nombre = nombre;
        Apellido = apellido;
        _edad = edad;
    }
}

// 2. Herencia
public abstract class Vehiculo
{
    public string Marca { get; set; }
    public string Modelo { get; set; }

    // Método abstracto
    public abstract void Arrancar();

    // Método virtual que puede ser sobrescrito
    public virtual string ObtenerInformacion()
    {
        return $"Vehículo {Marca} {Modelo}";
    }
}

// Clase derivada
public class Coche : Vehiculo
{
    public int NumeroPuertas { get; set; }

    // Implementación del método abstracto
    public override void Arrancar()
    {
        Console.WriteLine("El coche arranca con la llave");
    }

    // Sobrescritura del método virtual
    public override string ObtenerInformacion()
    {
        return base.ObtenerInformacion() + $" con {NumeroPuertas} puertas";
    }
}

// 3. Interfaces
public interface IVolador
{
    void Despegar();
    void Aterrizar();
}

public interface IMantenible
{
    void RealizarMantenimiento();
}

// Clase que implementa múltiples interfaces
public class Avion : Vehiculo, IVolador, IMantenible
{
    public override void Arrancar()
    {
        Console.WriteLine("El avión enciende sus motores");
    }

    public void Despegar()
    {
        Console.WriteLine("El avión despega");
    }

    public void Aterrizar()
    {
        Console.WriteLine("El avión aterriza");
    }

    public void RealizarMantenimiento()
    {
        Console.WriteLine("Realizando mantenimiento del avión");
    }
}

// 4. Polimorfismo
public class Empleado : Persona
{
    public decimal Salario { get; set; }

    public Empleado(string nombre, string apellido, int edad, decimal salario) 
        : base(nombre, apellido, edad)
    {
        Salario = salario;
    }

    public virtual decimal CalcularSalarioAnual()
    {
        return Salario * 12;
    }
}

public class Gerente : Empleado
{
    public decimal Bonus { get; set; }

    public Gerente(string nombre, string apellido, int edad, decimal salario, decimal bonus) 
        : base(nombre, apellido, edad, salario)
    {
        Bonus = bonus;
    }

    public override decimal CalcularSalarioAnual()
    {
        return base.CalcularSalarioAnual() + Bonus;
    }
}

// 5. Clase estática
public static class Utilidades
{
    public static int ContadorInstancias { get; private set; }

    public static void IncrementarContador()
    {
        ContadorInstancias++;
    }
}

// Programa principal para demostrar el uso
class Program
{
    static void Main()
    {
        try
        {
            // Crear instancias y usar encapsulamiento
            Persona persona = new Persona("Juan", "Pérez", 30);
            Console.WriteLine($"Persona: {persona.Nombre} {persona.Apellido}");

            // Usar herencia y polimorfismo
            Coche coche = new Coche
            {
                Marca = "Toyota",
                Modelo = "Corolla",
                NumeroPuertas = 4
            };
            coche.Arrancar();
            Console.WriteLine(coche.ObtenerInformacion());

            // Usar interfaces
            Avion avion = new Avion
            {
                Marca = "Boeing",
                Modelo = "747"
            };
            avion.Arrancar();
            avion.Despegar();
            avion.Aterrizar();
            avion.RealizarMantenimiento();

            // Demostrar polimorfismo
            Empleado empleado = new Empleado("Ana", "García", 25, 30000);
            Gerente gerente = new Gerente("Carlos", "López", 40, 50000, 10000);

            Console.WriteLine($"Salario anual empleado: {empleado.CalcularSalarioAnual():C}");
            Console.WriteLine($"Salario anual gerente: {gerente.CalcularSalarioAnual():C}");

            // Usar clase estática
            Utilidades.IncrementarContador();
            Console.WriteLine($"Contador: {Utilidades.ContadorInstancias}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
