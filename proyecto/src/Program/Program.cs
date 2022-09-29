using Library;
using System.Text.Json;
using System.Text.Json.Serialization;
public class Program
{
    public static void Main(string [] args)
    {
        Persona persona = new Persona("55383922", "Mateo", new DateTime(2003, 02, 13));
        Console.WriteLine(persona.ConvertToJson());
    }
}