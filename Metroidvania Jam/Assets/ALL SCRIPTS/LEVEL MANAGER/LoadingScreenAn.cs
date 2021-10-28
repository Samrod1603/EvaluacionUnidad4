using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreenAn : MonoBehaviour
{
    public static Animator ScreenAnimator;

    void Start()
    {
        ScreenAnimator = GetComponent<Animator>();
    }
}
