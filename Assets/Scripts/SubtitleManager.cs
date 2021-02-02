﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtitleManager : MonoBehaviour
{
    [SerializeField] private string[] mamaEstherDialogStrings = { "MAMA: Esther dear, come help me with breakfast. Did you wash your hands?\nESTHER: Sure, Mama!", "MAMA: Great job, my little bunny! Would you go and get me the gefilte fish recipe from the basement?\nESTHER: OK!", "MAMA: Be careful when you go down!" };
    [SerializeField] private string[] mamaMiraDialogStrings = { "MAMA: Want to come help us, Mira?\nMIRA: No, I don’t want your gross gefilte" };
    [SerializeField] private string[] afterRecipyDialog = { "MAMA: Thank you honey. And now we can put the onions on the frying pan and stir until are they become golden" };
    [SerializeField] private string[] answeringMachine = { "MIRA: Don't call me until you agree to give me the recipe. This has been going for far too long" };
    [SerializeField] private string[] lastDialog = { "ESTHER: Mira, please! I just want us to get along again. Mama would never want this." , "MIRA: Then let me have the recipe. You don’t even need it!", "ESTHER: She gave it to me, and you know it!", "MIRA: And YOU just can’t stand sharing any shred of whatever is left of her!  I miss her too, so much. \nBut  I could never compete with you, not in her eyes.", "SIGH, ESTHER:  It’s not worth it… time to let go..." };
    [SerializeField] private string[] other;
    private string[] myStrings;

    int curStringIdx = 0;

    bool displaying = false;

    public GUIStyle mamaStyle;
    public GUIStyle dinaraStyle;

    public IEnumerator ShowMe(int stringIdx, string arrayName)
    {
        getCharacterArray(arrayName);
        
        curStringIdx = stringIdx;

        displaying = true;
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);

        yield return new WaitForSeconds((myStrings[curStringIdx].Length / 20) + 5);

        displaying = false;
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    private void getCharacterArray(string arrayName)
    {
        if (arrayName == "mama")
        {
            myStrings = mamaEstherDialogStrings;
        }
        else if (arrayName == "mira")
        {
            myStrings = mamaMiraDialogStrings;
        }
        else if(arrayName == "after")
        {
            myStrings = afterRecipyDialog;
        }
        else if(arrayName == "answeringMachine")
        {
            myStrings = answeringMachine;
        }
    }

    public IEnumerator startMamaEstherDialog()
    {
        myStrings = mamaEstherDialogStrings;
        displaying = true;
        curStringIdx = 0;
        yield return new WaitForSeconds((myStrings[curStringIdx].Length / 20) + 2);

        displaying = false;
        displaying = true;
        curStringIdx = 1;
        yield return new WaitForSeconds((myStrings[curStringIdx].Length / 20) + 2);

        displaying = false;
        displaying = true;
        curStringIdx = 2;
        yield return new WaitForSeconds((myStrings[curStringIdx].Length / 20) + 2);

        displaying = false;
    }

    public void startMamaMiraDialog()
    {
        StartCoroutine(ShowMe(0, "mira"));
    }

    public void startAfterRecipyDialog()
    {
        StartCoroutine(ShowMe(0, "after"));
    }

    public void startAnsweringMachine()
    {
        StartCoroutine(ShowMe(0, "answeringMachine"));
    }

    public IEnumerator StartLastDialog()
    {
        myStrings = lastDialog;
        displaying = true;
        curStringIdx = 0;
        yield return new WaitForSeconds((myStrings[curStringIdx].Length / 20));

        displaying = false;
        displaying = true;
        curStringIdx = 1;
        yield return new WaitForSeconds((myStrings[curStringIdx].Length / 20));

        displaying = false;
        displaying = true;
        curStringIdx = 2;
        yield return new WaitForSeconds((myStrings[curStringIdx].Length / 20));

        displaying = false;
        displaying = true;
        curStringIdx = 3;
        yield return new WaitForSeconds((myStrings[curStringIdx].Length / 20));

        displaying = false;
        displaying = true;
        curStringIdx = 3;
        yield return new WaitForSeconds((myStrings[curStringIdx].Length / 20));

        displaying = false;
    }

    void OnGUI()
    {
        if (displaying)
        {
            GUI.Label(new Rect(20, Screen.height - 80, Screen.width - 40, 60), myStrings[curStringIdx], mamaStyle);
        }
    }
}
