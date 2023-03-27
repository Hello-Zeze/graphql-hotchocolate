using System;
using System.Collections.Generic;
using System.Linq;

class Card
{
    public string FaceValue { get; set; }
    public string Suit { get; set; }
    public int Value 
    { 
        get
        {
            if (int.TryParse(FaceValue, out int value))
            {
                return value;
            }
            else
            {
                switch (FaceValue)
                {
                    case "A":
                        return 11;
                    case "J":
                        return 11;
                    case "Q":
                        return 12;
                    case "K":
                        return 13;
                    default:
                        return 0;
                }
            }
        }
    }
}

class Player
{
    public string Name { get; set; }
    public List<Card> Cards { get; set; }
    public int BaseScore
    {
        get
        {
            return Cards.Sum(card => card.Value);
        }
    }
    public int SuitScore
    {
        get
        {
            return Cards.Max(card => card.Suit switch
            {
                "H" => 1,
                "S" => 2,
                "C" => 3,
                "D" => 4,
                _ => 0
            });
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Player> players = new List<Player>();
        //Read data from input file
        //Assuming input file name is passed as command line argument
        string[] inputLines = System.IO.File.ReadAllLines(args[0]);
        foreach (string inputLine in inputLines)
        {
            string[] playerData = inputLine.Split(":");
            string playerName = playerData[0].Trim();
            string[] cardData = playerData[1].Split(",");
            List<Card> cards = new List<Card>();
            foreach (string card in cardData)
            {
                Card newCard = new Card();
                newCard.FaceValue = card.Substring(0, card.Length - 1).ToUpper().Trim();
                newCard.Suit = card.Substring(card.Length - 1).ToUpper().Trim();
                cards.Add(newCard);
            }
            players.Add(new Player { Name = playerName, Cards = cards });
        }

        //Calculate scores and determine the winner(s)
        List<Player> tiedPlayers = new List<Player>();
        int maxScore = players.Max(player => player.BaseScore);
        foreach (Player player in players)
        {
            if (player.BaseScore == maxScore)
            {
                tiedPlayers.Add(player);
            }
        }

        if (tiedPlayers.Count == 1)
        {
            //Clear winner
            Console.WriteLine($"{tiedPlayers[0].Name}:{tiedPlayers[0].BaseScore}");
        }
        else
        {
            //Tie
            int maxSuitScore = tiedPlayers.Max(player => player.SuitScore);
            tiedPlayers = tiedPlayers.Where(player => player.SuitScore == maxSuitScore).ToList();
            string winners = string.Join(",", tiedPlayers.Select(player => player.Name));
            int totalScore = tiedPlayers[0
