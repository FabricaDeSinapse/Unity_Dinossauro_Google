using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorInimigos : MonoBehaviour
{
    public GameObject[] cactoPrefabs;

    public GameObject dinossauroVoadorPrefab;

    public float dinossauroVoadorYMinimo = -1;

    public float dinossauroVoadorYMaximo = 1;

    public float dinossauroVoadorPontuacaoMinima = 300;

    public float delayInicial;

    public float delayEntreCactos;

    public Jogador jogadorScript;

    private void Start()
    {
        InvokeRepeating("GerarInimigo", delayInicial, delayEntreCactos);
    }

    private void GerarInimigo()
    {
        var dado = Random.Range(1, 7);

        if (jogadorScript.pontos >= dinossauroVoadorPontuacaoMinima && dado <= 2)
        {
            // Gerar Dinossauro Voador
            var posicaoYAleatoria = Random.Range(dinossauroVoadorYMinimo, dinossauroVoadorYMaximo);

            var posicao = new Vector3(
                transform.position.x,
                transform.position.y + posicaoYAleatoria,
                transform.position.z
            );

            Instantiate(dinossauroVoadorPrefab, posicao, Quaternion.identity);
        }
        else
        {
            // Gerar Cacto
            var quantidadeCactos = cactoPrefabs.Length;
            var indiceAleatorio = Random.Range(0, quantidadeCactos);
            var cactoPrefab = cactoPrefabs[indiceAleatorio];
            Instantiate(cactoPrefab, transform.position, Quaternion.identity);
        }
    }
}
