using DOT.VIEW_MODEL;
using ENTITIES.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussinesslayer.INTERFACE
{
    public  interface IBusiness
    {
        public Task<object> GET();
        public Task<object> POST(View details);
        public Task<object> PUT( View details);
        public Task<object> DELETE(int id);
  

    }
}
