using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRot : MonoBehaviour
{
    public Vector2 turn;
    public float sensitivity;
    private CharacterMovement charMove;
    public float yMinLimit = -70f;
    public float yMaxLimit = 40f;

    private void Start()
    {
        charMove = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        turn.y += Input.GetAxisRaw("Mouse Y") * sensitivity * Time.deltaTime;
        turn.x += Input.GetAxisRaw("Mouse X") * sensitivity * Time.deltaTime;

        turn.y = Mathf.Clamp(turn.y, yMinLimit, yMaxLimit);

        transform.localRotation = Quaternion.Euler(-turn.y, 0, 0);
    }
}
