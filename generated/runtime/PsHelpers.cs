﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Pwsh = System.Management.Automation.PowerShell;

namespace Sample.API.Runtime.PowerShell
{
    internal static class PsHelpers
    {
        public static IEnumerable<T> RunScript<T>(string script)
            => Pwsh.Create().AddScript(script).Invoke<T>();

        public static void RunScript(string script)
            => RunScript<PSObject>(script);

        public static IEnumerable<T> RunScript<T>(CommandInvocationIntrinsics cii, string script)
            => cii.InvokeScript(script).Select(o => o?.ImmediateBaseObject).Where(o => o != null).OfType<T>();

        public static void RunScript(CommandInvocationIntrinsics cii, string script)
            => RunScript<PSObject>(cii, script);

        public static IEnumerable<CommandInfo> GetModuleCmdlets(PSCmdlet cmdlet, params string[] modulePaths)
        {
            var getCmdletsCommand = String.Join(" + ", modulePaths.Select(mp => $"(Get-Command -Module (Import-Module '{mp}' -PassThru))"));
            return (cmdlet?.RunScript<CommandInfo>(getCmdletsCommand) ?? RunScript<CommandInfo>(getCmdletsCommand))
                .Where(ci => ci.CommandType != CommandTypes.Alias);
        }

        public static IEnumerable<CommandInfo> GetModuleCmdlets(params string[] modulePaths)
            => GetModuleCmdlets(null, modulePaths);

        public static IEnumerable<FunctionInfo> GetScriptCmdlets(PSCmdlet cmdlet, string scriptFolder)
        {
            // https://stackoverflow.com/a/40969712/294804
            var getCmdletsCommand = $@"
$currentFunctions = Get-ChildItem function:
Get-ChildItem -Path '{scriptFolder}' -Recurse -Filter '*.ps1' -File | ForEach-Object {{ . $_.FullName }}
Get-ChildItem function: | Where-Object {{ ($currentFunctions -notcontains $_) -and $_.CmdletBinding }}
";
            return cmdlet?.RunScript<FunctionInfo>(getCmdletsCommand) ?? RunScript<FunctionInfo>(getCmdletsCommand);
        }

        public static IEnumerable<FunctionInfo> GetScriptCmdlets(string scriptFolder)
            => GetScriptCmdlets(null, scriptFolder);
    }
}
