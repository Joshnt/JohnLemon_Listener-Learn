using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public FMODUnity.EventReference gameOver;
    public FMODUnity.EventReference gameWon;

    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;

    bool m_IsPlayerAtExit;
    bool m_IsPlayerCaught;
    float m_Timer;
    bool m_HasAudioPlayed;
    
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    public void CaughtPlayer ()
    {
        m_IsPlayerCaught = true;
    }

    void Update ()
    {
        if (m_IsPlayerAtExit)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("GameState", 2);
            EndLevel (exitBackgroundImageCanvasGroup, false, gameWon);
        }
        else if (m_IsPlayerCaught)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("GameState", 1);
            EndLevel (caughtBackgroundImageCanvasGroup, true, gameOver);
        }
    }

    void EndLevel (CanvasGroup imageCanvasGroup, bool doRestart, FMODUnity.EventReference inputEvent)
    {
        if (!m_HasAudioPlayed)
        {
            FMODUnity.RuntimeManager.PlayOneShot(inputEvent, transform.position);
            m_HasAudioPlayed = true;
        }
            
        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene (0);
            }
            else
            {
                Application.Quit ();
            }
        }
    }
}
