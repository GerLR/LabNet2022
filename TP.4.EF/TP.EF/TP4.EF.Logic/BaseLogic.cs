using TP4.EF.Data;

namespace TP4.EF.Logic
{
    public class BaseLogic
    {
        protected readonly NorthwindContext context;
         
        public BaseLogic()
        {
            context = new NorthwindContext();
        }
    }
}
