using System;


namespace GflSDK
{
    public class SupportedFormat
    {
        [Flags]
        public enum ReadWrite
        {
            Read = 0x1,
            Write = 0x2
        }

        private class SupportedFormatInfo
        {
            public int Index { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public ReadWrite Status { get; set; }
            public string[] Extensions { get; set; }
        }

        private readonly Lazy<SupportedFormatInfo> _info;

        public SupportedFormat(string name)
        {
            Name = name;
            _info = new Lazy<SupportedFormatInfo>(() => GetInfo(Name), true);
        }

        private static SupportedFormatInfo GetInfo(string format)
        {
            var formatIndex = Interop.LibGFL.gflGetFormatIndexByName(format);
            if (formatIndex < 0) throw new ArgumentOutOfRangeException("format", "Unknown format");

            Interop.GFL_FORMAT_INFORMATION nativeInfo;
            var bRes = Interop.LibGFL.gflGetFormatInformationByIndex(formatIndex, out nativeInfo);
            if (bRes != Interop.GFL_ERROR.NO_ERROR) throw new InvalidOperationException("Cant get native format info");

            var rv = new SupportedFormatInfo
            {
                Index = nativeInfo.Index,
                Name = nativeInfo.Name,
                Description = nativeInfo.Description,
                Status = nativeInfo.Status == 1 ? ReadWrite.Read : (ReadWrite.Read | ReadWrite.Write),
                Extensions = nativeInfo.GetExtensions()
            };

            return rv;
        }

        public string Name { get; private set; }
        public string Description { get { return _info.Value.Description; } }
        public bool CanWrite { get { return _info.Value.Status.HasFlag(ReadWrite.Write); } }
        public bool CanRead { get { return _info.Value.Status.HasFlag(ReadWrite.Read); } }
    }
}