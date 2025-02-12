using HutongGames.PlayMaker;
using JetBrains.Annotations;
using MSCLoader;
using UnityEngine;

namespace InfiniteNitro
{
    [UsedImplicitly]
    public class InfiniteNitro : Mod
    {
        public override string ID => "InfiniteNitro";
        public override string Version => "1.1.0";
        public override string Author => "アカツキ/ RunAwayBlues";
        public override string Description => "N2O (Nitrous Oxide) Bottle never depletes.";

        private GameObject n2oBottle;
        private PlayMakerFSM n2oBottlePressure;
        private FsmFloat n2oBottlePressureFluid;

        public override void ModSetup()
        {
            base.ModSetup();

            SetupFunction(Setup.OnLoad, Mod_OnLoad);
            SetupFunction(Setup.OnModDisabled, Mod_OnDisabled);
            SetupFunction(Setup.OnModEnabled, Mod_OnEnabled);
            SetupFunction(Setup.Update, Mod_Update);
        }

        public void Mod_OnLoad()
        {
            n2oBottle = GameObject.Find("n2o bottle(Clone)/Dynamics");
            n2oBottlePressure = n2oBottle.GetPlayMaker("Pressure");
            n2oBottlePressureFluid = n2oBottlePressure.FsmVariables.GetFsmFloat("Fluid");

            ModConsole.Log("Infinite Nitro Mod Applied");
        }

        public void Mod_OnEnabled()
        {
            ModConsole.Log("Infinite Nitrous Oxide enabled");
        }

        public void Mod_OnDisabled()
        {
            ModConsole.Log("Infinite Nitrous Oxide disabled");
        }

        public void Mod_Update()
        {
            if(!isDisabled && n2oBottle != null && n2oBottle.activeSelf)
            {
                n2oBottlePressureFluid.Value = 5f;
            }
        }
    }
}
