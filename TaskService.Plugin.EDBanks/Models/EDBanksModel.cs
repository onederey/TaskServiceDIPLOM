using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskService.Plugin.EDBanks.Models
{
	/// <summary>
	/// Model for ED807
	/// </summary>
    public class EDBanksModel
    {
		public decimal? BIC { get; set; }

		public string NameP { get; set; }

		public string EnglName { get; set; }

		public string CntrCd { get; set; }

		public int? Rgn { get; set; }

		public decimal? Ind { get; set; }

		public string Tnp { get; set; }

		public string Nnp { get; set; }

		public string Adr { get; set; }

		public DateTime DateIn { get; set; }

		public DateTime DateOut { get; set; }

		public int? PtType { get; set; }

		public int? Srvcs { get; set; }

		public int? XchType { get; set; }

		public int? UID { get; set; }

		public string ParticipantStatus { get; set; }

		public decimal? Account { get; set; }

		public string RegulationAccType { get; set; }

		public decimal? AccountCBRBIC { get; set; }

		public DateTime UURSDate { get; set; }

		public DateTime LWRSDate { get; set; }

		public DateTime BusinessDay { get; set; }

		public DateTime UpdateDay { get; set; }

		public bool? IsLicenseValid { get; set; }
	}
}
