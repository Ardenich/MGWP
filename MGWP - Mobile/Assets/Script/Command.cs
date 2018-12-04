using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Command : MonoBehaviour {

    string[] commandsArray = new string[3];

    public int arrayNum;
    public float timer;
    public float timeLimit = 10f;

    public Text commandText;
    public Text timeText;

	// Use this for initialization
	void Start () {
        commandsArray[0] = "Take Blue Ball";
        commandsArray[1] = "Take Black Ball";
        commandsArray[2] = "Take Green Ball";
    }
	
	// Update is called once per frame
	void Update ()
    {
        timeText.text = FormatTimer(timer);
        if (timer == timeLimit)
        {
            arrayNum = Random.Range(0, commandsArray.Length);
        }
        timer -= Time.deltaTime;
        if (timer > 0)
        {
            commandText.text = commandsArray[arrayNum];
        }
        if (timer < 0)
        {
            Ended();
        }
	}

    public void Ended()
    {
        timeLimit -= Random.Range (-2f, 2f);
        timer = timeLimit;
    }
    public string FormatTimer(float timer)
    {
        float totalTime = timer;
        if (timer > 0)
        {
            int minutes = (int)(totalTime / 60) % 60;
            int seconds = (int)totalTime % 60;

            string time = string.Format("{0:00}:{1:00}", minutes, seconds);
            return time;
        } else
        {
            int minutes = (int)(totalTime / 60) % 60;
            int seconds = ((int)totalTime % 60) * -1;

            string time = string.Format("{0:0}", seconds);
            return time;
        }
    }
}
