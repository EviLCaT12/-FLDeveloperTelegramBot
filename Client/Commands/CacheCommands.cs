using Microsoft.VisualBasic;
using PRTelegramBot.Attributes;
using PRTelegramBot.Extensions;
using Telegram.Bot;
using Telegram.Bot.Types;

public class CacheCommands
{
    [ReplyMenuHandler("setcache")]
    public static async Task SetCache(ITelegramBotClient botClient, Update update)
    {
        update.GetCacheData<UserCache>().Id = update.GetChatId();
        string msg = $"Запомнил данные: {update.GetChatId()}";
        await PRTelegramBot.Helpers.Message.Send(botClient, update, msg);
    }
    [ReplyMenuHandler("getcache")]
    public static async Task GetCache(ITelegramBotClient botClient, Update update)
    {
        var cache = update.GetCacheData<UserCache>();
        string msg = "";
        if (cache.Id != 0)
        {
            msg = $"Данные из кэша: {cache.Id}";
        }
        else
        {
            msg = "Данных нет";
        }
        await PRTelegramBot.Helpers.Message.Send(botClient, update, msg);
    }
    [ReplyMenuHandler("clearcache")]
    public static async Task ClearCache(ITelegramBotClient botClient, Update update)
    {
        update.GetCacheData<UserCache>().ClearData();
        string msg = "clearDate";
        await PRTelegramBot.Helpers.Message.Send(botClient, update, msg);
    }
    
}