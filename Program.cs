using System;
using System.IO;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        bool validPath = false;
        string path = "";
        string[] teamScore = new string[6];

        //Collects and validates the csv file path from the user.
        while(!validPath){
            Console.Clear();

            Console.WriteLine("What is the path of the desired score.csv file?");
            path = Convert.ToString(Console.ReadLine());

            try {
                if (File.Exists(path)){
                    validPath = true;
                } else {
                    Console.WriteLine("The path is invalid.");
                    Thread.Sleep(2000);
                }
            } catch (Exception ex){
                Console.WriteLine("The path is invalid.");
                Console.WriteLine(ex);
                Thread.Sleep(2000);
            }
        }
        
        //Now we use the stream reader to read the csv file data into an array.
        using(var reader = new StreamReader(path)){

            while(!reader.EndOfStream){
                var line = reader.ReadLine();
                var values = line.Split(',');

                teamScore[0] = Convert.ToString(values[0]);
                teamScore[1] = Convert.ToString(values[1]);
                teamScore[2] = Convert.ToString(values[2]);
                teamScore[3] = Convert.ToString(values[3]);
            }
        }
        
        string winner = CheckWinner(teamScore);
        
        if (winner == teamScore[0]){
            Console.WriteLine(teamScore[0] + " wins with a score of " + teamScore[2] + ".");
            Console.ReadKey();
        }else if (winner == teamScore[1]){
            Console.WriteLine(teamScore[1] + " wins with a score of " + teamScore[3] + ".");
            Console.ReadKey();
        }else if (winner == "DRAW"){
            Console.WriteLine("There is a draw with a score of " + teamScore[2] + ".");
            Console.ReadKey();
        }
    }
    
    private static string CheckWinner(string[] teamScore){
        
        int team1Score = -1;
        int team2Score = -1;

        try {
            team1Score = Convert.ToInt32(teamScore[2]);
            team2Score = Convert.ToInt32(teamScore[3]);

        } catch (Exception ex) {
            Console.WriteLine("The score is not a valid integer.");
            Console.WriteLine(ex);
            Thread.Sleep(2000);
        }

        if (team1Score > team2Score){
            return teamScore[0];
        }
        else if(team1Score <team2Score){
            return teamScore[1];
        }
        else{
            return "DRAW";
        }
    }
}

