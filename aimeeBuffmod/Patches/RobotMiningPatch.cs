using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;
using Assets.Scripts.Objects;
//aimee tweaker by Storm and Copilot, written with help from the modding community


namespace StormsAimeeBuff
{
    [HarmonyPatch(typeof(RobotMining))]
    [HarmonyPatch("Awake")]
    public class RobotMiningPatch
    {
        [HarmonyPostfix]
        public static void aimeeBuffPatch(RobotMining __instance)
        {

            aimeeBuffModPlugin.Log.LogInfo("Patching aimee values.");

            //patch non static publics
            __instance.MaxSpeed = aimeeBuffModPlugin.aimeeSpeed.Value;

            //need to figure out how to implement this
            //__instance.WeatherDamageScale = aimeeStormDamage.Value;

            //patch static publics
            RobotMining.RepairSpeedScale = aimeeBuffModPlugin.aimeeRepairSpeed.Value;
            
            aimeeBuffModPlugin.Log.LogInfo("Aimee speed set to " + __instance.MaxSpeed);

            //patch private static fields with reflection
            var type = typeof(RobotMining);
            if(type.GetField("maxMiningDepth", BindingFlags.NonPublic | BindingFlags.Static) != null)
            {
                type.GetField("maxMiningDepth", BindingFlags.NonPublic | BindingFlags.Static).SetValue(null, aimeeBuffModPlugin.aimeeMiningDepth.Value);
                aimeeBuffModPlugin.Log.LogInfo("Aimee mining depth set to " + type.GetField("maxMiningDepth", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null));
            }

            if(type.GetField("_isStuckCheckAmount", BindingFlags.NonPublic | BindingFlags.Static) != null)
            {
                type.GetField("_isStuckCheckAmount", BindingFlags.NonPublic | BindingFlags.Static).SetValue(null, aimeeBuffModPlugin.aimeeStuckTimer.Value);
                aimeeBuffModPlugin.Log.LogInfo("Aimee stuck timer set to " + type.GetField("_isStuckCheckAmount", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null));
            }

            if(type.GetField("_isStuckMovementAmount", BindingFlags.NonPublic | BindingFlags.Static) != null)
            {
                type.GetField("_isStuckMovementAmount", BindingFlags.NonPublic | BindingFlags.Static).SetValue(null, aimeeBuffModPlugin.aimeeStuckSpeed.Value);
                aimeeBuffModPlugin.Log.LogInfo("Aimee stuck speed set to " + type.GetField("_isStuckMovementAmount", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null));
            }

            if(type.GetField("MinableSearchArea", BindingFlags.NonPublic | BindingFlags.Static) != null)
            {
                type.GetField("MinableSearchArea", BindingFlags.NonPublic | BindingFlags.Static).SetValue(null, aimeeBuffModPlugin.aimeeSearchArea.Value);
                aimeeBuffModPlugin.Log.LogInfo("Aimee search area set to " + type.GetField("MinableSearchArea", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null));
            }
        }
    }
}