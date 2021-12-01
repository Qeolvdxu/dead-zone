using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    public UnityEngine.UI.Button playButton, controlsButton, closeControlsButton;
    public UnityEngine.UI.RawImage controls;
    // Start is called before the first frame update
    void Start()
    {
        //Add the listners to detect when you click the menu buttons
        playButton.onClick.AddListener(TaskOnClick);
        controlsButton.onClick.AddListener(TaskOnClickControls);
        closeControlsButton.onClick.AddListener(TaskOnClickCloseControls);

        //Move controls popup and button out of the way by 300 units
        controls.canvasRenderer.transform.position = new Vector3(controls.canvasRenderer.transform.position.x - 300, controls.canvasRenderer.transform.position.y, controls.canvasRenderer.transform.position.z);
        closeControlsButton.GetComponentInChildren<RawImage>().canvasRenderer.transform.position = new Vector3(closeControlsButton.GetComponentInChildren<RawImage>().canvasRenderer.transform.position.x - 300, closeControlsButton.GetComponentInChildren<RawImage>().canvasRenderer.transform.position.y, closeControlsButton.GetComponentInChildren<RawImage>().canvasRenderer.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Play button
    void TaskOnClick()
    {
        LevelHandler.levelHandlerInstance.StartGame();
    }

    //Move controls popup and buttons back into view by the same 300 units
    void TaskOnClickControls()
    {
        controls.canvasRenderer.transform.position = new Vector3(controls.canvasRenderer.transform.position.x + 300, controls.canvasRenderer.transform.position.y, controls.canvasRenderer.transform.position.z);
        
        closeControlsButton.GetComponentInChildren<RawImage>().canvasRenderer.transform.position = new Vector3(closeControlsButton.GetComponentInChildren<RawImage>().canvasRenderer.transform.position.x + 300, closeControlsButton.GetComponentInChildren<RawImage>().canvasRenderer.transform.position.y, closeControlsButton.GetComponentInChildren<RawImage>().canvasRenderer.transform.position.z);
    }

    //Used to close controls by moving it out of the way by 300 units once again
    void TaskOnClickCloseControls()
    {
        controls.canvasRenderer.transform.position = new Vector3(controls.canvasRenderer.transform.position.x - 300, controls.canvasRenderer.transform.position.y, controls.canvasRenderer.transform.position.z);
        
        closeControlsButton.GetComponentInChildren<RawImage>().canvasRenderer.transform.position = new Vector3(closeControlsButton.GetComponentInChildren<RawImage>().canvasRenderer.transform.position.x - 300, closeControlsButton.GetComponentInChildren<RawImage>().canvasRenderer.transform.position.y, closeControlsButton.GetComponentInChildren<RawImage>().canvasRenderer.transform.position.z);
    }
}
