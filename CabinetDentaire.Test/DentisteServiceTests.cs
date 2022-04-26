using CabinetDentaire.Services;
using CabinetDentaire.Shared.Entities;
using System;
using System.Linq;
using Xunit;

namespace CabinetDentaire.Test
{
    public class DentisteServiceTests : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _databaseFixture;
        private IDentisteService _dentisteService;
        public DentisteServiceTests(DatabaseFixture databaseFixture)
        {
            _databaseFixture = databaseFixture;
            _dentisteService = new DentisteService(_databaseFixture._postgreSqlSerives);

        }

        [Fact]
        public async void ShouldReturnAllDentistes()
        {
            //arrange
            var dentistes = await _dentisteService.GetDentistes();

            //act 

            //assert
            Assert.NotEmpty(dentistes);
            Assert.True(dentistes.Count()==3);

        }

        [Fact]
        public async void ShouldUpdateWorkTime()
        {
            //arrange
            var workTime = new WorkCategory
            {
                HourStartWork = new TimeSpan(15,30,0),
                HourEndWork = new TimeSpan(17,30,0),
            };

            var dentisteId = new Guid("3ea1b98c-be52-469a-a18e-322bbc68d106");
            //act 

            var sut =await _dentisteService.UpdateTimeWorkDentiste(dentisteId, workTime);
            //assert
            Assert.NotNull(sut);
            Assert.True(sut==1);

        }

        [Fact]
        public async void ShouldUpdateWorkTimeForInvalidDentiste()
        {
            //arrange
            var workTime = new WorkCategory
            {
                HourStartWork = new TimeSpan(15, 30, 0),
                HourEndWork = new TimeSpan(17, 30, 0),
            };

            var dentisteId = new Guid("a676a44f-1049-475c-9b4a-f309ad922870");
            //act 

            var sut = await _dentisteService.UpdateTimeWorkDentiste(dentisteId, workTime);
            //assert
            
            Assert.True(sut==0);

        }
    }
}
