using PRTelegramBot.Core;

const string EXIT_COMMAND = "exit";



var telegram = new PRBot(options =>
{
    options.Token = "6535561233:AAHMRoPW_9WQyIGpxJNO5hiznGhOAIIGTfM";
    options.ClearUpdatesOnStart = true;
    options.WhiteListUsers = new List<long>();
    options.Admins = new List<long>();
    options.BotId = 0;
});


telegram.OnLogCommon += Telegram_OnLogCommon;
telegram.OnLogError += Telegram_OnLogError;

await telegram.Start();

void Telegram_OnLogError(Exception ex, long? id)
{
    Console.ForegroundColor = ConsoleColor.Red;
    string errorMsg = $"{DateTime.Now}: {ex}";
    Console.WriteLine(errorMsg);
    Console.ResetColor();
}

void Telegram_OnLogCommon(string msg, Enum typeEvent, ConsoleColor color)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    string message = $"{DateTime.Now}: {msg}";
    Console.WriteLine(message);
    Console.ResetColor();
}

while (true)
{
    var result = Console.ReadLine();
    if (result.ToLower() == EXIT_COMMAND)
    {
        Environment.Exit(0);
    }
}