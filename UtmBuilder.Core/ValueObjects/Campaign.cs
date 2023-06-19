namespace UtmBuilder.Core.ValueObjects;

public class Campaign : ValueObject
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Source { get; set; } = string.Empty;
    public string Medium { get; set; } = string.Empty;
    public string Term { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}