using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFader : MonoBehaviour
{
    private Material m_JohnToon;
    private Material m_JohnPBR;
    private bool m_PlayerFade;

    public enum RenderingMode
    {
        Opaque,
        Cutout,
        Fade,
        Transparent,
    }

    void Awake ()
    {
        // Materials of player
        m_JohnToon = transform.gameObject.GetComponent<SkinnedMeshRenderer>().materials[0];
        m_JohnPBR = transform.gameObject.GetComponent<SkinnedMeshRenderer>().materials[1];
    }

    private void Update()
    {
        // Player fades when fading trigger is true
        if (m_PlayerFade)
        {
            // New shader, no need to change rendering mode
            // SetMaterialRenderingMode(m_JohnToon, RenderingMode.Fade);
            // SetMaterialRenderingMode(m_JohnPBR, RenderingMode.Fade);
            // Using coroutines to fade
            StartCoroutine(Fade());
            m_PlayerFade = false;
        }
    }

    IEnumerator Fade()
    {
        // Slowly reduce alpha to zero
        for (int m_Fader = 255; m_Fader >= 0; m_Fader--)
        {
            m_JohnToon.SetColor("_Color", new Color32(192, 186, 186, (byte)m_Fader));
            m_JohnPBR.SetColor("_Color", new Color32(255, 255, 255, (byte)m_Fader));
            yield return null;
        }
    }

    public void PlayerFade ()
    {
        m_PlayerFade = true;
    }

    // Recover player's rendering mode and alpha
    public void PlayerRecover ()
    {
        // SetMaterialRenderingMode(m_JohnToon, RenderingMode.Opaque);
        // SetMaterialRenderingMode(m_JohnPBR, RenderingMode.Opaque);
        m_JohnToon.SetColor("_Color", new Color32(192, 186, 186, 255));
        m_JohnPBR.SetColor("_Color", new Color32(255, 255, 255, 255));
    }

    /*
     * New shader, no need to change rendering mode
     * 
    public static void SetMaterialRenderingMode (Material material, RenderingMode renderingMode)
    {
        switch (renderingMode)
        {
            case RenderingMode.Opaque:
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                material.SetInt("_ZWrite", 1);
                material.DisableKeyword("_ALPHATEST_ON");
                material.DisableKeyword("_ALPHABLEND_ON");
                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = -1;
                break;
            case RenderingMode.Cutout:
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                material.SetInt("_ZWrite", 1);
                material.EnableKeyword("_ALPHATEST_ON");
                material.DisableKeyword("_ALPHABLEND_ON");
                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = 2450;
                break;
            case RenderingMode.Fade:
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                material.SetInt("_ZWrite", 0);
                material.DisableKeyword("_ALPHATEST_ON");
                material.EnableKeyword("_ALPHABLEND_ON");
                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = 3000;
                break;
            case RenderingMode.Transparent:
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                material.SetInt("_ZWrite", 0);
                material.DisableKeyword("_ALPHATEST_ON");
                material.DisableKeyword("_ALPHABLEND_ON");
                material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = 3000;
                break;
        }
    }
    */
}