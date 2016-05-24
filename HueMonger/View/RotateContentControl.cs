using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace HueMonger.View
{
    [Windows.UI.Xaml.Markup.ContentProperty(Name = "Content")]
    public sealed class RotateContentControl : Control
    {
        private ContentControl _content;
       
        public enum RotateDirection
        {
            Normal = 0,
            Up = 270,
            Down = 90,
            UpsideDown = 180
        };

        public object Content
        {
            get { return (object)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Content.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(object), typeof(RotateContentControl), null);

        public RotateDirection Direction
        {
            get { return (RotateDirection)GetValue(DirectionProperty); }
            set { SetValue(DirectionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Direction.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DirectionProperty =
            DependencyProperty.Register("Direction", typeof(RotateDirection), typeof(RotateContentControl), new PropertyMetadata(RotateDirection.Normal, OnDirectionPropertyChanged));

        private static void OnDirectionPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as RotateContentControl;

            if ((int)e.OldValue % 180 == (int)e.NewValue % 180)
            {
                // Flipping only changes flow not size
                control.InvalidateArrange();
            }
            else
            {
                // Need to remeasure
                control.InvalidateMeasure();
            }
        }

        public RotateContentControl()
        {
            this.DefaultStyleKey = typeof(RotateContentControl);
        }

        protected override void OnApplyTemplate()
        {
            _content = GetTemplateChild("Content") as ContentControl;
            base.OnApplyTemplate();
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            if (_content != null)
            {
                if (((int)Direction) % 180 == 90)
                {
                    _content.Measure(new Size(availableSize.Height, availableSize.Width));
                    return new Size(_content.DesiredSize.Height, _content.DesiredSize.Width);
                }
                else
                {
                    _content.Measure(availableSize);
                    return _content.DesiredSize;
                }
            }
            else
            {
                return base.MeasureOverride(availableSize);
            }
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            if (_content != null)
            {
                _content.RenderTransform = new RotateTransform() { Angle = (int)Direction };

                switch (Direction)
                {
                    case RotateDirection.Up:
                        _content.Arrange(new Rect(new Point(0, finalSize.Height), new Size(finalSize.Height, finalSize.Width)));
                        break;
                    case RotateDirection.Down:
                        _content.Arrange(new Rect(new Point(finalSize.Width, 0), new Size(finalSize.Height, finalSize.Width)));
                        break;
                    case RotateDirection.UpsideDown:
                        _content.Arrange(new Rect(new Point(finalSize.Width, finalSize.Height), finalSize));
                        break;
                    default:
                        _content.Arrange(new Rect(new Point(), finalSize));
                        break;
                }

                return finalSize;
            }
            else
            {
                return base.ArrangeOverride(finalSize);
            }
        }
    }
}
