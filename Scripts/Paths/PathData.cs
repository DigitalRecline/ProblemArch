using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RailShooter/Path Data")]

public class PathData : ScriptableObject
{
    public List<GameObject> BezierCurve;
}
