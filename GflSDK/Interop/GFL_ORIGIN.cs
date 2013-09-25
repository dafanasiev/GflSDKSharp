namespace GflSDK.Interop
{
    public enum GFL_ORIGIN : ushort
    {
        GFL_LEFT = 0x00,
        GFL_RIGHT = 0x01,
        GFL_TOP = 0x00,
        GFL_BOTTOM = 0x10,
        GFL_TOP_LEFT = (GFL_TOP | GFL_LEFT),
        GFL_BOTTOM_LEFT = (GFL_BOTTOM | GFL_LEFT),
        GFL_TOP_RIGHT = (GFL_TOP | GFL_RIGHT),
        GFL_BOTTOM_RIGHT = (GFL_BOTTOM | GFL_RIGHT),
    }
}