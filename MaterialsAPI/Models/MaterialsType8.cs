using System.Text.Json.Serialization;

namespace MaterialsAPI.Models
{
    public class MaterialsType8
    {
        [JsonIgnore]
        public double DuctLength { get; set; }

        [JsonIgnore]
        public int AddedLength { get; set; }

        [JsonIgnore]
        public int ProfileLength { get; set; }

        public int EndlockCount { get; set; }

        public int HRailProfileCount { get; set; }

        public int HRailConnectorCount { get; set; }

        public int AdjustableCableDropCount { get; set; }

        public int WireSuspensionCount { get; set; }

        public int HRailAdjustableCableLockCount { get; set; }
    }
}
