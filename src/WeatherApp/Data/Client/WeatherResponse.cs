namespace WeatherApp.Data.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.8.0 (NJsonSchema v11.0.1.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class WeatherResponse
{

    [System.Text.Json.Serialization.JsonPropertyName("coord")]
    public Coord Coord { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("weather")]
    public System.Collections.Generic.ICollection<Weather> Weather { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("base")]
    public string Base { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("main")]
    public Main Main { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("visibility")]
    public int Visibility { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("wind")]
    public Wind Wind { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("clouds")]
    public Clouds Clouds { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("dt")]
    public int Dt { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("sys")]
    public Sys Sys { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("timezone")]
    public int Timezone { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public int Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("cod")]
    public int Cod { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}