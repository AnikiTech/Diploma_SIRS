using SIRS.Infrastructure.Domain.Base.User;
using SIRS.RMT.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIRS.RMT.Domain.Memory.Colors
{
    public class ColorsSetting : SirsUserEntity<User>
    {
        private readonly Action<object, string> lazyLoader;
        private List<ColorsSettingToDictionary> _colorsSettingToDictionary = new List<ColorsSettingToDictionary>();
        private User _user;

        public List<ColorsSettingToDictionary> ColorsSettingToDictionary
        {
            get => lazyLoader.Load(this, ref _colorsSettingToDictionary);
            protected set => _colorsSettingToDictionary = value;
        }

        public string HexColorBackground { get; protected set; }

        public override User User
        {
            get => lazyLoader.Load(this, ref _user);
            protected set => _user = value;
        }

        private ColorsSetting(Action<object, string> lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }

        public ColorsSetting(string hexColorBackground, IList<ColorsDictionary> colors, User user) : base(user)
        {
            if (string.IsNullOrEmpty(hexColorBackground)) throw new ArgumentNullException(nameof(hexColorBackground));
            if (!colors.Any()) throw new Exception("Settings must have colors (include default)");

            this.HexColorBackground = hexColorBackground;

            colors.ToList().ForEach(x =>
            {
                this.ColorsSettingToDictionary.Add(new ColorsSettingToDictionary(this, x));
            });
        }

        // TODO need thinking... case when user change default color via UI (settings) and BO take id of colors dictionary
        //public void ChangeColor(ColorsDictionary color, string newHexColor)
        //{
        //    if (string.IsNullOrEmpty(newHexColor)) throw new ArgumentNullException(nameof(newHexColor));

        //    if (color.HexColor != newHexColor)
        //    {
        //        ColorsDictionary.Add(new ColorsDictionary(newHexColor));
        //    }
        //}
    }
}