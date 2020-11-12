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
                Console.WriteLine(ex);
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

        
    }
}

