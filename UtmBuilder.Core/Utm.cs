using UtmBuilder.Core.ValueObjects;

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

}