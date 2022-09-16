using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Input;

public class PlatformPlacer : MonoBehaviour
{
    GameObject indexFinger;
    MixedRealityPose pose;

    public GameObject platformPrefab;
    public GameObject previewPrefab;
    GameObject preview;
    GameObject platform;
    public float cooldown = 2.5f;
    float currentCD = 0f;
    bool cooledDown = true;

    void Start()
    {
        indexFinger = new GameObject();
        preview = Instantiate(previewPrefab, indexFinger.transform.position, indexFinger.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        cooledDown = Time.time - currentCD > cooldown;
        Debug.Log(currentCD);
        if(HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out pose)){
            indexFinger.transform.position = pose.Position;
            indexFinger.transform.rotation = pose.Rotation;
        }
        preview.transform.position = indexFinger.transform.position;

        if(HandPoseUtils.CalculateIndexPinch(Handedness.Right) > 0.8f && HandPoseUtils.CalculateIndexPinch(Handedness.Right) < 1f)
        {
            if (cooledDown)
            {
                //Get the orientation of the controller
                platform = Instantiate(platformPrefab, indexFinger.transform.position, indexFinger.transform.rotation);
                platform.transform.position = indexFinger.transform.position;
                platform.transform.rotation = indexFinger.transform.rotation;
                currentCD = Time.time;

            }
        }

        
    }

    
}

    
