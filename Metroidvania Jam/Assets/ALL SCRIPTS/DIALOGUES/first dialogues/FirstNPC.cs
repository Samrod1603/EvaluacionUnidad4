using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstNPC : MonoBehaviour
{
    Interact scriptInteract;
    public GameObject Player;
    private GameObject panel;

    private void Start()
    {
        scriptInteract =GameObject.Find("PLAYER").GetComponent<Interact>();
        panel = GameObject.Find("Panel");
        panel.SetActive(false);
    }

    public void sentencesNPCtom()
    {
        panel.SetActive(true);
        scriptInteract.sentence1 = "menyuca";
        scriptInteract.sentence2 = "Impactrueno";
        scriptInteract.sentence3 = "cortauñas como arma letal contra dragones";
        scriptInteract.sentLenght = 3;
        scriptInteract.beInSentence1 = true;
        scriptInteract.talking = true;
        scriptInteract.Still();
    }

    public void SentencesNPCyuca()
    {
        panel.SetActive(true);
        scriptInteract.sentence1 = "maracuya";
        scriptInteract.sentence2 = "pikachu";
        scriptInteract.sentLenght = 2;
        scriptInteract.beInSentence1 = true;
        scriptInteract.talking = true;
        scriptInteract.Still();
    }

    public void SentencesNPCotro()
    {
        panel.SetActive(true);
        scriptInteract.sentence1 = "menguanabana";
        scriptInteract.sentLenght = 1;
        scriptInteract.beInSentence1 = true;
        scriptInteract.talking = true;
        scriptInteract.Still();
    }
}
