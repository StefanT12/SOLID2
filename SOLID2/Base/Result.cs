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
        Embarked
    }
    public class Result
    {
        public ResultCode Code { get; set; }
        public string CodeMsg { get; set; }//in case it fails, we wanna see why
    }
}