using System.Collections.Generic;

namespace Dispractice.Models
{
    public static class RankData
    {
        public static readonly Dictionary<MilitaryRank,Rank> Ranks = new Dictionary<MilitaryRank, Rank>()
        {
            { MilitaryRank.RYD, new Rank(0,
                new RankInfo("рядовой", "ряд."),
                new RankInfo("матрос", "м-с"))},
            { MilitaryRank.EFR, new Rank(1,
                new RankInfo("ефрейтор", "ефр."),
                new RankInfo("старший матрос", "ст. м-с"))},
            { MilitaryRank.MLSGT, new Rank(2,
                new RankInfo("младший сержант", "мл. с-т"),
                new RankInfo("старшина 2 статьи", "с-на 2 ст."))},
            { MilitaryRank.SGT, new Rank(3,
                new RankInfo("сержант", "с-т"),
                new RankInfo("старшина 1 статьи", "с-на 1 ст."))},
            { MilitaryRank.STSGT, new Rank(4,
                new RankInfo("старший сержант", "ст. с-т"),
                new RankInfo("главный старшина", "гл. с-на"))},
            { MilitaryRank.SHNA, new Rank(5,
                new RankInfo("старшина", "с-на"),
                new RankInfo("главный корабельный старшина", "гл. к. с-на"))},
            { MilitaryRank.PRP, new Rank(6,
                new RankInfo("прапорщик", "пр-к"),
                new RankInfo("мичман", "м-н"))},
            { MilitaryRank.STPRP, new Rank(7,
                new RankInfo("старший прапорщик", "ст. пр-к"),
                new RankInfo("старший мичман", "ст. м-н"))},
            { MilitaryRank.MLLT, new Rank(8,
                new RankInfo("младший лейтенант", "мл. л-т"),
                new RankInfo("младший лейтенант", "мл. л-т"))},
            { MilitaryRank.LT, new Rank(9,
                new RankInfo("лейтенант", "л-т"),
                new RankInfo("лейтенант", "л-т"))},
            { MilitaryRank.STLT, new Rank(10,
                new RankInfo("старший лейтенант", "ст. л-т"),
                new RankInfo("старший лейтенант", "ст. л-т"))},
            { MilitaryRank.CPT, new Rank(11,
                new RankInfo("капитан", "к-н"),
                new RankInfo("капитан-лейтенант", "к/л"))},
            { MilitaryRank.MAJ, new Rank(12,
                new RankInfo("майор", "м-р"),
                new RankInfo("капитан 3 ранга", "кап. 3 р."))},
            { MilitaryRank.LTC, new Rank(13,
                new RankInfo("подполковник", "п/п-к"),
                new RankInfo("капитан 2 ранга", "кап. 2 р."))},
            { MilitaryRank.COL, new Rank(14,
                new RankInfo("полковник", "п-к"),
                new RankInfo("капитан 1 ранга", "кап. 1 р."))},
            { MilitaryRank.GMJ, new Rank(15,
                new RankInfo("генерал-майор", "г/м-р"),
                new RankInfo("контр-адмирал", "к-адм."))},
            { MilitaryRank.GLT, new Rank(16,
                new RankInfo("генерал-лейтенант", "г/л-т"),
                new RankInfo("вице-адмирал", "в-адм."))},
            { MilitaryRank.GPC, new Rank(17,
                new RankInfo("генерал-полковник", "г/п-к"),
                new RankInfo("адмирал", "адм."))},
            { MilitaryRank.GA, new Rank(18,
                new RankInfo("генерал армии", "генерал армии"),
                new RankInfo("адмирал флота", "адмирал флота"))}
            };

        public static IEnumerable<Rank> GetRanks()
        {
            foreach (var rank in Ranks.Values)
            {
                yield return rank;
            }
        }

        public static Rank GetRank(this MilitaryRank rank)
        {
            return Ranks[rank];
        }

        public static MilitaryRank GetRank(this Rank rank)
        {
            foreach (var kvp in Ranks)
            {
                if (kvp.Value == rank)
                {
                    return kvp.Key;
                }
            }
            throw new KeyNotFoundException("Rank not found");
        }

        public static RankInfo GetRankInfo(this MilitaryRank rank, bool isNaval)
        {
            return Ranks[rank].GetRankInfo(isNaval);
        }
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

    public enum MilitaryRank
    {
        RYD = 0,       // рядовой / матрос
        EFR = 1,       // ефрейтор / ст. матрос
        MLSGT = 2,     // мл. сержант / старшина 2 ст.
        SGT = 3,       // сержант / старшина 1 ст.
        STSGT = 4,     // ст. сержант / гл. старшина
        SHNA = 5,      // старшина / гл. к. старшина
        PRP = 6,       // прапорщик / мичман
        STPRP = 7,     // ст. прапорщик / ст. мичман
        MLLT = 8,      // мл. лейтенант
        LT = 9,        // лейтенант
        STLT = 10,     // ст. лейтенант
        CPT = 11,      // капитан / капитан-лейтенант
        MAJ = 12,      // майор / капитан 3 ранга
        LTC = 13,      // подполковник / капитан 2 ранга
        COL = 14,      // полковник / капитан 1 ранга
        GMJ = 15,      // генерал-майор / контр-адмирал
        GLT = 16,      // генерал-лейтенант / вице-адмирал
        GPC = 17,      // генерал-полковник / адмирал
        GA = 18        // генерал армии / адмирал флота
    }

}



