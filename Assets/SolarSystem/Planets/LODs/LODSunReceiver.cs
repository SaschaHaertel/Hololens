// Copyright Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;

public class LODSunReceiver : MonoBehaviour
{
    public Transform Sun;
    public Material planetLod;

#if UNITY_EDITOR
    private void Awake()
    {
        if (planetLod)
        {
            // We don't want to change the material in the Editor, but a copy of it.
            planetLod = new Material(planetLod);
        }
    }
#endif

    private void Update()
    {
        if (Sun)
        {
            planetLod.SetVector("_SunPosition", Sun.position);
        }
    }
}
