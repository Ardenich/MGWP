using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Task : NetworkBehaviour
{


    string[] commandsArray = new string[3];

    public int arrayNum;
    public float timer;
    public float timeLimit = 10f;

    public Text commandText;
    public Text timeText;
    public bool flag = true;
    public int tes;


    // Use this for initialization
    void Start()
    {
        commandsArray[0] = "ambil buku";
        commandsArray[1] = "ambil tas";
        commandsArray[2] = "ambil baju";

    }

    // Update is called once per frame
    void Update()
    {
        //    if (flag == false)
        //  {
        //    Application.LoadLevel("Menu");
        //  }
        

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
                tes++;
                if (tes > 1)
                {
                    flag = false;
                }

                Ended();



            }
        

    }

    public void Ended()
    {
        timeLimit -= Random.Range(-2f, 2f);
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
        }
        else
        {
            int minutes = (int)(totalTime / 60) % 60;
            int seconds = ((int)totalTime % 60) * -1;

            string time = string.Format("{0:0}", seconds);
            return time;

        }



    }
}
