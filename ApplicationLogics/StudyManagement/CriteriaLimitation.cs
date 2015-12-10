using System;

namespace ApplicationLogics.StudyManagement
{
    public class CriteriaLimitation
    {
        private int intLimitation;
        private DateTime dateLimitation;
        private string wordLimitation;

        private bool intIsCurrentReturnValue = false;
        private bool DateIsCurrentReturnValue = false;
        private bool WordIsCurrentReturnValue = false;

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
        /// Return the the wrapped object. You can use GetVariableType to determin the objects class type.
        /// </summary>
        /// <returns></returns>
        public Object GetLimitation()
        {
            if (intIsCurrentReturnValue)
                return intLimitation;
            else if (DateIsCurrentReturnValue)
                return dateLimitation;
            else
                return wordLimitation;
        }

        /// <summary>
        /// Returns the wrappedd objects type
        /// </summary>
        /// <returns></returns>
        public Type GetVariableType()
        {
            if (intIsCurrentReturnValue)
                return intLimitation.GetType();
            else if (DateIsCurrentReturnValue)
                return dateLimitation.GetType();
            else
                return wordLimitation.GetType();
        }
    }
}
