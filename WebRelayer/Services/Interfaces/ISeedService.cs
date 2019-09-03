using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRelayer.Database_Contexts;

namespace WebRelayer.Services
{
    public interface ISeedService
    {
        void Seed(string fileName, AppCtx db);
    }
}
