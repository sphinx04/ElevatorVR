using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class CustomActions : MonoBehaviour
{
    public SteamVR_ActionSet m_ActionSet;
    public SteamVR_Action_Boolean menuClick;
    public SteamVR_Action_Boolean turnLeft;
    public SteamVR_Action_Boolean turnRight;
    public GameObject ui;
    public GameObject teleportingArea;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        m_ActionSet.Activate(SteamVR_Input_Sources.Any, 0, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (menuClick.GetStateDown(SteamVR_Input_Sources.Any))
        {
            if (ui.activeSelf == false)
            {
                ui.SetActive(true);
                Time.timeScale = 0.1f;
                teleportingArea.SetActive(false);
            }
            else
            {
                ui.SetActive(false);
                Time.timeScale = 1f;
                teleportingArea.SetActive(true);
            }
        }
        if (turnLeft.GetLastStateDown(SteamVR_Input_Sources.Any))
        {
            player.transform.Rotate(Vector3.up * 2000 * Time.deltaTime);
        }
        if (turnRight.GetLastStateDown(SteamVR_Input_Sources.Any))
        {
            player.transform.Rotate(Vector3.down * 2000 * Time.deltaTime);
        }
    }
}
