using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class CheckBoxColliderCollision : MonoBehaviour
{
    public string CollisionTag { get; private set; }

    public string LastCollisionTag{ get; private set; }

    public LayerMask CollisionLayer;//{ get; private set; }

    public LayerMask LastCollisionLayer{ get; private set; }

    public Transform HitTransform{ get; private set; }

    void Start()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<BoxCollider>().isTrigger = true;
    }

    void OnTriggerEnter(Collider other)
    {
        CollisionTag = other.gameObject.name;
        CollisionLayer = 1 << other.gameObject.layer;
        HitTransform = other.transform;
    }

    void OnTriggerStay(Collider other)
    {
        CollisionTag = other.gameObject.name;
        CollisionLayer = 1 << other.gameObject.layer;
        HitTransform = other.transform;
    }

    void OnTriggerExit(Collider other)
    {
        LastCollisionTag = CollisionTag;
        LastCollisionLayer = CollisionLayer;

        CollisionTag = string.Empty;
        CollisionLayer = 0;
        HitTransform = null; 
    }   

    public bool IsColliding(LayerMask layer)
    {       
        return (CollisionLayer.value & layer) > 0;
    }

    public bool IsColliding(string tag)
    {
        return CollisionTag == tag;
    }

}
