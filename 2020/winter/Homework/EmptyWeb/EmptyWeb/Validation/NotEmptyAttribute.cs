using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmptyWeb
{
	public class NotEmptyAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value != null && value.ToString() != "";
        }
    }
}
