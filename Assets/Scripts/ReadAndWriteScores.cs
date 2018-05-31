using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


// Class for writing the scoreboard
public class ReadAndWriteScores : MonoBehaviour {

    string pathToLoadFile = "Assets/Resources/Loads/scores.txt";
    FileStream file;
    public Text scoreboard;
    float score;
    string playerName;

    private List<string> times = new List<string>();
    private List<string> names = new List<string>();


    // Opens the file to see if it exists, if not then creates it
    public void Start()
    {
        File.Open(pathToLoadFile, FileMode.OpenOrCreate, FileAccess.ReadWrite).Close();

    }

    // takes care of saving the game score for after
    public void ReadAndWrite(float score)
    {
        this.score = score;
        Read();
        
    }

    // Writes the score to scoreboard
    void AddToScoreboard(string time, string name)
    {
        scoreboard.text += name + ": " + time + "\n";
    }


    // Just reads and shows the times already saved
     private void Read()
    {
        // Make sure the lists are empty
        times = new List<string>();
        names = new List<string>();
        scoreboard.text = "";
        StreamReader reader = new StreamReader(pathToLoadFile);
        string piece;
        while ((piece = reader.ReadLine()) != null)
        {
            string[] pieces = piece.Split(';');
            string time = pieces[0];
            string name = pieces[1];
            AddToScoreboard(time, name);

        }
        reader.Close();
    }
    
    // Reads and saves the scores to lists to write them out again
    private void Read(float score)
    { 
        // Make sure the lists are empty
        times = new List<string>();
        names = new List<string>();
        scoreboard.text = "";
        StreamReader reader = new StreamReader(pathToLoadFile);
        string piece;
        while ((piece = reader.ReadLine()) != null && times.Count <= 10)
        {
            string[] pieces = piece.Split(';');
            string time = pieces[0];
            string name = pieces[1];
            AddToScoreboard(time, name);

            // If current score is bigger than saved score, then add to list change current score to 0 and add saved score to list 
            if (score >= float.Parse(time))
            {
                times.Add(score.ToString("0.00"));
                names.Add(playerName);
                score = 0;
                times.Add(time);
                names.Add(name);
            } else
            {
                times.Add(time);
                names.Add(name);
            }

        }
        // If all saved scores are read and there are not enough scores, then current score is added also (if it is not 0)
        if (times.Count < 10 && score > 0)
        {
            times.Add(score.ToString("0.00"));
            names.Add(playerName);
        }
        reader.Close();
    }

    // Write all saved scores to file again, overwriting it
    private void Write()
    {
        StreamWriter writer = new StreamWriter(pathToLoadFile,false);
        for (int i = 0; i < times.Count; i++)
        {
            writer.WriteLine(times[i].ToString() + ';' + names[i]);
        }
        writer.Close();
    }

    // Method that is bound to input field: if inout field is edited, then this method is called
    public void GetText(string text)
    {
        playerName = text;
        Read(this.score);
        Write();
        Read();
    }
}
