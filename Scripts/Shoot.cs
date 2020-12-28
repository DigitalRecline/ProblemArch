using UnityEngine;
using TigerForge;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform _firePosition;
  

    public float fireDelta = 0.5F;
    private float currentFireTime;
    private void Awake()
    {
        EventManager.StartListening("SHOOT", ShootProjectile);
    }

    private void Start()
    {
        currentFireTime = fireDelta;
    }

    private void Update()
    { 
        currentFireTime -= Time.deltaTime;
    }

    private void ShootProjectile()
    {
        GameObject obj = ObjectPooler.PalyerProjectilePooler.GetPooledObject();
      
        if (obj != null && currentFireTime < 0)
        {
            obj.transform.position = _firePosition.position;
            obj.transform.rotation = _firePosition.rotation;
            obj.SetActive(true);

            currentFireTime = fireDelta;


            //SOUNDS
        }

    }
}
