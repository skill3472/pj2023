using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(player.position.x, gameObject.transform.position.y,
            gameObject.transform.position.z);
    }
}
