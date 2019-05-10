using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections;
using DataAccess;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;

namespace FriendsOrganizer.Ui.ViewModels
{
    public class FriendWrapper : ViewModelBase, INotifyDataErrorInfo
    {
        public Friend Model { get; }
        public FriendWrapper(Friend f )
        {
            Model = f;
        }

        public string FirstName
        {
            get
            {
                return Model.FirstName;
            }
            set
            {
                Model.FirstName = value;
                OnPropertyChanged();
                ValidateProperty(value);
            }
        }

        private void ValidateProperty(string value, [CallerMemberName] string propertyName = null )
        {
            //Data annotations
           var validationContext = new ValidationContext(Model) { MemberName = propertyName };
            var results = new List<ValidationResult>();
            Validator.TryValidateProperty(value, validationContext, results);

            foreach (var error in results)
            {
                AddError(propertyName, error.ErrorMessage);
            }
            //custom errors
            if (propertyName == "FirstName" && FirstName == "robot")
            {
                AddError(propertyName, "les robots ne sont pas nos amis");
            }
        }

        public string LastName
        {
            get
            {
                return Model.LastName;
            }
            set
            {
                Model.LastName = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get
            {
                return Model.Email;
            }
            set
            {
                Model.Email = value;
                OnPropertyChanged();
            }
        }

        Dictionary<string, List<string>> _errorsByPropertyName = new Dictionary<string, List<string>>();

        public bool HasErrors
        {
            get
            {
                return _errorsByPropertyName.Any(); 
            }
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public IEnumerable GetErrors(string propertyName)
        {
            if(_errorsByPropertyName.ContainsKey(propertyName))
                return _errorsByPropertyName[propertyName];
            return null;
        }

        private void AddError(string propertyName, string error)
        {
            //si il n'y a aucune erreur on créé la liste
            if(!_errorsByPropertyName.ContainsKey(propertyName))
            {
                _errorsByPropertyName[propertyName] = new List<string>();
            }
            // sert à ne pas rentrer plusierus fois la meme erreur
            if(!_errorsByPropertyName[propertyName].Contains(error))
            {
                _errorsByPropertyName[propertyName].Add(error);
                OnErrorsChanged(propertyName);
            }
        }
        private void ClearErrors(string propertyName)
        {
            if (_errorsByPropertyName.ContainsKey(propertyName))
            {
                _errorsByPropertyName[propertyName].Clear();
                OnErrorsChanged(propertyName);
            }
        }

    }
}
