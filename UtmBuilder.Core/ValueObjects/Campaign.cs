using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.ValueObjects;

public class Campaign : ValueObject
{
    /// <summary>
    /// Generates a new campaing for a URL
    /// </summary>
    /// <param name="name">Product, promo code, or slogan. One campaing name or id is required.</param>
    /// <param name="source">The referrer (e.g. google, newsletter).</param>
    /// <param name="medium">Marketing medium (e.g. cpc, banner, email).</param>
    /// <param name="id">The ads campaing id.</param>
    /// <param name="term">Identify the paid keywords.</param>
    /// <param name="content">Use to differentiate ads</param>
    public Campaign(string name, string source, string medium,
        string? id = null, string? term = null, string? content = null)
    {
        Name = name;
        Source = source;
        Medium = medium;
        Id = id;
        Term = term;
        Content = content;

        InvalidCampaignException.ThrowIfNull(name, "Name is invalid.");
        InvalidCampaignException.ThrowIfNull(source, "Source is invalid.");
        InvalidCampaignException.ThrowIfNull(medium, "Medium is invalid.");
    }

    public string? Id { get; set; }
    public string Name { get; set; }

    /// <summary>
    /// The referrer (e.g. google, newsletter).
    /// </summary>
    public string Source { get; set; }

    /// <summary>
    /// Marketing medium (e.g. cpc, banner, email).
    /// </summary>
    public string Medium { get; set; }

    /// <summary>
    /// Identify the paid keywords.
    /// </summary>
    public string? Term { get; set; }

    /// <summary>
    /// Use to differentiate ads
    /// </summary>
    public string? Content { get; set; }

}