using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class addLives : MonoBehaviour {

    public Text lives;
    public static int l = 6;
    public static int bonus;
	void Start () {
        //l = textAsset.faultCounter;
    }
	
	
	void Update () {
        lives.text = l.ToString();
        if (l == 3)
            bonus = 130;
        else if (l == 4)
            bonus = 120;
        else if (l == 5)
            bonus = 110;
        else if (l == 6)
            bonus = 100;
        else if (l == 7)
            bonus = 90;
        else if (l == 8)
            bonus = 80;
        else if (l == 9)
            bonus = 70;
        else if (l == 10)
            bonus = 60;
        else if (l == 11)
            bonus = 50;
        else if (l == 12)
            bonus = 40;
        else if (l == 13)
            bonus = 30;
        else if (l == 14)
            bonus = 20;
        else
            bonus = 10; 
	}



    public void addLife()
    {
        l++;
        if (l >= 15)
            l = 15;
    }

    public void removeLife()
    {
        l--;
        if (l < 3)
            l = 3;
    }

}
