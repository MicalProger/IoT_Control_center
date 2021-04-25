using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoT_Control_center
{
    class TeamData
    {
        public void UpdatePoliFill()
        {
            isPoli = !(string.IsNullOrEmpty(poliIOServ) || string.IsNullOrEmpty(poliThingName));
        }

        public void UpdateManipFill()
        {
            isManip = !(string.IsNullOrWhiteSpace(manipThingName) || string.IsNullOrWhiteSpace(manipIOServ));
        }

        public void UpdateTrL1Fill()
        {
            isTrL1 = !(string.IsNullOrWhiteSpace(trL1ThingName) || string.IsNullOrWhiteSpace(trL1IOServ));
        }

        public void UpdateTrl2Fill()
        {
            isTrL2 = !(string.IsNullOrWhiteSpace(trL2ThingName) || string.IsNullOrWhiteSpace(trL2IOServ));
        }
        bool isTrL2;
        string trL2ThingName;
        string trL2IOServ;
        string poliThingName;
        string poliIOServ;
        bool isPoli;
        bool isManip;
        string manipThingName;
        string manipIOServ;
        bool isTrL1;
        string trL1ThingName;
        string trL1IOServ;
        public bool IsPoli
        {
            get => isPoli;
            set => isPoli = value;
        }
        public string PoliThingName
        {
            get => poliThingName;
            set
            {
                poliThingName = value;
                var _ = IsPoli;
            }
        }
        public string PoliIOServ
        {
            get => poliIOServ;
            set
            {
                poliIOServ = value;
                var _ = IsPoli;
            }
        }
        public bool IsManip
        {
            get =>  isManip;

            set => isManip = value;
        }
        public string ManipThingName
        {
            get => manipThingName;
            set
            {
                manipThingName = value;
                var _ = IsManip;
            }
        }
        public string ManipIOServ
        {
            get => manipIOServ;
            set
            {
                manipIOServ = value;
                var _ = IsManip;
            }
        }
        public bool IsTrL1 { get =>  isTrL1; set => isTrL1 = value;
        }
        public string TrL1ThingName
        {
            get => trL1ThingName;
            set
            {
                trL1ThingName = value;
                _ = IsTrL1;
            }
        }
        public string TrL1IOServ
        {
            get => trL1IOServ;
            set
            {
                trL1IOServ = value;
                _ = IsTrL1;
            }
        }
        public bool IsTrL2 { get =>   isTrL2; set => isTrL2 = value;
        }
        public string TrL2ThingName
        {
            get => trL2ThingName;
            set
            {
                trL2ThingName = value;
                var _ = IsTrL2;
            }
        }
        public string TrL2IOServ
        {
            get => trL2IOServ;
            set
            {

                trL2IOServ = value;
                var _ = IsTrL2;
            }
        }
        public string AppKey { get; set; }
    }
}
