using System.Text.Json;
using System.Text.Json.Serialization;
public interface IJsonConvertible
{
    string ConvertToJson();
    void LoadFromJson(string json);
}