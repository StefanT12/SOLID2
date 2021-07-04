using System.Collections.Generic;

namespace SOLID2.Base
{
    public enum ResultCode
    {
        /// <summary>
        /// All went according to plan at the location.
        /// </summary>
        Success,
        /// <summary>
        /// Something went wrong at the location.
        /// </summary>
        Fail,
        /// <summary>
        /// The vehicle did not fit with the location.
        /// </summary>
        NotFit,
        /// <summary>
        /// The vehicle was embarked at the location.
        /// </summary>
        Embark
    }
    public class Result
    {
        public ResultCode Code { get; }
        public IList<string> Log { get; set; }

        public bool Succeeded => Code == ResultCode.Success;
        public bool Failed => Code == ResultCode.Fail;
        public bool Embarked => Code == ResultCode.Embark;
        public bool IsNotFit => Code == ResultCode.NotFit;

        public static Result Embark()
        {
            return new Result(ResultCode.Embark);//$"{employeeID} parked the vehicle {vehicleType} on ferry {ferryId}, Additional Notes: {additionalMsg}"
        }
        public static Result Embark(IList<string> log)
        {
            return new Result(ResultCode.Embark) { Log = log };//$"{employeeID} parked the vehicle {vehicleType} on ferry {ferryId}, Additional Notes: {additionalMsg}"
        }

        public static Result Fail()
        {
            return new Result(ResultCode.Fail);// { CodeMsg = msg };
        }

        public static Result Fail(IList<string> log)
        {
            return new Result(ResultCode.Fail) { Log = log };
        }

        public static Result Success()
        {
            return new Result(ResultCode.Success);
        }

        public static Result Success(IList<string> log)
        {
            return new Result(ResultCode.Success) { Log = log };
        }

        public static Result NotFit()
        {
            return new Result(ResultCode.NotFit);
        }

        public Result(ResultCode code)
        {
            Code = code;
        }
    }
}