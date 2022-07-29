using System.Globalization;
using System.Threading;
using Terraria.Localization;
using Terraria.ModLoader;

namespace LanguageFix
{
	public class LanguageFix : Mod
	{
        public override void Load() {
            On.Terraria.Localization.LanguageManager.SetLanguage_GameCulture += Fix;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        }

        public override void Unload() {
            Thread.CurrentThread.CurrentCulture = Language.ActiveCulture.CultureInfo;
        }

        private void Fix(On.Terraria.Localization.LanguageManager.orig_SetLanguage_GameCulture orig, Terraria.Localization.LanguageManager self, Terraria.Localization.GameCulture culture) {
            orig.Invoke(self, culture);
            // 强制设置为en-US
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        }
    }
}