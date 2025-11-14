using UnityEngine;

public class scr_Proyectile : MonoBehaviour
{


    void Start()
    {
        
    }
    public override void  onNerworkSpawn(){

    
    base.OnNetworkSpawn();
    gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.up;
    }

    void Update()
    {
        
    }
}
