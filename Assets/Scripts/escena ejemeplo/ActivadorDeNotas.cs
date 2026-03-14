using UnityEngine;

public class Activador : MonoBehaviour
{
    public GameObject notaVisual;
    public bool activa;

    void Update()
    {
        // Si presionas E y estás cerca (activa es true)
        if (Input.GetKeyDown(KeyCode.E) && activa)
        {
            notaVisual.SetActive(true);
        }

        // Si presionas Escape y estás cerca
        if (Input.GetKeyDown(KeyCode.Escape) && activa)
        {
            notaVisual.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // CompareTag es más eficiente que other.tag ==
        {
            activa = true; // CORREGIDO: Usamos '=' para asignar
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            activa = false; // Desactiva la posibilidad de abrir la nota al salir
            notaVisual.SetActive(false); // Opcional: cierra la nota si se aleja
        }
    }
}       