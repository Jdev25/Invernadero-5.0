using UnityEngine;

public class CicloDiaNoche : MonoBehaviour
{
    [Range(0, 24)]
    public float horaDelDia = 12; // Empieza al mediodía
    public float velocidadTiempo = 1f; // Qué tan rápido pasa el día

    public Light sol;
    public Gradient colorDelCielo; // Para cambiar el color del sol según la hora

    void Update()
    {
        // Hacer que el tiempo avance
        horaDelDia += Time.deltaTime * velocidadTiempo;
        if (horaDelDia >= 24) horaDelDia = 0;

        // Rotar el sol (360 grados / 24 horas = 15 grados por hora)
        // Restamos 90 para que a las 12:00 el sol esté arriba
        float rotacionX = (horaDelDia * 15f) - 90f;
        sol.transform.localRotation = Quaternion.Euler(rotacionX, 170f, 0f);

        // Cambiar color del sol (opcional pero recomendado)
        if (colorDelCielo != null)
        {
            sol.color = colorDelCielo.Evaluate(horaDelDia / 24f);
        }

        // Apagar el sol si es de noche para ahorrar procesamiento
        sol.enabled = (horaDelDia > 6 && horaDelDia < 18);
    }
}
