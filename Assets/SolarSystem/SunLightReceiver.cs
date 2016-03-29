// Copyright Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;

public class SunLightReceiver : MonoBehaviour
{
    public Transform Sun;
    private MeshRenderer currentRenderer;

    private void Awake()
    {
        FindSunIfNeeded();

        currentRenderer = gameObject.GetComponent<MeshRenderer>();

#if UNITY_EDITOR
        // We don't want to change the material in the Editor, but a copy of it.
        // currentRenderer.material will make a copy of the material,
        // and we reassign it in currentRenderer.material so that mat and currentRenderer.material are the same instance of a material
        // note that using "Instantiate(currentRenderer.sharedMaterial)" doesn't work
        currentRenderer.material = currentRenderer.material;
#endif
    }

    public bool FindSunIfNeeded()
    {
        if (!Sun)
        {
            var sunGo = GameObject.Find("Sun");
            if (sunGo)
            {
                Sun = sunGo.transform;
                return true;
            }
        }

        return Sun;
    }

    private void LateUpdate()
    {
        if (FindSunIfNeeded())
        {
            Vector3 dir = (Sun.position - transform.position).normalized;
            currentRenderer.sharedMaterial.SetVector("_SunDirection", new Vector4(dir.x, dir.y, dir.z, 0));
        }
    }
}
