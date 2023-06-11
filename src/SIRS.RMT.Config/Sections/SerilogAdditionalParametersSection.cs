namespace SIRS.RMT.Config.Sections
{
    public sealed class SerilogAdditionalParametersSection
    {
        public int RetainedFileCountLimit { get; set; }
        public string OutputTemplate { get; set; }
        public string BasePath { get; set; }

        public void Deconstruct(out string basePath, out string outputTemplate, out int retainedFileCountLimit)
        {
            basePath = this.BasePath;
            outputTemplate = this.OutputTemplate;
            retainedFileCountLimit = this.RetainedFileCountLimit;
        }

        public override string ToString()
        {
            return $"Retained file count limit: '{this.RetainedFileCountLimit}', base path: '{this.BasePath}'";
        }
    }
}