using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    [SerializeField] float _deathTime;
    [SerializeField] float _speed;
    private void OnEnable()
    {
        Destroy(gameObject,_deathTime);
        _rb.AddForce((transform.position + Vector3.forward)*Time.deltaTime*_speed,ForceMode.Impulse);
    }
}
