using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TrafikLambaKontrol : MonoBehaviour
{
    [SerializeField] private Material[] materyaller = new Material[3];
    [SerializeField] private MeshRenderer Lamp_meshRenderer;
    [SerializeField] private Material black_material;
    private bool isPlay = false;
    void Start()
    {
        Lamp_meshRenderer = gameObject.GetComponent<MeshRenderer>();
        
        if(Lamp_meshRenderer == null )
        {
            Debug.Log("Meshrenderer Bulunamadi");
        }
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S) && !isPlay)
        {
            StartCoroutine(GecisYok(2.0f));

        }
        if(Input.GetKeyDown(KeyCode.W) && !isPlay)
        {
            StartCoroutine(GecisVar(2.0f));
        }
    }
    private void Reset()
    {

        Lamp_meshRenderer.materials[2].color= black_material.color;
        Lamp_meshRenderer.materials[3].color= black_material.color;
        Lamp_meshRenderer.materials[0].color= black_material.color;
        //Debug.Log("resetlendi");
    }
    IEnumerator GecisYok(float sec)
    {
        isPlay = true;
        Reset();
        Lamp_meshRenderer.materials[0].color = materyaller[2].color;
        yield return new WaitForSeconds(sec);
        Reset();
        Lamp_meshRenderer.materials[3].color = materyaller[1].color;
        yield return new WaitForSeconds(sec);
        Reset();
        Lamp_meshRenderer.materials[2].color = materyaller[0].color;
        isPlay= false;

    }
    IEnumerator GecisVar(float sec)
    {
        isPlay = true;
        Reset();
        Lamp_meshRenderer.materials[2].color = materyaller[0].color;
        yield return new WaitForSeconds(sec);
        Reset();
        Lamp_meshRenderer.materials[3].color = materyaller[1].color;
        yield return new WaitForSeconds(sec);
        Reset();
        Lamp_meshRenderer.materials[0].color = materyaller[2].color;
        isPlay = false;


    }

}



