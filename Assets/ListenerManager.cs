using UnityEngine;

public class ListenerManager : MonoBehaviour
{
    [SerializeField]
    GameObject ListenerOnPlayerLockedToCam;
    [SerializeField]
    GameObject HeadphonesOnPlayerLockedToCam;
    [SerializeField]
    bool useCameraRotation;
    [SerializeField]
    GameObject MainCamera;
    [SerializeField]
    bool usePlayerModellPosition;

    [Space(10)]
    [SerializeField]
    GameObject ListenerOnPlayerRotatingWithPlayer;
    [SerializeField]
    GameObject HeadphoneOnPlayerRotatingWithPlayer;
    [Space(30)] 
    [SerializeField]
    GameObject ListenerOnCameraLockedToCam;
    [SerializeField]
    GameObject HeadphonesOnCameraLockedToCam;
    [Space(10)]
    [SerializeField]
    GameObject ListenerOnCameraRotatingWithPlayer;
    [SerializeField]
    GameObject HeadphonesOnCameraRotatingWithPlayer;
    [SerializeField]
    bool usePlayerRotation;
    [SerializeField]
    bool skipForListener = false;
    [SerializeField]
    bool useLocalRotation;
    [SerializeField]
    GameObject PlayerModell;

    private bool headphonesVisible = false;

    void Update()
    {
        if (useCameraRotation && HeadphonesOnPlayerLockedToCam.activeInHierarchy && MainCamera)
        {
            HeadphonesOnPlayerLockedToCam.transform.rotation = MainCamera.transform.rotation;
        }else if(usePlayerModellPosition && HeadphonesOnPlayerLockedToCam.activeInHierarchy && PlayerModell)
        {
            HeadphonesOnPlayerLockedToCam.transform.position = PlayerModell.transform.position;
        }

        if (usePlayerRotation && HeadphonesOnCameraRotatingWithPlayer.activeInHierarchy && PlayerModell)
        {
            if (useLocalRotation)
            {
                HeadphonesOnCameraRotatingWithPlayer.transform.localRotation = PlayerModell.transform.localRotation;
            }
            else
                HeadphonesOnCameraRotatingWithPlayer.transform.rotation = PlayerModell.transform.rotation;
        }
        if (usePlayerRotation && PlayerModell && !skipForListener && ListenerOnCameraRotatingWithPlayer.activeInHierarchy)
        {
            ListenerOnCameraRotatingWithPlayer.transform.rotation = PlayerModell.transform.rotation;
        }
    }

    public void DisableAllListeners()
    {
        ListenerOnPlayerLockedToCam.SetActive(false);
        ListenerOnPlayerRotatingWithPlayer.SetActive(false);
        ListenerOnCameraLockedToCam.SetActive(false);
        ListenerOnCameraRotatingWithPlayer.SetActive(false);
    }

    void DisableAllHeadphones()
    {
        HeadphonesOnPlayerLockedToCam.SetActive(false);
        HeadphoneOnPlayerRotatingWithPlayer.SetActive(false);
        HeadphonesOnCameraLockedToCam.SetActive(false);
        HeadphonesOnCameraRotatingWithPlayer.SetActive(false);
    }

    public void SetListenerMode(ListenerPerspectiveRotation lpr)
    {
        DisableAllListeners();

        SetHeadphonesVisible(headphonesVisible, lpr);

        switch (lpr)
        {
            case ListenerPerspectiveRotation.onCameraWithCamera:
                ListenerOnCameraLockedToCam.SetActive(true);
                break;
            case ListenerPerspectiveRotation.onCameraWithPlayer:
                ListenerOnCameraRotatingWithPlayer.SetActive(true);
                break;
            case ListenerPerspectiveRotation.onPlayerWithCamera:
                ListenerOnPlayerLockedToCam.SetActive(true);
                break;
            case ListenerPerspectiveRotation.onPlayerWithPlayer:
                ListenerOnPlayerRotatingWithPlayer.SetActive(true);
                break;
        }
    }
    
    public void SetHeadphonesVisible(bool SetHeadphonesVisible, ListenerPerspectiveRotation lpr)
    {
        headphonesVisible = SetHeadphonesVisible;
        DisableAllHeadphones();
        if (SetHeadphonesVisible)
        {
            switch (lpr)
            {
                case ListenerPerspectiveRotation.onCameraWithCamera:
                    HeadphonesOnCameraLockedToCam.SetActive(true);
                    break;
                case ListenerPerspectiveRotation.onCameraWithPlayer:
                    HeadphonesOnCameraRotatingWithPlayer.SetActive(true);
                    break;
                case ListenerPerspectiveRotation.onPlayerWithCamera:
                    HeadphonesOnPlayerLockedToCam.SetActive(true);
                    break;
                case ListenerPerspectiveRotation.onPlayerWithPlayer:
                    HeadphoneOnPlayerRotatingWithPlayer.SetActive(true);
                    break;
            }
        }
    }
}
