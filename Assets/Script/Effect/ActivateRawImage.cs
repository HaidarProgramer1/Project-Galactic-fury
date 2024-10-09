using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ActivateRawImage : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;

    private void Start()
    {
        // Menonaktifkan RawImage pada awalnya
        rawImage.enabled = false;
        
        // Menonaktifkan VideoPlayer pada awalnya
        videoPlayer.enabled = false;

        // Menambahkan event listener untuk mendeteksi akhir video
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            // Mengaktifkan RawImage dan VideoPlayer ketika Player memasuki collider
            rawImage.enabled = true;
            videoPlayer.enabled = true;
            
            // Memulai pemutaran video
            videoPlayer.Play();
        }
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        // Menonaktifkan RawImage dan VideoPlayer setelah video selesai diputar
        rawImage.enabled = false;
        videoPlayer.enabled = false;
    }
}
