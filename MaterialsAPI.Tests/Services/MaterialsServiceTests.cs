using MaterialsAPI.Services;
using MaterialsAPI.Models;
using NUnit.Framework;
using System;
using MaterialsAPI.Dtos;
using System.Collections.Generic;

namespace MaterialsAPI.Tests.Services
{
    [TestFixture]
    public class MaterialsServiceTests
    {
        [Test]
        public void CalculateWireLength_GivenInputs_ReturnResults()
        {
            var materialsService = new MaterialsService();
            var wire = new Wire();

            wire.Diameter = 10;
            wire.DuctLength = 10;

            var wireLength = Math.Round(materialsService.CalculateWireLength(wire), 2);
            Assert.AreEqual(314.16, wireLength);
        }


        [Test]
        public void CalculateMaterialsType8_AllInputs_ReturnMaterials()
        {
            var materialsService = new MaterialsService();
            var materialsType8 = new MaterialsType8();
            var input = new InputDto();

            input.DuctLength = 100;
            input.AddedLength = 100;
            input.ProfileLength = 10;

            var materialsType8Results = materialsService.CalculateMaterialsType8(input, materialsType8);

            Assert.AreEqual((2, 20, 20, 21, 0, 21),
                (materialsType8Results.EndlockCount, materialsType8Results.HRailProfileCount,
                materialsType8Results.HRailConnectorCount, materialsType8Results.AdjustableCableDropCount,
                materialsType8Results.WireSuspensionCount, materialsType8Results.HRailAdjustableCableLockCount));
        }

        [Test]
        public void CalculateMaterialsType8_OnlyRequiredInputs_ReturnMaterials()
        {
            var materialsService = new MaterialsService();
            var materialsType8 = new MaterialsType8();
            var input = new InputDto();

            input.DuctLength = 100;
            input.ProfileLength = 10;

            var materialsType8Results = materialsService.CalculateMaterialsType8(input, materialsType8);

            Assert.AreEqual((2, 10, 9, 11, 0, 11),
                (materialsType8Results.EndlockCount, materialsType8Results.HRailProfileCount,
                materialsType8Results.HRailConnectorCount, materialsType8Results.AdjustableCableDropCount,
                materialsType8Results.WireSuspensionCount, materialsType8Results.HRailAdjustableCableLockCount));
        }
    }
}
