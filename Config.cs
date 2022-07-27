using System.Collections.Generic;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace FastRecall;

public class Config : ModConfig
{
    public override ConfigScope Mode => ConfigScope.ServerSide;

    [Header("$Mods.FastRecall.Config.Header")]
    [Label("$Mods.FastRecall.Config.EnabledForMirrors.Label")]
    [Tooltip("$Mods.FastRecall.Config.EnabledForMirrors.Tooltip")]
    [DefaultValue(true)]
    [ReloadRequired]
    public bool EnabledForMirrors;

    [Label("$Mods.FastRecall.Config.EnabledForCellphone.Label")]
    [Tooltip("$Mods.FastRecall.Config.EnabledForCellphone.Tooltip")]
    [DefaultValue(true)]
    [ReloadRequired]
    public bool EnabledForCellphone;

    [Label("$Mods.FastRecall.Config.SpeedFactor.Label")]
    [Tooltip("$Mods.FastRecall.Config.SpeedFactor.Tooltip")]
    [Range(1, 10)]
    [Increment(1)]
    [Slider]
    [DrawTicks]
    [DefaultValue(3)]
    [ReloadRequired]
    public int SpeedFactor;

    [Label("$Mods.FastRecall.Config.MirrorLikeItems.Label")]
    [Tooltip("$Mods.FastRecall.Config.MirrorLikeItems.Tooltip")]
    [ReloadRequired]
    public List<ItemDefinition> MirrorLikeItems = new List<ItemDefinition>();
}