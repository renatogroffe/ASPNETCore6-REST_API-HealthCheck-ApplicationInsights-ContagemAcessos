using System.Runtime.InteropServices;

namespace APIContagem;

public class ApplicationStatus
{
    public static string Local { get; } = Environment.MachineName;
    public static string Kernel { get; } = Environment.OSVersion.VersionString;
    public static string Framework { get; } = RuntimeInformation.FrameworkDescription;
    public static bool Healthy { get; set; } = true;
}