using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void AbrirJuego()
    {
        SceneManager.LoadScene("Aguado Asier_ZAXXON");
    }

    public void VolverMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void SalirJuego()
    {
        Application.Quit();
    }
}