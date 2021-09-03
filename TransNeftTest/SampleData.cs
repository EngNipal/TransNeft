using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest
{
    public static class SampleData
    {
        public static void Initialize(OrganizationContext context)
        {
            if (!context.Holdings.Any())
            {
                context.Holdings.Add(
                    new Holding
                    {
                        Name = "Транснефть",
                        Address = "123112, г. Москва, Пресненская набережная, д. 4, стр. 2"
                    });
            }

            if (!context.Subsidiaries.Any())
            {
                context.Subsidiaries.Add(
                    new Subsidiary
                    {
                        Name = "ТранснефтьЭнерго",
                        Address = "123112, Москва, Пресненская наб., д.4, стр.2, башня \"Эволюция\"",
                        HoldingId = 1
                    });
            }

            if (!context.Consumers.Any())
            {
                context.Consumers.AddRange(
                    new Consumer
                    {
                        Name = "ПС 110/10 Весна",
                        Address = "В деревне у дедушки",
                        SubsidiaryId = 1
                    },
                    new Consumer
                    {
                        Name = "Потребитель-1",
                        Address = "Адрес потребителя-1",
                        SubsidiaryId = 1
                    });
            }

            if (!context.MeasurePoints.Any())
            {

            }
        }
    }
}