using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;
using Assets.Scripts.Objects;
//aimee tweaker by Storm and Copilot, written with help from the modding community and AI

namespace StormsAimeeBuff
{
    [BepInPlugin("StormsAimeeBuff", "Storms Aimee Tweaker", "2.0.0")]
    public class aimeeBuffModPlugin : BaseUnityPlugin
    {
        public static ManualLogSource Log;
        public static ConfigEntry<float> aimeeSpeed;
        public static ConfigEntry<float> aimeeStormDamage;
        public static ConfigEntry<int> aimeeMiningDepth;
        public static ConfigEntry<float> aimeeStuckTimer;
        public static ConfigEntry<float> aimeeStuckSpeed;
        public static ConfigEntry<int> aimeeSearchArea;
        public static ConfigEntry<float> aimeeRepairSpeed;

        void Awake()
        {
            Log = Logger;

            aimeeSpeed = Config.Bind("General", "aimeeSpeed", 1.3f, new ConfigDescription("In m/s." + "\nDefault is 2.6, vanilla is 1.3"));
            aimeeStormDamage = Config.Bind("General", "aimeeStormDamage", 1.f, new ConfigDescription("Not implemented yet." + "\nIn % where 1 = 100%. " + "\nDefault is 0.25, vanilla is 1"));
            aimeeRepairSpeed = Config.Bind("General", "aimeeRepairSpeed", 0.4f, new ConfigDescription("In % where 1 = 100%. " + "\nDefault is 0.4, vanilla is 0.4"));
            aimeeMiningDepth = Config.Bind("General", "aimeeMiningDepth", 3, new ConfigDescription("I think in meters." + "\nDefault is 6, vanilla is 3"));
            aimeeStuckTimer = Config.Bind("General", "aimeeStuckTimer", 60f, new ConfigDescription("In seconds." + "\nDefault is 1200, vanilla is 60"));
            aimeeStuckSpeed = Config.Bind("General", "aimeeStuckSpeed", 0.1f, new ConfigDescription("I think in m/s." + "\nDefault is 0, vanilla is 0.1"));
            aimeeSearchArea = Config.Bind("General", "aimeeSearchArea", 32, new ConfigDescription("The range aimee will look for ores in when in mining mode. I think in meters." + "\nDefault is 16, vanilla is 16"));

            //apply patching
            var harmony = new Harmony("StormsAimeeBuff");
            harmony.PatchAll();
        }
    }
}