using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_Bolnica.Model
{
    public class ReportData
    {
        public int RoomId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public ReportData(int roomId, DateTime dateFrom, DateTime dateTo)
        {
            RoomId = roomId;
            DateFrom = dateFrom;
            DateTo = dateTo;
        }

    }
}
