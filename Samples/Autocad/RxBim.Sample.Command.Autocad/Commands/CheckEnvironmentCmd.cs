﻿namespace RxBim.Sample.Command.Autocad.Commands
{
    using Autodesk.AutoCAD.ApplicationServices.Core;
    using Autodesk.AutoCAD.Runtime;
    using JetBrains.Annotations;
    using Models;
    using RxBim.Command.Autocad;
    using Shared;
    using Shared.Autocad;

    /// <inheritdoc />
    [RxBimCommandClass("RunCheckEnvironmentExample",
        CommandFlags.Modal | CommandFlags.NoPaperSpace | CommandFlags.NoBlockEditor)]
    [PublicAPI]
    public class CheckEnvironmentCmd : RxBimCommand
    {
        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="settings"><see cref="PluginSettings"/></param>
        public PluginResult ExecuteCommand(PluginSettings settings)
        {
            Application.ShowAlertDialog(
                $"Current environment variable = {settings.EnvironmentVariable}");
            
            return PluginResult.Succeeded;
        }
    }
}