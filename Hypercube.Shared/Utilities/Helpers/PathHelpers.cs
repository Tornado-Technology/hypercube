﻿using System.Reflection;

namespace Hypercube.Shared.Utilities.Helpers;

public static class PathHelpers
{
    public static string GetExecDirectory()
    {
        return AppDomain.CurrentDomain.BaseDirectory;
    }

    public static string GetExecRelativeFile(string file)
    {
        return Path.GetFullPath(Path.Combine(GetExecDirectory(), file));
    }
    
    public static IEnumerable<string> GetFiles(string path)
    {
        return Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories);
    }
    
    public static bool IsFileSystemCaseSensitive() =>
        !OperatingSystem.IsWindows()
        && !OperatingSystem.IsMacOS();
}