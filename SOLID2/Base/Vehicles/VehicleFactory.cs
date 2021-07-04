using SOLID2.Base.Vehicles;
using SOLID2.Base.Vehicles.Interfaces;
using System;
using System.Collections.Generic;

namespace SOLID2.Base
{
    
    public static class VehicleFactory
    {
        #region interfaces
        private interface IParameters
        {
            public IVehicle.VehicleEnum VehicleType { get; set; }
        }

        private interface IGasVehicleParameters:IParameters
        {
            public double RefuelLevel { get; set; }
        }

        private interface IElectricVehicleParameters : IParameters
        {
            public double RechargeLevel { get; set; }
        }

        private interface IHybridVehicleParameters: IElectricVehicleParameters, IGasVehicleParameters
        {

        }
        #endregion

        #region classes
        private class GasVehicleParams : IGasVehicleParameters
        {
            public IVehicle.VehicleEnum VehicleType { get; set; }
            public double RefuelLevel { get; set; }
        }

        private class ElectricVehicleParams : IElectricVehicleParameters
        {
            public IVehicle.VehicleEnum VehicleType { get; set; }
            public double RechargeLevel { get; set; }
        }

        private class HybridVehicleParams : IHybridVehicleParameters
        {
            public IVehicle.VehicleEnum VehicleType { get; set; }
            public double RechargeLevel { get; set; }
            public double RefuelLevel { get; set; }
        }
        #endregion

        private delegate IVehicle CreateVehicle(IParameters parameters);

        private static readonly Random _random;
        
        private static readonly IVehicle.VehicleEnum[] _vehicEnumVals;

        private static readonly Dictionary<IVehicle.VehicleEnum, IParameters> _templates;

        private static readonly Dictionary<IVehicle.VehicleEnum, CreateVehicle> _factories;
        public static IVehicle RandomVehicle()
        {
            var rVehicleType = (IVehicle.VehicleEnum)_vehicEnumVals.GetValue(_random.Next(_vehicEnumVals.Length));

            return _factories[rVehicleType].Invoke(_templates[rVehicleType]);
        }
        static VehicleFactory()
        {
            _random = new Random();
            _vehicEnumVals = (IVehicle.VehicleEnum[])Enum.GetValues(typeof(IVehicle.VehicleEnum));

            _templates = new Dictionary<IVehicle.VehicleEnum, IParameters>()
            {
                //Bus template
                {
                        IVehicle.VehicleEnum.Bus,
                        new GasVehicleParams
                        {
                            RefuelLevel = 0.1,
                            VehicleType = IVehicle.VehicleEnum.Bus
                        }
                    },
                //Car template
                {
                        IVehicle.VehicleEnum.Car,
                        new GasVehicleParams
                        {
                            RefuelLevel = 0.1,
                            VehicleType = IVehicle.VehicleEnum.Car
                        }
                    },
                //Electric car template
                {
                        IVehicle.VehicleEnum.Electric,
                        new ElectricVehicleParams
                        {
                            RechargeLevel = 0.1,
                            VehicleType = IVehicle.VehicleEnum.Electric
                        }
                    },
                //Hybrid car template
                {
                        IVehicle.VehicleEnum.Hybrid,
                        new HybridVehicleParams
                        {
                            RefuelLevel = 0.5,
                            RechargeLevel = 0.5,
                            VehicleType = IVehicle.VehicleEnum.Hybrid
                        }
                    },
                //Truck template
                {
                        IVehicle.VehicleEnum.Truck,
                        new GasVehicleParams
                        {
                            RefuelLevel = 0.1,
                            VehicleType = IVehicle.VehicleEnum.Truck
                        }
                    },
                //Van template
                {
                        IVehicle.VehicleEnum.Van,
                        new GasVehicleParams
                        {
                            RefuelLevel = 0.1,
                            VehicleType = IVehicle.VehicleEnum.Van
                        }
                    }
            };

            _factories = new Dictionary<IVehicle.VehicleEnum, CreateVehicle>()
            {
                {IVehicle.VehicleEnum.Car, new CreateVehicle(_CreateGasVehicle)},
                {IVehicle.VehicleEnum.Bus, new CreateVehicle(_CreateGasVehicle)},
                {IVehicle.VehicleEnum.Van, new CreateVehicle(_CreateCargoVehicle)},
                {IVehicle.VehicleEnum.Truck, new CreateVehicle(_CreateCargoVehicle)},
                {IVehicle.VehicleEnum.Electric, new CreateVehicle(_CreateElectricVehicle)},
                {IVehicle.VehicleEnum.Hybrid, new CreateVehicle(_CreateHybridVehicle)}
            };
        }
        
        private static IVehicle _CreateGasVehicle(IParameters parameters)
        {
            var convParameters = parameters as IGasVehicleParameters;
            return new GasVehicle(_random.NextDouble(), convParameters.VehicleType, convParameters.RefuelLevel);
        }

        private static IVehicle _CreateElectricVehicle(IParameters parameters)
        {
            var convParameters = parameters as IElectricVehicleParameters;
            return new ElectricVehicle(_random.NextDouble(), convParameters.VehicleType, convParameters.RechargeLevel);
        }

        private static IVehicle _CreateCargoVehicle(IParameters parameters)
        {
            var convParameters = parameters as IGasVehicleParameters;
            return new CargoVehicle(_random.NextDouble(), convParameters.VehicleType, convParameters.RefuelLevel);
        }

        private static IVehicle _CreateHybridVehicle(IParameters parameters)
        {
            var convParameters = parameters as IHybridVehicleParameters;
            return new HybridVehicle(_random.NextDouble(), convParameters.RefuelLevel, _random.NextDouble(), convParameters.RechargeLevel, convParameters.VehicleType);
        }

    }
}
