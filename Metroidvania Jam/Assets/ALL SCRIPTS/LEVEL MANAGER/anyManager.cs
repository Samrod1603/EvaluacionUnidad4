using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class anyManager : MonoBehaviour
{
    public static anyManager AnyManager;

    bool gameStart;

    private void Awake()
    {
        if (gameStart==false)
        {
            AnyManager = this;

            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);

            gameStart = true;
        }
    }
}
