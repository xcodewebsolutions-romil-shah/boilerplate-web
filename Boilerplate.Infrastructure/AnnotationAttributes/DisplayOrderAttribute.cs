using System;
using System.Collections.Generic;
using System.Text;

namespace Boilerplate.Infrastructure.AnnotationAttributes
{
    public class DisplayOrderAttribute : Attribute
    {
        public virtual int DisplayOrder { get; set; }

        public DisplayOrderAttribute(int displayOrder)
        {
            DisplayOrder = displayOrder;
        }
    }
}
