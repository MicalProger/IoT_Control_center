using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoT_Control_center
{
    public class Equipment
    {
        public void UpdateProperties()
        {
            
        }
        public string Ip;
        public string Name;
        public List<ShowProrerty> UDP;
        public List<ShowProrerty> FromHardwere;
        public List<ShowProrerty> FromSoftwere;
    }
}
