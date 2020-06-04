using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPontuacao : MonoBehaviour
{
    private Player playerScript;
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = (Player) FindObjectOfType(typeof(Player));
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = playerScript.pontuacao.GetCoins().ToString();
    }
}
