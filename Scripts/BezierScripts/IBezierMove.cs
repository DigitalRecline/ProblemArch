using UnityEngine;
using TigerForge;

public class IBezierMove : MonoBehaviour, IMove
{
    public SOFloat CurrentTParam;
    public bool isEnemy;
    private void Awake()
    {
        EventManager.StartListening("BEZIER_MOVEMENT", PlayerTParamChange);
        EventManager.StartListening("BEZIER_STARTING_POSITION", SetupGameObject);
    }

    private void Update()
    {
        if (isEnemy)
        {
            MoveEnemy();
        }
    }

    private void MoveEnemy()
    {
        EventManager.SetData("BEZIER_MOVE", gameObject);
        EventManager.EmitEvent("BEZIER_MOVE");
    }

    public void SetupGameObject()
    {
        float startingposition = EventManager.GetFloat("BEZIER_STARTING_POSITION");
        CurrentTParam.SOFloatValue = startingposition;
        Move();
    }

    public void PlayerTParamChange()
    {
        var eventData = EventManager.GetDataGroup("BEZIER_MOVEMENT");
        var horizontalAxis = eventData[0].ToFloat();
        var speedmodifier = eventData[1].ToFloat();

        if (horizontalAxis < 0f)
        {
            CurrentTParam.SOFloatValue -= Time.deltaTime * speedmodifier;
        }
        else if (horizontalAxis > 0f)
        {
            CurrentTParam.SOFloatValue += Time.deltaTime * speedmodifier;
        }
        Move();
    }

    public void Move()
    {
        EventManager.SetData("BEZIER_MOVE", gameObject);
        EventManager.EmitEvent("BEZIER_MOVE");
    }
}
