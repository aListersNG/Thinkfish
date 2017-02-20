using UnityEngine;
using System.Collections;

public class VignetteControl : MonoBehaviour {
    
    public Material material;
    public float vignette;
    public Transform worldPos;

    private void Update()
    {
        if(vignette <= 5.0f)
        {
            vignette += Time.deltaTime;
        }
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Vector3 screenPos = GetComponent<Camera>().WorldToViewportPoint(worldPos.position);

        material.SetFloat("_VignetteStrength", vignette);
        material.SetFloat("_FocusPointX", screenPos.x);
        material.SetFloat("_FocusPointY", screenPos.y);

        Graphics.Blit(src, dest, material);
    }
}
