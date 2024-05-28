using Desafio.Setis.Domain.Common;
using Desafio.Setis.Domain.Models.Aggregator;
using Desafio.Setis.Domain.Models.Entities;

namespace Desafio.Setis.DataGen
{
    internal class Program
    {
        private static readonly XmlDataMapper<AdmDatabase> _xmlDataMapper = new();
        static async Task Main(string[] args)
        {
            Console.WriteLine("Iniciando Db!");
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
            var validator = db.ValidateContext();
            if (validator.IsValid)
            {
                Console.WriteLine("Iniciando Exportação!");
                await _xmlDataMapper.ExportDataAsync(db, "TesteData.xml");
                Console.WriteLine("Exportação Concluida!");
            }
            else
            {
                Console.WriteLine("Problema ao realizar Exportação!");
                Console.WriteLine(validator.Log);
            }
        }
    }
}
