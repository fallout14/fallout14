using Robust.Shared.Configuration;

namespace Content.Server._NC.CCCvars;

[CVarDefs]
public static class CCCVars
{
    /*
     *  Discord OAuth2
     */

    public static readonly CVarDef<string> DiscordApiUrl =
        CVarDef.Create("jerry.discord_api_url", "", CVar.CONFIDENTIAL | CVar.SERVERONLY);
    public static readonly CVarDef<bool> DiscordAuthEnabled =
        CVarDef.Create("jerry.discord_auth_enabled", false, CVar.CONFIDENTIAL | CVar.SERVERONLY);

    /*
     * Sponsors
     */

    // #Cythisiax Fixed - Default guild updated to current Fallout 14 Discord guild (taken from fallout14-old)
    public static readonly CVarDef<string> DiscordGuildID =
        CVarDef.Create("jerry.discord_guildId", "1522031609535008798", CVar.CONFIDENTIAL | CVar.SERVERONLY);

    public static readonly CVarDef<string> ApiKey =
        CVarDef.Create("jerry.discord_apikey", "", CVar.CONFIDENTIAL | CVar.SERVERONLY);
}
