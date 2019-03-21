using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textAsset : MonoBehaviour
{

    public TextAsset dictionaryTextFile;
    private string wordsFile;
    private List<string> eachLine;
    private List<string> correctChar;
    private List<string> incorrectChar;
    private string[] letters;
    public Text textbox;
    public Text result;
    private Text letterTrans;
    public Text lettersBox;
    public string word;
    public Text category;
    public Text hiddenWord;
    public Text whatWord;
    public int line;
    public string inputChar;
    public int counter = 0;
    public int lastCounter;
    public static int faultCounter = 6;
    public string lastChar;
    public bool isWon = false;
    public GameObject replayBox;
    public GameObject loseBox;
    public Text chances;
    public GameObject hit;
    public GameObject point;
    public Text scores;
    public Text scoresWonInfo;
    int score = 0;
    public int hiddenLetters = 0;
    public int len;
    public Text highScore;
    int bonus;

    public void Start()
    {
        
        wordsFile = dictionaryTextFile.text;
        eachLine = new List<string>();
        correctChar = new List<string>();
        incorrectChar = new List<string>();

        letters = new string[26] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" }; 
        eachLine.AddRange(wordsFile.Split('_', '\n'));
        line = Random.Range(0, eachLine.Count - 1);

        if (line % 2 == 0)
        {
            word = eachLine[line];
            category.text = eachLine[line + 1];
        }
        else
        {
            word = eachLine[line - 1];
            category.text = eachLine[line];
        }
        replayBox.SetActive(false);
        loseBox.SetActive(false);
        faultCounter = addLives.l;
        counter = 0;
        isWon = false;
        hiddenWord.text = "";
        highScore.text = PlayerPrefs.GetInt("HighScore",0).ToString();
        len = word.Length;
        for (int i = 0; i < word.Length; i++)
        {
            if (word[i].ToString() == " ")
            {
                hiddenWord.text += " ";
                counter += 1;
                hiddenLetters += 1;
            }
            else
                hiddenWord.text += "-";
        }
        /*
        if (addLives.bonus == 3)
            bonus = 130;
        else if (addLives.l == 4)
            bonus = 120;
        else if (addLives.l == 5)
            bonus = 110;
        else if (addLives.l == 6)
            bonus = 100;
        else if (addLives.l == 7)
            bonus = 90;
        else if (addLives.l == 8)
            bonus = 80;
        else if (addLives.l == 9)
            bonus = 70;
        else if (addLives.l == 10)
            bonus = 60;
        else if (addLives.l == 11)
            bonus = 50;
        else if (addLives.l == 12)
            bonus = 40;
        else if (addLives.l == 13)
            bonus = 30;
        else if (addLives.l == 14)
            bonus = 20;
        else
            bonus = 10;
            */

    }



    public void CheckChar()
    {
        int charIndex = 0;



        lastCounter = counter;
        if (word.Contains(inputChar) && !correctChar.Contains(inputChar))
        {
            correctChar.Add(inputChar);
            
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i].ToString() == inputChar)
                {
                    charIndex = i;
                    hiddenWord.text = hiddenWord.text.Remove(charIndex, 1);
                    hiddenWord.text = hiddenWord.text.Insert(charIndex, inputChar);
                    counter++;
                    hiddenLetters++;
                    score += 10;


                }

            }


        }
        else
        {
            incorrectChar.Add(inputChar);
            faultCounter--;

        }

        if (counter == word.Length)
        {
            isWon = true;
            replayBox.SetActive(true);
            //Start();
            hiddenWord.text = word;
            result.text = null;
        }
        else if (textbox.text.ToLower() == word)
        {
            score += (len - hiddenLetters) * addLives.bonus;
            isWon = true;
            replayBox.SetActive(true);
            //Start();
            hiddenWord.text = textbox.text.ToLower();
            result.text = null;
            

        }
        else
        {
            replayBox.SetActive(false);
        }
        if (faultCounter <= 0)
        {
            loseBox.SetActive(true);
            whatWord.text = word;
            Debug.Log("LOSE");
            result.text = null;
        }
        else
        {
            loseBox.SetActive(false);
        }

    }


    /*

        void OnGUI()
        {
            GUI.Label(new Rect(10, 10, 200, 100), hiddenWord + "    (Correct Word: " + word + ")");

        inputChar = GUI.TextField(new Rect(60, 500, 200, 20), inputChar, 1);

             if(GUI.Button (new Rect(220,500,80,20), "Submit")) {



                //Prevent char to be sent if null
                if (!string.IsNullOrEmpty(inputChar))
                     CheckChar();

        //Reset input char to empty
        inputChar = "";


            }


        }*/



    void Update()
    {
        /*
        A - ye,a,yay 
        B - be, bee, 
        C - see, sea, 
        D - thee, dee, de
        E - eh, ee, 
        F - eff, F
        G - jee, 
        H - edge, hedge, hatch, itch
        I - Aye, eye, I
        J - je, jay, joy
        K - kay, ke, 
        L - el, yell, hell
        M - am, yam, em
        N - yen, en,
        O - oh, vow, waw
        P - pee, pay, pie
        Q - queue,
        R - are, err, year
        S - yes, ass, S
        T - tee, tea, 
        U - you, U
        V - we, wee,
        W - double you, 
        X - axe
        Y - why
        Z - zed, zee, jed
        
        if (textbox.text.ToLower() == "ye" || textbox.text.ToLower() == "yay")
            inputChar = "a";
        else if (textbox.text.ToLower() == "be" || textbox.text.ToLower() == "bee")
            inputChar = "b";
        else if (textbox.text.ToLower() == "see" || textbox.text.ToLower() == "sea")
            inputChar = "c";
        else if (textbox.text.ToLower() == "thee" || textbox.text.ToLower() == "dee" || textbox.text.ToLower() == "de" || textbox.text.ToLower() == "the")
            inputChar = "d";
        else if (textbox.text.ToLower() == "eh" || textbox.text.ToLower() == "ee")
            inputChar = "e";
        else if (textbox.text.ToLower() == "eff")
            inputChar = "f";
        else if (textbox.text.ToLower() == "jee")
            inputChar = "g";
        else if (textbox.text.ToLower() == "edge" || textbox.text.ToLower() == "hedge" || textbox.text.ToLower() == "hatch" || textbox.text.ToLower() == "itch" || textbox.text.ToLower() == "8" || textbox.text.ToLower() == "gee")
            inputChar = "h";
        else if (textbox.text.ToLower() == "aye" || textbox.text.ToLower() == "eye")
            inputChar = "i";
        else if (textbox.text.ToLower() == "je" || textbox.text.ToLower() == "jay" || textbox.text.ToLower() == "joy")
            inputChar = "j";
        else if (textbox.text.ToLower() == "kay" || textbox.text.ToLower() == "ke" || textbox.text.ToLower() == "key" || textbox.text.ToLower() == "gay")
            inputChar = "k";
        else if (textbox.text.ToLower() == "el" || textbox.text.ToLower() == "yell" || textbox.text.ToLower() == "hell")
            inputChar = "l";
        else if (textbox.text.ToLower() == "am" || textbox.text.ToLower() == "yam" || textbox.text.ToLower() == "em")
            inputChar = "m";
        else if (textbox.text.ToLower() == "yen" || textbox.text.ToLower() == "en")
            inputChar = "n";
        else if (textbox.text.ToLower() == "oh" || textbox.text.ToLower() == "vow" || textbox.text.ToLower() == "waw")
            inputChar = "o";
        else if (textbox.text.ToLower() == "pee" || textbox.text.ToLower() == "pay" || textbox.text.ToLower() == "pie")
            inputChar = "p";
        else if (textbox.text.ToLower() == "queue" || textbox.text.ToLower() == "cute")
            inputChar = "q";
        else if (textbox.text.ToLower() == "are" || textbox.text.ToLower() == "err" || textbox.text.ToLower() == "year")
            inputChar = "r";
        else if (textbox.text.ToLower() == "yes" || textbox.text.ToLower() == "ass")
            inputChar = "s";
        else if (textbox.text.ToLower() == "tee" || textbox.text.ToLower() == "tea")
            inputChar = "t";
        else if (textbox.text.ToLower() == "you")
            inputChar = "u";
        else if (textbox.text.ToLower() == "we" || textbox.text.ToLower() == "wee" || textbox.text.ToLower() == "hugh")
            inputChar = "v";
        else if (textbox.text.ToLower() == "double you")
            inputChar = "w";
        else if (textbox.text.ToLower() == "axe" || textbox.text.ToLower() == "ex")
            inputChar = "x";
        else if (textbox.text.ToLower() == "why")
            inputChar = "y";
        else if (textbox.text.ToLower() == "zed" || textbox.text.ToLower() == "zee" || textbox.text.ToLower() == "jed" || textbox.text.ToLower() == "zedd")
            inputChar = "z";
        else
            inputChar = textbox.text.ToLower();
            */
        
        chances.text = faultCounter.ToString();
        if (textbox.text.ToLower() == "the")
            inputChar = "d";
        else if (textbox.text.ToLower() == "air")
            inputChar = "r";
        else
        inputChar = textbox.text.ToLower();
       
        lastChar = inputChar;
        int index = System.Array.IndexOf(letters, inputChar);
        if (index != -1 || index == 1)
            letters[index] = " ";

        if (!string.IsNullOrEmpty(inputChar))
        {
            CheckChar();
        }
        scores.text = score.ToString();
        scoresWonInfo.text = score.ToString();
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore.text = score.ToString();
        }
        lettersBox.text = string.Join(" ", letters);
        textbox.text = null;
        inputChar = null;
    }


    public void clearResult()
    {
        result.text = null;
    }

    public void clearScores()
    {
        score = 0;
    }
}



