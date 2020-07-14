using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogo : MonoBehaviour
{
    public float modificadorVelocidade = 1f;

    public float velocidade = 4.5f;

    public float velocidadeMaxima = 10f;

    private void Update()
    {
        velocidade = Mathf.Clamp(
            velocidade + modificadorVelocidade * Time.deltaTime,
            0,
            velocidadeMaxima
        );
    }
}
