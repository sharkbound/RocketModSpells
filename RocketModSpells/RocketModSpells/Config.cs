using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;

namespace RocketModSpells
{
    public class Config : IRocketPluginConfiguration
    {
        public string PlaceHolder;
        public void LoadDefaults()
        {
            PlaceHolder = "lel";
        }
    }
}
