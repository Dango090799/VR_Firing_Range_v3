using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuGameManager : MonoBehaviour
{
    public enum VRSelectables
    {
        NoVR,
        OculusRift
    }

    [Header("Settings Menu")]
    public GameObject optionsMenuHolder;
    public VRSelectables vrSetting;

    // Start is called before the first frame update
    void Start()
    {
        vrSetting = VRSelectables.NoVR; // default vr off setting
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowSettingsMenu()
    {
        optionsMenuHolder.SetActive(true);
    }

    public void HideSettingsMenu()
    {
        optionsMenuHolder.SetActive(false);
    }

    public void StartGame()
    {
        switch (vrSetting)
        {
            case VRSelectables.NoVR:
                //Load non vr scene
                SceneManager.LoadScene(1);
                break;
            case VRSelectables.OculusRift:
                //Load Oculus VR scene
                Debug.Log("I got into here");
                SceneManager.LoadScene(2);
                break;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void UpdateVRSetting(GameObject dropdown)
    {
        switch (dropdown.GetComponent<Dropdown>().value)
        {
            case 0:
                vrSetting = VRSelectables.NoVR;
                Debug.Log("Successfully selected NoVR");
                break;
            case 1:
                vrSetting = VRSelectables.OculusRift;
                Debug.Log("Successfully selected OculusRift");
                break;
            default:
                Debug.Log("An error has occurred with selecting the VR setting");
                break;
        }
    }
}
