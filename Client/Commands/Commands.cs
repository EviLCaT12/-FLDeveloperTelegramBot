using PRTelegramBot.Attributes;
using PRTelegramBot.Models;
using PRTelegramBot.Utils;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

public class Commands
{
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
    [SlashHandler("/getFlatsByPriceAndArea")]
    public static async Task GetFlatsByPriceAndArea(ITelegramBotClient botClient, Update update)
    {
        var lowPrice = 0;
        var highPrice = 0;
        var lowArea = 0.0;
        var highArea = 0.0;

        var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, "Введите начальную стоимость");
        sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, $"{update.Message.Text}");
    }
    #endregion
}