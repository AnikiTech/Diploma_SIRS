using SIRS.Infrastructure.Domain.Base.Entities;
using System;
using System.Collections.Generic;

namespace SIRS.RMT.Domain.Memory.Colors
{
    public class ColorsDictionary : Entity<Guid>
    {
        private readonly Action<object, string> lazyLoader;
        private List<ColorsSettingToDictionary> _colorsSettingToDictionary = new List<ColorsSettingToDictionary>();

        public string HexColor { get; protected set; }

        public List<ColorsSettingToDictionary> ColorsSettingToDictionary
        {
            get => lazyLoader.Load(this, ref _colorsSettingToDictionary);
            protected set => _colorsSettingToDictionary = value;
        }

        public ColorsDictionary(string hexColor)
        {
            if (string.IsNullOrEmpty(hexColor)) throw new ArgumentNullException(nameof(hexColor));

            this.HexColor = hexColor;
        }

        private ColorsDictionary(Action<object, string> lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }
    }
}