namespace GflSDK.Interop
{
    public enum GFL_BITMAP_TYPE : ushort
    {
        GFL_BINARY = 0x0001,
        GFL_GREY = 0x0002,
        GFL_COLORS = 0x0004,
        GFL_RGB = 0x0010,
        GFL_RGBA = 0x0020,
        GFL_BGR = 0x0040,
        GFL_ABGR = 0x0080,
        GFL_BGRA = 0x0100,
        GFL_ARGB = 0x0200,
        GFL_CMYK = 0x0400,
    }
}