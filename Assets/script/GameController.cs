using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public Text timeField;
    private float time = 0.0f;
    private string[] arr = {"eat", "drink", "sleep", "play", "work", "study", "sleep", "play", "work", "study"};
    public Text wordToFindField;
    private string choosenWord;
    private string hiddenWord;
    //private int[] wordLength = {3,5,5,4,4,5,5,4,4,5};
    //private bool isRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        choosenWord = arr[Random.Range(0, arr.Length)];
        wordToFindField.text = "";
        timeField.text = "0.0";

        for (int i = 0; i < hiddenWord.Length; i++)
        {
            wordToFindField.text += "_ ";
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime; //Time.deltaTime is the time between frames
        timeField.text = time.ToString();
    }

}
