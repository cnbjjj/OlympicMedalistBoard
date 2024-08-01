using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicMedalistBoard.Models {
	public class CountryViewModel {
		[Required(ErrorMessage = "Name is needed")]
		public string CountryName { get; set; }

		[Required(ErrorMessage = "Code is needed")]
		[StringLength(2, ErrorMessage = "Code cannot be longer than 2 characters")]
		public string CountryCode { get; set; }
	}
}
