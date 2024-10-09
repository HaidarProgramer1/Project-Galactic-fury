using UnityEngine;
using UnityEngine.UI;

public class ExitGameButton : MonoBehaviour
{
    // Ini adalah method yang akan dipanggil saat tombol ditekan
    public void ExitGame()
    {
        // Jika sedang dalam editor Unity, gunakan ini untuk menghentikan mode play
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        // Jika sedang dalam build (game yang di-build), gunakan ini untuk keluar dari game
        Application.Quit();
        #endif
    }
}
