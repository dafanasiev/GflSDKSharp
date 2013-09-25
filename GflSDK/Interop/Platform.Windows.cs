using System;
using System.Runtime.InteropServices;


#if WINDOWS

namespace GflSDK.Interop
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1310:FieldNamesMustNotContainUnderscore", Justification = "Compatibility with native headers.")]
    internal static class Platform
    {
        public const string LibSuffix = ".dll";
        public const string PlatformName = "windows";
        private const string KernelLib = "kernel32";

        public static SafeLibraryHandle OpenHandle(string filename)
        {
            return LoadLibrary(filename);
        }

        public static IntPtr LoadProcedure(SafeLibraryHandle handle, string functionName)
        {
            return GetProcAddress(handle, functionName);
        }

        public static bool ReleaseHandle(IntPtr handle)
        {
            return FreeLibrary(handle);
        }

        public static Exception GetLastLibraryError()
        {
            return Marshal.GetExceptionForHR(Marshal.GetHRForLastWin32Error());
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1060:MovePInvokesToNativeMethodsClass"), DllImport(KernelLib, SetLastError = true, CharSet = CharSet.Unicode)]
        static extern SafeLibraryHandle LoadLibrary(string lpFileName);


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1060:MovePInvokesToNativeMethodsClass"), DllImport(KernelLib, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool FreeLibrary(IntPtr hModule);

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA2101:SpecifyMarshalingForPInvokeStringArguments", MessageId = "1"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1060:MovePInvokesToNativeMethodsClass"), DllImport(KernelLib, CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        static extern IntPtr GetProcAddress(SafeLibraryHandle hModule, string procName);

    }
}

#endif