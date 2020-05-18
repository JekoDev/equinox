using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharControl : MonoBehaviour
{
    public float speed = 0.005f;
    public float SetToPosSpeed = 10f;

    public static Vector3 MoveToPosition;
    private Rigidbody rb;

    public static GameObject GObject;

    public float FallNotBeyond = -13;

    private CapsuleCollider coll;

    public static Card Card1;
    public static Card Card2;
    public static Card Card3;
    public static int CardCount = 0;

    public static int Select1;
    public static int Select2;
    public static int Select3;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        GObject = this.transform.gameObject;
        coll = this.GetComponent<CapsuleCollider>();
    }

    bool isGrounded()
    {
        return Physics.CheckCapsule(coll.bounds.center, new Vector3(coll.bounds.center.x, coll.bounds.min.y - 0.1f, coll.bounds.center.z), 0.18f);
    }


    public static void CollectCard(Card c)
    {
        if (CardCount == 0) Card1 = c;
        if (CardCount == 1) Card2 = c;
        if (CardCount == 2) Card3 = c;
        CardCount++;
    }

    public static Card GetLastCard() {
        Card c = null;
        if (CardCount == 1) return Card1;
        if (CardCount == 2) return Card2;
        if (CardCount >= 3) return Card3;
        return c;
    }

    public static void SelectMeaning(int Meaning)
    {
        if (CardCount == 1) Select1 = Meaning;
        if (CardCount == 2) Select2 = Meaning;
        if (CardCount >= 3) Select3 = Meaning;
    }

    public static int GetMeaning(int Card)
    {
        if (Card == 0) return Select1;
        if (Card == 1) return Select2;
        if (Card == 2) return Select3;
        return 0;
    }


    // Update is called once per frame
    void Update()
    {
        
        if (Level_Rotator.Rotated == true)
        {
            if (rb != null) rb.useGravity = false;
            if (rb != null) rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        }
        else {
            if (rb != null) rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            if (rb != null) rb.useGravity = true;

            if (isGrounded() == true)
            {
                if (Input.GetKey(KeyCode.W)) this.transform.Translate(new Vector3(0, 0, -speed) * Time.deltaTime);
                if (Input.GetKey(KeyCode.S)) this.transform.Translate(new Vector3(0, 0, speed) * Time.deltaTime);
                if (Input.GetKey(KeyCode.A)) this.transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
                if (Input.GetKey(KeyCode.D)) this.transform.Translate(new Vector3(-speed, 0, 0) * Time.deltaTime);
            }
        }

        if(this.transform.position.y < FallNotBeyond)
        {
            SceneManager.LoadScene(2);
        }
    }
}
