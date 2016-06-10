// Copyright Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
using UnityEngine;

public class ScrollMaterialTexture : MonoBehaviour
{
    public Vector2 direction;
    public float speed;

    public Material material;
    public string textureName;

    private float currentOffset;

#if UNITY_EDITOR
    private void Awake()
    {
        if (material)
        {
            // We don't want to change the material in the Editor, but a copy of it.
            material = new Material(material);
        }
    }
#endif

    private void Update()
    {
        currentOffset += Time.deltaTime * speed;

        if (material)
        {
            material.SetTextureOffset(textureName, new Vector2((currentOffset * direction.x) % 1.0f, (currentOffset * direction.y) % 1.0f));
        }
    }
}
