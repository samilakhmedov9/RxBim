﻿// ReSharper disable All
#pragma warning disable SA1600,1591
namespace RxBim.Nuke
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using CommandLine;

    /// <summary>
    /// Installation package options.
    /// </summary>
    public class Options
    {
        [Option('p', "project", Required = true, HelpText = "Set project name.")]
        public string? ProjectName { get; set; }

        [Option('j', "productProject", Required = true, HelpText = "Set product project name.")]
        public string? ProductProjectName { get; set; }

        [Option('i', "installDir", Required = true, HelpText = "Set install directory.")]
        public string? InstallDir { get; set; }

        [Option('b', "bundleDir", Required = true, HelpText = "Set bundle directory.")]
        public string? BundleDir { get; set; }

        [Option('s', "sourceDir", Required = true, HelpText = "Set source directory.")]
        public string? SourceDir { get; set; }

        [Option('m', "manifestDir", Required = true, HelpText = "Set manifest directory.")]
        public string? ManifestDir { get; set; }

        [Option('d', "description", Required = false, HelpText = "Set description.")]
        public string? Description { get; set; }

        [Option('c', "comment", Required = false, HelpText = "Set comment.")]
        public string? Comments { get; set; }

        [Option('g', "packageGuid", Required = true, HelpText = "Set package guid.")]
        public string? PackageGuid { get; set; }

        [Option('u', "updateCode", Required = true, HelpText = "Set update code.")]
        public string? UpgradeCode { get; set; }

        [Option('v', "version", Required = true, HelpText = "Set version.")]
        public string? Version { get; set; }

        [Option('y', "productVersion", Required = false, HelpText = "Set product version.")]
        public string? ProductVersion { get; set; }

        [Option('o', "outDir", Required = true, HelpText = "Set output directory.")]
        public string? OutDir { get; set; }

        [Option('f', "fileName", Required = true, HelpText = "Set install file name.")]
        public string? OutFileName { get; set; }

        [Option('a', "addAllAppToManifest", Required = false, HelpText = "Set need add all Application from output to manifest.")]
        public bool AddAllAppToManifest { get; set; }

        [Option('t', "projectAddingToManifest", Required = false, HelpText = "Set projects adding to manifest.")]
        public IEnumerable<string>? ProjectsAddingToManifest { get; set; }

        [Option('x', "msiFilePrefix", Required = false, HelpText = "Set install file prefix.")]
        public string? InstallFilePrefix { get; set; }

        [Option('n', "setupIcon", Required = false, HelpText = "Set setup icon file.")]
        public string? SetupIcon { get; set; }

        [Option('l', "uninstallIcon", Required = false, HelpText = "Set uninstall icon file.")]
        public string? UninstallIcon { get; set; }

        [Option('e', "environment", Required = false, HelpText = "Set environment.")]
        public string? Environment { get; set; }

        public override string ToString()
        {
            return string.Join(" ",
                GetType()
                    .GetProperties()
                    .Select(p => (
                        val: ToString(p.GetValue(this)),
                        shortName: p.GetCustomAttribute<OptionAttribute>()?.ShortName))
                    .Where(tuple => !string.IsNullOrEmpty(tuple.val))
                    .Select(tuple => $"-{tuple.shortName} {tuple.val}"));
        }

        private string? ToString(object? value)
        {
            if (value == null)
                return string.Empty;

            switch (value)
            {
                case string _:
                    return value.ToString();

                case IEnumerable eValue:
                    var result = new StringBuilder();
                    foreach (var v in eValue)
                    {
                        if (result.Length > 0)
                            result.Append(" ");
                        result.Append(v.ToString());
                    }

                    return result.ToString();

                default:
                    return value.ToString();
            }
        }
    }
}