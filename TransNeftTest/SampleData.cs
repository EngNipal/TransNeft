using System;
using System.Linq;
using TransNeftTest.Models;

namespace TransNeftTest
{
    public static class SampleData
    {
        public static void Initialize(TNEContext context)
        {
            var organization1 = new Organization()
            {
                Name = "Транснефть",
                Address = "123112, г. Москва, Пресненская набережная, д. 4, стр. 2"
            };

            var organization2 = new Organization()
            {
                Name = "ТранснефтьЭнерго",
                Address = "123112, Москва, Пресненская наб., д.4, стр.2, башня \"Эволюция\""
            };

            if (!context.Organizations.Any())
            {
                context.Organizations.Add(organization1);
                context.Organizations.Add(organization2);
                context.SaveChanges();

                organization2.ParentOrganizationId = organization1.Id;

                context.Organizations.Update(organization2);
                context.SaveChanges();
            }

            var eObject1 = new EObject()
            {
                Name = "Потребитель-1",
                Address = "Адрес потребителя-1",
                ParentOrganizationId = organization2.Id,
            };

            var eObject2 = new EObject()
            {
                Name = "Потребитель-2",
                Address = "Адрес потребителя-2",
                ParentOrganizationId = organization2.Id,
            };

            if (!context.EObjects.Any())
            {
                context.EObjects.Add(eObject1);
                context.EObjects.Add(eObject2);
                context.SaveChanges();
            }

            var deliveryPoint1 = new DeliveryPoint()
            {
                Name = "Точка поставки-1",
                EObjectId = eObject1.Id
            };

            var deliveryPoint2 = new DeliveryPoint()
            {
                Name = "Точка поставки-2",
                EObjectId = eObject2.Id
            };

            var deliveryPoint3 = new DeliveryPoint()
            {
                Name = "Точка поставки-3",
                EObjectId = eObject2.Id
            };

            if (!context.DeliveryPoints.Any())
            {
                context.DeliveryPoints.Add(deliveryPoint1);
                context.DeliveryPoints.Add(deliveryPoint2);
                context.DeliveryPoints.Add(deliveryPoint3);
                context.SaveChanges();
            }

            var calcMeter1 = new CalcMeter()
            {
                Number = "1-2018",
                StartDate = new DateTime(2018, 05, 18),
                EndDate = new DateTime(2018, 11, 13),
                DeliveryPointId = deliveryPoint1.Id
            };

            var calcMeter2 = new CalcMeter()
            {
                Number = "2-2020",
                StartDate = new DateTime(2020, 01, 01),
                EndDate = new DateTime(2020, 12, 31),
                DeliveryPointId = deliveryPoint2.Id
            };

            var calcMeter3 = new CalcMeter()
            {
                Number = "3-2018",
                StartDate = new DateTime(2018, 06, 05),
                EndDate = new DateTime(2018, 12, 13),
                DeliveryPointId = deliveryPoint3.Id
            };

            var calcMeter4 = new CalcMeter()
            {
                Number = "4-2021",
                StartDate = new DateTime(2021, 10, 01),
                EndDate = new DateTime(2021, 12, 31),
                DeliveryPointId = deliveryPoint3.Id
            };

            if (!context.CalcMeters.Any())
            {
                context.CalcMeters.Add(calcMeter1);
                context.CalcMeters.Add(calcMeter2);
                context.CalcMeters.Add(calcMeter3);
                context.CalcMeters.Add(calcMeter4);
                context.SaveChanges();
            }

            var meterPoint1 = new MeterPoint()
            {
                Name = "Точка измерения-1",
                EObjectId = eObject1.Id,
                CalcMeterId = calcMeter1.Id
            };

            var meterPoint2 = new MeterPoint()
            {
                Name = "Точка измерения-2",
                EObjectId = eObject2.Id,
                CalcMeterId = calcMeter2.Id
            };

            var meterPoint3 = new MeterPoint()
            {
                Name = "Точка измерения-3",
                EObjectId = eObject2.Id,
                CalcMeterId = calcMeter3.Id
            };

            if (!context.MeterPoints.Any())
            {
                context.MeterPoints.Add(meterPoint1);
                context.MeterPoints.Add(meterPoint2);
                context.MeterPoints.Add(meterPoint3);
                context.SaveChanges();

                calcMeter1.MeterPointId = meterPoint1.Id;
                calcMeter2.MeterPointId = meterPoint2.Id;
                calcMeter3.MeterPointId = meterPoint3.Id;
                context.CalcMeters.UpdateRange(calcMeter1, calcMeter2, calcMeter3);
                context.SaveChanges();
            }

            var elMeter1 = new ElectricityMeter()
            {
                Number = "Счётчик-1",
                CheckDate = new DateTime(2018, 01, 01),
                Type = "Тип-1",
                MeterPointId = meterPoint1.Id
            };

            var elMeter2 = new ElectricityMeter()
            {
                Number = "Счётчик-2",
                CheckDate = new DateTime(2022, 01, 01),
                Type = "Тип-2",
                MeterPointId = meterPoint2.Id
            };

            var elMeter3 = new ElectricityMeter()
            {
                Number = "Счётчик-3",
                CheckDate = new DateTime(2023, 01, 01),
                Type = "Тип-3"
                // No MeterPoint
            };

            if (!context.ElectricityMeters.Any())
            {
                context.ElectricityMeters.Add(elMeter1);
                context.ElectricityMeters.Add(elMeter2);
                context.ElectricityMeters.Add(elMeter3);
                context.SaveChanges();

                meterPoint1.ElectricityMeterId = elMeter1.Id;
                meterPoint2.ElectricityMeterId = elMeter2.Id;

                context.MeterPoints.UpdateRange(meterPoint1, meterPoint2);
                context.SaveChanges();
            }

            var currTransformer1 = new CurrentTransformer()
            {
                Number = "Трансформатор тока-1",
                CheckDate = new DateTime(2018, 02, 02),
                KTT = 1.73,
                MeterPointId = meterPoint1.Id
            };

            var currTransformer2 = new CurrentTransformer()
            {
                Number = "Трансформатор тока-2",
                CheckDate = new DateTime(2022, 02, 02),
                KTT = 1.41,
                MeterPointId = meterPoint2.Id
            };

            var currTransformer3 = new CurrentTransformer()
            {
                Number = "Трансформатор тока-3",
                CheckDate = new DateTime(2023, 02, 02),
                KTT = 3.14,
                // No MeterPoint
            };

            if (!context.CurrentTransformers.Any())
            {
                context.CurrentTransformers.Add(currTransformer1);
                context.CurrentTransformers.Add(currTransformer2);
                context.CurrentTransformers.Add(currTransformer3);
                context.SaveChanges();

                meterPoint1.CurrentTransformerId = currTransformer1.Id;
                meterPoint2.CurrentTransformerId = currTransformer2.Id;

                context.MeterPoints.UpdateRange(meterPoint1, meterPoint2);
                context.SaveChanges();
            }

            var voltageTransformer1 = new VoltageTransformer()
            {
                Number = "Трансформатор напряжения-1",
                CheckDate = new DateTime(2018, 03, 03),
                KTH = 1.73,
                MeterPointId = meterPoint1.Id
            };

            var voltageTransformer2 = new VoltageTransformer()
            {
                Number = "Трансформатор напряжения-2",
                CheckDate = new DateTime(2022, 03, 03),
                KTH = 1.41,
                MeterPointId = meterPoint2.Id
            };

            var voltageTransformer3 = new VoltageTransformer()
            {
                Number = "Трансформатор напряжения-3",
                CheckDate = new DateTime(2023, 03, 03),
                KTH = 3.14,
                // No MeterPoint
            };

            if (!context.VoltageTransformers.Any())
            {
                context.VoltageTransformers.Add(voltageTransformer1);
                context.VoltageTransformers.Add(voltageTransformer2);
                context.VoltageTransformers.Add(voltageTransformer3);
                context.SaveChanges();

                meterPoint1.VoltageTransformerId = voltageTransformer1.Id;
                meterPoint2.VoltageTransformerId = voltageTransformer2.Id;

                context.MeterPoints.UpdateRange(meterPoint1, meterPoint2);
                context.SaveChanges();
            }
        }
    }
}