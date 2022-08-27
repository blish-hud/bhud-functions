Func<string, object> parseCdnInfo = (rawCdnResponse) => {
    string[] cdnVars = rawCdnResponse.Split(' ');

    if (cdnVars.Length == 5) {
        bool parsedSuccessfully = true;

        parsedSuccessfully &= int.TryParse(cdnVars[0], out int oBuildId);
        parsedSuccessfully &= int.TryParse(cdnVars[1], out int oExeFileId);
        parsedSuccessfully &= int.TryParse(cdnVars[2], out int oExeFileSize);
        parsedSuccessfully &= int.TryParse(cdnVars[3], out int oManifestFileId);
        parsedSuccessfully &= int.TryParse(cdnVars[4], out int oManifestFileSize);

        if (parsedSuccessfully) {
            return new { 
                buildId          = oBuildId,
                exeFileId        = oExeFileId,
                exeFileSize      = oExeFileSize,
                manifestFileId   = oManifestFileId,
                manifestFileSize = oManifestFileSize
            };
        }
    }

    SetResponse("FAILED", 500);
    return null;
};

var standardCdn = parseCdnInfo(await "http://assetcdn.101.arenanetworks.com/latest/101".GetStringAsync());
var chineseCdn  = parseCdnInfo(await "http://assetcdn.111.cgw2.com/latest/111".GetStringAsync());

if (standardCdn == null || chineseCdn == null) return;

await SetJsonResponse(new { standard = standardCdn, chinese = chineseCdn }, cacheDuration: TimeSpan.FromMinutes(1));