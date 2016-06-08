// Copyright Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;

public class LODInstanceSunReceiver : MonoBehaviour
{
    public Transform Sun;

    private MeshRenderer currentRenderer;

    private void Awake()
    {
        currentRenderer = GetComponent<MeshRenderer>();
#if UNITY_EDITOR
        // We don't want to change the material in the Editor, but a copy of it.
        currentRenderer.sharedMaterial = new Material(currentRenderer.sharedMaterial);
#endif
    }

    private void Update()
    {
        if (Sun && currentRenderer)
        {
            currentRenderer.sharedMaterial.SetVector("_SunPosition", Sun.position);
        }
    }
}
