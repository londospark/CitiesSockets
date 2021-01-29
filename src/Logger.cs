using ColossalFramework;
using ColossalFramework.Plugins;
using ICities;

namespace SkylinesMod
{
    public class Logger : ThreadingExtensionBase
    {
        private float delta = 0.0f;
        public override void OnUpdate(float realTimeDelta, float simulationTimeDelta)
        {
            base.OnUpdate(realTimeDelta, simulationTimeDelta);

            delta += realTimeDelta;
            if (delta > 2.0f)
            {
                var trafficFlow = Singleton<VehicleManager>.instance.m_lastTrafficFlow;
                DebugOutputPanel.AddMessage(PluginManager.MessageType.Message, $"Current traffic would be: {trafficFlow}");
                delta -= 2.0f;
            }
        }
    }
}
