using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

public class FMOD_distancesCheck : MonoBehaviour
{
    GameObject[] Ghosts;
    GameObject[] Gargoyles;

    [field: SerializeField]
    public float minDistanceG { get; set; }
    private float[] DistanceArrayG;
    [field: SerializeField]
    public float minDistanceGa { get; set; }
    private float[] DistanceArrayGa;
    [field: SerializeField]
    public float minDistanceAll { get; set; }

    public Transform Exit;
    void Start()
    {
        Ghosts = GameObject.FindGameObjectsWithTag("Ghost");
        Gargoyles = GameObject.FindGameObjectsWithTag("Gargoyle");

        minDistanceG = 10;
        minDistanceGa = 10;
        minDistanceAll = 10;
        DistanceArrayG = new float[Ghosts.Length];
        DistanceArrayGa = new float[Gargoyles.Length];
        StartCoroutine(DistanceCheck());
        StartCoroutine(ExitCheck());
    }

    IEnumerator DistanceCheck()
    {
        while (true){
            for (int i = 0; i < Ghosts.Length; i++ ){
                DistanceArrayG[i] = Vector3.Distance(Ghosts[i].transform.position, transform.position);
            }
            for (int i = 0; i < Gargoyles.Length; i++ ){
                DistanceArrayGa[i] = Vector3.Distance(Gargoyles[i].transform.position, transform.position);
            }
            minDistanceGa = Math.Clamp(DistanceArrayGa.Min(), 0.0f, 10.0f);
            minDistanceG = Math.Clamp(DistanceArrayG.Min(), 0.0f, 10.0f);
            minDistanceAll = Math.Clamp(Math.Min(minDistanceG, minDistanceGa), 0.0f, 10.0f);
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("DistanceToClosestEnemy", minDistanceAll);
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("DistanceToClosestGhost", minDistanceG);
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("DistanceToClosestGargoyle", minDistanceGa);
            yield return new WaitForSeconds(.1f);
        }
    }

    IEnumerator ExitCheck()
    {   
        while (true){
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("DistanceToExit", Math.Clamp(Vector3.Distance(Exit.position, transform.position), 0.0f, 35.0f));
            yield return new WaitForSeconds(.5f); // slower check for exit
        }
    }
}
