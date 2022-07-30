using System.Globalization;
using System.Threading;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace LanguageFix
{
	public class LanguageFix : Mod
	{
        public override void Load() {
            On.Terraria.Localization.LanguageManager.SetLanguage_GameCulture += Fix;
            Main.QueueMainThreadAction(() => {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            });
        }

        public override void Unload() {
            Thread.CurrentThread.CurrentCulture = Language.ActiveCulture.CultureInfo;
        }

        private void Fix(On.Terraria.Localization.LanguageManager.orig_SetLanguage_GameCulture orig, LanguageManager self, GameCulture culture) {
            orig.Invoke(self, culture);
            // 强制设置为en-US
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        }
    }
}