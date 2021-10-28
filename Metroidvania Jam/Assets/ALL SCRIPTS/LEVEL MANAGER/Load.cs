using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    StateMachinePlayer statemachine;
    public string SceneNAME;
    bool loaded;
    private GameObject startPoint;
    Rigidbody2D playeRigidBody;
    public string startPointString;
    public string sceneToUnload;
    public int startState;

    void Start()
    {
        statemachine = GameObject.FindGameObjectWithTag("Player").GetComponent<StateMachinePlayer>();
        playeRigidBody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        startPoint = GameObject.Find(startPointString);
}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && loaded == false)
        {
            loadscene();
            loaded = true;
        }
    }

    public void loadscene()
    {
        StartCoroutine(LoadSceneScreen());
        statemachine.state = startState;
        statemachine.attackState = 2;
    }

    IEnumerator LoadSceneScreen()
    {
        //animation
        LoadingScreenAn.ScreenAnimator.SetBool("Exit", true);

        yield return new WaitForSeconds(2.3f);

        SceneManager.LoadSceneAsync(SceneNAME, LoadSceneMode.Additive);
        playeRigidBody.position = startPoint.transform.position;
        statemachine.state = 3;

        yield return new WaitForSeconds(0.5f);

        LoadingScreenAn.ScreenAnimator.SetBool("Exit", false);
        SceneManager.UnloadSceneAsync(sceneToUnload);
        statemachine.state = 1;
        statemachine.attackState = 1;
    }
}
