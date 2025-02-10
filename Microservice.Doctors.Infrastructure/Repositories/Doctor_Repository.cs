using Microservice.Doctors.Application.DTO;
using Microservice.Doctors.Application.Interfaces.Repository;
using Microservice.Doctors.Domain.Doctor;
using Microservice.Doctors.Infrastructure.Context;

namespace Microservice.Doctors.Infrastructure.Repositories
{
    public class Doctor_Repository : IDoctor_Repository
    {
        private DataContext _dataContext;

        public Doctor_Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(Doctor Doctor)
        {
            try
            {
                _dataContext.Doctors.Add(Doctor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int? Delete(int credential)
        {
            try
            {
                Doctor? Doctor = GetByCredential(credential);
                if (Doctor == null) return null;

                Doctor.SetStatus(false);
                _dataContext.Doctors.Update(Doctor);
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Doctor> GetAll()
        {
            try
            {
                return _dataContext.Doctors.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Doctor? GetByCredential(int credential)
        {
            try
            {
                return _dataContext.Doctors.Where(p => p.Credential == credential).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int UniqueDoctorValidation(Doctor_DTO dto)
        {
            try
            {
                int output = _dataContext.Doctors.Where(p => p.Credential == dto.Credential).Count();

                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
