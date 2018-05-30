using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ReadAndWriteScores : MonoBehaviour {

    string pathToLoadFile = "Assets/Resources/Loads/scores.txt";
    FileStream file;
    public Text scoreboard;
    private int frame = 0;

    private float score;

    private List<string> times = new List<string>();
    private List<string> names = new List<string>();

    // Use this for initialization
    void Start () {
        //pathToLoadFile = "Assets/Resources/Loads/scores.txt";
        scoreboard.text = "";
    }

    public void ReadAndWrite(float score)
    {
        this.score = score;
        file = File.Open(pathToLoadFile, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        Read(score);
        Write();
        file.Close();
    }

    /* public void ReadAndWrite()
    {
        file = File.Open(pathToLoadFile, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        Read();
        file.Close();
    } */

    void AddToScoreboard(string time, string name)
    {
        
        Debug.Log("siin");
        scoreboard.text += name + ": " + time + "\n";
    }

    /* private void Read()
    {
        
        StreamReader reader = new StreamReader(file);
        string piece;
        while ((piece = reader.ReadLine()) != null)
        {
            string[] pieces = piece.Split(';');
            string time = pieces[0];
            string name = pieces[1];
            //AddToScoreboard(time, name);

        }
        //Debug.Log(float.Parse(reader.ReadLine().Split(';')[0]));
        reader.Close();
    }
    */

    private void Read(float score)
    {
        scoreboard.text = "";
        StreamReader reader = new StreamReader(file);
        string piece;
        while ((piece = reader.ReadLine()) != null && times.Count <= 10)
        {
            string[] pieces = piece.Split(';');
            string time = pieces[0];
            string name = pieces[1];
            AddToScoreboard(time, name);
            if (score >= float.Parse(time))
            {
                times.Add(score.ToString());
                names.Add("Nimi");
                score = 0;
                times.Add(time);
                names.Add(name);
            } else
            {
                times.Add(time);
                names.Add(name);
            }

        }
        //Debug.Log(float.Parse(reader.ReadLine().Split(';')[0]));
        reader.Close();
    }

    private void Write()
    {
        StreamWriter writer = new StreamWriter(pathToLoadFile,false);
        for (int i = 0; i < times.Count; i++)
        {
            writer.WriteLine(times[i].ToString() + ';' + names[i]);
        }
        writer.Close();
    }
}
