using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kino;

public class Level_Rotator : MonoBehaviour
{
    public static Vector3 RotateTo;
    public float RotationSpeed = 1.0f;

    private float sec;
    public static bool Rotated = false;

    public static Vector3 MoveCharTo;
    public static Vector3 MoveCharToStart;

    public static GameObject Collider;
    public AnalogGlitch analogGlitch;
    public static float CannotRotateTimer = 0;

    private float Distance;

    public static Vector3 AtTheEnd;


    // Start is called before the first frame update
    void Start()
    {
        //RotateTo = this.transform.rotation;
        Debug.Log(this.name);
        GameObject Cache = Camera.main.gameObject;
        analogGlitch = Cache.GetComponent<AnalogGlitch>();
    }

    // Update is called once per frame
    void Update()
    {
        if (RotateTo != Vector3.zero) {
            if (Rotated == false)
            {
                Rotated = true;
                Distance = Vector3.Distance(Vector3.zero, RotateTo);
                if (MoveCharToStart != Vector3.zero) CharControl.GObject.transform.position = Collider.transform.TransformPoint(MoveCharToStart);
                MoveCharToStart = Vector3.zero;
                CannotRotateTimer = 10;
                AtTheEnd = this.transform.eulerAngles;
                AtTheEnd += RotateTo;
            }

            if (Vector3.Distance(Vector3.zero, RotateTo) > 0)
            {
                analogGlitch.scanLineJitter = 0.7f;
                analogGlitch.colorDrift = 0.7f;
                analogGlitch.verticalJump = 0.3f;
            }else{
                analogGlitch.scanLineJitter = 0.0f;
                analogGlitch.colorDrift = 0.0f;

            }

            if (RotateTo.x > 0)
            {
                RotateTo.x -= RotationSpeed * Time.deltaTime;
                this.transform.Rotate(RotationSpeed * Time.deltaTime, 0, 0);
                if (RotateTo.x < 0.3f)
                {
                    this.transform.Rotate(RotateTo.x, 0, 0);
                    RotateTo.x = 0;
                }
            }
            if (RotateTo.x < 0)
            {
                RotateTo.x += RotationSpeed * Time.deltaTime;
                this.transform.Rotate(-RotationSpeed * Time.deltaTime, 0, 0);
                if (RotateTo.x > -0.3f)
                {
                    this.transform.Rotate(-RotateTo.x, 0, 0);
                    RotateTo.x = 0;
                }
            }
            if (RotateTo.y > 0)
            {
                RotateTo.y -= RotationSpeed * Time.deltaTime;
                this.transform.Rotate(0, RotationSpeed * Time.deltaTime, 0);
                if (RotateTo.y < 0.3f)
                {
                    this.transform.Rotate(0, RotateTo.y, 0);
                    RotateTo.y = 0;
                }
            }
            if (RotateTo.y < 0)
            {
                RotateTo.y += RotationSpeed * Time.deltaTime;
                this.transform.Rotate(0, -RotationSpeed * Time.deltaTime, 0);
                if (RotateTo.y > -0.3f)
                {
                    this.transform.Rotate(0, -RotateTo.y, 0);
                    RotateTo.y = 0;
                }
            }
            if (RotateTo.z > 0)
            {
                RotateTo.z -= RotationSpeed * Time.deltaTime;
                this.transform.Rotate(0, 0, RotationSpeed * Time.deltaTime);
                if (RotateTo.z < 0.3f)
                {
                    this.transform.Rotate(0, 0, RotateTo.z);
                    RotateTo.z = 0;
                }
            }
            if (RotateTo.z < 0)
            {
                RotateTo.z += RotationSpeed * Time.deltaTime;
                this.transform.Rotate(0, 0, -RotationSpeed * Time.deltaTime);
                if (RotateTo.z > -0.3f)
                {
                    this.transform.Rotate(0, 0, -RotateTo.z);
                    RotateTo.z = 0;
                }
            }

            /*
            if (RotateTo.x > -0.3f && RotateTo.z < 0f)
            {
                this.transform.Rotate(RotateTo.x, 0, 0);
                RotateTo.x = 0f;
            }

            if (RotateTo.x < 0.3f && RotateTo.z > 0f) {
                this.transform.Rotate(-RotateTo.x, 0, 0);
                RotateTo.x = 0f;
            }

            if (RotateTo.y > -0.3f && RotateTo.z < 0f)
            {
                this.transform.Rotate(0, -RotateTo.y, 0);
                RotateTo.y = 0f;
            }

            if (RotateTo.y < 0.3f && RotateTo.z > 0f)
            {
                this.transform.Rotate(0, RotateTo.y, 0);
                RotateTo.y = 0f;
            }

            if (RotateTo.z > -0.3f && RotateTo.z < 0f)
            {
                this.transform.Rotate(0, 0, -RotateTo.z);
                RotateTo.z = 0f;
            }

            if (RotateTo.z < 0.3f && RotateTo.z > 0f)
            {
                this.transform.Rotate(0, 0, RotateTo.z);
                RotateTo.z = 0f;
            }
            */
            
        }
        else
        {
            if (Rotated == true) {
                this.transform.rotation = Quaternion.Euler(AtTheEnd);
                //if (MoveCharTo != Vector3.zero) MoveCharTo = Collider.transform.worldToLocalMatrix.MultiplyPoint(world;
                //if (MoveCharTo != Vector3.zero) CharControl.GObject.transform.position = Collider.transform.position - MoveCharTo;
                if (MoveCharTo != Vector3.zero) CharControl.GObject.transform.position = Collider.transform.TransformPoint(MoveCharTo);
                CharControl.MoveToPosition = Vector3.zero;
                Rotated = false;
                analogGlitch.scanLineJitter = 0.0f;
                analogGlitch.colorDrift = 0.0f;
                analogGlitch.verticalJump = 0.0f;
            }

            CannotRotateTimer--;
        }
   
    }
}
