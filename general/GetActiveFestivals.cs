var festivalLookup = new Dictionary<int, string>() {
    { 79, "halloween" }, 
    { 98, "wintersday" },
    { 162, "superadventurefestival" }, 
    { 201, "lunarnewyear" },
    { 213, "festivalofthefourwinds" },
    { 233, "dragonbash" }
};

var festivals = new List<string>();

var response = await "https://api.guildwars2.com/v2/achievements/groups/18DB115A-8637-4290-A636-821362A3C4A8".GetJsonAsync();

foreach (int id in response.categories) {
    if (festivalLookup.ContainsKey(id)) {
        festivals.Add(festivalLookup[id]);
    }
}

if (festivals.Count == festivalLookup.Count) {
    festivals = new List<string>() {
        "halloween"
    };
}
        
await SetJsonResponse(festivals, cacheDuration: TimeSpan.FromMinutes(5));
