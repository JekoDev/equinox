using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "CharacterPhysic") return;
        if (CharControl.CardCount < 3)
        {
            InterfaceM.Comeback();
        }
        else
        {
            InterfaceM.Guard();
        }
    }
}
