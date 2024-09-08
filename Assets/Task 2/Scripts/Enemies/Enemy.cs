using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private float _speed;
    public virtual void Initialize(float speed)
    {
        _speed = speed;
    }
    private void Update()
    {
        transform.Translate(Vector3.forward* Time.deltaTime * _speed);
    }
}
