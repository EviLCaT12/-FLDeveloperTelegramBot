using System;
using System.ComponentModel.DataAnnotations.Schema;
using Telegram.Bot;
using Telegram.Bot.Types;


var botClient = new TelegramBotClient("6535561233:AAHMRoPW_9WQyIGpxJNO5hiznGhOAIIGTfM");
botClient.StartReceiving(Update, Error);

Console.WriteLine($"{DateTime.Now} Бот {botClient.BotId} начал работу");
Console.ReadLine();

async Task Error(ITelegramBotClient client, Exception exception, CancellationToken token)
{
    
}

async static Task Update(ITelegramBotClient client, Update update, CancellationToken token)
{
    var message = update.Message;
    var chatId = message.Chat.Id;
    if (message.Text != null)
    {
        Console.WriteLine($"{DateTime.Now}: {message.Chat.FirstName} написал \"{message.Text}\"");
        if (message.Text == "/start") //TODO Завести enum команд и сделать switch для приемки команд
        {
            await client.SendTextMessageAsync(chatId, "Здесь будет обработчик команды старт");
        }
        else if (message.Text == "/") ;
    }
}


