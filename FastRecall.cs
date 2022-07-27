using System;
using System.Linq;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace FastRecall;

public class FastRecall : Mod
{
    public override object Call(params object[] args)
    {
        if (args is null || args.Length == 0)
        {
            throw new ArgumentNullException(nameof(args), "Arguments cannot be null or empty.");
        }

        if (args.ElementAt(0) is string content)
        {
            try
            {
                return content switch
                {
                    // "AddMirrorLikeItem" => AddMirrorLikeItem(args.ElementAt(1)),
                    _ => throw new ArgumentException($"Invalid Call argument: {content}.")
                };
            }
            catch (Exception e)
            {
                Logger.Error($"Error while parsing Call arguments for argument: {content}.", e);
            }
        }

        return false;
    }

    /// <summary>
    /// Cross-mod compatibility method which will add an item to be used faster.
    /// <example><c>fastRecall.Call("AddMirrorLikeItem", itemId)</c></example>
    /// </summary>
    /// <param name="itemId">The item's to be added ID</param>
    /// <returns>A <see cref="bool"/> representing the status of success.</returns>
    /// TODO: Finish implementing this Call method
    private bool AddMirrorLikeItem(object itemId)
    {
        if (itemId is not int id)
        {
            return false;
        }

        try
        {
            ModContent.GetInstance<Config>().MirrorLikeItems.Add(new ItemDefinition(id));
        }
        catch (Exception e)
        {
            Logger.Error($"Error while adding new Item of ID: {itemId}", e);
            return false;
        }

        return true;
    }
}