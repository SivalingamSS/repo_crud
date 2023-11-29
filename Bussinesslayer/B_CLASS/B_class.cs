using Bussinesslayer.INTERFACE;
using Datalayer.INTERFACE;
using DOT.VIEW_MODEL;
using ENTITIES.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussinesslayer.B_CLASS
{
    public  class Bussiness_class: IBusiness
    {
        private readonly IDatalayer _IDatalayer;
        public Bussiness_class(IDatalayer Idatalayer)
        {
            _IDatalayer = Idatalayer;
        }
        public Task<object> GET()
        {
            var Get_Values = _IDatalayer.GET();
            return Get_Values;
        }
        public Task<object> POST(View details)
        {
            var Post_Values = _IDatalayer.POST(details);
            return Post_Values;
        }
        public Task<object> PUT(View details)
        {
            var Put_Values = _IDatalayer.PUT( details);
            return Put_Values;
        }
        public Task<object> DELETE(int id)
        {
            var Delete_Values = _IDatalayer.DELETE(id);
            return Delete_Values;
        }
      

    }
}
