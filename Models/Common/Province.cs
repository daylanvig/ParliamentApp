using System.Xml.Serialization;

namespace ParliamentApp.Models.Common
{
    public enum Province
    {
        [XmlEnum("Alberta")]
        Alberta,
        [XmlEnum("British Columbia")]
        BritishColumbia,
        [XmlEnum("Manitoba")]
        Manitoba,
        [XmlEnum("New Brunswick")]
        NewBrunswick,
        [XmlEnum("Newfoundland and Labrador")]
        NewfoundlandAndLabrador,
        [XmlEnum("Northwest Territories")]
        NorthwestTerritories,
        [XmlEnum("Nova Scotia")]
        NovaScotia,
        [XmlEnum("Nunavut")]
        Nunavut,
        [XmlEnum("Ontario")]
        Ontario,
        [XmlEnum("Prince Edward Island")]
        PrinceEdwardIsland,
        [XmlEnum("Quebec")]
        Quebec,
        [XmlEnum("Saskatchewan")]
        Saskatchewan,
        [XmlEnum("Yukon")]
        Yukon
    }
}
