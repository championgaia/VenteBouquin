using DataAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FriendsOrganizer.Ui.ViewModels
{
    public class FriendWrapper : ViewModelBase, INotifyDataErrorInfo //design patter decorator
    {
        public Friend _model;
        public FriendWrapper(Friend f)
        {
            _model = f;
        }
        public string FirstName
        {
            get
            {
                return _model.FirstName;
            }
            set
            {
                _model.FirstName = value;
                OnPropertyChanged();
                ValidateProperty(value);
            }
        }
        public string LastName
        {
            get
            {
                return _model.LastName;
            }
            set
            {
                _model.LastName = value;
            }
        }
        public string Email
        {
            get
            {
                return _model.Email;
            }
            set
            {
                _model.Email = value;
            }
        }
        Dictionary<string, List<string>> _errorsByProp = new Dictionary<string, List<string>>();
        public bool HasErrors
        {
            get
            {
                return _errorsByProp.Count >= 0;//equiv   _errorsByProp.Any();
            }
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            if (_errorsByProp.ContainsKey(propertyName))
                return _errorsByProp[propertyName];
            return null;
        }
        private void AddError(string propertyName, string error)
        {
            if (_errorsByProp.ContainsKey(propertyName))
            {
                _errorsByProp[propertyName] = new List<string>();
            }
            if (!_errorsByProp[propertyName].Contains(error))
            {
                _errorsByProp[propertyName].Add(error);
                OnErrorChange(propertyName);
            }
        }
        private void ClearError(string propertyName)
        {
            if (_errorsByProp.ContainsKey(propertyName))
            {
                _errorsByProp.Remove(propertyName);
                OnErrorChange(propertyName);
            }
        }
        private void OnErrorChange(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
        private void ValidateProperty(string value, [CallerMemberName]string propertyName = null) //permets de ne pas passer le param
        {
            var validationContext = new ValidationContext(_model)
            {
                MemberName = propertyName
            };
            var result = new List<ValidationResult>();
            Validator.TryValidateProperty(value, validationContext, result);
            ClearError(propertyName);
            if (propertyName == "FirstName" && FirstName == "robot")
            {
                AddError(propertyName, "Les robots ne sont pas des amis");
            }
        }
    }
}
