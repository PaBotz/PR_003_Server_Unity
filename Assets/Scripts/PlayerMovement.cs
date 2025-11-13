using Unity.Netcode;
using UnityEngine;

//public class PlayerMovement : MonoBehaviour
public class PlayerMovement : NetworkBehaviour
{
    Rigidbody2D rb;
    float moverHorizontal, moverVertical;
    float moverSpeed;
    Vector2 movimiento;

    
    [SerializeField]
    NetworkVariable<int> health = new NetworkVariable<int>(
        3,
        NetworkVariableReadPermission.Everyone,
        NetworkVariableWritePermission.Owner
    );




    void Start()
    {
        moverSpeed = 10;
        rb = GetComponent<Rigidbody2D>();
    }

   
    void Update() 
    {
        if (!IsOwner) return; //Si no es el duenyo/pcServer return
        moveFuncion();
      
    }

    void moveFuncion()
    {
        //Movimiento Player
        moverHorizontal = Input.GetAxisRaw("Horizontal");
        moverVertical = Input.GetAxisRaw("Vertical");

        movimiento = new Vector2(moverHorizontal, moverVertical).normalized; //Direccion.Normalize() (En profe script)
        rb.linearVelocity = movimiento * moverSpeed; 
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        health.Value -= 1;
    }




}
