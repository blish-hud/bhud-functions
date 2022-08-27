var standardCdn = (await "http://assetcdn.101.arenanetworks.com/latest/101".GetStringAsync()).Split(' ');
var chineseCdn = (await "http://assetcdn.111.cgw2.com/latest/111".GetStringAsync()).Split(' ');

await SetJsonResponse(new { standard = standardCdn, chinese = chineseCdn }, cacheDuration: TimeSpan.FromMinutes(10));