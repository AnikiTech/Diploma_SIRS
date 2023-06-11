using System;

namespace SIRS.RMT.Domain.Memory.Colors
{
    //https://github.com/aspnet/EntityFrameworkCore/issues/1368
    public class ColorsSettingToDictionary
    {
        private readonly Action<object, string> lazyLoader;
        private ColorsSetting _colorsSetting;
        private ColorsDictionary _colorsDictionary;

        public Guid ColorsSettingId { get; protected set; }
        public Guid ColorsDictionaryId { get; protected set; }

        public ColorsSetting ColorsSetting
        {
            get => lazyLoader.Load(this, ref _colorsSetting);
            protected set => _colorsSetting = value;
        }

        public ColorsDictionary ColorsDictionary
        {
            get => lazyLoader.Load(this, ref _colorsDictionary);
            protected set => _colorsDictionary = value;
        }

        private ColorsSettingToDictionary(Action<object, string> lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }

        public ColorsSettingToDictionary(ColorsSetting colorsSetting, ColorsDictionary colorsDictionary)
        {
            this.ColorsSetting = colorsSetting;
            this.ColorsDictionary = colorsDictionary;
        }
    }
}