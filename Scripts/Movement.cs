using UnityEngine;
using TigerForge;


public class Movement : MonoBehaviour
{

    [SerializeField] private float _playerSpeed;
    [SerializeField] private float _bezierCurveStartingPosition;

    void Awake()
    {
        EventManager.StartListening("HORIZONTAL_MOVEMENT", Move);
      
    }

    private void Update()
    {
        
    }

    void Start()
    {
        EventManager.SetData("BEZIER_STARTING_POSITION", _bezierCurveStartingPosition);
        EventManager.EmitEvent("BEZIER_STARTING_POSITION");
    }

    private void Move()
    {
        var eventData = EventManager.GetDataGroup("HORIZONTAL_MOVEMENT");
        EventManager.SetDataGroup("BEZIER_MOVEMENT", eventData[0].ToFloat(), _playerSpeed);
        EventManager.EmitEvent("BEZIER_MOVEMENT");
    }
}
