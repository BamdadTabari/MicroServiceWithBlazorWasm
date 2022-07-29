namespace Illegible_Cms_V2.Server.Application.Constants;

public static class FileFormat
{
    public static IEnumerable<string> AcceptableFileFormats => new List<string>()
        .Concat(AcceptableImageFileFormats)
        .Concat(AcceptableDocumentFileFormats);

    public static IEnumerable<string> AcceptableImageFileFormats =>
        new List<string>
        {
            "jpg",
            "jpeg",
            "png",
            "gif"
        }.Select(x => x.Normalize());

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