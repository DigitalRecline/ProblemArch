using System.Collections.Generic;
using UnityEngine;

public class BezierCalculations
{
    public Vector3 P0;
    public Vector3 P1;
    public Vector3 P2;
    public Vector3 P3;

    public Vector3 PositionOnCurve(float tparam, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        Vector3 position;
        //Brezier maths equation where tParam is distance along the curve from  start (0) to End (1);
        position = Mathf.Pow(1 - tparam, 3) * p0 +
                            3 * Mathf.Pow(1 - tparam, 2) * tparam * p1 +
                            3 * (1 - tparam) * Mathf.Pow(tparam, 2) * p2 +
                            Mathf.Pow(tparam, 3) * p3;

        return position;
    }
    public void PointsDefiningBezierCurve(List<GameObject> path, int index)
    {
            P0 = path[index].transform.GetChild(0).position;
            P1 = path[index].transform.GetChild(1).position;
            P2 = path[index].transform.GetChild(2).position;
            P3 = path[index].transform.GetChild(3).position;
    }
}
