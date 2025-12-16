using System.Text;

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

    public const string ServerFiles_ClaimCompressionTasks = "claimCompressionTasks";
    public const string ServerFiles_CancelCompressionTasks = "cancelCompressionTasks";
    public const string ServerFiles_SubmitCompressionResult = "submitCompressionResult";


    public const string Main = "/main";

    public static Uri ServerFilesDeleteAllFullPath(Uri baseUri)
        => BuildFullPath(baseUri, ServerFiles + "/" + ServerFiles_DeleteAll);
    public static Uri ServerFilesFilesSendFullPath(Uri baseUri)
        => BuildFullPath(baseUri, ServerFiles + "/" + ServerFiles_FilesSend);
    public static Uri ServerFilesGetSizesFullPath(Uri baseUri, int? timeZoneOffset = null)
        => BuildFullPath(baseUri, ServerFiles + "/" + ServerFiles_GetSizes, [
            new(nameof(timeZoneOffset), timeZoneOffset?.ToString())]);
    public static Uri ServerFilesUploadFullPath(Uri baseUri, string hash, int? timeZoneOffset = null, string? filenameExtension = null)
        => BuildFullPath(baseUri, ServerFiles + "/" + ServerFiles_Upload + "/" + hash,
            new(nameof(timeZoneOffset), timeZoneOffset?.ToString()),
            new(nameof(filenameExtension), filenameExtension));

    public static Uri ServerFilesClaimCompressionTasksFullPath(Uri baseUri, string token, string filenameExtension, int count)
        => BuildFullPath(baseUri, ServerFiles + "/" + ServerFiles_ClaimCompressionTasks,
            new(nameof(token), token),
            new(nameof(filenameExtension), filenameExtension),
            new(nameof(count), count.ToString()));
    public static Uri ServerFilesCancelCompressionTasksFullPath(Uri baseUri, string token)
        => BuildFullPath(baseUri, ServerFiles + "/" + ServerFiles_CancelCompressionTasks, [
            new(nameof(token), token)]);
    public static Uri ServerFilesSubmitCompressionResultFullPath(Uri baseUri, string token, string hash)
        => BuildFullPath(baseUri, ServerFiles + "/" + ServerFiles_SubmitCompressionResult + "/" + hash, [
            new(nameof(token), token)]);

    private static Uri BuildFullPath(Uri baseUri, string path, params KeyValuePair<string, string?>[] queryParams)
    {
        if (queryParams.Length == 0)
            return new Uri(baseUri, path);

        var sb = new StringBuilder();
        foreach (var queryParam in queryParams)
        {
            if (queryParam.Value != null)
            {
                if (sb.Length == 0)
                {
                    sb.Append('?');
                }
                else
                {
                    sb.Append('&');
                }

                sb.Append(queryParam.Key);
                sb.Append('=');
                sb.Append(Uri.EscapeDataString(queryParam.Value));
            }
        }

        return new Uri(baseUri, path + sb.ToString());
    }
}