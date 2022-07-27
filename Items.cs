using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace FastRecall;

public class Items
{
    public abstract class MirrorLikeItem : GlobalItem
    {
        private int Id { get; }

        protected MirrorLikeItem(int itemId)
        {
            Id = itemId;
        }

        protected MirrorLikeItem()
        {
        }

        public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.type == Id;

        public override void SetDefaults(Item item)
        {
            item.StatsModifiedBy.Add(Mod);
            item.useTime /= ModContent.GetInstance<Config>().SpeedFactor;
            item.useAnimation /= ModContent.GetInstance<Config>().SpeedFactor;
        }
    }

    public class Mirror : MirrorLikeItem
    {
        public Mirror() : base(itemId: ItemID.MagicMirror)
        {
        }

        public override bool IsLoadingEnabled(Mod mod) => ModContent.GetInstance<Config>().EnabledForMirrors;
    }

    public class IceMirror : MirrorLikeItem
    {
        public IceMirror() : base(itemId: ItemID.IceMirror)
        {
        }

        public override bool IsLoadingEnabled(Mod mod) => ModContent.GetInstance<Config>().EnabledForMirrors;
    }

    public class CellPhone : MirrorLikeItem
    {
        public CellPhone() : base(itemId: ItemID.CellPhone)
        {
        }

        public override bool IsLoadingEnabled(Mod mod) => ModContent.GetInstance<Config>().EnabledForCellphone;
    }

    public class MirrorLikeItemFactory : MirrorLikeItem
    {
        private static IEnumerable<ItemDefinition> Items { get; } = ModContent.GetInstance<Config>().MirrorLikeItems;

        public override bool AppliesToEntity(Item entity, bool lateInstantiation) =>
            Items.Any(a => a.Type == entity.type);
    }
}