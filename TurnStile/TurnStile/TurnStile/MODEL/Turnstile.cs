using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnStile.MODEL
{
    public class Turnstile
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public string IPNUMBER { get; set; }
        public string PORTNUMBER { get; set; }
        public bool? ISENTRANCE { get; set; }
        public bool? HASOWNREADER { get; set; }
        public string READER_ENTRY_COMPORT { get; set; }
        public string READER_EXIT_COMPORT { get; set; }

        public bool Active { get; set; }
        public bool EntryComActive { get; set; }
        public bool ExitComActive { get; set; }
        public int Number { get; set; }
    }
}
