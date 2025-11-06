using UnityEngine;
using System.Collections;

public class FMOD_SetSoundset : MonoBehaviour
{
    private bool showLabel = false;
    private float alpha = 1f;
    private string labelText = "";
    void Update()
    {
        for (int i = 0; i <= 9; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Soundset", i);
                ShowLabel("Soundset " + i);
            }
        }
    }

    void OnGUI()
    {
        if (showLabel)
        {
            GUI.color = new Color(1, 1, 1, alpha); // Set label transparency
            GUI.Label(new Rect(10, 10, 300, 20), labelText);
            GUI.color = Color.white; // Reset color
        }
    }

    public void ShowLabel(string text)
    {
        labelText = text;
        showLabel = true;
        alpha = 1f;
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(1.5f); // Wait before fading

        float startTime = Time.time;
        while (Time.time < startTime + 1f)
        {
            alpha = Mathf.Lerp(1f, 0f, (Time.time - startTime) / 1f);
            yield return null;
        }

        alpha = 0f;
        showLabel = false;
    }
}
