//
//
//
// Players play for 48 minutes total
//
// 12 players total
//
// Create a report to show how long people played on the court.
//
//

int fullTime = 48;
int[] PlayersIn = new int[] { 1, 2, 3, 4, 5 };

// Setup all players and flag starting lineup
PlayerOnCourt[] PlayersOnCourtArray = new PlayerOnCourt[12];

for (int p = 0; p < PlayersOnCourtArray.Length; p++)
{
    var player = p + 1;
    PlayersOnCourtArray[p] = new PlayerOnCourt(player, 0, 0, PlayersIn.Contains(player));
}

Substitution[] Substitutions = new Substitution[]
{
    new Substitution(6, 1, 300000),
    new Substitution(7, 3, 900000),
    new Substitution(8, 5, 1200000),
};

for (int s = 0; s < Substitutions.Length; s++)
{
    var sub = Substitutions[s];
    
    // Handle Player Out
    UpdatePlayer(PlayersOnCourtArray[sub.PlayerOut - 1], sub.SubstituteTime);

    // Handle Player In
    UpdatePlayer(PlayersOnCourtArray[sub.PlayerIn - 1], sub.SubstituteTime);

}

for ( int p = 0; p < PlayersOnCourtArray.Length; p++)
{
    var player = PlayersOnCourtArray[p];
    if (player.HavePlayed && player.TotalTime == 0 && player.LastPlayed == 0)
    {
        player.TotalTime = fullTime;
    }

    Console.WriteLine("Player = " + player.Player + " Total Court Time = " + player.TotalTime);

}


static void UpdatePlayer(PlayerOnCourt player, int subTime)
{
    var convertToMinutes = 60000;
    // Handle Player In
    if (!player.HavePlayed)
    {
        player.LastPlayed = subTime / convertToMinutes;
    }
    else
    {
        player.TotalTime = (subTime / convertToMinutes) - player.LastPlayed;
    }

}


class Substitution
{
    public int PlayerIn { get; }    
    public int PlayerOut { get; }
    
    public int SubstituteTime { get; }

    public Substitution(int playerIn, int playerOut, int substituteTime)
    {
        PlayerIn = playerIn;
        PlayerOut = playerOut;
        SubstituteTime = substituteTime;
    }
 }

class PlayerOnCourt
{
    public int Player { get; set; }
    public int LastPlayed { get; set; }
    public int TotalTime { get; set; }
    public bool HavePlayed { get; set; }

    public PlayerOnCourt(int player, int lastPlayed, int totalTime, bool havePlayed)
    {
        Player = player;
        LastPlayed = lastPlayed;    
        TotalTime = totalTime;  
        HavePlayed = havePlayed;
    }
}