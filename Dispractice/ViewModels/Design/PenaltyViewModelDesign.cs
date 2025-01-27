using Dispractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispractice.ViewModels.Design
{
    public class PenaltyViewModelDesign : PenaltyViewModel
    {
        public PenaltyViewModelDesign()
        {
            Serviceman = GenerateTestServiceman();
            Penalty = Serviceman.Penalties.First();
        }

        public static Serviceman GenerateTestServiceman()
        {
            // Создаем подразделения
            var rootUnit = new MilitaryUnit
            {
                Name = "1-я Бригада",
                SubUnits = new List<MilitaryUnit>()
            };

            var subUnit = new MilitaryUnit
            {
                Name = "1-й Батальон",
                ParentUnit = rootUnit
            };
            rootUnit.SubUnits.Add(subUnit);

            // Создаем воинские должности
            var position = new MilitaryPosition
            {
                Name = "Командир роты",
                MilitaryUnit = subUnit
            };

            // Создаем военнослужащего
            var serviceman = new Serviceman
            {
                Name = "Иван",
                Surname = "Иванов",
                Patronomic = "Иванович",
                RankIndex = 3,
                MilitaryPosition = position,
                ServiceStartYear = 2015,
                Commendations = new List<Commendation>(),
                Penalties = new List<Penalty>()
            };

            // Добавляем поощрения
            serviceman.Commendations.Add(new Commendation
            {
                Description = "За отличное выполнение боевой задачи, боевые заслуги и еще очень-очень-очень-очень-очень-очень-очень-очень-очень-очень-очень-очень-очень-очень-очень-очень-очень-очень-очень много всего",
                DateAwarded = new DateTime(2020, 5, 9),
                AwardedBy = "Командующий",
                Type = "Медаль"
            });

            // Добавляем взыскание
            var penalty = new Penalty
            {
                Description = "Нарушение дисциплины",
                OffenseDate = new DateTime(2023, 3, 15),
                DateApplied = new DateTime(2023, 3, 20),
                DateExecuted = new DateTime(2023, 3, 20),
                AppliedBy = "Командир батальона",
                Type = "Выговор"
            };

            serviceman.Penalties.Add(penalty);

            // Добавляем снятие взыскания по поощрению
            var commendationForPenaltyRemoval = new Commendation
            {
                Description = "За снятие взыскания",
                DateAwarded = new DateTime(2024, 3, 20),
                AwardedBy = "Командующий",
                Type = "Снятие взыскания"
            };

            serviceman.Commendations.Add(commendationForPenaltyRemoval);

            // Связываем снятие взыскания с поощрением
            penalty.Commendation = commendationForPenaltyRemoval;

            return serviceman;
        }
    }
}
