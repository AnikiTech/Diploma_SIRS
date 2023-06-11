using NUnit.Framework;
using SIRS.RMT.Domain.Tools;
using System;

namespace SIRS.RMT.Tests
{
    public class ShuffleArrayTest
    {
        [Test]
        public void Order_MustBe_Changed()
        {
            var defaultColors = new[] { "#4286f5", "#673bb7", "#b19bd9", "#109d58", "#f5b400", "#fe5722", "#ea1e63", "#e8d1a8", "#795547", "#607d8b" };

            var colors = new string[defaultColors.Length];
            Array.Copy(defaultColors, colors, defaultColors.Length);
            colors.Shuffle();

            var original = string.Join(", ", defaultColors);
            var afterChanges = string.Join(", ", colors);

            Assert.IsFalse(original == afterChanges);
        }
    }
}