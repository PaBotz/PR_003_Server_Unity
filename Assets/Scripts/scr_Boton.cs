using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class scr_Boton : MonoBehaviour
{
    public Button button_Host;
    public Button Button_Client;
    public Button Button_Desconectar;

   
   public void conectarComoHost()
   {
    NetworkManager.Singleton.StartHost();

   }

   public void conectarComoClient()
   {
    NetworkManager.Singleton.StartClient();

   }

   public void desconectar()
   {
    NetworkManager.Singleton.Shutdown();

   }


}
