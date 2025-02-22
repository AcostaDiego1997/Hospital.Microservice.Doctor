//using AutoFixture;
//using Microservice.Doctors.Domain.Doctor;
//using Microservice.Doctors.Infrastructure.Context;
//using Microservice.Doctors.Infrastructure.Repositories;
//using Microservice.Doctors.Tests.Common;
//using Moq;
//using System.Data.Entity;
//using Xunit;

//namespace Microservice.Doctors.Tests.Application
//{
//    public class DoctorQueries_Test
//    {
//        private Fixture _fixture;
//        private readonly Doctor_Repository _repository;
//        private readonly Mock<DataContext> _contextMock;

//        #region ARRANGE
//        public DoctorQueries_Test()
//        {
//            ConfigAutoFixture();
//            _contextMock = CreateContext();
//            _repository = new(_contextMock.Object);
//        }
//        private void ConfigAutoFixture()
//        {
//            _fixture.Customize<Doctor>(composer => composer.Do(doctor =>
//            {
//                doctor.SetCredential(_fixture.Create<int>());
//                doctor.SetName(_fixture.Create<string>());
//                doctor.SetLastName(_fixture.Create<string>());
//                doctor.SetStatus(_fixture.Create<bool>());
//                doctor.SetSpecialty(_fixture.Create<string>());
//                doctor.SetEmail(_fixture.Create<string>());
//                doctor.SetPassword(_fixture.Create<string>());
//            }));
//        }
//        private Mock<DataContext> CreateContext()
//        {
//            IQueryable<Doctor> mockData = GetMockDoctors().AsQueryable();

//            var dbSet = new Mock<DbSet<Doctor>>();
//            dbSet.As<IQueryable<Doctor>>().Setup(x => x.Provider).Returns(mockData.Provider);
//            dbSet.As<IQueryable<Doctor>>().Setup(x => x.Expression).Returns(mockData.Expression);
//            dbSet.As<IQueryable<Doctor>>().Setup(x => x.ElementType).Returns(mockData.ElementType);
//            dbSet.As<IQueryable<Doctor>>().Setup(x => x.GetEnumerator()).Returns(mockData.GetEnumerator());

//            dbSet.As<IAsyncEnumerable<Doctor>>().Setup(x => x.GetAsyncEnumerator(new CancellationToken())).Returns(new AsyncEnumerator<Doctor>(mockData.GetEnumerator()));

//            Mock<DataContext> context = new();
//            context.Setup(x => x.Set<Doctor>()).Returns(dbSet.Object);

//            return context;

//        }
//        private IEnumerable<Doctor> GetMockDoctors()
//        {
//            var output = _fixture.CreateMany<Doctor>(20).ToList();
//            return output.AsEnumerable();
//        }
//        #endregion


//        #region ACT - ASSERT
//        [Fact]
//        public void AllDoctors()
//        {



//            Assert.True(1 == 1);
//        }
//        #endregion

        
//    }
//}
