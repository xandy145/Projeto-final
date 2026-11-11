using UnityEngine;

public class Arma : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("DISPAROU!");
        }
    }
}