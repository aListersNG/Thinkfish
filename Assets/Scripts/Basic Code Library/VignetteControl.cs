using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class VignetteControl : MonoBehaviour {
    
    public Material material;
    public float vignette;
    public Transform worldPos;


    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Vector3 screenPos = GetComponent<Camera>().WorldToViewportPoint(worldPos.position);

        material.SetFloat("_VignetteStrength", vignette);
        material.SetFloat("_FocusPointX", screenPos.x);
        material.SetFloat("_FocusPointY", screenPos.y);

        Graphics.Blit(src, dest, material);
    }
}
