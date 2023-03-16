using UnityEngine;

public class SoundsController : MonoBehaviour
{
    public void ChangeCurrentMusicState(AudioSource audioSource)
    {
        audioSource.mute = !audioSource.mute;
    }
}
