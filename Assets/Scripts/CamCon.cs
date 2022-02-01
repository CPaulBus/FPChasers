using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniGLTF;
using UniGLTF.MeshUtility;
using VRM;

public class CamCon : MonoBehaviour
{
    public Transform camTar;
    public float pLerp;
    public float rLerp;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, camTar.position, pLerp);
        transform.rotation = Quaternion.Lerp(transform.rotation, camTar.rotation, rLerp);
    }
}
