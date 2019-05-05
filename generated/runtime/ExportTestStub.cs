using System;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using static Sample.API.Runtime.PowerShell.PsProxyOutputExtensions;
using static Sample.API.Runtime.PowerShell.PsHelpers;

namespace Sample.API.Runtime.PowerShell
{
    [Cmdlet(VerbsData.Export, "TestStub")]
    [DoNotExport]
    public class ExportTestStub : PSCmdlet
    {
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string[] ModulePath { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string OutputFolder { get; set; }

        [Parameter]
        public SwitchParameter IncludeGenerated { get; set; }

        private const string RuntimeFolder = @"..\generated\runtime";

        protected override void ProcessRecord()
        {
            var variantGroups = GetModuleCmdlets(this, ModulePath)
                .SelectMany(ci => ci.ToVariants())
                .Where(v => !v.IsDoNotExport)
                .GroupBy(v => v.CmdletName)
                .Select(vg => new VariantGroup(vg.Key, vg.Select(v => v).ToArray(), OutputFolder, isTest: true))
                .Where(vtg => !File.Exists(vtg.FilePath) && (IncludeGenerated || !vtg.IsGenerated));

            foreach (var variantGroup in variantGroups)
            {
                var sb = new StringBuilder();
                sb.AppendLine($@". (Join-Path $PSScriptRoot '{RuntimeFolder}' 'HttpPipelineMocking.ps1'){Environment.NewLine}");

                sb.AppendLine($"Describe '{variantGroup.CmdletName}' {{");
                var variants = variantGroup.Variants
                    .Where(v => IncludeGenerated || !v.Attributes.OfType<GeneratedAttribute>().Any())
                    .ToList();

                foreach (var variant in variants)
                {
                    sb.AppendLine($"{Indent}It '{variant.VariantName}' {{");
                    sb.AppendLine($"{Indent}{Indent}{{ throw [System.NotImplementedException] }} | Should -Not -Throw");
                    var variantSeparator = variants.IndexOf(variant) == variants.Count - 1 ? String.Empty : Environment.NewLine;
                    sb.AppendLine($"{Indent}}}{variantSeparator}");
                }
                sb.AppendLine("}");

                File.WriteAllText(variantGroup.FilePath, sb.ToString());
            }
        }
    }
}
