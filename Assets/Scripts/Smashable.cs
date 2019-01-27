using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smashable : MonoBehaviour
{
    public SmashableData data;

    Vector3 _startScale;
    Vector3 _startPosition;
    Vector3 _minPosition;
    int hitsTaken = 0;
    int chunksBroken = 0;

    ParticleSystem dust;

    // Start is called before the first frame update
    void Start()
    {
        _startScale = transform.localScale;
        _startPosition = transform.localPosition;
        _minPosition = _startPosition - (data.height * transform.up);
        dust = GetComponent<ParticleSystem>();
    }

    public Transform Smash(int power)
    {
        if (chunksBroken >= data.ChunksPerLife)
            return null;

        hitsTaken += power;
        Transform reward = null;

        while (hitsTaken >= data.HitsPerChunk)
        {
            if (dust)
                dust.Play();

            chunksBroken++;
            hitsTaken -= data.ChunksPerLife;
            transform.localScale = _startScale * (data.ChunksPerLife - chunksBroken) / data.ChunksPerLife;
            if (data.loot.Length > 0)
            {
                reward = data.loot[chunksBroken % data.loot.Length];
            }

            if (chunksBroken >= data.ChunksPerLife)
            {
                StartCoroutine(Regrow());
                break;
            }
        }

        return reward;
    }

    private IEnumerator Regrow()
    {
        var collider = GetComponent<Collider>();

        //Sleep
        yield return new WaitForSeconds(data.GrowthDelay);

        //Regrow the mountain
        float t = 0f;
        while (t < data.GrowthTime)
        {
            transform.localScale = Vector3.Lerp(Vector3.zero, _startScale, t / data.GrowthTime);
            t += Time.deltaTime;
            yield return null;
        }

        //Enable the collider
        hitsTaken = 0;
        chunksBroken = 0;
    }
}
