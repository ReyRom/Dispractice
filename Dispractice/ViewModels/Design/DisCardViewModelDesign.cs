using Dispractice.Models;
using Dispractice.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dispractice.ViewModels.Design
{
    public class DisCardViewModelDesign : DisCardViewModel
    {
        public DisCardViewModelDesign() : base()
        {
            Serviceman = GenerateTestServiceman();
        }

        public static Serviceman GenerateTestServiceman()
        {
            // Создаем подразделения
            var rootUnit = new Unit
            {
                Name = "1-я Бригада",
                SubUnits = new ObservableCollection<Unit>()
            };

            var subUnit = new Unit
            {
                Name = "1-й Батальон",
                ParentUnit = rootUnit
            };
            rootUnit.SubUnits.Add(subUnit);

            // Создаем воинские должности
            var position = new Position
            {
                Name = "Командир роты",
                Unit = subUnit
            };

            // Создаем военнослужащего
            var serviceman = new Serviceman
            {
                Name = "Иван",
                Surname = "Иванов",
                Patronomic = "Иванович",
                Rank = MilitaryRank.SGT, 
                Position = position,
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
                Type = CommendationType.Medal
            });

            // Добавляем взыскание
            var penalty = new Penalty
            {
                Description = "Нарушение дисциплины",
                OffenseDate = new DateTime(2023, 3, 15),
                DateApplied = new DateTime(2023, 3, 20),
                AppliedBy = "Командир батальона",
                Type = PenaltyType.Reprimand,
            };

            serviceman.Penalties.Add(penalty);

            // Добавляем снятие взыскания по поощрению
            var commendationForPenaltyRemoval = new Commendation
            {
                Description = "За снятие взыскания",
                DateAwarded = new DateTime(2024, 3, 20),
                AwardedBy = "Командующий",
                Type = CommendationType.Removal
            };

            serviceman.Commendations.Add(commendationForPenaltyRemoval);

            // Связываем снятие взыскания с поощрением
            penalty.Commendation = commendationForPenaltyRemoval;

            return serviceman;
        }
    }
}
