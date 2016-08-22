using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;
using Rocket.Unturned.Player;

namespace RocketModSpells
{
    class CommandSpell : IRocketCommand
    {
        public List<string> Aliases
        {
            get { return new List<string>(); }
        }

        public AllowedCaller AllowedCaller
        {
            get { return Rocket.API.AllowedCaller.Player; }
        }

        public void Execute(IRocketPlayer caller, string[] command)
        {
            Plugin.CastSpell(34, (UnturnedPlayer)caller);
        }

        public string Help
        {
            get { return "allows you to cast a spell."; }
        }

        public string Name
        {
            get { return "spell"; }
        }

        public List<string> Permissions
        {
            get { return new List<string> { "spell" }; }
        }

        public string Syntax
        {
            get { return "<spell name>"; }
        }
    }
}
