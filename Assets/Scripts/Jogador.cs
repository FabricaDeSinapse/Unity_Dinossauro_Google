using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jogador : MonoBehaviour
{
    public Rigidbody2D rb;

    public float forcaPulo = 700;

    public LayerMask layerChao;

    public float distanciaMinimaChao = 1;

    private bool estaNoChao;

    public float pontos;

    private float highscore;

    public float multiplicadorPontos = 1;

    public Text pontosText;

    public Text highscoreText;

    public Animator animatorComponent;

    public AudioSource pularAudioSource;

    public AudioSource cemPontosAudioSource;

    public AudioSource fimDeJogoAudioSource;

    public GameObject reiniciarButton;

    private void Start()
    {
        highscore = PlayerPrefs.GetFloat("HIGHSCORE");
        highscoreText.text = $"HI {Mathf.FloorToInt(highscore)}";
    }

    void Update()
    {
        pontos += Time.deltaTime * multiplicadorPontos;

        var pontosArredondado = Mathf.FloorToInt(pontos);
        pontosText.text = pontosArredondado.ToString();

        if (pontosArredondado > 0
            && pontosArredondado % 100 == 0
            && !cemPontosAudioSource.isPlaying)
        {
            cemPontosAudioSource.Play();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Pular();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Abaixar();
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            Levantar();
        }
    }

    void Pular()
    {
        if (estaNoChao)
        {
            rb.AddForce(Vector2.up * forcaPulo);

            pularAudioSource.Play();
        }
    }

    void Abaixar()
    {
        animatorComponent.SetBool("Abaixado", true);
    }

    void Levantar()
    {
        animatorComponent.SetBool("Abaixado", false);
    }

    private void FixedUpdate()
    {
        estaNoChao = Physics2D.Raycast(transform.position, Vector2.down, distanciaMinimaChao, layerChao);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Inimigo"))
        {
            if (pontos > highscore)
            {
                highscore = pontos;

                PlayerPrefs.SetFloat("HIGHSCORE", highscore);
            }

            fimDeJogoAudioSource.Play();

            reiniciarButton.SetActive(true);

            Time.timeScale = 0;
        }
    }
}
