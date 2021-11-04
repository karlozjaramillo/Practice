using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject player;  

    // Es la funci�n que se ejecuta fotograma por fotograma
    void Update()
    {
        transform.position = player.transform.position + new Vector3(0, 2, -5);
    }
}
