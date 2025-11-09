using Unity.Netcode;
using UnityEngine;

//public class PlayerMovement : MonoBehaviour
public class PlayerMovement : NetworkBehaviour
{
    Rigidbody2D rb;
    float moverHorizontal, moverVertical;
    float moverSpeed;
    Vector2 movimiento;
    void Start()
    {
        moverSpeed = 10;
        rb = GetComponent<Rigidbody2D>();
    }

   
    void Update() 
    {
        if (!IsOwner) return; //Si no es el dueño/pcServer return
        moveFuncion();
      
    }

    void moveFuncion()
    {
        //Movimiento Player
        moverHorizontal = Input.GetAxis("Horizontal");
        moverVertical = Input.GetAxis("Vertical");

        movimiento = new Vector2(moverHorizontal, moverVertical).normalized;
        rb.linearVelocity = movimiento * moverSpeed;
    }

}
