using System.Collections;
using UnityEngine;
public class Ataque : MonoBehaviour
{
    [Header("Ataque")]
    public int dano = 25;
    // quanto de vida o golpe tira 
    public float alcance = 1.5f;
    // distância do golpe à frente do 
   
   public float raioDoGolpe = 1f;
    // tamanho da "área" do golpe 
    public float tempoEntreAtaques = 0.6f;   // evita clicar sem parar 
    [Header("Visual do golpe (opcional)")]
    public Transform espadaNaMao;            // a mesma espada da mão 

    private Inventario inventario;
    private float proximoAtaque = 0f;

    void Start()
    {
        inventario = GetComponent<Inventario>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= proximoAtaque)
        {
            // Sem espada na mão: não faz nada 
            if (!inventario.TemEspadaEquipada()) return;

            proximoAtaque = Time.time + tempoEntreAtaques;
            Atacar();
        }
    }

    void Atacar()
    {
        // Centro do golpe: um pouco à frente e na altura do peito 
        Vector3 centro = transform.position + transform.forward * alcance +
Vector3.up * 1f;

        // Pega TODOS os colliders dentro de uma esfera nesse ponto 
        Collider[] atingidos = Physics.OverlapSphere(centro, raioDoGolpe);

        foreach (Collider c in atingidos)
        {
            Inimigo inimigo = c.GetComponentInParent<Inimigo>();
            if (inimigo != null)
            {
                inimigo.TomarDano(dano);
                break; // um golpe acerta um inimigo só 
            }
        }

        if (espadaNaMao != null)
        {
            StartCoroutine(MovimentoDoGolpe());
        }
    }

    // Faz a espada "balançar" rapidinho 
    IEnumerator MovimentoDoGolpe()
    {
        Quaternion inicial = espadaNaMao.localRotation;
        espadaNaMao.localRotation = inicial * Quaternion.Euler(70, 0, 0);
        yield return new WaitForSeconds(0.15f);
        espadaNaMao.localRotation = inicial;
    }
    // Desenha a área do golpe na janela Scene (esfera vermelha) 
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 centro = transform.position + transform.forward * alcance +
        Vector3.up * 1f;
        Gizmos.DrawWireSphere(centro, raioDoGolpe);
    }
}