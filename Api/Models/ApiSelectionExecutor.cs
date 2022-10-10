using System.Collections;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Api.Models;

public class ApiSelectionExecutor
{
    private readonly ApiSelector apiSelector;

    public ApiSelectionExecutor(ApiSelector apiSelector)
    {
        this.apiSelector = apiSelector;
    }

    public IDictionary<string,object> Execute<T>(T graph)
        where T : class
    {
        var element = new Dictionary<string, object>();

        var jobject = new JsonObject();

        // foreach (var prop in apiSelector)
        // {
        // }

        return element;
    }

    private IDictionary<string, object> GetProperty<T>(T graph, string property)
    {
        var element = new Dictionary<string, object>();
        //
        // if (property.Contains('.'))
        // {
        //     // TODO: Set property value with child properties.
        //     var props = new Stack<string>(
        //         property.Split('.',
        //             StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries));
        //
        //     foreach (var prop in props)
        //     {
        //     }
        //     return element;
        // }
        //

        return element;
    }
}