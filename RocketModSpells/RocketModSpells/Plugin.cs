using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;
using Rocket.Core.Plugins;
using Rocket.Core.Logging;
using Rocket.Unturned.Player;
using SDG.Unturned;
using UnityEngine;
using System.Threading;

namespace RocketModSpells
{
    public class Plugin : RocketPlugin<Config>
    {
        public static Plugin Instance;
        protected override void Load()
        {
            Instance = this;
            Logger.Log("RocketModSpells has Loaded!");
        }

        protected override void Unload()
        {
            Logger.Log("RocketModSpells has Unloaded!");
        }

        public static void CastSpell(ushort effectId, UnturnedPlayer caster)
        {
            new Thread(() => boomSpell(effectId, caster)).Start(); 
        }

        public static void boomSpell(ushort effectId, UnturnedPlayer caster)
        {
            Vector3 boomLocation = caster.Position;

            Plugin.Boom(effectId, caster);
            for (int ii = 10; ii >= 0; ii--)
            {
                Logger.Log("BOOM");
                boomLocation.z += 5;
                Plugin.Boom(effectId, boomLocation);
                Thread.Sleep(500);
            }
        }

        public static void Boom(ushort effectId, UnturnedPlayer caster)
        {
            EffectManager.sendEffect(effectId, EffectManager.SMALL, caster.Position);
            DamageTool.explode(caster.Position, EffectManager.SMALL, EDeathCause.GRENADE, 20, 400, 400, 20, 20, 50, 20, 20);
        }

        public static void Boom(ushort effectId, Vector3 pos)
        {
            EffectManager.sendEffect(effectId, EffectManager.SMALL, pos);
            DamageTool.explode(pos, EffectManager.SMALL, EDeathCause.GRENADE, 20, 400, 400, 20, 20, 50, 20, 20);
        }
    }
}
