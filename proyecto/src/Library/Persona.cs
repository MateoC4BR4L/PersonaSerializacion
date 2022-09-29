namespace Library;
using System.Text.Json;
using System.Text.Json.Serialization;
public class Persona : IJsonConvertible{

    private static string cedulaReferencia = "2987634";
    private string cedula;  //Cedula tiene el formato 12345678
    private string nombre;
    private DateTime fechaNacimiento;

    [JsonConstructor]
    public Persona(string cedula, string nombre, DateTime nacimiento) {
        this.cedula = cedula;
        this.nombre = nombre;
        this.fechaNacimiento = nacimiento;
    }
    public Persona(string json)
        {
            this.LoadFromJson(json);
        }


    public string GetCedula() {
        this.cedula = this.cedula.Replace(".", "");
        this.cedula = this.cedula.Replace("-", "");
        this.cedula = this.cedula.Replace("/", "");
        this.cedula = this.cedula.Replace(" ", "");
        this.cedula = this.cedula.Trim();   
        return this.cedula;
    }
    public void SetCedula(string cedula) {
        if (isCedulaValida(cedula) == true) {
            this.cedula = cedula;    
        }
        else{
            Console.WriteLine("La cedula ingresada es invalida");
        }
    }
    public string GetNombre() {
        return this.nombre;
    }
    public void SetNombre(string nombre) {
        this.nombre = nombre;
    }

    public DateTime GetFechaNacimiento(){
        return this.fechaNacimiento;  
    }

    public void SetFechaNacimiento(DateTime fecha) {
        this.fechaNacimiento=fecha;
    }

    public int GetEdad() {
        int edad = 0;
        DateTime fecha = DateTime.Now;
    
        edad = fecha.Year-this.fechaNacimiento.Year;
        if (fecha.Month >= this.fechaNacimiento.Month && fecha.Day >= this.fechaNacimiento.Day)
        {
          return edad;
        }
        else
        {
            edad-=1;
        }
        return edad;   
    }
    public bool isCedulaValida(string cedula){
        cedula = cedula.Replace(".", "");
        cedula = cedula.Replace("-", "");
        this.cedula = this.cedula.Replace("/", "");
        this.cedula = this.cedula.Replace(" ", "");
        this.cedula = this.cedula.Trim();   
        int suma = 0;
        int resto = 0;
        int digito = 0;
        List<int> ci = new List<int>();
        for (int i = 0; i < cedula.Length; i++){
            int a = int.Parse(cedula.Substring(i,1));
            ci.Add(a);
        }
        suma = (ci[6] * 4) + (ci[5] * 3) + (ci[4] * 6) + (ci[3] * 7) + (ci[2] * 8) + (ci[1] * 9) + (ci[0] * 2);
        resto = suma % 10;
        if (resto != 0){
            digito = 10 - resto;
        }
        if (digito == ci[7]){
            return true;
        }   
        else{
            return false;
        }   
    }

    public void LoadFromJson(string json)
        {
            Persona deserialized = JsonSerializer.Deserialize<Persona>(json);
            this.nombre = deserialized.nombre;
            this.cedula = deserialized.cedula;
            this.fechaNacimiento = deserialized.fechaNacimiento;
        }
    
     public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this);
        }
}
