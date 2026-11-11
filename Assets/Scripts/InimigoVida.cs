using UnityEngine;

public class InimigoVida : MonoBehaviour
{
    public int vidaMaxima = 100;
    public int vidaAtual = 100;

    public void TomarDano(int dano)
    {
        vidaAtual -= dano;

        vidaAtual = Mathf.Max(vidaAtual, 0);

        Debug.Log("Vida do inimigo: " + vidaAtual);

        if (vidaAtual <= 0)
        {
            Destroy(gameObject);
        }
    }
}