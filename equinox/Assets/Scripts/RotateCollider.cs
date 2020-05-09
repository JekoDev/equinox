using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCollider : MonoBehaviour
{
    public Vector3 RotateTo;
    public Vector3 MoveCharTo;
    public Vector3 MoveCharToStart;

    public RotateCollider[] Enable;
    public RotateCollider[] Disable;

    private RotateCollider thi;

 
    // Start is called before the first frame update
    void Start()
    {
        thi = this.GetComponent<RotateCollider>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (thi == null) thi = this.GetComponent<RotateCollider>();
        if (thi != null && thi.enabled == false) return;

        if(collision.transform.name == "CharacterPhysic" && Level_Rotator.RotateTo == Vector3.zero && Level_Rotator.Rotated == false && Level_Rotator.CannotRotateTimer < 0)
        {
            Debug.Log("Dreh dich!");
            Level_Rotator.RotateTo = RotateTo;
            Level_Rotator.MoveCharTo = MoveCharTo;
            Level_Rotator.MoveCharTo = MoveCharToStart;
            Level_Rotator.Collider = this.gameObject;

            int x = 0;


            for (x=0; x < Enable.Length; x++)
            {
                Enable[x].enabled = true;
            }

            for (x = 0; x < Disable.Length; x++)
            {
                Disable[x].enabled = false;
            }

            if (thi == null) thi = this.GetComponent<RotateCollider>();
            if(thi != null) thi.enabled = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.matrix = transform.localToWorldMatrix;
        //Gizmos.matrix = Matrix4x4.TRS(transform.localPosition, transform.localRotation, transform.localScale);

        Gizmos.DrawWireCube(Vector3.zero + MoveCharTo, Vector3.one);

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Vector3.zero + MoveCharToStart, Vector3.one/2);

        //Gizmos.DrawWireCube(this.transform.position, new Vector3(1, 1, 1));
    }
}
