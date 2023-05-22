using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace iKandi.Common
{
    public class NewsLetter : BaseEntity
    {
        public Int32 LinePlanFrameId
        {
            get;
            set;
        }
        public string StyleCode
        {
            get;
            set;
        }
        public short LineNo
        {
            get;
            set;
        }
        public DateTime FrameStartDate
        {
            get;
            set;
        }
        public DateTime FrameEndDate
        {
            get;
            set;
        }
        public DateTime MinExFactory
        {
            get;
            set;
        }
        public DateTime MaxExFactory
        {
            get;
            set;
        }
        public string FabricName
        {
            get;
            set;
        }
        public string FabricColor
        {
            get;
            set;
        }
        public string ContractNumber
        {
            get;
            set;
        }
        public string SerialNumber
        {
            get;
            set;
        }
        public DateTime FabricShortDate
        {
            get;
            set;
        }
        public DateTime FabricStartEta
        {
            get;
            set;
        }
        public DateTime FabricEndEta
        {
            get;
            set;
        }
        public List<NewsLetter> NewsLetterDetail
        {
            get;
            set;
        }
        public Int64 OrderDetailId
        {
            get;
            set;
        }
        public string AccessName
        {
            get;
            set;
        }
        public DateTime AccessShortDate
        {
            get;
            set;
        }
        public DateTime AccessEta
        {
            get;
            set;
        }
        public string status
        {
            get;
            set;
        }
        public DateTime StatusEta
        {
            get;
            set;
        }
        public string CWIP
        {
            get;
            set;
        }
        
    }
}
