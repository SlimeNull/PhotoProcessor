using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using PhotoProcessor.Editing;
using PhotoProcessor.Editing.Tools;
using PhotoProcessor.Extensions;
using SkiaSharp;

namespace PhotoProcessor.Controls
{
    public class ProjectEditor : Control
    {
        private SKBitmap? _buffer;
        private WriteableBitmap? _cachedBitmap;

        static ProjectEditor()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ProjectEditor), new FrameworkPropertyMetadata(typeof(ProjectEditor)));
        }

        public Project? Project
        {
            get { return (Project)GetValue(ProjectProperty); }
            set { SetValue(ProjectProperty, value); }
        }

        public Layer CurrentLayer
        {
            get { return (Layer)GetValue(CurrentLayerProperty); }
            set { SetValue(CurrentLayerProperty, value); }
        }

        public Tool? CurrentTool
        {
            get { return (Tool)GetValue(CurrentToolProperty); }
            set { SetValue(CurrentToolProperty, value); }
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            if (CurrentLayer is not null &&
                CurrentTool is not null &&
                CaptureMouse())
            {
                e.Handled = true;
                var mousePosition = e.GetPosition(this);

                CurrentTool.OnCursorDown(CurrentLayer, (int)mousePosition.X, (int)mousePosition.Y);
                InvalidateVisual();
                return;
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (CurrentLayer is not null &&
                CurrentTool is not null && 
                IsMouseCaptured)
            {
                e.Handled = true;
                var mousePosition = e.GetPosition(this);

                CurrentTool.OnCursorDrag(CurrentLayer, (int)mousePosition.X, (int)mousePosition.Y);
                InvalidateVisual();
                return;
            }

            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            ReleaseMouseCapture();

            if (CurrentLayer is not null &&
                CurrentTool is not null)
            {
                e.Handled = true;
                var mousePosition = e.GetPosition(this);

                CurrentTool.OnCursorUp(CurrentLayer, (int)mousePosition.X, (int)mousePosition.Y);
                InvalidateVisual();
                return;
            }

            base.OnMouseUp(e);
        }

        protected override Size MeasureOverride(Size constraint)
        {
            if (Project is not null)
            {
                return new Size(Project.PixelWidth, Project.PixelHeight);
            }

            return base.MeasureOverride(constraint);
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if (Project is null)
            {
                return;
            }

            if (_cachedBitmap is null ||
                _cachedBitmap.PixelWidth != Project.PixelWidth ||
                _cachedBitmap.PixelHeight != Project.PixelHeight)
            {
                _cachedBitmap = new WriteableBitmap(Project.PixelWidth, Project.PixelHeight, 96, 96, Project.ColorType.ToWpfPixelFormat(), null);
            }

            if (_buffer is null ||
                _buffer.Width != Project.PixelWidth ||
                _buffer.Height != Project.PixelHeight)
            {
                _buffer = new SKBitmap(Project.PixelWidth, Project.PixelHeight, Project.ColorType, SKAlphaType.Unpremul);
            }

            using var canvas = new SKCanvas(_buffer);
            Project.Render(canvas);

            _cachedBitmap.WritePixels(new Int32Rect(0, 0, Project.PixelWidth, Project.PixelHeight), _buffer.GetPixels(), _buffer.ByteCount, _buffer.RowBytes);

            drawingContext.DrawImage(_cachedBitmap, new Rect(0, 0, Project.PixelWidth, Project.PixelHeight));
        }

        public static readonly DependencyProperty ProjectProperty =
            DependencyProperty.Register(nameof(Project), typeof(Project), typeof(ProjectEditor), new PropertyMetadata(null, propertyChangedCallback: OnProjectChanged));

        public static readonly DependencyProperty CurrentLayerProperty =
            DependencyProperty.Register(nameof(CurrentLayer), typeof(Layer), typeof(ProjectEditor), new PropertyMetadata(null));

        public static readonly DependencyProperty CurrentToolProperty =
            DependencyProperty.Register(nameof(CurrentTool), typeof(Tool), typeof(ProjectEditor), new PropertyMetadata(null, propertyChangedCallback: OnCurrentToolChanged));

        private static void OnProjectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ProjectEditor projectEditor)
            {
                projectEditor.InvalidateVisual();
            }
        }

        private static void OnCurrentToolChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ProjectEditor projectEditor)
            {
                projectEditor.ReleaseMouseCapture();
            }
        }
    }
}
