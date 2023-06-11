using SIRS.RMT.Config.Sections;
using System;

namespace SIRS.RMT.Config
{
    public class ReadingMemoryThinkingConfiguration
    {
        public const string AppCodeSuffix = "reading-memory-thinking";

        public ConnectionStringSection ConnectionString { get; set; }
        public ApplicationSection Application { get; set; }
        public SerilogAdditionalParametersSection SerilogAdditionalParameters { get; set; }

        public override string ToString()
        {
            return $"Application: {this.Application}" + Environment.NewLine +
                   $"Connection: {this.ConnectionString}" + Environment.NewLine +
                   $"Serilog: {this.SerilogAdditionalParameters}";
        }
    }
}