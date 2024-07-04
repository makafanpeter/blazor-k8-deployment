namespace WeatherApp.Data.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.8.0 (NJsonSchema v11.0.1.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class Main
{

    [System.Text.Json.Serialization.JsonPropertyName("temp")]
    public double Temp { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("feels_like")]
    public double Feels_like { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("temp_min")]
    public double Temp_min { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("temp_max")]
    public double Temp_max { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("pressure")]
    public int Pressure { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("humidity")]
    public int Humidity { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("sea_level")]
    public int Sea_level { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("grnd_level")]
    public int Grnd_level { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}