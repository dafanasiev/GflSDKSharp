using System.Runtime.InteropServices;


namespace GflSDK.Interop
{
    [StructLayout(LayoutKind.Sequential, Pack = 8, CharSet = CharSet.Ansi)]
    public struct GFL_COLOR
    {
        public ushort Red;
        public ushort Green;
        public ushort Blue;
        public ushort Alpha;
    }
}