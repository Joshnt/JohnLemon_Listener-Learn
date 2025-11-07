using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public enum CameraPerspective
{
    firstPerson,
    topDown,
    thirdPerson
}

public enum ListenerPerspective
{
    onCamera,
    onPlayer
}

public enum ListenerRotation
{
    withCamera,
    withPlayer
}

public enum ListenerPerspectiveRotation
{
    onCameraWithCamera,
    onCameraWithPlayer,
    onPlayerWithCamera,
    onPlayerWithPlayer
}

public class CamSwitcher : MonoBehaviour
{
    [Header("Camera")]
    public GameObject FirstPerson;
    public GameObject TopDown;
    public GameObject ThirdPerson;

    public GameObject FirstPersonModell;
    public GameObject TopDownModell;
    public GameObject ThirdPersonModell;

    [Space(10)]

    [SerializeField]
    private CameraPerspective cameraPerspective = CameraPerspective.topDown;
    [SerializeField]
    private ListenerPerspective listenerPerspective = ListenerPerspective.onPlayer;
    [SerializeField]
    private ListenerRotation listenerRotation = ListenerRotation.withCamera;
    private ListenerPerspectiveRotation listenerFull;

    private CameraPerspective previousCameraPerspective = CameraPerspective.topDown;

    [Space(10)]

    [SerializeField]
    private TextMeshProUGUI cameraPerspectiveText;
    [SerializeField]
    private TextMeshProUGUI listenerPerspectiveText;
    [SerializeField]
    private TextMeshProUGUI listenerRotationText;
    [SerializeField]
    private TextMeshProUGUI showListenerText;

    [Header("Listener")]
    [SerializeField]
    private ListenerManager firstPersonListenerManager;
    [SerializeField]
    private ListenerManager topDownListenerManager;
    [SerializeField]
    private ListenerManager thirdPersonListenerManager;
    

    private bool showHeadphones = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FirstPerson.SetActive(false);
        TopDown.SetActive(false);
        ThirdPerson.SetActive(false);
        UpdateCameraPerspective(cameraPerspective);
        UpdateListenerFull();
        ShowHeadphones();
    }

    // Update is called once per frame
    void Update()
    {
        //Get Input command: Shift = Camera
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                UpdateCameraPerspective(CameraPerspective.firstPerson);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                UpdateCameraPerspective(CameraPerspective.topDown);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                UpdateCameraPerspective(CameraPerspective.thirdPerson);
            }
        }
        // Alt = Listener Rotation
        else if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                listenerRotation = ListenerRotation.withCamera;
                
                UpdateListenerFull();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                listenerRotation = ListenerRotation.withPlayer;
                UpdateListenerFull();
            }
        }
        // CTRL = Listener Pos
        else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.Space))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                listenerPerspective = ListenerPerspective.onCamera;
                UpdateListenerFull();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                listenerPerspective = ListenerPerspective.onPlayer;
                UpdateListenerFull();
            }
        }
        // Show Headphones
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            showHeadphones = !showHeadphones;
            ShowHeadphones();
        }
        // Reload Scene
        else if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    #region Camera
    void UpdateCameraPerspective(CameraPerspective cP)
    {
        previousCameraPerspective = cameraPerspective;
        cameraPerspective = cP;

        SetPositionOfNewCamera();

        GetContainerOfCameraPerspective(previousCameraPerspective).SetActive(false);
        GetContainerOfCameraPerspective(cameraPerspective).SetActive(true);

        cameraPerspectiveText.text = GetNameOfCameraPerspective(cameraPerspective);

        UpdateListenerFull();
        ShowHeadphones();
    }

    void SetPositionOfNewCamera()
    {
        GameObject prevCameraModell = GetModellOfCameraPerspective(previousCameraPerspective);
        GameObject newCameraModell = GetModellOfCameraPerspective(cameraPerspective);
        newCameraModell.transform.position = prevCameraModell.transform.position;
    }

    GameObject GetModellOfCameraPerspective(CameraPerspective cP)
    {
        switch (cP)
        {
            case CameraPerspective.firstPerson:
                return FirstPersonModell;
            case CameraPerspective.thirdPerson:
                return ThirdPersonModell;
            default:
                return TopDownModell;
        }
    }

    GameObject GetContainerOfCameraPerspective(CameraPerspective cP)
    {
        switch (cP)
        {
            case CameraPerspective.firstPerson:
                return FirstPerson;
            case CameraPerspective.thirdPerson:
                return ThirdPerson;
            default:
                return TopDown;
        }
    }

    string GetNameOfCameraPerspective(CameraPerspective cP)
    {
        switch (cP)
        {
            case CameraPerspective.firstPerson:
                return "First Person";
            case CameraPerspective.thirdPerson:
                return "Third Person";
            default:
                return "Top Down/ Iso";
        }
    }
    #endregion

    #region Listener
    void UpdateListenerFull()
    {
        if (listenerPerspective == ListenerPerspective.onCamera)
        {
            if (listenerRotation == ListenerRotation.withCamera)
            {
                listenerFull = ListenerPerspectiveRotation.onCameraWithCamera;
            }
            else
            {
                listenerFull = ListenerPerspectiveRotation.onCameraWithPlayer;
            }
        }
        else
        {
            if (listenerRotation == ListenerRotation.withCamera)
            {
                listenerFull = ListenerPerspectiveRotation.onPlayerWithCamera;
            }
            else
            {
                listenerFull = ListenerPerspectiveRotation.onPlayerWithPlayer;
            }
        }

        UpdateListenerMode();
        UpdateListenerText();
    }

    void ShowHeadphones()
    {
        ListenerManager currLM = GetListenerManagerForCameraPerspective(cameraPerspective);
        currLM.SetHeadphonesVisible(showHeadphones, listenerFull);
        showListenerText.text = showHeadphones ? "On" : "Off";
    }

    void UpdateListenerMode()
    {
        ListenerManager currLM = GetListenerManagerForCameraPerspective(cameraPerspective);
        currLM.SetListenerMode(listenerFull);
    }

    ListenerManager GetListenerManagerForCameraPerspective(CameraPerspective cP)
    {
        switch (cameraPerspective)
        {
            case CameraPerspective.firstPerson:
                return firstPersonListenerManager;
            case CameraPerspective.thirdPerson:
                return thirdPersonListenerManager;
            default:
                return topDownListenerManager;
        }
    }

    void UpdateListenerText()
    {
        listenerPerspectiveText.text = GetNameOfListenerPerspective(listenerPerspective);
        listenerRotationText.text = GetNameOfListenerRotation(listenerRotation);
    }


    string GetNameOfListenerPerspective(ListenerPerspective lp)
    {
        switch (lp)
        {
            case ListenerPerspective.onCamera:
                return "On Camera";
            //case ListenerPerspective.onPlayer:
            default:
                return "On Player";
        }
    }
    
    string GetNameOfListenerRotation(ListenerRotation lr)
    {
        switch (lr)
        {
            case ListenerRotation.withCamera:
                return "With Camera";
            //case ListenerPerspective.onPlayer:
            default:
                return "With Player";
        }
    }
    #endregion
}
