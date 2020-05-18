using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class ClickEnd : MonoBehaviour
{ 

    // Start is called before the first frame update
    void Start()
    {
        Button b = this.GetComponent<Button>();
        b.onClick.AddListener(Press);
    }

    public static void Press()
    {
        SceneManager.LoadScene(0);
    }
}
