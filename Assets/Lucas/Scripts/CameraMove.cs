using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera cameraMove;
    public Camera mainCamera;

    public float waitTime;

    public MonoBehaviour[] scriptsToDisable;

    private void Update() // pour skip la CS
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            SwitchCamera();

            foreach (var script in scriptsToDisable)
            {
                script.enabled = true;
            }
        }
    }

    private void SwitchCamera()
    {
        cameraMove.gameObject.SetActive(false);

        mainCamera.gameObject.SetActive(true);
    }

    private void Start() // sinon on attend juste
    {
        foreach (var script in scriptsToDisable)
        {
            script.enabled = false;
        }

        StartCoroutine(WaitCamera());
    }

    public IEnumerator WaitCamera()
    {
        mainCamera.gameObject.SetActive(false);

        // Temps de pause
        yield return new WaitForSeconds(waitTime);


        cameraMove.gameObject.SetActive(false);

        mainCamera.gameObject.SetActive(true);

        foreach (var script in scriptsToDisable)
        {
            script.enabled = true;
        }


    }

}