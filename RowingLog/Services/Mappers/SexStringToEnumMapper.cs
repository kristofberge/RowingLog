using RowingLog.Common.Enums;

namespace RowingLog.Services.Mappers
{
    public class SexStringToEnumMapper : IMapper<string, Sex>
    {
        public Sex Map(string from)
        {
            switch(from.ToLowerInvariant())
            {
                case "f":
                    return Sex.Female;
                case "m":
                    return Sex.Male;
                default:
                    return Sex.Other;
            }
        }
    }
}
