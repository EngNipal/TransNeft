using System;
using System.Linq;
using TransNeftTest.Models;

namespace TransNeftTest
{
    public static class SampleData
    {
        public static void Initialize(TNEContext context)
        {
            if (!context.Organizations.Any())
            {
                context.Organizations.AddRange(
                    new Organization()
                    {
                        Name = "Транснефть",
                        Address = "123112, г. Москва, Пресненская набережная, д. 4, стр. 2"
                    },
                    new Organization()
                    {
                        Name = "ТранснефтьЭнерго",
                        Address = "123112, Москва, Пресненская наб., д.4, стр.2, башня \"Эволюция\"",
                        ParentOrganizationId = 1
                    });
            }

            if (!context.EObjects.Any())
            {
                context.EObjects.AddRange(
                    new EObject()
                    {
                        Name = "ПС 110/10 Весна",
                        Address = "В деревне у дедушки",
                        ParentOrganizationId = 2
                    },
                    new EObject()
                    {
                        Name = "Потребитель-1",
                        Address = "Адрес потребителя-1",
                        ParentOrganizationId = 2
                    });
            }

            if (!context.MeterPoints.Any())
            {
                context.MeterPoints.AddRange(
                    new MeterPoint()
                    {
                        Name = "Точка измерения-1",
                        EObjectId = 1
                    },
                    new MeterPoint()
                    {
                        Name = "Точка измерения-2",
                        EObjectId = 2
                    });
            }

            if (!context.ElectricityMeters.Any())
            {
                context.ElectricityMeters.AddRange(
                    new ElectricityMeter()
                    {
                        Number = "Счётчик-1",
                        CheckDate = new DateTime(2018, 01, 01),
                        Type = "Тип-1",
                        MeterPointId = 1
                    },
                    new ElectricityMeter()
                    {
                        Number = "Счётчик-2",
                        CheckDate = new DateTime(2022, 01, 01),
                        Type = "Тип-2",
                        MeterPointId = 2
                    },
                    new ElectricityMeter()
                    {
                        Number = "Счётчик-3",
                        CheckDate = new DateTime(2023, 01, 01),
                        Type = "Тип-3"
                    });
            }

            if (!context.CurrentTransformers.Any())
            {
                context.CurrentTransformers.AddRange(
                    new CurrentTransformer()
                    {
                        Number = "Трансформатор тока-1",
                        CheckDate = new DateTime(2018, 02, 02),
                        KTT = 1.73,
                        MeterPointId = 1
                    },
                    new CurrentTransformer()
                    {
                        Number = "Трансформатор тока-2",
                        CheckDate = new DateTime(2022, 02, 02),
                        KTT = 1.41,
                        MeterPointId = 2
                    },
                    new CurrentTransformer()
                    {
                        Number = "Трансформатор тока-3",
                        CheckDate = new DateTime(2023, 02, 02),
                        KTT = 3.14,
                    });
            }

            if (!context.VoltageTransformers.Any())
            {
                context.VoltageTransformers.AddRange(
                    new VoltageTransformer()
                    {
                        Number = "Трансформатор напряжения-1",
                        CheckDate = new DateTime(2018, 03, 03),
                        KTH = 1.73,
                        MeterPointId = 1
                    },
                    new VoltageTransformer()
                    {
                        Number = "Трансформатор напряжения-2",
                        CheckDate = new DateTime(2022, 03, 03),
                        KTH = 1.41,
                        MeterPointId = 2
                    },
                    new VoltageTransformer()
                    {
                        Number = "Трансформатор напряжения-3",
                        CheckDate = new DateTime(2023, 03, 03),
                        KTH = 3.14,
                        MeterPointId = 2
                    });
            }

            if (!context.CalcMeters.Any())
            {
                context.CalcMeters.AddRange(
                    new CalcMeter()
                    {
                        Number = "1-2018",
                        StartDate = new DateTime(2018, 05, 18),
                        EndDate = new DateTime(2018, 11, 13)
                    },
                    new CalcMeter()
                    {
                        Number = "2-2020",
                        StartDate = new DateTime(2020, 01, 01),
                        EndDate = new DateTime(2020, 12, 31)
                    },
                    new CalcMeter()
                    {
                        Number = "3-2018",
                        StartDate = new DateTime(2018, 06, 05),
                        EndDate = new DateTime(2018, 12, 13)
                    });
            }

            context.SaveChanges();
        }
    }
}