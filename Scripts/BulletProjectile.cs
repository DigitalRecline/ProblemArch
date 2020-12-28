using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    [SerializeField] private float _projectileSpeed;
    [SerializeField] private float _disableProjectileAfter = 5f;
    [SerializeField] private Transform _lookAtTarget;
    [SerializeField] private AudioSource _audio;
    private Vector3 shootDir;

    private void OnEnable()
    {
        Invoke("Disable", _disableProjectileAfter);
        _audio.Play();
    }

    private void Update()
    {
        shootDir = (_lookAtTarget.transform.position - transform.position);
        transform.position += shootDir * Time.deltaTime * _projectileSpeed;
    }


    private void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }



}
