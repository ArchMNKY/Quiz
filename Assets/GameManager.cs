using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Score scoresystem;

    public Animator scoreani;
    public Image timebar;
    public float totalTime = 10;

    public TMP_Text scoreLabel;
    public Preguntas[] questions;

    public TMP_Text pregus;
    public TMP_Text[] opcionse;

    private int Indexquestions;
    private int score;

    private bool isGameActive;

    private float timer;

    public void Start()
    {
        isGameActive = true;

        pregus.text = questions[0].question;
        for(int i =0; i < questions[0].options.Length; i++)
        {
            opcionse[i].text = questions[0].options[i].option;
        }
        RestartTimer();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        timebar.fillAmount -= Time.deltaTime/totalTime;

        if (!isGameActive)
            return;

        if (timer < 0)
        {
            SigPreg();
        }
        

    }


   private void SigPreg()
    {
        Indexquestions++;

        if (Indexquestions < questions.Length)
        {
            RestartTimer();
            timebar.fillAmount = 1;

            pregus.text = questions[Indexquestions].question;
            for (int i = 0; i < questions[Indexquestions].options.Length; i++)
            {
                opcionse[i].text = questions[Indexquestions].options[i].option;
            }



        }
        else 
        {
            Debug.Log("Quiz Over");
            isGameActive = false;
            if (!isGameActive)
                return;
        }

    }

    public void OptionSelected(int index)
    {
        if (!isGameActive)
            return;


        if (questions[Indexquestions].options[index].Correct)
        {
            scoresystem.Addpoints(10);
          
        }

        else
        {
            scoresystem.Reducepoints(-10);
        }
        SigPreg();

    }

    private void RestartTimer()
    {
        timer = totalTime;
        timebar.fillAmount = 1f;
    }
}

[System.Serializable]
public struct Preguntas
{
    public string question;
    public Opcion[] options;
}

[System.Serializable]
public struct Opcion
{
    public string option;
    public bool Correct;
}