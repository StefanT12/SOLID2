namespace SOLID2.Base
{
    public enum ResultCode
    {
        /// <summary>
        /// all went according to plan
        /// </summary>
        Success,
        /// <summary>
        /// something wrong happened
        /// </summary>
        Fail,
        /// <summary>
        /// the vehicle does not fit with the operation
        /// </summary>
        NotFit,
        /// <summary>
        /// the vehicle was embarked during the operation
        /// </summary>
        Embark
    }
    public class Result
    {
        public ResultCode Code { get; }
        public string CodeMsg { get; set; }

        public bool Succeeded => Code == ResultCode.Success;
        public bool Failed => Code == ResultCode.Fail;
        public bool Embarked => Code == ResultCode.Embark;
        public bool IsNotFit => Code == ResultCode.NotFit;

        public static Result Embark(string employeeID, string ferryId, string vehicleType, string additionalMsg = "none")
        {
            return new Result(ResultCode.Embark) { CodeMsg = $"{employeeID} parked the vehicle {vehicleType} on ferry {ferryId}, Additional Notes: {additionalMsg}" };
        }

        public static Result Fail(string msg)
        {
            return new Result(ResultCode.Fail) { CodeMsg = msg };
        }

        public static Result Success(string msg)
        {
            return new Result (ResultCode.Success) { CodeMsg = msg };
        }

        public static Result Success()
        {
            return new Result(ResultCode.Success);
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