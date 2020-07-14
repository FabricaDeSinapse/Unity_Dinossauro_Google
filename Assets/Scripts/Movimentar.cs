using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentar : MonoBehaviour
{
    public Vector2 direcao;

    private Jogo jogoScript;

    private void Start()
    {
        jogoScript = GameObject.Find("Jogo").GetComponent<Jogo>();
    }

    private void Update()
    {
        transform.Translate(direcao * jogoScript.velocidade * Time.deltaTime);
    }
}
