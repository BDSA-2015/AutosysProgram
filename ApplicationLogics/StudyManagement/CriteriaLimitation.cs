using System;
/// <summary>
/// Deprecated. This functionality is no longer supported and should not be used. 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// </summary>
namespace ApplicationLogics.StudyManagement
{
    public class CriteriaLimitation
    {
        private readonly bool DateIsCurrentReturnValue;
        private DateTime dateLimitation;

        private readonly bool intIsCurrentReturnValue;
        private readonly int intLimitation;
        private bool WordIsCurrentReturnValue;
        private readonly string wordLimitation;

        public CriteriaLimitation(int limitation)
        {
            intLimitation = limitation;
            intIsCurrentReturnValue = true;
        }

        public CriteriaLimitation(DateTime limitation)
        {
            dateLimitation = limitation;
            DateIsCurrentReturnValue = true;
        }

        public CriteriaLimitation(string limitation)
        {
            wordLimitation = limitation;
            WordIsCurrentReturnValue = true;
        }

        /// <summary>
        ///     Return the the wrapped object. You can use GetVariableType to determin the objects class type.
        /// </summary>
        /// <returns></returns>
        public object GetLimitation()
        {
            if (intIsCurrentReturnValue)
                return intLimitation;
            if (DateIsCurrentReturnValue)
                return dateLimitation;
            return wordLimitation;
        }

        /// <summary>
        ///     Returns the wrappedd objects type
        /// </summary>
        /// <returns></returns>
        public Type GetVariableType()
        {
            if (intIsCurrentReturnValue)
                return intLimitation.GetType();
            if (DateIsCurrentReturnValue)
                return dateLimitation.GetType();
            return wordLimitation.GetType();
        }
    }
}