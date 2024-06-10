using PRTelegramBot.Interface;

public class UserCache : ITelegramCache
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    /// Временные данные
    /// </summary>
    public string Data { get; set; }
 
    public bool ClearData()
    {
        Id = 0;
        Data = "";
        return true;
    }
}