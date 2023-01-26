using GrifindoPS.Commands;
using GrifindoPS.Models;
using GrifindoPS.Services;
using GrifindoPS.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GrifindoPS.ViewModels
{
    internal class LeavesDetailsViewModel : ViewModelBase
    {
        private LeaveModel? _leave;
        private ObservableCollection<string> _approvals;
        private Guid _id;
        private DateTime _date = new(2000, 1, 1);
        private string? _description;
        private string _approval = string.Empty;

        public LeavesDetailsViewModel(NavigationService leavesListNavigationService)
        {
            _approvals = new()
            {
                "Pending",
                "Approved",
                "Rejected"
            };

            _leave = RuntimeStore.Instance.CurrentLeave;
            
            if (_leave == null)
            {
                // Setup to the registration
                SubmitName = "Register";
                SubmitCommand = new LeaveRegisterCommand(this, leavesListNavigationService);
            }
            else
            {
                // Setup to the update
                _date = _leave.Date;
                _description = _leave.Description;
                _approval = _leave.Approval;

                SubmitName = "Update";
                SubmitCommand = new LeaveUpdateCommand(this, leavesListNavigationService);
            }

            CancelCommand = new NavigationCommand(leavesListNavigationService);
        }

        public Guid Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        public string? Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public string Approval
        {
            get { return _approval; }
            set
            {
                _approval = value;
                OnPropertyChanged(nameof(Approval));
            }
        }

        public IEnumerable<string> Approvals => _approvals;

        public string SubmitName { get; }

        public ICommand SubmitCommand { get; }

        public ICommand CancelCommand { get; }
    }
}
