using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void ReiniciarJogo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Time.timeScale = 1;
    }
}
