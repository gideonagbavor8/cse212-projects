/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("week03/teach/basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // ignore header row
        while (!reader.EndOfData) {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            var points = int.Parse(fields[8]);

            // Accumulate points for each player
            if (players.ContainsKey(playerId))
            {
                players[playerId] += points;
            } else
            {
                players[playerId] = points;
            }
        }

        // Convert dictionary to array by points (descending)
        var sortedPlayers = players.OrderByDescending(p => p.Value).ToArray();

        // Top 10 players
        Console.WriteLine("Top 10 Players by career points:");
        Console.WriteLine("-------------------------------");
        for (int i = 0; i < Math.Min(10, sortedPlayers.Length); i++)
        {
            Console.WriteLine($"{sortedPlayers[i].Key}: {sortedPlayers[i].Value} points");
        }
        // Console.WriteLine($"Players: {{{string.Join(", ", players)}}}");

        // var topPlayers = new string[10];
    }
}