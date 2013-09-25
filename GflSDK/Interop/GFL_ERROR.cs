using System.Diagnostics.CodeAnalysis;


namespace GflSDK.Interop
{
// ReSharper disable InconsistentNaming
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1310:FieldNamesMustNotContainUnderscore", Justification = "Compatibility with native headers.")]
    internal enum GFL_ERROR :short
    {
        NO_ERROR = 0,
        FILE_OPEN = 1,
        FILE_READ = 2,
        FILE_CREATE = 3,
        FILE_WRITE = 4,
        NO_MEMORY = 5,
        UNKNOWN_FORMAT = 6,
        BAD_BITMAP = 7,
        BAD_FORMAT_INDEX = 10,
        BAD_PARAMETERS = 50,

        UNKNOWN_ERROR = 255
    }
    // ReSharper restore InconsistentNaming
}