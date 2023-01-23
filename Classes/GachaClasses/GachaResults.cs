namespace GBF_Never_Buddy.Classes.GachaClasses
{
    internal class GachaResults
    {
        List<GameDataClasses.Character> characters = new();
        List<GameDataClasses.Summon> summons = new();

        public void AddCharacter(GameDataClasses.Character character)
        {
            characters.Add(character);
        }

        public void AddSummons(GameDataClasses.Summon summon)
        {
            summons.Add(summon);
        }
    }
}
