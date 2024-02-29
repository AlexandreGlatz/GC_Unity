using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;

    [Range(0f, 1f)]
    public float Smooth;

    public float offSetY;
    public float offSetX;

    Vector3 shakeTarget;
    float shakeEnd;
    bool isShaking;

    void FixedUpdate()
    {

        var playerPositon = player.position;

        if (isShaking)
        {
            if (shakeEnd < Time.time)
            {
                isShaking = false;
            }
            playerPositon.y += offSetY;
            playerPositon -= shakeTarget;
            var moveVector = Vector3.Lerp(playerPositon, transform.position, .92f);
            moveVector.z = -10;
            gameObject.transform.position = moveVector;
        }
        else
        {
            playerPositon.y += offSetY;
            var moveVector = Vector3.Lerp(playerPositon, transform.position, Smooth);
            moveVector.z = -10;
            gameObject.transform.position = moveVector;
        }

    }
}