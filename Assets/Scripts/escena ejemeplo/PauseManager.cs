using UnityEngine;
using UnityEngine.UI; // Necesario para controlar el Slider

[System.Serializable]
public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    public Slider volumeSlider;
    public AudioSource musicSource;
    private bool isPaused = false;

    void Start()
    {
        // Valor preestablecido del volumen (ej. 0.5f o 50%)
        volumeSlider.value = 0.5f;
        musicSource.volume = volumeSlider.value;
        pausePanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Presiona ESC para pausar
        {
            isPaused = !isPaused;
            PauseGame();
        }
    }

    void PauseGame()
    {
        pausePanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f; // Pausa el motor de físicas
        Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isPaused;
    }

    public void OnVolumeChange(float value)
    {
        musicSource.volume = value; // Controla el volumen en tiempo real
    }
}