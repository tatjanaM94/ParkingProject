using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingProject.Domain.Models.Base
{
    public abstract  class BaseEntity
    {
        public virtual Guid Id { get; set; }
    }
}
