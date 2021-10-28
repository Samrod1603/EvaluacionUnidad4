using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FollowDefine : MonoBehaviour
{
    private Transform PlayerTrans;
    CinemachineVirtualCamera Vcam;

    private void Start()
    {
        PlayerTrans = GameObject.Find("PLAYER").transform;
        Vcam = gameObject.GetComponent<CinemachineVirtualCamera>();
        Vcam.Follow = PlayerTrans;
    }
}
