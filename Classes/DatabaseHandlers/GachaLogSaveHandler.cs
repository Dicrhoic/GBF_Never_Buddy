using GBF_Never_Buddy.Classes.GachaClasses;

namespace GBF_Never_Buddy.Classes.DatabaseHandlers
{
    internal class GachaLogSaveHandler
    {
        GachaHandler handler;
        List<GameDataClasses.Summon>? summons;
        List<GameDataClasses.Character>? characters;
        public GachaLogSaveHandler(GachaHandler handler)
        {
            this.handler = handler;
            summons = handler.summons;
            characters = handler.characters;
        }
    }
}
