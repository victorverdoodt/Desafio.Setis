using Desafio.Setis.Domain.Common;
using Desafio.Setis.Domain.Models.Aggregator;
using Desafio.Setis.Domain.Models.Entities;

namespace Desafio.Setis.Tests.Domain
{
    public class XmlDataMapperTest
    {
        private AdmDatabase CreateSuccessfulAdmDatabase()
        {
            AdmDatabase db = new()
            {
                AdmSystems = [
                   new AdmSystem {
                        Id = 1,
                        Link = "http://teste.do.teste",
                        Name = "Victor"
                    }
               ],
                AdmEntities =
               [
                   new AdmEntity
                    {
                        Id = 1,
                        Name = "TesteEntidade",
                        Responsible = "TesteResponsavel",
                        TerminalPrefix = 50,
                    }
               ],
                AdmProfiles =
               [
                   new AdmProfile
                    {
                        Id= 1,
                        Name = "TesteAdmProfile",
                        SystemId = 1,
                    }
               ],
                AdmUsers =
               [
                   new AdmUser
                    {
                        Id = 1,
                        LastAccessDate = DateTime.Now,
                        EntityId = 1,
                        IsBlocked = true,
                        Login = "OneLogin",
                        Name = "UserOne",
                        Password = "Password"

                    },
                    new AdmUser
                    {
                        Id = 2,
                        LastAccessDate = DateTime.Now,
                        EntityId = 1,
                        IsBlocked = true,
                        Login = "TwoLogin",
                        Name = "UserTwo",
                        Password = "Password"
                    }
               ],
                AdmUsersToProfiles =
               [
                   new AdmUserToProfile {ProfileId = 1, UserId = 1},
                    new AdmUserToProfile {ProfileId = 1, UserId = 2},
                ]
            };

            return db;
        }

        [Fact]
        public async Task ExportDataAsync_ShouldSuccess()
        {
            var tempFilePath = Path.GetTempFileName();
            var mapper = new XmlDataMapper<AdmDatabase>();
            var data = CreateSuccessfulAdmDatabase();

            await mapper.ExportDataAsync(data, tempFilePath);

            Assert.True(File.Exists(tempFilePath));

            var content = await File.ReadAllTextAsync(tempFilePath);
            Assert.Contains("ADM_Database", content);

            File.Delete(tempFilePath);
        }

        [Fact]
        public async Task ImportDataAsync_WithStreamReader_ShouldSuccess()
        {

            string pathToFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "ShouldSuccess.xml");
            using var streamReader = new StreamReader(pathToFile);
            var mapper = new XmlDataMapper<AdmDatabase>();
            var result = await mapper.ImportDataAsync(streamReader);
            var validate = result.ValidateContext();

            Assert.NotNull(result);
            Assert.IsType<AdmDatabase>(result);
            Assert.True(validate.IsValid);
        }

        [Fact]
        public async Task ImportDataAsync_WithFilePath_ShouldSuccess()
        {
            string pathToFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "ShouldSuccess.xml");
            var mapper = new XmlDataMapper<AdmDatabase>();
            var result = await mapper.ImportDataAsync(pathToFile);
            var validate = result.ValidateContext();

            Assert.NotNull(result);
            Assert.IsType<AdmDatabase>(result);
            Assert.True(validate.IsValid);
        }

        [Fact]
        public async Task ImportDataAsync_WithFilePath_ShouldFailWithException()
        {
            string pathToFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "ShouldFail.xml");

            var mapper = new XmlDataMapper<AdmDatabase>();

            await Assert.ThrowsAsync<InvalidOperationException>(async () => await mapper.ImportDataAsync(pathToFile));

        }

        [Fact]
        public async Task ImportDataAsync_WithStreamReader_ShouldFailWithException()
        {
            string pathToFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "ShouldFail.xml");

            using var streamReader = new StreamReader(pathToFile);

            var mapper = new XmlDataMapper<AdmDatabase>();

            await Assert.ThrowsAsync<InvalidOperationException>(async () => await mapper.ImportDataAsync(streamReader));
        }
    }
}
