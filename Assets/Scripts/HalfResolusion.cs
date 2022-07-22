using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class HalfResolusion : ScriptableObject
{
    [SerializeField, Range(0.1f, 1f)] float rate = 0.25f;
    void OnEnable()
    {
#if UNITY_EDITOR
        if (UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode == false) {return; }
#endif
        Screen.SetResolution((int)(Screen.width*rate),(int)(Screen.height*rate),true);

    }
}
