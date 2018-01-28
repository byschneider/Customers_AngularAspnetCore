using System;
using System.Collections.Generic;

namespace Customers_AngularAspnetCore.DataModel
{
    public partial class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }

        public Region Region { get; set; }
    }
}
