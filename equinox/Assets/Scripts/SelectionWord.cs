using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SelectionWord : MonoBehaviour
{
    public int NumberButton = 0;
    public static SelectionWord t;

    // Start is called before the first frame update
    void Start()
    {
        t = this;
        Button b = this.GetComponent<Button>();
        b.onClick.AddListener(Press);
    }

    public static void Press()
    {
        CharControl.SelectMeaning(t.NumberButton);
        InterfaceM.ShowSelected(t.NumberButton);
    }
}
