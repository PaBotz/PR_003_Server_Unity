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
        [SerializeField]
    NetworkVariable<int> puntos = new NetworkVariable<int>(
        0,
        NetworkVariableReadPermission.Everyone,
        NetworkVariableWritePermission.Owner
    );

    [SerializeField] GameObject prefabProyectile;

   


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

        //Lanzar Proyectile

        if(Input.GetKeyDown(KeyCode.Space))
        GameObject nuevoProyectile = Instantiate(prefabProyectile);
        nuevoProyectile.transform.position = transform.position;
        nuevoProyectile.GetComponent<NetworkObject>();
        no.spawn();
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!IsOwner) return;
        if(collision.gameObject.CompareTag("moneda"))

        puntos.Value += 1;
    
        
        NetworkObject no = collision.gameObject.GetComponent<NetworkObject>();
        no.Despawn(); //Desconectar la moneda*/

        eliminarMonedaServerRpc(no.NetworkObjectId);

       
    }

    [ServerRpc]
    void eliminarMonedaServerRpc(ulong noID) 
    //void eliminarMonedaServerRpc(NetworkObject no)
    {
        NetworkObject no = NetworkManager.Singleton.SpawnManager.SpawnedObjects [noID];
        no.Despawn();//Desconecta y elimina la moneda
    }


}
