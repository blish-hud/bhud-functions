// Left for reference.
var festivalLookup = new Dictionary<int, string>() {
    { 79, "halloween" }, 
    { 98, "wintersday" },
    { 162, "superadventurefestival" }, 
    { 201, "lunarnewyear" },
    { 213, "festivalofthefourwinds" },
    { 233, "dragonbash" }
};

var festivals = await "https://cap.blishhud.com/festivals.json".GetJsonAsync<List<string>>();
        
await SetJsonResponse(festivals, cacheDuration: TimeSpan.FromMinutes(5));
