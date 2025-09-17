namespace MareSynchronos.API.Routes;

public class MareFiles
{
    public const string ServerFiles = "/files";

    // Called by a player to delete all the mod files they have uploaded to the service.
    public const string ServerFiles_DeleteAll = "deleteAll";

    // Called by a player to determine which files it needs to upload because they are not present on the service.
    public const string ServerFiles_FilesSend = "filesSend";

    // Called by a player to get the download metadata for a set of files.
    public const string ServerFiles_GetSizes = "getFileSizes";

    // Called by a player to upload the data for an individual mod file.
    public const string ServerFiles_Upload = "upload";


    public const string Main = "/main";

    public static Uri ServerFilesDeleteAllFullPath(Uri baseUri) => new(baseUri, ServerFiles + "/" + ServerFiles_DeleteAll);
    public static Uri ServerFilesFilesSendFullPath(Uri baseUri) => new(baseUri, ServerFiles + "/" + ServerFiles_FilesSend);
    public static Uri ServerFilesGetSizesFullPath(Uri baseUri) => new(baseUri, ServerFiles + "/" + ServerFiles_GetSizes);
    public static Uri ServerFilesUploadFullPath(Uri baseUri, string hash) => new(baseUri, ServerFiles + "/" + ServerFiles_Upload + "/" + hash);
}