using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEffect : MonoBehaviour {

    public float spawnEffectTime = 2;
    public float pause = 1;
    public AnimationCurve fadeIn;

    public ParticleSystem ps;
    float timer = 0;
    public Renderer _renderer;

    int shaderProperty;

	 void Start ()
    {
        shaderProperty = Shader.PropertyToID("_cutoff");
       

        var main = ps.main;
        main.duration = spawnEffectTime;

        ps.Play();

    }

    public void Update ()
    {
        if (timer < spawnEffectTime + pause)
        {
            timer += Time.deltaTime;
        }
        else
        {
            ps.Play();
            timer = 0;
        }


        _renderer.material.SetFloat(shaderProperty, fadeIn.Evaluate( Mathf.InverseLerp(0, spawnEffectTime, timer)));
        
    }
}
