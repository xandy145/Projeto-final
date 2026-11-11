using UnityEngine;
using TMPro;


public class Interacao : MonoBehaviour
{
    public float distancia = 2.5f;        
    public TextMeshProUGUI textoDica;       
    public TextMeshProUGUI textoMensagem;   

    void Update()
    {
        textoDica.text = "";

        Ray raio = new Ray(transform.position, transform.forward);

       
        Debug.DrawRay(raio.origin, raio.direction * distancia, Color.red);

        if (Physics.Raycast(raio, out RaycastHit acerto, distancia))
        {
           
            Porta porta = acerto.collider.GetComponentInParent<Porta>();

            if (porta != null && !porta.aberta)
            {
                textoDica.text = "Aperte E para abrir";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    string mensagem = porta.Interagir();
                    if (mensagem != "")
                    {
                        textoMensagem.text = mensagem;

                    
                        CancelInvoke(nameof(LimparMensagem));
                        if (!porta.correta)
                            Invoke(nameof(LimparMensagem), 2f);
                    }
                }
            }
        }
    }

    void LimparMensagem()
    {
        textoMensagem.text = "";
    }
}
