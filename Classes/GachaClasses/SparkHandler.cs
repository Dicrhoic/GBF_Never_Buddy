namespace GBF_Never_Buddy.Classes.GachaClasses
{
    internal class SparkHandler : GachaHandler
    {

        //spark means that 3000 x 30
        //
        int max = 90000;
        int currentDrawCount = 1;
        int maxDrawCount = 30;
        string drawCaption = $"Draw ";


        List<GachaResults> Draws = new();

        Tuple<string, List<GachaResults>> DrawDetails;


    }
}
