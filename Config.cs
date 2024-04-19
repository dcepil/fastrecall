using System.Collections.Generic;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace FastRecall;

public class Config : ModConfig
{
    public override ConfigScope Mode => ConfigScope.ServerSide;

    [Header("$Mods.FastRecall.Config.Header")]

    [DefaultValue(true)]
    [ReloadRequired]
    public bool EnabledForMirrors;

    [DefaultValue(true)]
    [ReloadRequired]
    public bool EnabledForCellphone;

    [DefaultValue(true)]
    [ReloadRequired]
    public bool EnabledForConches;

    [DefaultValue(true)]
    [ReloadRequired]
    public bool EnabledForShellphone;

    [Range(1, 10)]
    [Increment(1)]
    [Slider]
    [DrawTicks]
    [DefaultValue(3)]
    [ReloadRequired]
    public int SpeedFactor;

    [ReloadRequired]
    public List<ItemDefinition> MirrorLikeItems = new List<ItemDefinition>();
}