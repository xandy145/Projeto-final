using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    public Image barraVida;
    public Vida sistemaDeVida;

    void Update()
    {
        barraVida.fillAmount =
            sistemaDeVida.VidaAtual /
            sistemaDeVida.VidaMaxima;
    }
}