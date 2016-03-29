// Copyright Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Collections;
using UnityEngine;

public class GalaxyCameraSetup : MonoBehaviour
{
    private int oldCameraCulling;
    private Camera targetCamera;

    public bool Ready { get; private set; }

    private IEnumerator Start()
    {
        while (!Camera.main || Camera.main.GetComponent<GalaxyCameraSetup>() != null || !Camera.main.isActiveAndEnabled)
        {
            yield return null;
        }
        
        // TODO figure out why everything falls apart (nothing rendered) if we don't do that ...
        yield return new WaitForSeconds(2);

        Ready = true;

        targetCamera = Camera.main;

        oldCameraCulling = targetCamera.cullingMask;
        targetCamera.cullingMask = 0;
        targetCamera.clearFlags = CameraClearFlags.Depth;
    }

    private void OnDisable()
    {
        if (targetCamera)
        {
            targetCamera.cullingMask = oldCameraCulling;
            targetCamera.clearFlags = CameraClearFlags.SolidColor;
        }
    }
}
