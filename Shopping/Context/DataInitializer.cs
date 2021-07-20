using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Shopping.Context
{
    public class DataInitializer:DropCreateDatabaseIfModelChanges<ContextDb>
    {
        protected override void Seed(ContextDb context)
        {
            base.Seed(context);
        }
    }
}