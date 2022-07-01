using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameController : MonoBehaviour{
    public Text timeField;
    private float time = 0.0f;
    private string[] arr = {"eat", "drink", "sleep", "play", "work", "study", "sleep", "play", "work", "study"};
    //private string[] arr = File.ReadAllLines("./Assets/script/words.TXT");
    public Text wordToFindField;
    private string choosenWord;
    private string hiddenWord;
    public GameObject[] bodyparts;
    private int fail;
    public GameObject failField;
    public GameObject winField;
    public GameObject ResetButton;
    //private int[] wordLength = {3,5,5,4,4,5,5,4,4,5};
    //private bool isRunning = false;
    // Start is called before the first frame update
    void Start(){
        fail = 0;
        choosenWord = arr[Random.Range(0, arr.Length)];
        wordToFindField.text = "";
        hiddenWord = "";
        timeField.text = "0.0";
        for (int i = 0; i < choosenWord.Length; i++){
            if(choosenWord[i] == ' ' ) {hiddenWord += " ";}  else {hiddenWord += "-";}
        } 
        wordToFindField.text = hiddenWord;
        ResetButton.SetActive(false);
    }

    // Update is called once per frame
    void Update(){
        time += Time.deltaTime; //Time.deltaTime is the time between frames
        timeField.text = time.ToString();
    }
    private void OnGUI(){
        Event e = Event.current;
        if(e.type == EventType.KeyDown && e.keyCode.ToString().Length == 1){
            char letter = e.keyCode.ToString().ToLower()[0];
            //string str = e.keyCode.ToString();
            //Debug.Log("Key down event is triggered: " + letter + "\n");
            //Debug.Log("the letter " + str + " has position " + choosenWord.IndexOf(letter) + " in the word " + choosenWord);
            int pos = choosenWord.IndexOf(letter);
            if(pos != -1){
                for (int i = pos; i < choosenWord.Length; i++){
                    if(choosenWord[i] == letter){
                        hiddenWord = hiddenWord.Remove(i, 1);
                        hiddenWord = hiddenWord.Insert(i, letter.ToString());
                        wordToFindField.text = hiddenWord;
                    }
                }
                if(hiddenWord.IndexOf("-") == -1){
                    winField.SetActive(true);
                    ResetButton.SetActive(true);
                }
            }
            else{
                bodyparts[fail].SetActive(true);
                fail++;
                if(fail > 5){
                    Debug.Log("You lose");
                    failField.SetActive(true);
                    ResetButton.SetActive(true);
                }
            }
        }
    }
}
