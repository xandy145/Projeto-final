using UnityEngine;

public class Vida : MonoBehaviour
{
    public float vidaMaxima = 100f;
    public float vidaAtual;
    public float VidaAtual => vidaAtual;
    public float VidaMaxima => vidaMaxima;
    void Start()
    {
        vidaAtual = vidaMaxima;
    }

    public void ReceberDano(float dano)
    {
        vidaAtual -= dano;
        vidaAtual = Mathf.Clamp(vidaAtual, 0, vidaMaxima);

        if (vidaAtual <= 0)
        {
            Debug.Log("Jogador morreu!");
        }
    }
    public void TomarDano(int danoRecebido)
    {
        vidaAtual -= danoRecebido;

        if (vidaAtual < 0)
            vidaAtual = 0;

    }
}