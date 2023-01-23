namespace GBF_Never_Buddy.Classes.GachaClasses
{
    public enum DrawType
    {
        Single = 300,
        Multi = 3000
    }

    public class GachaHandler
    {

        public int crystalsSpent = 0;
        public string preText = "Crystals used: ";
        public PictureBox? currentCharacterImage = null;
        public List<GameDataClasses.Character>? characters;
        public List<GameDataClasses.Summon>? summons;
        public int drawNumber = 0;
        public int lastCrystalAmount = 0;

        public int drawID { get; set; }

        public void UpdateCharacter(PictureBox picture)
        {
            currentCharacterImage = picture;
        }

        public void UpdateCrystalsUsed(Label textHolder, DrawType drawType)
        {
            int crystals = (int)drawType;
            crystalsSpent = crystalsSpent + crystals;
            string text = preText + $" {crystalsSpent}";
            textHolder.Text = text;
        }

        public void UpdateDrawDB()
        {

        }

        public void UpdateLists(List<GameDataClasses.Summon> sumList, List<GameDataClasses.Character> charList)
        {
            characters = charList;
            summons = sumList;
        }

    }
}
