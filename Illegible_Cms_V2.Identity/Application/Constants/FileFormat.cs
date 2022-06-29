namespace Illegible_Cms_V2.Identity.Application.Constants
{
    public static class FileFormat
    {
        // All
        public static IEnumerable<string> AcceptableFileFormats => new List<string>()
            .Concat(AcceptableImageFileFormats)
            .Concat(AcceptableDocumentFileFormats);

        // Images
        public static IEnumerable<string> AcceptableImageFileFormats =>
            new List<string>
            {
                "jpg",
                "jpeg",
                "png",
                "gif"
            }.Select(x => x.Normalize());

        // Documents
        public static IEnumerable<string> AcceptableDocumentFileFormats =>
            new List<string>
            {
                "txt",
                "pdf",
                "doc",
                "docx",
                "xls",
                "xlsx"
            }.Select(x => x.Normalize());
    }
}