using DOT.VIEW_MODEL;
using ENTITIES.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer.INTERFACE
{
    public interface IDatalayer
    {
        public Task<object> GET();
        public Task<object> POST(View details);
        public Task<object> PUT(View details);
        public Task<object> DELETE(int id);
            
    }
}
