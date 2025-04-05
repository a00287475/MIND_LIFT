using System.ComponentModel;
using System.Windows.Input;
using System.Threading.Tasks;

namespace MIND_LIFT.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _email;
        private string _password;
        private string _statusMessage;

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string StatusMessage
        {
            get => _statusMessage;
            set
            {
                _statusMessage = value;
                OnPropertyChanged(nameof(StatusMessage));
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await PerformLogin());
        }

        private async Task PerformLogin()
        {
            // Simulate login delay
            await Task.Delay(1000);

            if (Email == "test@user.com" && Password == "password123")
            {
                StatusMessage = "Login Successful!";
                // Navigate to homepage later
            }
            else
            {
                StatusMessage = "Invalid email or password.";
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
