using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using TMPro;
using Unity.VisualScripting;

public class Inventario : MonoBehaviour
{
    public List<string> itens = new List<string>();

    [Header("Interface(UI)")]

    public GameObject painelInventario;

    public TextMeshProUGUI TextoItem;
    void Start()
    {
        painelInventario.SetActive(false);
        AtualizarTela();
    }
    public bool TemEspadaEquipada()
    {
        return espadaEquipada;
    }
    public bool espadaEquipada = false;

    void Update()
    {
        if (Keyboard.current.iKey.wasPressedThisFrame)
        {
            painelInventario.SetActive(!painelInventario.activeSelf);
        }
    }

    public void AdicionarItem(string nomeDoItem)
    {
        itens.Add(nomeDoItem);
        Debug.Log("Guardou no iventario: " + nomeDoItem);
        AtualizarTela();
    }

    void AtualizarTela()
    {
        if (itens.Count == 0)
        {
            TextoItem.text = "Inventário Vazio";
        }
        else
        {
            TextoItem.text = "";
            foreach (string item in itens)
            {
                TextoItem.text += item + "\n";

            }
        }
    }
}

