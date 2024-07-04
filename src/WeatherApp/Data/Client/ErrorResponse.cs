namespace WeatherApp.Data.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.8.0 (NJsonSchema v11.0.1.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class ErrorResponse
{

    [System.Text.Json.Serialization.JsonPropertyName("cod")]
    public string Cod { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("message")]
    public string Message { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("parameters")]
    public System.Collections.Generic.ICollection<string> Parameters { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}