using System.Collections;
using UnityEngine;
using TMPro;

public class Inimigo : MonoBehaviour
{
    [Header("Vida")]
    public int vidaMaxima = 100;
    private int vidaAtual;
    public TextMeshPro textoVida;           

    [Header("Movimento")]
    public float velocidade = 2f;
    public float distanciaDeVisao = 8f;      

    [Header("Ataque")]
    public int dano = 10;
    public float distanciaDeAtaque = 1.5f;  
    public float tempoEntreAtaques = 1.5f;

    private Transform jogador;
    private Vida vidaDoJogador;
    private float proximoAtaque = 0f;
    private Renderer[] partes;            

    void Start()
    {
        vidaAtual = vidaMaxima;

        // Acha o jogador pela Tag "Player" 
        GameObject objJogador = GameObject.FindGameObjectWithTag("Player");
        jogador = objJogador.transform;
        vidaDoJogador = objJogador.GetComponent<Vida>();

        partes = GetComponentsInChildren<Renderer>();
        AtualizarTexto();
    }

    void Update()
    {
        float distancia = Vector3.Distance(transform.position, jogador.position);

        if (distancia <= distanciaDeAtaque)
        {
            OlharParaJogador();
            TentarAtacar();
        }
        else if (distancia <= distanciaDeVisao)
        {
            OlharParaJogador();
            Perseguir();
        }
        // Mais longe que a visão: fica parado 
    }

    void OlharParaJogador()
    {
        Vector3 alvo = jogador.position;
        alvo.y = transform.position.y;       // não inclina para cima/baixo 
        transform.LookAt(alvo);
    }

    void Perseguir()
    {
        Vector3 alvo = jogador.position;
        alvo.y = transform.position.y;
        transform.position = Vector3.MoveTowards(transform.position, alvo, velocidade
* Time.deltaTime);
    }

    void TentarAtacar()
    {
        if (Time.time >= proximoAtaque)
        {
            proximoAtaque = Time.time + tempoEntreAtaques;
            vidaDoJogador.TomarDano(dano);
        }
    }

    // Chamado pelo script Ataque e pelo Projetil 
    public void TomarDano(int danoRecebido)
    {
        vidaAtual -= danoRecebido;
        if (vidaAtual < 0) vidaAtual = 0;

        AtualizarTexto();
        StartCoroutine(PiscarVermelho());

        if (vidaAtual == 0)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        Destroy(gameObject);
    }

    IEnumerator PiscarVermelho()
    {
        foreach (Renderer r in partes) r.material.color = Color.red;
        yield return new WaitForSeconds(0.15f);
        foreach (Renderer r in partes) r.material.color = Color.white;
    }

    void AtualizarTexto()
    {
        if (textoVida != null)
        {
            textoVida.text = vidaAtual + " / " + vidaMaxima;
        }
    }

    // Desenha a visão (amarelo) e o alcance de ataque (vermelho) na janela Scene 
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanciaDeVisao);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanciaDeAtaque);
    }
}