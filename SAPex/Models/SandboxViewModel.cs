using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SAPex.Models
{
    public class SandboxViewModel
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int MaxCandidates { get; set; }

        private DateTime _createDate;

        public string CreateDate
        {
            get { return _createDate.ToString("d"); }
            set { _createDate = DateTime.Parse(value); }
        }

        private DateTime _startDate;

        public string StartDate
        {
            get { return _startDate.ToString("d"); }
            set { _startDate = DateTime.Parse(value); }
        }

        private DateTime _endDate;

        public string EndDate
        {
            get { return _endDate.ToString("d"); }
            set { _endDate = DateTime.Parse(value); }
        }

        private DateTime _startRegistration;

        public string StartRegistration
        {
            get { return _startRegistration.ToString("d"); }
            set { _startRegistration = DateTime.Parse(value); }
        }

        private DateTime _endRegistration;

        public string EndRegistration
        {
            get { return _endRegistration.ToString("d"); }
            set { _endRegistration = DateTime.Parse(value); }
        }

        public StatusName Status { get; set; }

        public IEnumerable<StackTechnologyViewModel> StackTechnologies { get; set; }

        public IEnumerable<LanguageViewModel> Languages { get; set; }
    }

    public enum StatusName
    {
        Draft,
        Active,
        Registration,
        Application,
        Inprogress,
        Archive,
    }
}
