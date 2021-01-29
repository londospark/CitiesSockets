using ColossalFramework;
using ColossalFramework.Plugins;
using ICities;
using UnityEngine;

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
                Debug.Log($"Current traffic: {trafficFlow}");
                delta -= 2.0f;
            }
        }
    }
}
