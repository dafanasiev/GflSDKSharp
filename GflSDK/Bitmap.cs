using System;
using System.Drawing;
using GflSDK.Interop;


namespace GflSDK
{
    //see GFL_BITMAP_TYPE
    public enum BitmapType : ushort
    {
        BINARY = 0x0001,
        GREY = 0x0002,
        COLORS = 0x0004,
        RGB = 0x0010,
        RGBA = 0x0020,
        BGR = 0x0040,
        ABGR = 0x0080,
        BGRA = 0x0100,
        ARGB = 0x0200,
        CMYK = 0x0400,
    }

    public class Bitmap : IDisposable
    {
        private IntPtr _nativePtr;

        public Bitmap(BitmapType type, int width, int height, uint linePadding, Color bgColor)
        {
            var gbColorNative = new Interop.GFL_COLOR()
            {
                Alpha = bgColor.A,
                Blue = bgColor.B,
                Green = bgColor.G,
                Red = bgColor.R
            };

            Interop.LibGFL.gflAllockBitmap((GFL_BITMAP_TYPE)type, width, height, linePadding, gbColorNative);
        }

        internal Bitmap()
        {
            Context.Initialize(ContextInitializationOptions.Default);
        }

        private bool _disposed;

        ~Bitmap()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    //_contextProxy.Dispose();
                    //unmanaged
                }
            }

            _disposed = true;
        }

    }
}