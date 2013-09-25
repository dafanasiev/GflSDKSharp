using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;


#if DOTNET
namespace GflSDK.Interop
{
    // ReSharper disable InconsistentNaming
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Compatibility with native headers.")]
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1307:AccessibleFieldsMustBeginWithUpperCaseLetter", Justification = "Compatibility with native headers.")]
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1310:FieldNamesMustNotContainUnderscore", Justification = "Compatibility with native headers.")]
    [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1201:ElementsMustAppearInTheCorrectOrder", Justification = "Compatibility with native headers.")]
    [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess", Justification = "Reviewed. Suppression is OK here.")]
    internal static class LibGFL
    {
        public const string LibraryName = "libgfl340";
        private static readonly UnmanagedLibrary NativeLib;

        static LibGFL()
        {
            NativeLib = new UnmanagedLibrary(LibraryName);
            AssignDelegates();

        }

        private static void AssignDelegates()
        {
            gflLibraryInit = NativeLib.GetUnmanagedFunction<gflLibraryInitProc>("gflLibraryInit");
            gflLibraryExit = NativeLib.GetUnmanagedFunction<gflLibraryExitProc>("gflLibraryExit");
            gflEnableLZW = NativeLib.GetUnmanagedFunction<gflEnableLZWProc>("gflEnableLZW");
            gflGetVersion = NativeLib.GetUnmanagedFunction<gflGetVersionProc>("gflGetVersion");
            gflGetErrorString = NativeLib.GetUnmanagedFunction<gflGetErrorStringProc>("gflGetErrorString");
            gflGetNumberOfFormat = NativeLib.GetUnmanagedFunction<gflGetNumberOfFormatProc>("gflGetNumberOfFormat");
            gflFormatIsSupported = NativeLib.GetUnmanagedFunction<gflFormatIsSupportedProc>("gflFormatIsSupported");
            gflGetFormatNameByIndex = NativeLib.GetUnmanagedFunction<gflGetFormatNameByIndexProc>("gflGetFormatNameByIndex");
            gflGetFormatIndexByName = NativeLib.GetUnmanagedFunction<gflGetFormatIndexByNameProc>("gflGetFormatIndexByName");
            gflFormatIsReadableByIndex = NativeLib.GetUnmanagedFunction<gflFormatIsReadableByIndexProc>("gflFormatIsReadableByIndex");
            gflFormatIsReadableByName = NativeLib.GetUnmanagedFunction<gflFormatIsReadableByNameProc>("gflFormatIsReadableByName");
            gflFormatIsWritableByIndex = NativeLib.GetUnmanagedFunction<gflFormatIsWritableByIndexProc>("gflFormatIsWritableByIndex");
            gflFormatIsWritableByName = NativeLib.GetUnmanagedFunction<gflFormatIsWritableByNameProc>("gflFormatIsWritableByName");
            gflGetFormatDescriptionByIndex = NativeLib.GetUnmanagedFunction<gflGetFormatDescriptionByIndexProc>("gflGetFormatDescriptionByIndex");
            gflGetFormatDescriptionByName = NativeLib.GetUnmanagedFunction<gflGetFormatDescriptionByNameProc>("gflGetFormatDescriptionByName");
            gflGetDefaultFormatSuffixByIndex = NativeLib.GetUnmanagedFunction<gflGetDefaultFormatSuffixByIndexProc>("gflGetDefaultFormatSuffixByIndex");
            gflGetDefaultFormatSuffixByName = NativeLib.GetUnmanagedFunction<gflGetDefaultFormatSuffixByNameProc>("gflGetDefaultFormatSuffixByName");
            gflGetFormatInformationByIndex = NativeLib.GetUnmanagedFunction<gflGetFormatInformationByIndexProc>("gflGetFormatInformationByIndex");
            gflSetPluginsPathname = NativeLib.GetUnmanagedFunction<gflSetPluginsPathnameProc>("gflSetPluginsPathname");
            gflAllockBitmap = NativeLib.GetUnmanagedFunction<gflAllockBitmapProc>("gflAllockBitmap");
        }


        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate GFL_ERROR gflLibraryInitProc();
        public static gflLibraryInitProc gflLibraryInit;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void gflLibraryExitProc();
        public static gflLibraryExitProc gflLibraryExit;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void gflEnableLZWProc(GFL_BOOL enable);
        public static gflEnableLZWProc gflEnableLZW;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate IntPtr gflGetVersionProc();
        private static gflGetVersionProc gflGetVersion;
        public static string gflGetVersionAsString()
        {
            var r = gflGetVersion();
            return Marshal.PtrToStringAnsi(r);
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate IntPtr gflGetErrorStringProc(GFL_ERROR error);
        private static gflGetErrorStringProc gflGetErrorString;
        public static string gflGetErrorStringAsString(GFL_ERROR error)
        {
            var r = gflGetErrorString(error);
            return Marshal.PtrToStringAnsi(r);
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int gflGetNumberOfFormatProc();
        public static gflGetNumberOfFormatProc gflGetNumberOfFormat;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate GFL_BOOL gflFormatIsSupportedProc([MarshalAs(UnmanagedType.LPStr)]string format);
        public static gflFormatIsSupportedProc gflFormatIsSupported;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate IntPtr gflGetFormatNameByIndexProc(int index);
        private static gflGetFormatNameByIndexProc gflGetFormatNameByIndex;
        public static string gflGetFormatNameByIndexAsString(int index)
        {
            var r = gflGetFormatNameByIndex(index);
            return Marshal.PtrToStringAnsi(r);
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int gflGetFormatIndexByNameProc([MarshalAs(UnmanagedType.LPStr)]string format);
        public static gflGetFormatIndexByNameProc gflGetFormatIndexByName;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate GFL_BOOL gflFormatIsReadableByIndexProc(int index);
        public static gflFormatIsReadableByIndexProc gflFormatIsReadableByIndex;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate GFL_BOOL gflFormatIsReadableByNameProc([MarshalAs(UnmanagedType.LPStr)]string format);
        public static gflFormatIsReadableByNameProc gflFormatIsReadableByName;


        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate GFL_BOOL gflFormatIsWritableByIndexProc(int index);
        public static gflFormatIsWritableByIndexProc gflFormatIsWritableByIndex;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate GFL_BOOL gflFormatIsWritableByNameProc([MarshalAs(UnmanagedType.LPStr)]string format);
        public static gflFormatIsWritableByNameProc gflFormatIsWritableByName;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate IntPtr gflGetFormatDescriptionByIndexProc(int index);
        private static gflGetFormatDescriptionByIndexProc gflGetFormatDescriptionByIndex;
        public static string gflGetFormatDescriptionByIndexAsString(int index)
        {
            var r = gflGetFormatDescriptionByIndex(index);
            return Marshal.PtrToStringAnsi(r);
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate IntPtr gflGetFormatDescriptionByNameProc([MarshalAs(UnmanagedType.LPStr)]string format);
        private static gflGetFormatDescriptionByNameProc gflGetFormatDescriptionByName;
        public static string gflGetFormatDescriptionByNameAsString([MarshalAs(UnmanagedType.LPStr)]string format)
        {
            var r = gflGetFormatDescriptionByName(format);
            return Marshal.PtrToStringAnsi(r);
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate IntPtr gflGetDefaultFormatSuffixByIndexProc(int index);
        private static gflGetDefaultFormatSuffixByIndexProc gflGetDefaultFormatSuffixByIndex;
        public static string gflGetDefaultFormatSuffixByIndexAsString(int index)
        {
            var r = gflGetDefaultFormatSuffixByIndex(index);
            return Marshal.PtrToStringAnsi(r);
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate IntPtr gflGetDefaultFormatSuffixByNameProc([MarshalAs(UnmanagedType.LPStr)]string format);
        private static gflGetDefaultFormatSuffixByNameProc gflGetDefaultFormatSuffixByName;
        public static string gflGetDefaultFormatSuffixByNameAsString([MarshalAs(UnmanagedType.LPStr)]string format)
        {
            var r = gflGetDefaultFormatSuffixByName(format);
            return Marshal.PtrToStringAnsi(r);
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate GFL_ERROR gflGetFormatInformationByIndexProc(int index, [MarshalAs(UnmanagedType.Struct)]out GFL_FORMAT_INFORMATION information);
        public static gflGetFormatInformationByIndexProc gflGetFormatInformationByIndex;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void gflSetPluginsPathnameProc([MarshalAs(UnmanagedType.LPStr)]string path);
        public static gflSetPluginsPathnameProc gflSetPluginsPathname;


        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void gflAllockBitmapProc(GFL_BITMAP_TYPE type, int width, int height, uint linePadding, [MarshalAs(UnmanagedType.LPStruct)]GFL_COLOR color);
        public static gflAllockBitmapProc gflAllockBitmap;
    }
    // ReSharper restore InconsistentNaming
}
#endif