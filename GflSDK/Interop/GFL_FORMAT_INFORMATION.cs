using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;


namespace GflSDK.Interop
{
    [StructLayout(LayoutKind.Sequential, Pack = 8, CharSet = CharSet.Ansi)]
    public struct GFL_FORMAT_INFORMATION
    {
        public Int32 Index;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        public string Name;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string Description;

        public UInt32 Status;

        public UInt32 NumberOfExtension;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16 * 8)]
        private char[] Extension;

        public string[] GetExtensions()
        {
            var rv = new List<string>();
            var tmp = new StringBuilder();
            int i = 0;
            while (i < Extension.Length)
            {
                tmp.Clear();
                for (int j = 0; j < 8; ++j)
                {
                    if (Extension[i + j] == 0) break;
                    tmp.Append(Extension[i + j]);
                }
                if (tmp.Length > 0) rv.Add(tmp.ToString());
                i += 8;
            }
            return rv.ToArray();
        }
    }
}