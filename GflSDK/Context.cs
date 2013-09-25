using System;
using System.IO;


namespace GflSDK
{
    public static class Context
    {
        // ReSharper disable InconsistentNaming
        private static readonly object _sync = new object();
        // ReSharper restore InconsistentNaming

        private static bool _initialized;

        public static void Initialize(ContextInitializationOptions options)
        {
            if (!_initialized)
            {
                lock (_sync)
                {
                    if (!_initialized)
                    {
                        var e = Interop.LibGFL.gflLibraryInit();
                        if (e != Interop.GFL_ERROR.NO_ERROR) throw new InvalidOperationException("Native lib cant be initialized");

                        if (options.EnableLZW) Interop.LibGFL.gflEnableLZW(Interop.GFL_BOOL.TRUE);
                        if (Directory.Exists(options.PluginPath)) Interop.LibGFL.gflSetPluginsPathname(options.PluginPath);
                        _initialized = true;
                    }
                }
            }
        }

        public static void DeInitialize()
        {
            if (!_initialized) return;
            lock (_sync)
            {
                if (!_initialized) return;

                Interop.LibGFL.gflLibraryExit();
                _initialized = false;
            }
        }

        private static string _version;
        public static string Version
        {
            get
            {
                if (!_initialized) throw new InvalidOperationException("Context not initialized");
                if (_version != null) return _version;
                lock (_sync)
                {
                    if (_version != null) return _version;
// ReSharper disable PossibleMultipleWriteAccessInDoubleCheckLocking
                    _version = Interop.LibGFL.gflGetVersionAsString();
// ReSharper restore PossibleMultipleWriteAccessInDoubleCheckLocking
                }

                return _version;
            }
        }

        private static SupportedFormat[] _supportedFormats;
        public static SupportedFormat[] SupportedFormats
        {
            get
            {
                if (!_initialized) throw new InvalidOperationException("Context not initialized");
                if (_supportedFormats != null) return _supportedFormats;
                lock (_sync)
                {
                    if (_supportedFormats != null) return _supportedFormats;

                    var formatsCount = Interop.LibGFL.gflGetNumberOfFormat();
                    var lSupportedFormats = new SupportedFormat[formatsCount];
                    if (formatsCount <= 0) throw new InvalidOperationException("Cant get format count");
                    for (; formatsCount > 0; --formatsCount)
                    {
                        var formatName = Interop.LibGFL.gflGetFormatNameByIndexAsString(formatsCount - 1);
                        lSupportedFormats[formatsCount - 1] = new SupportedFormat(formatName);
                    }

// ReSharper disable PossibleMultipleWriteAccessInDoubleCheckLocking
                    _supportedFormats = lSupportedFormats;
// ReSharper restore PossibleMultipleWriteAccessInDoubleCheckLocking
                }

                return _supportedFormats;
            }
        }

    }
}