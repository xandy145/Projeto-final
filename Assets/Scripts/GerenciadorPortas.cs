using UnityEngine;



public class GerenciadorPortas : MonoBehaviour
{
    public Porta[] portas; 

    void Start()
    {
        int sorteada = Random.Range(0, portas.Length); 

        for (int i = 0; i < portas.Length; i++)
        {
            portas[i].correta = (i == sorteada);
        }

        Debug.Log("Porta certa: " + (sorteada + 1)); 
    }
}
