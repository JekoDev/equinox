using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPickup : MonoBehaviour
{
    private Card PickUpCard;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Start_RandomCardGetter", 0.5f);
        //Wait until CardCollection is ready
    }

    void Start_RandomCardGetter()
    {
        PickUpCard = CardCollection.GetRandomCard();
    }

    //Pickup
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "CharacterPhysic")
        {
            CharControl.CollectCard(PickUpCard);
            InterfaceM.ShowCollect();
            Destroy(this.gameObject);
        }
    }
}
