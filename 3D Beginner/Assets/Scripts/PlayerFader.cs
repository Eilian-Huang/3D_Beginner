using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFader : MonoBehaviour
{
    public float fadeDuration = 1f;

    private Material m_JohnPBR;

    void Awake()
    {
        // m_JohnPBR = transform.gameObject.GetComponent<SkinnedMeshRenderer>().materials[1];
        // m_JohnPBR.SetColor("_Color", Vector4.one);
    }

    private void Update()
    {
        
    }
}