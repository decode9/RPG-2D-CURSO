using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
   private CinemachineVirtualCamera cv;
   public GameObject player;

   private void Start() {
       cv = GetComponent<CinemachineVirtualCamera>();
       player = GameManager.instance.player;
       cv.m_Follow = player.transform;
   }


}
