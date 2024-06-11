using System.Runtime.CompilerServices;
using PRTelegramBot.Attributes;
using PRTelegramBot.Extensions;
using PRTelegramBot.Models;
using PRTelegramBot.Utils;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using domain.Usecases;
using DataBase.Repository;

public class Commands
{
    private static readonly FlatRepository flatRepo = new FlatRepository();
    private static readonly FlatService flatService = new FlatService(flatRepo);
    #region Menu
    [ReplyMenuHandler("/Menu")]
    public static async Task Example(ITelegramBotClient botClient, Update update)
    {
        var message = "Меню";
        var menuList = new List<KeyboardButton>();
        menuList.Add(new KeyboardButton("Меню 1"));
        menuList.Add(new KeyboardButton("Меню 2"));
        menuList.Add(new KeyboardButton("Меню 3"));
        menuList.Add(new KeyboardButton("Меню 4"));
        menuList.Add(new KeyboardButton("Меню 5"));
        menuList.Add(new KeyboardButton("Меню 6"));

        var menu = MenuGenerator.ReplyKeyboard(2, menuList);

        var option = new OptionMessage();
        option.MenuReplyKeyboardMarkup = menu;

        var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, option);

    }
    #endregion

    #region Get Flat by price and area

    [ReplyMenuHandler("/get_flat_by_price_and_area")]
    public static async Task StartStep(ITelegramBotClient botClient, Update update)
    {
        string msg = "Введите начальную стоимость";
        update.RegisterStepHandler(new StepTelegram(GetLowPrice, new UserCache()));
        await PRTelegramBot.Helpers.Message.Send(botClient, update, msg);
    } 
    public static async Task GetLowPrice(ITelegramBotClient botClient, Update update)
    {
        var handler = update.GetStepHandler<StepTelegram>();
        handler!.GetCache<UserCache>().LowPrice = int.Parse(update.Message.Text);
        handler.RegisterNextStep(GetHighPrice);
        string msg = "Введите конечную стоимость";
        await PRTelegramBot.Helpers.Message.Send(botClient, update, msg);
    }
    public static async Task GetHighPrice(ITelegramBotClient botClient, Update update)
    {
        var handler = update.GetStepHandler<StepTelegram>();
        handler!.GetCache<UserCache>().HighPrice = int.Parse(update.Message.Text);
        handler.RegisterNextStep(GetLowArea);
        string msg = "Введите начальную площадь";
        await PRTelegramBot.Helpers.Message.Send(botClient, update, msg);
    }
    public static async Task GetLowArea(ITelegramBotClient botClient, Update update)
    {
        var handler = update.GetStepHandler<StepTelegram>();
        handler!.GetCache<UserCache>().LowArea = Convert.ToDouble(update.Message.Text);
        handler.RegisterNextStep(GetHighArea);
        string msg = "Введите конечную площадь";
        await PRTelegramBot.Helpers.Message.Send(botClient, update, msg);
    }
    public static async Task GetHighArea(ITelegramBotClient botClient, Update update)
    {
        var handler = update.GetStepHandler<StepTelegram>();
        handler!.GetCache<UserCache>().HighArea = double.Parse(update.Message.Text);
        var cache = handler.GetCache<UserCache>();
        update.ClearStepUserHandler();
        var res =  flatService.GetFlatsByPriceAndArea(cache.LowPrice, cache.HighPrice, cache.LowArea, cache.HighArea);
        foreach (var flat in res.Value)
        {
            string msg = $"id квартиры с подходящими условиями {flat.Id}";
            await PRTelegramBot.Helpers.Message.Send(botClient, update, msg);
        }
    }
    #endregion
}