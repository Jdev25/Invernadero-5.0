using UnityEngine;

public class RayVisualizer : MonoBehaviour
{
    public float distance = 10f;
    public Color rayColor = Color.red;

    void Update()
    {
        // Esto dibuja una línea en la ventana "Scene" pero no en el "Game"
        Debug.DrawRay(transform.position, transform.forward * distance, rayColor);
    }
}