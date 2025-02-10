using Microservice.Doctors.Domain.Doctor.ValueObject;

namespace Microservice.Doctors.Domain.Doctor
{
    public class Doctor
    {
        private int _id;
        private int _credential;
        private string _name;
        private string _lastname;
        private string _specialty;
        private Email _email;
        private Password _password;
        private Phone _phone;
        private bool _status;

        public Doctor()
        {
            _status = true;
        }

        public Doctor(int credential, string name, string lastname, string specialty, bool status, string email, string password, string phone)
        {
            _credential = credential;
            _name = name;
            _lastname = lastname;
            _specialty = specialty;
            _status = true;
            _email = Email.Create(email);
            _password = Password.Create(password);
            _phone = Phone.Create(phone);
        }

        public int Id { get => _id; }
        public int Credential { get => _credential; }
        public string Name { get => _name; }
        public string LastName { get => _lastname; }
        public string FullName { get => $"{_name} {_lastname}"; }
        public string Specialty { get => _specialty; }
        public bool Status { get => _status; }
        public Email Email { get => _email; }
        public Password Password { get => _password; }
        public Phone Phone { get => _phone; }
        public void SetCredential(int newCredential) => _credential = newCredential;
        public void SetName(string newName) => _name = newName;
        public void SetLastName(string newLastName) => _lastname = newLastName;
        public void SetStatus(bool newStatus) => _status = newStatus;
        public void SetSpecialty(string newSpecialty) => _specialty = newSpecialty;
        public void SetEmail(string newEmail) => _email = Email.Create(newEmail);
        public void SetPassword(string newPassword) => _password = Password.Create(newPassword);
        public void SetPhone(string newPhone) => _phone = Phone.Create(newPhone);
    }
}
