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
