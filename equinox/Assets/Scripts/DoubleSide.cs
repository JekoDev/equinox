using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class DoubleSide : MonoBehaviour
{

    void Start()
    {
        Vector2[] uvs = GetComponent<MeshFilter>().sharedMesh.uv;

        uvs[6] = new Vector2(0, 0);
        uvs[7] = new Vector2(1, 0);
        uvs[10] = new Vector2(0, 1);
        uvs[11] = new Vector2(1, 1);

        GetComponent<MeshFilter>().sharedMesh.uv = uvs;
    }
}