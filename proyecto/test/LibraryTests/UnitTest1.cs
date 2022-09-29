namespace LibraryTests;

using Library;
public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    
    public void ProbarCedulaValida()
    {
        Persona persona = new Persona("55383922", "Mateo", new DateTime(2003, 02, 13));
        bool resultado = persona.isCedulaValida(persona.GetCedula());
        Assert.AreEqual(true, resultado);
    }
}