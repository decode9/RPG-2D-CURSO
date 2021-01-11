using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        FollowCamera();
    }

    void FollowCamera(){
        float positionX = player.position.x;
        float positionY = player.position.y;

        MoveCamera(positionX, positionY);
    }

    void MoveCamera(float coordenadaX, float coordenadaY){
        Vector3 newPosition = new Vector3(coordenadaX, coordenadaY, transform.position.z);
        transform.position = newPosition;
    }
}
