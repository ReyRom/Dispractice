namespace Dispractice.Models
{
    public static class RankData
    {



        public static readonly Rank[] Ranks = 
        {
            new Rank(0, 
                new RankInfo("рядовой", "ряд."), 
                new RankInfo("матрос", "м-с")),
            new Rank(1, 
                new RankInfo("ефрейтор", "ефр."),
                new RankInfo("старший матрос", "ст. м-с")),
            new Rank(2, 
                new RankInfo("младший сержант", "мл. с-т"), 
                new RankInfo("старшина 2 статьи", "с-на 2 ст.")),
            new Rank(3, 
                new RankInfo("сержант", "с-т"), 
                new RankInfo("старшина 1 статьи", "с-на 1 ст.")),
            new Rank(4,
                new RankInfo("старший сержант", "ст. с-т"),
                new RankInfo("главный старшина", "гл. с-на")),
            new Rank(5,
                new RankInfo("старшина", "с-на"),
                new RankInfo("главный корабельный старшина", "гл. к. с-на")),
            new Rank(6,
                new RankInfo("прапорщик", "пр-к"),
                new RankInfo("мичман", "м-н")),
            new Rank(7,
                new RankInfo("старший прапорщик", "ст. пр-к"),
                new RankInfo("старший мичман", "ст. м-н")),
            new Rank(8,
                new RankInfo("младший лейтенант", "мл. л-т"),
                new RankInfo("младший лейтенант", "мл. л-т")),
            new Rank(9,
                new RankInfo("лейтенант", "л-т"),
                new RankInfo("лейтенант", "л-т")),
            new Rank(10,
                new RankInfo("старший лейтенант", "ст. л-т"),
                new RankInfo("старший лейтенант", "ст. л-т")),
            new Rank(11,
                new RankInfo("капитан", "к-н"),
                new RankInfo("капитан-лейтенант", "к/л")),
            new Rank(12,
                new RankInfo("майор", "м-р"),
                new RankInfo("капитан 3 ранга", "кап. 3 р.")),
            new Rank(13,
                new RankInfo("подполковник", "п/п-к"),
                new RankInfo("капитан 2 ранга", "кап. 2 р.")),
            new Rank(14,
                new RankInfo("полковник", "п-к"),
                new RankInfo("капитан 1 ранга", "кап. 1 р.")),
            new Rank(15,
                new RankInfo("генерал-майор", "г/м-р"),
                new RankInfo("контр-адмирал", "к-адм.")),
            new Rank(16,
                new RankInfo("генерал-лейтенант", "г/л-т"),
                new RankInfo("вице-адмирал", "в-адм.")),
            new Rank(17,
                new RankInfo("генерал-полковник", "г/п-к"),
                new RankInfo("адмирал", "адм.")),
            new Rank(18,
                new RankInfo("генерал армии", "генерал армии"),
                new RankInfo("адмирал флота", "адмирал флота"))
                };
    }
    public class Rank
    {
        public Rank(int seniorityOrder, RankInfo armyRank, RankInfo navalRank)
        {
            SeniorityOrder = seniorityOrder;
            ArmyRank = armyRank;
            NavalRank = navalRank;
        }
        public int SeniorityOrder { get; }
        public RankInfo ArmyRank { get; }
        public RankInfo NavalRank { get; }

        public RankInfo GetRankInfo(bool isNaval) => isNaval ? NavalRank : ArmyRank;
    }
    public record RankInfo(string Name, string ShortName);
}



  