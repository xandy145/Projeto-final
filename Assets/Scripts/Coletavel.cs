using UnityEngine;


public class Coletavel : MonoBehaviour
{
    public string nomeDoItem = "Chave";
    public float velocidadeGiro = 90f;

    void Update()
    {
        transform.Rotate(0, velocidadeGiro * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider outro)
    {
        Debug.Log("Encostou em: " + outro.name);
        Inventario inventario = outro.GetComponent<Inventario>();
        if (inventario != null)
        {
            inventario.AdicionarItem(nomeDoItem);
            Destroy(gameObject);
        }
    }
}