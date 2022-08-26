using MaterialsAPI.Dtos;
using MaterialsAPI.Models;

namespace MaterialsAPI.Services
{
    public class MaterialsService
    {
        public double CalculateWireLength(Wire wire)
        {
            return Math.Round(wire.Diameter * Math.PI * wire.DuctLength, 2);
        }

        public MaterialsType8 CalculateMaterialsType8(InputDto input, MaterialsType8 materials)
        {
            double ductLength = input.DuctLength;
            int addedLength = input.AddedLength;
            int profileLength = input.ProfileLength;
            int hRailConnectorCount = materials.HRailConnectorCount;

            int endlockCount = 2;
            int hRailProfileCount = (int)Math.Ceiling((ductLength + addedLength) / profileLength);

            if (addedLength != 0)
                hRailConnectorCount = hRailProfileCount;
            else
                hRailConnectorCount = hRailProfileCount - 1;

            AdjustProfileCount(ductLength, ref hRailProfileCount);

            int adjustableCableDropCount = hRailProfileCount + 1;
            int wireSuspensionCount = 0;
            int hRailAdjustableCableLockCount = adjustableCableDropCount;

            materials.EndlockCount = endlockCount;
            materials.HRailProfileCount = hRailProfileCount;
            materials.HRailConnectorCount = hRailConnectorCount;
            materials.AdjustableCableDropCount = adjustableCableDropCount;
            materials.WireSuspensionCount = wireSuspensionCount;
            materials.HRailAdjustableCableLockCount = hRailAdjustableCableLockCount;

            return materials;
        }

        public void AdjustProfileCount (double ductLength, ref int profileCount)
        {
            if ((profileCount * 2000 - ductLength) <= 500)
                profileCount++;
        }
    }
}
