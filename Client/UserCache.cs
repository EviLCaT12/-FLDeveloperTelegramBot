using domain.Models;
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
    public int LowPrice { get; set; }
    public int HighPrice { get; set; }
    public double LowArea { get; set; }
    public double HighArea { get; set; }
    public WorldSide WorldSide{ get; set; }
    public bool ClearData()
    {
        Id = 0;
        LowPrice = 0;
        HighPrice = 0;
        LowArea = 0;
        HighArea = 0;
        WorldSide = 0; 
        return true;
    }
}