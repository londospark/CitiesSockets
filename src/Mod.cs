using System.Reflection;
using ICities;
using UnityEngine;

[assembly: AssemblyVersion("1.0.*")]

namespace SkylinesMod
{
    public class Mod : LoadingExtensionBase, IUserMod
    {
        public string Name => "Cities Sockets";
        public string Description => "Exposes a socket interface to Cities: Skylines";

        public override void OnLevelLoaded(LoadMode mode)
        {
            base.OnLevelLoaded(mode);
            var testServer = new GameObject("SocketServer").AddComponent<TCPTestServer>();
            testServer.StartServer();
        }

        public override void OnLevelUnloading()
        {
            base.OnLevelUnloading();
            var gameObject = GameObject.Find("SocketServer");

            if (gameObject is null)
                return;

            gameObject.GetComponent<TCPTestServer>().Destroy();
            GameObject.Destroy(gameObject);
        }

        public void OnEnabled()
        {
            Debug.Log("Enabled mod");
        }

        public void OnDisabled()
        {
            Debug.Log("Disabled mod");
        }
    }
}
