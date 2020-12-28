using UnityEngine;
using TigerForge;

public class BezierPathPosition : MonoBehaviour
{
    [SerializeField] private PathData _pathData;
    [SerializeField] private SOInt _routeIndex;
    [SerializeField] private SOFloat _currentTParam;

    [SerializeField] private bool _isPathALoop;

    private BezierCalculations _bezierCalc;
    private readonly float _endOfBezierCurve = 1f;
    private readonly float _startOfBezierCurve = 0f;
    private int _numberOfCurvesInList;

    private void Awake()
    {
        EventManager.StartListening("BEZIER_MOVE", BezierMove);
        _bezierCalc = new BezierCalculations();
        _routeIndex.CurrentIntValue = 0;
        _numberOfCurvesInList = _pathData.BezierCurve.Count - 1; // to match with routeIndexNumbers
        _bezierCalc.PointsDefiningBezierCurve(_pathData.BezierCurve, _routeIndex.CurrentIntValue);

    }

    private void Start()
    {
        _bezierCalc = new BezierCalculations();
        _routeIndex.CurrentIntValue = 0;
        _numberOfCurvesInList = _pathData.BezierCurve.Count - 1; // to match with routeIndexNumbers
        _bezierCalc.PointsDefiningBezierCurve(_pathData.BezierCurve, _routeIndex.CurrentIntValue);
    }

    private void Update()
    {
        DoINeedToChangeCurve();
    }

    private void DoINeedToChangeCurve()
    {
       
        if (_currentTParam.SOFloatValue < _startOfBezierCurve)
        {
            ChangeCurveDown();
        }

        if (_currentTParam.SOFloatValue > _endOfBezierCurve)
        {
            ChangeCurveUp();
        }

    }

    private void ChangeCurveUp()
    {
        //All the way right in base bezier curve and there are more avalibe
        if (_routeIndex.CurrentIntValue != _numberOfCurvesInList)
        {
            _routeIndex.CurrentIntValue++;
            _currentTParam.SOFloatValue = 0;
        }else if (_routeIndex.CurrentIntValue == _numberOfCurvesInList && !_isPathALoop)  //We Are on the last curve
        {
            _currentTParam.SOFloatValue = 1; // set to the end of the new curve
        }
        else
        { //loops back to first curve
            _routeIndex.CurrentIntValue = 0;
            _currentTParam.SOFloatValue = 0;
        }
    }

    private void ChangeCurveDown()
    {
        if (_numberOfCurvesInList >= 1 && _routeIndex.CurrentIntValue != 0)
        {
            _routeIndex.CurrentIntValue--; 
            _currentTParam.SOFloatValue = _endOfBezierCurve; 
        }
        else if (_routeIndex.CurrentIntValue == 0 && !_isPathALoop) 
        {
            _currentTParam.SOFloatValue = _startOfBezierCurve;
        }
        else
        {
            _routeIndex.CurrentIntValue = _numberOfCurvesInList;
            _currentTParam.SOFloatValue = 1;
        }
    }

    public void BezierMove()
    {

        GameObject goPlayer = EventManager.GetGameObject("BEZIER_MOVE");
        if (goPlayer != null)
        {
            _bezierCalc.PointsDefiningBezierCurve(_pathData.BezierCurve, _routeIndex.CurrentIntValue);
            goPlayer.transform.position = _bezierCalc.PositionOnCurve(_currentTParam.SOFloatValue, _bezierCalc.P0, _bezierCalc.P1, _bezierCalc.P2, _bezierCalc.P3);
        }
    }
}

