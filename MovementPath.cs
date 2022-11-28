using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPath : MonoBehaviour
{
    public enum PathTypes
    {
        Linear,
        Loop
    }
    public PathTypes PathType;
    public Transform[] PathSequence;

    public void OnDrawGizmos()
    {
        if (PathSequence == null || PathSequence.Length <2 )
        {
            return;
        }
        for(int i = 0; i < PathSequence.Length - 1; i++)
        {
            Gizmos.DrawLine(PathSequence[i].position, PathSequence[i + 1].position);
        }
        if (PathType == PathTypes.Loop)
        {
            Gizmos.DrawLine(PathSequence[0].position, PathSequence[PathSequence.Length-1].position);
        }
    }
}
