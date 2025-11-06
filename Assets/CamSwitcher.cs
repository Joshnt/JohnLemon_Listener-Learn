using TMPro;
using UnityEngine;
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
    withPlayer,
    locked
}

public class CamSwitcher : MonoBehaviour
{
    public GameObject FirstPerson;
    public GameObject TopDown;
    public GameObject ThirdPerson;

    public GameObject FirstPersonModell;
    public GameObject TopDownModell;
    public GameObject ThirdPersonModell;

    [SerializeField]
    private CameraPerspective cameraPerspective = CameraPerspective.topDown;
    [SerializeField]
    private ListenerPerspective listenerPerspective = ListenerPerspective.onPlayer;
    [SerializeField]
    private ListenerRotation listenerRotation = ListenerRotation.withCamera;

    private CameraPerspective previousCameraPerspective = CameraPerspective.topDown;

    [SerializeField]
    private TextMeshProUGUI cameraPerspectiveText;
    [SerializeField]
    private TextMeshProUGUI listenerPerspectiveText;
    [SerializeField]
    private TextMeshProUGUI listenerRotationText;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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

            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {

            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                
            }
        }
        // CTRL = Listener Pos
        else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {

            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {

            }
        }
    }
    
    void UpdateCameraPerspective(CameraPerspective cP)
    {
        previousCameraPerspective = cameraPerspective;
        cameraPerspective = cP;

        SetPositionOfNewCamera();

        GetContainerOfCameraPerspective(previousCameraPerspective).SetActive(false);
        GetContainerOfCameraPerspective(cameraPerspective).SetActive(true);

        cameraPerspectiveText.text = GetNameOfCameraPerspective(cameraPerspective);
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
}
