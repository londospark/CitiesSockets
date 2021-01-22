using System.Reflection;
using ColossalFramework;
using ColossalFramework.UI;
using ICities;

[assembly: AssemblyVersion("1.0.*")]

namespace SkylinesMod
{
    public class Mod : LoadingExtensionBase, IUserMod
    {
        public string Name => "Cities Sockets";
        public string Description => "Exposes a socket interface to Cities: Skylines";

        public void OnEnabled()
        {
            if (Singleton<LoadingManager>.instance.m_currentlyLoading || (UnityEngine.Object)UIView.library == (UnityEngine.Object)null)
            {
                Singleton<LoadingManager>.instance.m_introLoaded += new LoadingManager.IntroLoadedHandler(OnIntroLoaded);
                Singleton<LoadingManager>.instance.m_levelLoaded += new LoadingManager.LevelLoadedHandler(OnLevelLoaded);
            }
        }

        private void OnIntroLoaded()
        {
            Singleton<LoadingManager>.instance.m_introLoaded -= new LoadingManager.IntroLoadedHandler(OnIntroLoaded);
        }

        private void OnLevelLoaded(SimulationManager.UpdateMode updateMode)
        {
            Singleton<LoadingManager>.instance.m_levelLoaded -= new LoadingManager.LevelLoadedHandler(OnLevelLoaded);
        }
    }
}
