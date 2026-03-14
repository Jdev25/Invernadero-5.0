using UnityEngine;

public class CamaraInvernadero : MonoBehaviour
{
    public Transform[] puntosRuta; // Crea unos GameObjects vacíos como "puntos de control"
    public float velocidad = 2.0f;
    public float suavizado = 0.5f;

    private int puntoActual = 0;

    void Update()
    {
        if (puntosRuta.Length == 0) return;

        // Mover hacia el siguiente punto
        transform.position = Vector3.Lerp(transform.position, puntosRuta[puntoActual].position, Time.deltaTime * velocidad);

        // Rotar suavemente hacia el siguiente punto
        Quaternion targetRotation = Quaternion.LookRotation(puntosRuta[puntoActual].position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * suavizado);

        // Si llegamos cerca del punto, pasamos al siguiente
        if (Vector3.Distance(transform.position, puntosRuta[puntoActual].position) < 0.5f)
        {
            puntoActual = (puntoActual + 1) % puntosRuta.Length;
        }
    }
}