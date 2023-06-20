using UtmBuilder.Core.Extensions;
using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core;

public class Utm
{
    public Utm(Url url, Campaign campaing)
    {
        Url = url;
        Campaign = campaing;
    }

    /// <summary>
    /// Url (Website link)
    /// </summary>
    public Url Url { get; }

    /// <summary>
    /// Campain details
    /// </summary>
    public Campaign Campaign { get; }

    public static implicit operator string(Utm utm)
        => utm.ToString();

    public static implicit operator Utm(string link)
    {
        if (string.IsNullOrEmpty(link))
            throw new InvalidUrlException();

        var url = new Url(link);
        var segments = url.Address.Split("?");

        if (segments.Length == 1)
            throw new InvalidUrlException("No segments were provided");

        var parms = segments[1].Split("&");
        var source = parms.Where(x => x.StartsWith("utm_source")).FirstOrDefault("").Split("=")[1];
        var medium = parms.Where(x => x.StartsWith("utm_medium")).FirstOrDefault("").Split("=")[1];
        var name = parms.Where(x => x.StartsWith("utm_name")).FirstOrDefault("").Split("=")[1];
        var id = parms.Where(x => x.StartsWith("utm_id")).FirstOrDefault("").Split("=")[1];
        var term = parms.Where(x => x.StartsWith("utm_term")).FirstOrDefault("").Split("=")[1];
        var content = parms.Where(x => x.StartsWith("utm_content")).FirstOrDefault("").Split("=")[1];

        var utm = new Utm(new Url(segments[0]), new Campaign(source, medium, name, id, term, content));

        return utm;
    }

    public override string ToString()
    {
        var urlSegments = new List<string>();
        urlSegments.AddIfNotNull("utm_source", Campaign.Source);
        urlSegments.AddIfNotNull("utm_medium", Campaign.Medium);
        urlSegments.AddIfNotNull("utm_name", Campaign.Name);
        urlSegments.AddIfNotNull("utm_id", Campaign.Id);
        urlSegments.AddIfNotNull("utm_term", Campaign.Term);
        urlSegments.AddIfNotNull("utm_content", Campaign.Content);
        return $"{Url.Address}?{string.Join("&", urlSegments)}";
    }

}