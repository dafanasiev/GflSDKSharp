using System.Runtime.InteropServices;


namespace GflSDK.Interop
{
    [StructLayout(LayoutKind.Sequential, Pack = 8, CharSet = CharSet.Ansi)]
    public struct GFL_BITMAP
    {
        public GFL_BITMAP_TYPE Type;
        public GFL_ORIGIN Origin;
        public int Width;
        public int Height;
        public uint BytesPerLine;
        public short LinePadding;
        public ushort BitsPerComponent;
        public ushort ComponentsPerPixel;
        public ushort BytesPerPixel;
        public ushort Xdpi;
        public ushort Ydpi;
        public short TransparentIndex;
        public int ColorUsed;
        //GFL_COLORMAP * ColorMap,  
        //public byte[] Data; //???

    }
}