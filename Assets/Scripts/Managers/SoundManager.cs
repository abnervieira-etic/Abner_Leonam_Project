using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip TungTungSound;
    [SerializeField] private AudioClip TralaleloSound;
    [SerializeField] private AudioSource audioSource;
    public float duration = 5; 
    public void PlayTungTungSound()
    {
        if (audioSource.isPlaying) return;
        {
            audioSource.PlayOneShot(TungTungSound);
            Invoke(nameof(StopSound), duration);
        }
        
    }

    public void PlayTralaleloSound()
    {
        if (audioSource.isPlaying) return;
        {
            audioSource.PlayOneShot(TralaleloSound);
            Invoke(nameof(StopSound), duration);
        }
    }

    private void StopSound()
    {
        audioSource.Stop();
    }
}
