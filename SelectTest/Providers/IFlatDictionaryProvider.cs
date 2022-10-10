namespace SelectTest.Providers;

public interface IFlatDictionaryProvider
{
    Dictionary<string, string> Execute(object @object, string prefix = "");
}