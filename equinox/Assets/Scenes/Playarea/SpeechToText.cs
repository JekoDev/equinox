using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using TMPro;

public class SpeechToText : MonoBehaviour
{
    private string currentString;

    private DictationRecognizer m_DictationRecognizer;

    public Button Bttn1, Bttn2;
    public TMP_Text Text;

    void Start()
    {
        m_DictationRecognizer = new DictationRecognizer();
       

        m_DictationRecognizer.DictationResult += (text, confidence) =>
        {
            Debug.LogFormat("Dictation result: {0}", text);
            currentString += ">> ";
            currentString += text + "\n";
        };

        m_DictationRecognizer.DictationHypothesis += (text) =>
        {
            Debug.LogFormat("Dictation hypothesis: {0}", text);
            //currentString += "\n\n 50%: ";
            //currentString += text + "\n";
        };

        m_DictationRecognizer.DictationComplete += (completionCause) =>
        {
            if (completionCause != DictationCompletionCause.Complete)
                Debug.LogErrorFormat("Dictation completed unsuccessfully: {0}.", completionCause);
        };

        m_DictationRecognizer.DictationError += (error, hresult) =>
        {
            Debug.LogErrorFormat("Dictation error: {0}; HResult = {1}.", error, hresult);
        };

        ColorBlock colorsb = Bttn2.colors;
        colorsb.normalColor = Color.gray;
        colorsb.highlightedColor = Color.gray;
        colorsb.selectedColor = Color.gray;
        Bttn2.colors = colorsb;
    }

    private void Update()
    {
        Text.text = GetCurrentText();
    }

    public void StartSTT()
    {
        
        currentString = "";

        Debug.Log("Start");


        ColorBlock colors = Bttn1.colors;
        colors.normalColor = Color.gray;
        colors.selectedColor = Color.gray;
        colors.highlightedColor = Color.gray;
        colors.disabledColor = Color.gray;
        Bttn1.colors = colors;
        Bttn1.enabled = false;

        ColorBlock colorsb = Bttn2.colors;
        colorsb.normalColor = Color.gray;
        colorsb.selectedColor = Color.gray;
        colorsb.highlightedColor = Color.gray;
        Bttn2.colors = colorsb;
        Bttn2.enabled = true;

        m_DictationRecognizer.Start();
    }

    public void StopSTT()
    {

        Debug.Log("Stop");
        ColorBlock colors = Bttn1.colors;
        colors.normalColor = Color.gray;
        colors.selectedColor = Color.gray;
        colors.highlightedColor = Color.gray;
        colors.disabledColor = Color.gray;
        
        Bttn2.enabled = false;

        ColorBlock colorsb = Bttn2.colors;
        colorsb.normalColor = Color.gray;
        colorsb.selectedColor = Color.gray;
        colorsb.highlightedColor = Color.gray;
        Bttn1.colors = colorsb;
        Bttn2.colors = colors;
        Bttn1.enabled = true;

        m_DictationRecognizer.Stop();
    }

    public string GetCurrentText()
    {
        return currentString;
    }
}