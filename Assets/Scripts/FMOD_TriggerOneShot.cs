using UnityEngine;
using FMODUnity;

public class FMODSoundEventTrigger : MonoBehaviour
{
    // This should be the FMOD event path
    public FMODUnity.EventReference oneShot;

    // This method will be called by the animation event
    public void PlayFMODSound()
    {
        // Play the FMOD event as a one-shot sound
        RuntimeManager.PlayOneShot(oneShot);
    }
}
