using UnityEngine;

public class MageProjectileMover : MonoBehaviour
{
    public float speed = 12f;
    public float lifeTime = 5f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    
    
}
