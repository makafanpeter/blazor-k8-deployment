namespace WeatherApp.Data.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.8.0 (NJsonSchema v11.0.1.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class Coord
{

    [System.Text.Json.Serialization.JsonPropertyName("lon")]
    public double Lon { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("lat")]
    public double Lat { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}