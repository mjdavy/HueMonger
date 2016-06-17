#region License
//-----------------------------------------------------------------------
// <copyright>
//     Copyright matatabi-ux 2015.
// </copyright>
//-----------------------------------------------------------------------
#endregion

using GalaSoft.MvvmLight;
using System;
using System.Linq;
using Windows.UI;

namespace HueColorPicker
{
    /// <summary>
    /// Color picker ViewModel
    /// </summary>
    public partial class ColorPickerViewModel : ViewModelBase
    {
        private static readonly double PickerHeight = 150d;
        private static readonly double PickerWidth = 150d;
        private static readonly ColorConverter Converter = new ColorConverter();

        private string _color;
        private int _red;
        private string _redString;
        private int _green;
        private string _greenString;
        private int _blue;
        private string _blueString;
        private int _alpha;
        private string _alphaString;
        private double _pickPointX;
        private double _pickPointY;
        private string _hueColor;
        private double _colorSpectrumPoint;
        private string _redStartColor;
        private string _redEndColor;
        private string _greenStartColor;
        private string _greenEndColor;
        private string _blueStartColor;
        private string _blueEndColor;
        private string _alphaStartColor;
        private string _alphaEndColor;

        #region partial method declarations
        partial void OnAlphaEndColorChanging(ref string value);
        partial void OnAlphaEndColorChanged();
        partial void OnAlphaStartColorChanging(ref string value);
        partial void OnAlphaStartColorChanged();
        partial void OnBlueEndColorChanging(ref string value);
        partial void OnBlueEndColorChanged();
        partial void OnBlueStartColorChanging(ref string value);
        partial void OnBlueStartColorChanged();
        partial void OnGreenEndColorChanging(ref string value);
        partial void OnGreenEndColorChanged();
        partial void OnColorChanging(ref string value);
        partial void OnColorChanged();
        partial void OnRedChanging(ref int value);
        partial void OnRedChanged();
        partial void OnRedStringChanging(ref string value);
        partial void OnRedStringChanged();
        partial void OnGreenChanging(ref int value);
        partial void OnGreenChanged();
        partial void OnGreenStringChanging(ref string value);
        partial void OnGreenStringChanged();
        partial void OnBlueChanging(ref int value);
        partial void OnBlueChanged();
        partial void OnBlueStringChanging(ref string value);
        partial void OnBlueStringChanged();
        partial void OnAlphaChanging(ref int value);
        partial void OnAlphaChanged();
        partial void OnAlphaStringChanging(ref string value);
        partial void OnAlphaStringChanged();
        partial void OnPickPointYChanging(ref double value);
        partial void OnPickPointYChanged();
        partial void OnPickPointXChanging(ref double value);
        partial void OnPickPointXChanged();
        partial void OnHueColorChanging(ref string value);
        partial void OnHueColorChanged();
        partial void OnColorSpectrumPointChanging(ref double value);
        partial void OnColorSpectrumPointChanged();
        partial void OnRedStartColorChanging(ref string value);
        partial void OnRedStartColorChanged();
        partial void OnRedEndColorChanging(ref string value);
        partial void OnRedEndColorChanged();
        partial void OnGreenStartColorChanging(ref string value);
        partial void OnGreenStartColorChanged();
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public ColorPickerViewModel()
        {
            _color = "#FFFF0000";
            _pickPointX = 150d;
            _pickPointY = 0d;
            _colorSpectrumPoint = 0d;
            this.UpdateColor(Colors.Red);
            this.UpdatePickPoint();
        }

        public string Color
        {
            get
            {
                return _color;
            }

            set
            {
                this.OnColorChanging(ref value);
                Set(() => Color, ref _color, value);
                this.OnColorChanged();
            }
        }

        public int Red
        {
            get
            {
                return _red;
            }

            set
            {
                this.OnRedChanging(ref value);
                Set(() => Red, ref _red, value);
                this.OnRedChanged();
            }
        }

        public string RedString
        {
            get
            {
                return _redString;
            }

            set
            {
                this.OnRedStringChanging(ref value);
                Set(() => RedString, ref _redString, value);
                this.OnRedStringChanged();
            }
        }

        public int Green
        {
            get
            {
                return _green;
            }

            set
            {
                this.OnGreenChanging(ref value);
                Set(() => Green, ref _green, value);
                this.OnGreenChanged();
            }
        }

        public string GreenString
        {
            get
            {
                return _greenString;
            }

            set
            {
                this.OnGreenStringChanging(ref value);
                Set(() => GreenString, ref _greenString, value);
                this.OnGreenStringChanged();
            }
        }


        public int Blue
        {
            get
            {
                return _blue;
            }

            set
            {
                this.OnBlueChanging(ref value);
                Set(() => Blue, ref _blue, value);
                this.OnBlueChanged();
            }
        }

        public string BlueString
        {
            get
            {
                return _blueString;
            }

            set
            {
                this.OnBlueStringChanging(ref value);
                Set(() => BlueString, ref _blueString, value);
                this.OnBlueStringChanged();
            }
        }

        public int Alpha
        {
            get
            {
                return _alpha;
            }

            set
            {
                this.OnAlphaChanging(ref value);
                Set(() => Alpha, ref _alpha, value);
                this.OnAlphaChanged();
            }
        }


        public string AlphaString
        {
            get
            {
                return _alphaString;
            }

            set
            {
                this.OnAlphaStringChanging(ref value);
                Set(() => AlphaString, ref _alphaString, value);
                this.OnAlphaStringChanged();
            }
        }

        public double PickPointX
        {
            get
            {
                return _pickPointX;
            }

            set
            {
                this.OnPickPointXChanging(ref value);
                Set(() => PickPointX, ref _pickPointX, value);
                this.OnPickPointXChanged();
            }
        }

        public double PickPointY
        {
            get
            {
                return _pickPointY;
            }

            set
            {
                this.OnPickPointYChanging(ref value);
                Set(() => PickPointY, ref _pickPointY, value);
                this.OnPickPointYChanged();
            }
        }

        public string HueColor
        {
            get
            {
                return _hueColor;
            }

            set
            {
                this.OnHueColorChanging(ref value);
                Set(() => HueColor, ref _hueColor, value);
                this.OnHueColorChanged();

            }
        }


        public double ColorSpectrumPoint
        {
            get
            {
                return _colorSpectrumPoint;
            }

            set
            {
                this.OnColorSpectrumPointChanging(ref value);
                Set(() => ColorSpectrumPoint, ref _colorSpectrumPoint, value);
                this.OnColorSpectrumPointChanged();
            }
        }


        public string RedStartColor
        {
            get
            {
                return _redStartColor;
            }

            set
            {
                this.OnRedStartColorChanging(ref value);
                Set(() => RedStartColor, ref _redStartColor, value);
                this.OnRedStartColorChanged();
            }
        }


        public string RedEndColor
        {
            get
            {
                return _redEndColor;
            }

            set
            {
                this.OnRedEndColorChanging(ref value);
                Set(() => RedEndColor, ref _redEndColor, value);
                this.OnRedEndColorChanged();
            }
        }

        public string GreenStartColor
        {
            get
            {
                return _greenStartColor;
            }

            set
            {
                this.OnGreenStartColorChanging(ref value);
                Set(() => GreenStartColor, ref _greenStartColor, value);

            }
        }

        public string GreenEndColor
        {
            get
            {
                return _greenEndColor;
            }

            set
            {
                this.OnGreenEndColorChanging(ref value);
                Set(() => GreenEndColor, ref _greenEndColor, value);
                this.OnGreenEndColorChanged();
            }
        }

        public string BlueStartColor
        {
            get
            {
                return _blueStartColor;
            }

            set
            {
                this.OnBlueStartColorChanging(ref value);
                Set(() => BlueStartColor, ref _blueStartColor, value);
                this.OnBlueStartColorChanged();
            }
        }

        public string BlueEndColor
        {
            get
            {
                return _blueEndColor;
            }

            set
            {
                this.OnBlueEndColorChanging(ref value);
                Set(() => BlueEndColor, ref _blueEndColor, value);
                this.OnBlueEndColorChanged();
            }
        }

        public string AlphaStartColor
        {
            get
            {
                return _alphaStartColor;
            }

            set
            {
                this.OnAlphaStartColorChanging(ref value);
                Set(() => AlphaStartColor, ref _alphaStartColor, value);
                this.OnAlphaStartColorChanged();
            }
        }

        public string AlphaEndColor
        {
            get
            {
                return _alphaEndColor;
            }

            set
            {
                this.OnAlphaEndColorChanging(ref value);
                Set(() => AlphaEndColor, ref _alphaEndColor, value);
                this.OnAlphaEndColorChanged();
            }
        }

        /// <summary>
        /// Update color properties
        /// </summary>
        /// <param name="color">new color</param>
        public void UpdateColor(Color color)
        {
            _color = string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", color.A, color.R, color.G, color.B);
            _alpha = color.A;
            _alphaString = _alpha.ToString();
            _red = color.R;
            _redString = _red.ToString();
            _green = color.G;
            _greenString = _green.ToString();
            _blue = color.B;
            _blueString = _blue.ToString();

            _redStartColor = string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", 0xff, 0, color.G, color.B);
            _redEndColor = string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", 0xff, 0xff, color.G, color.B);
            _greenStartColor = string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", 0xff, color.R, 0, color.B);
            _greenEndColor = string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", 0xff, color.R, 0xff, color.B);
            _blueStartColor = string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", 0xff, color.R, color.G, 0);
            _blueEndColor = string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", 0xff, color.R, color.G, 0xff);
            _alphaStartColor = string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", 0, color.R, color.G, color.B);
            _alphaEndColor = string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", 0xff, color.R, color.G, color.B);

            var hsv = ToHSV(color);
            var h = FromHsv(hsv[0], 1f, 1f);
            _hueColor = string.Format("#FF{0:X2}{1:X2}{2:X2}", h.R, h.G, h.B);

            this.RaisePropertyChanged("Color");
            this.RaisePropertyChanged("Red");
            this.RaisePropertyChanged("RedString");
            this.RaisePropertyChanged("Green");
            this.RaisePropertyChanged("GreenString");
            this.RaisePropertyChanged("Blue");
            this.RaisePropertyChanged("BlueString");
            this.RaisePropertyChanged("Alpha");
            this.RaisePropertyChanged("AlphaString");
            this.RaisePropertyChanged("RedStartColor");
            this.RaisePropertyChanged("RedEndColor");
            this.RaisePropertyChanged("GreenStartColor");
            this.RaisePropertyChanged("GreenEndColor");
            this.RaisePropertyChanged("BlueStartColor");
            this.RaisePropertyChanged("BlueEndColor");
            this.RaisePropertyChanged("AlphaStartColor");
            this.RaisePropertyChanged("AlphaEndColor");
            this.RaisePropertyChanged("HueColor");
        }

        /// <summary>
        /// Update pick color point
        /// </summary>
        public void UpdatePickPoint()
        {
            var hsv = ToHSV((Color)Converter.Convert(_color, typeof(Color), null, null));
            _pickPointX = PickerWidth * hsv[1];
            _pickPointY = PickerHeight * (1 - hsv[2]);
            _colorSpectrumPoint = PickerHeight * hsv[0] / 360f;

            this.RaisePropertyChanged("PickPointX");
            this.RaisePropertyChanged("PickPointY");
            this.RaisePropertyChanged("ColorSpectrumPoint");
        }

        /// <summary>
        /// Convert rgb to hsv color
        /// </summary>
        /// <param name="color">rgb color</param>
        /// <returns>hsv color</returns>
        private static float[] ToHSV(Color color)
        {
            var rgb = new float[]
            {
                color.R / 255f, color.G / 255f, color.B / 255f
            };

            // RGB to HSV
            float max = rgb.Max();
            float min = rgb.Min();

            float h, s, v;
            if (max == min)
            {
                h = 0f;
            }
            else if (max == rgb[0])
            {
                h = (60f * (rgb[1] - rgb[2]) / (max - min) + 360f) % 360f;
            }
            else if (max == rgb[1])
            {
                h = 60f * (rgb[2] - rgb[0]) / (max - min) + 120f;
            }
            else
            {
                h = 60f * (rgb[0] - rgb[1]) / (max - min) + 240f;
            }

            if (max == 0d)
            {
                s = 0f;
            }
            else
            {
                s = (max - min) / max;
            }
            v = max;

            return new float[] { h, s, v };
        }

        /// <summary>
        /// Convert hsv to rgb color
        /// </summary>
        /// <param name="hue">hue</param>
        /// <param name="saturation">saturation</param>
        /// <param name="brightness">brightness</param>
        /// <returns>Color</returns>
        private static Color FromHsv(float hue, float saturation, float brightness)
        {
            if (saturation == 0)
            {
                var c = (byte)Math.Round(brightness * 255f, MidpointRounding.AwayFromZero);
                return ColorHelper.FromArgb(0xff, c, c, c);
            }

            var hi = ((int)(hue / 60f)) % 6;
            var f = hue / 60f - (int)(hue / 60d);
            var p = brightness * (1 - saturation);
            var q = brightness * (1 - f * saturation);
            var t = brightness * (1 - (1 - f) * saturation);

            float r, g, b;
            switch (hi)
            {
                case 0:
                    r = brightness;
                    g = t;
                    b = p;
                    break;

                case 1:
                    r = q;
                    g = brightness;
                    b = p;
                    break;

                case 2:
                    r = p;
                    g = brightness;
                    b = t;
                    break;

                case 3:
                    r = p;
                    g = q;
                    b = brightness;
                    break;

                case 4:
                    r = t;
                    g = p;
                    b = brightness;
                    break;

                case 5:
                    r = brightness;
                    g = p;
                    b = q;
                    break;

                default:
                    throw new InvalidOperationException();
            }

            return ColorHelper.FromArgb(
                0xff,
                (byte)Math.Round(r * 255d),
                (byte)Math.Round(g * 255d),
                (byte)Math.Round(b * 255d));
        }

        /// <summary>
        /// Process in changing color
        /// </summary>
        partial void OnColorChanged()
        {
            this.UpdateColor((Color)Converter.Convert(_color, typeof(Color), null, null));
            this.UpdatePickPoint();
        }

        /// <summary>
        /// Process in changing alpha channel string
        /// </summary>
        partial void OnAlphaStringChanged()
        {
            int parsed;
            if (int.TryParse(_alphaString, out parsed))
            {
                _alpha = parsed;
            }
            else
            {
                _alphaString = _alpha.ToString();
            }
        }

        /// <summary>
        /// Process in changing alpha channel
        /// </summary>
        partial void OnAlphaChanged()
        {
            var updated = (Color)Converter.Convert(_color, typeof(Color), null, null);
            updated.A = (byte)Math.Max(0, _alpha);
            updated.A = Math.Min((byte)0xff, updated.A);
            this.UpdateColor(updated);
            this.UpdatePickPoint();
        }

        /// <summary>
        /// Process in changing red string
        /// </summary>
        partial void OnRedStringChanged()
        {
            int parsed;
            if (int.TryParse(_redString, out parsed))
            {
                _red = parsed;
            }
            else
            {
                _redString = _red.ToString();
            }
        }

        /// <summary>
        /// Process in changing red
        /// </summary>
        partial void OnRedChanged()
        {
            var updated = (Color)Converter.Convert(_color, typeof(Color), null, null);
            updated.R = (byte)Math.Max(0, _red);
            updated.R = Math.Min((byte)0xff, updated.R);
            this.UpdateColor(updated);
            this.UpdatePickPoint();
        }

        /// <summary>
        /// Process in changing green string
        /// </summary>
        partial void OnGreenStringChanged()
        {
            int parsed;
            if (int.TryParse(_greenString, out parsed))
            {
                _green = parsed;
            }
            else
            {
                _greenString = _green.ToString();
            }
        }

        /// <summary>
        /// Process in changing green
        /// </summary>
        partial void OnGreenChanged()
        {
            var updated = (Color)Converter.Convert(_color, typeof(Color), null, null);
            updated.G = (byte)Math.Max(0, _green);
            updated.G = Math.Min((byte)0xff, updated.G);
            this.UpdateColor(updated);
            this.UpdatePickPoint();
        }

        /// <summary>
        /// Process in changing blue string
        /// </summary>
        partial void OnBlueStringChanged()
        {
            int parsed;
            if (int.TryParse(_blueString, out parsed))
            {
                _blue = parsed;
            }
            else
            {
                _blueString = _blue.ToString();
            }
        }

        /// <summary>
        /// Process in changing blue
        /// </summary>
        partial void OnBlueChanged()
        {
            var updated = (Color)Converter.Convert(_color, typeof(Color), null, null);
            updated.B = (byte)Math.Max(0, _blue);
            updated.B = Math.Min((byte)0xff, updated.B);
            this.UpdateColor(updated);
            this.UpdatePickPoint();
        }

        /// <summary>
        /// Process in changing color spectrum point
        /// </summary>
        partial void OnColorSpectrumPointChanged()
        {
            var old = (Color)Converter.Convert(_color, typeof(Color), null, null);
            var hsv = ToHSV(old);
            hsv[0] = (float)(_colorSpectrumPoint * 360f / PickerHeight);
            var updated = FromHsv(hsv[0], hsv[1], hsv[2]);
            updated.A = old.A;
            this.UpdateColor(updated);

            var h = FromHsv(hsv[0], 1f, 1f);
            _hueColor = string.Format("#FF{0:X2}{1:X2}{2:X2}", h.R, h.G, h.B);
        }

        /// <summary>
        /// Process in changing color pick point
        /// </summary>
        public void OnPickPointChanged()
        {
            var old = (Color)Converter.Convert(_hueColor, typeof(Color), null, null);
            var hsv = ToHSV(old);
            var updated = FromHsv(hsv[0], (float)(_pickPointX / PickerWidth), 1f - (float)(_pickPointY / PickerHeight));
            updated.A = old.A;
            this.UpdateColor(updated);
        }
    }
}
