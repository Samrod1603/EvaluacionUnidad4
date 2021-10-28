using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interact : MonoBehaviour
{
    public Transform InteractablePlayerZone;
    public float interactRange;
    public LayerMask interactableStuff;
    private TextMeshProUGUI textDisplay;
    public float typingSPeed;
    public bool talking = false;
    public string sentence1="";
    public string sentence2="";
    public string sentence3="";
    public int sentLenght=0;
    public bool beInSentence1 = false;
    StateMachinePlayer StateMachine;
    FirstNPC SentencesTownNature;
    private GameObject panel;
    //public GameObject LifeDisplay;
    Animator displayLifes;
    public static string CheckPoint;


    private void Start()
    {
        textDisplay = GameObject.Find("Dialog Text").GetComponent<TextMeshProUGUI>();
        StateMachine = GetComponent<StateMachinePlayer>();
        SentencesTownNature = GameObject.Find("ALL NPCs").GetComponent<FirstNPC>();
        displayLifes = GameObject.Find("LIFES & COINS DISPLAY").GetComponent<Animator>();
        panel = GameObject.Find("Panel");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            PlayerInteract();
        }

        switch(sentLenght)
        {
            case 1:
                if (beInSentence1 == true)
                {
                    StartCoroutine(typeSentence1());
                    beInSentence1 = false;
                }

                if (textDisplay.text == sentence1 && Input.GetKeyUp(KeyCode.X))
                {
                    sentLenght = 0;
                    StateMachine.state = 1;
                    StateMachine.attackState = 1;
                    panel.SetActive(false);
                }
                break;

            case 2:
                if (beInSentence1 == true)
                {
                    StartCoroutine(typeSentence1());
                    beInSentence1 = false;
                }

                if (textDisplay.text == sentence1 && Input.GetKeyUp(KeyCode.X))
                {
                    textDisplay.text = "";
                    StartCoroutine(typeSentence2());
                }

                if (textDisplay.text == sentence2 && Input.GetKeyUp(KeyCode.X))
                {
                    sentLenght = 0;
                    StateMachine.state = 1;
                    StateMachine.attackState = 1;
                    panel.SetActive(false);
                }
                    break;

            case 3:
                if (beInSentence1 == true)
                {
                    StartCoroutine(typeSentence1());
                    beInSentence1 = false;
                }

                if (textDisplay.text == sentence1 && Input.GetKeyUp(KeyCode.X))
                {
                    textDisplay.text = "";
                    StartCoroutine(typeSentence2());
                }

                if (textDisplay.text == sentence2 && Input.GetKeyUp(KeyCode.X))
                {
                    textDisplay.text = "";
                    StartCoroutine(typeSentence3());
                }

                if (textDisplay.text == sentence3 && Input.GetKeyUp(KeyCode.X))
                {
                    sentLenght = 0;
                    StateMachine.state = 1;
                    StateMachine.attackState = 1;
                    panel.SetActive(false);
                }
                break;
            default:
                talking = false;
                textDisplay.text = "";
                displayLifes.SetBool("GoOut", false);
                //LifeDisplay.SetActive(true);
                break;
        }
    }



    void PlayerInteract()
    {
        Collider2D[] Interacting = Physics2D.OverlapCircleAll(InteractablePlayerZone.position, interactRange, interactableStuff);
        foreach (Collider2D stuff in Interacting)
        {
            displayLifes.SetBool("GoOut", true);

            if (stuff.CompareTag("Towns") && talking == false)
            {
                SentencesTownNature.SentencesNPCotro();
            }

            if (stuff.CompareTag("yuca") && talking == false)
            {
                SentencesTownNature.SentencesNPCyuca();
            }

            if (stuff.CompareTag("firstNPC") && talking == false)
            {
                SentencesTownNature.sentencesNPCtom();
            }

            if (stuff.name=="CheckPoint 1" && talking == false)
            {
                //ANIMACION DE DORMIR
                StateMachine.state = 3;
                StateMachine.attackState = 2;
                CheckPoint = "CheckPoint 1";
            }
        }
    }

    IEnumerator SaveCheckPoint()
    {
        //animacion pantalla negra
        yield return new WaitForSeconds(2);
        StateMachine.state = 1;
        StateMachine.attackState = 1;
        //vuelve pantalla normal
    }

    public void Still()
    {
        StateMachine.state = 3;
        StateMachine.attackState = 2;
        Debug.Log("uy quieto");
    }

    IEnumerator typeSentence1()
    {
        foreach (char letter in sentence1.ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSPeed);
        }
    }

    IEnumerator typeSentence2()
    {
        foreach (char letter in sentence2.ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSPeed);
        }
    }

    IEnumerator typeSentence3()
    {
        foreach (char letter in sentence3.ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSPeed);
        }
    }
}
