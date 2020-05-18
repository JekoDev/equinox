using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InterfaceM : MonoBehaviour
{
    public GameObject Int_Collect;
    public GameObject Int_Collect_Description;
    public GameObject Int_Collect_Options;
    public GameObject Int_Collect_OptionA;
    public GameObject Int_Collect_OptionB;
    public GameObject Int_Collect_OptionC;
    public GameObject Int_Collect_Image;
    public GameObject Int_Comeback;
    public GameObject Int_Guard;
    public GameObject Int_Guard1;
    public GameObject Int_Guard2;
    public GameObject Int_Guard3;

    public GameObject Int_End;
    public static GameObject Int_Intern_Collect, Int_Intern_End, Int_Intern_Image;
    public static GameObject Int_Intern_Options, Int_Intern_OptionA, Int_Intern_OptionB, Int_Intern_OptionC;
    public static GameObject Int_Intern_Desc, Int_Intern_Comeback, Int_Intern_Guard;
    public static GameObject Int_Intern_Guard1, Int_Intern_Guard2, Int_Intern_Guard3;

    public static Card selected;

    public static int GameState = 0;

    public void Start()
    {
        Int_Intern_Collect = Int_Collect;
        Int_Intern_End     = Int_End;
        Int_Intern_Options = Int_Collect_Options;
        Int_Intern_OptionA = Int_Collect_OptionA;
        Int_Intern_OptionB = Int_Collect_OptionB;
        Int_Intern_OptionC = Int_Collect_OptionC;
        Int_Intern_Image   = Int_Collect_Image;
        Int_Intern_Desc    = Int_Collect_Description;
        Int_Intern_Guard   = Int_Guard;
        Int_Intern_Guard1  = Int_Guard1;
        Int_Intern_Guard2  = Int_Guard2;
        Int_Intern_Guard3  = Int_Guard3;

        Int_Intern_Comeback = Int_Comeback;
    }

    public static void HideCollect()
    {
        GameState = 0;
        Int_Intern_Collect.SetActive(false);
    }

    public static void ShowCollect()
    {
        Int_Intern_Collect.SetActive(true);
        Int_Intern_Options.SetActive(true);
        Int_Intern_Desc.SetActive(false);

        TextMeshProUGUI o1 = Int_Intern_OptionA.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI o2 = Int_Intern_OptionB.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI o3 = Int_Intern_OptionC.GetComponent<TextMeshProUGUI>();

        Image i = Int_Intern_Image.GetComponent<Image>();
        if (i != null) i.sprite = CharControl.GetLastCard().CardImage;

        if (o1 != null) o1.text = CharControl.GetLastCard().Word1;
        if (o2 != null) o2.text = CharControl.GetLastCard().Word2;
        if (o3 != null) o3.text = CharControl.GetLastCard().Word3;

        selected = CharControl.GetLastCard();

        GameState = 1;
    }

    public static void ShowSelected(int number)
    {
        Int_Intern_Options.SetActive(false);
        Int_Intern_Desc.SetActive(true);

        TextMeshProUGUI desc = Int_Intern_Desc.GetComponent<TextMeshProUGUI>();

        if (number == 0 && desc != null) desc.text = CharControl.GetLastCard().Meaning1; 
        if (number == 1 && desc != null) desc.text = CharControl.GetLastCard().Meaning2; 
        if (number == 2 && desc != null) desc.text = CharControl.GetLastCard().Meaning3;

        GameState = 2;
    }

    public static void Comeback()
    {
        Int_Intern_Comeback.SetActive(false);
        Int_Intern_Comeback.SetActive(true);
    }

    public static void Guard()
    {
        Int_Intern_Guard.SetActive(true);
        Image i1 = Int_Intern_Guard1.GetComponent<Image>();
        Image i2 = Int_Intern_Guard2.GetComponent<Image>();
        Image i3 = Int_Intern_Guard3.GetComponent<Image>();
        if (i1 != null) i1.sprite = CharControl.Card1.CardImage;
        if (i1 != null) i2.sprite = CharControl.Card2.CardImage;
        if (i1 != null) i3.sprite = CharControl.Card3.CardImage;

        GameState = 3;
    }

    public static void End()
    {
        Int_Intern_Guard.SetActive(false);
        Int_Intern_End.SetActive(true);
        GameState = 4;
    }

    public void Update()
    {
        switch (GameState)
        {
            case 0: //Nothing (IDLE)
                break;

            case 1: //Collect a Card
                break;

            case 2: //Meaning of Card
                if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
                {
                    HideCollect();
                }
                break;

            case 3: //Levelkeeper
                break;

            case 4: //Levelkeeper End
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
                {
                    SceneManager.LoadScene(0);   
                }
                break;
        }
    }
}
