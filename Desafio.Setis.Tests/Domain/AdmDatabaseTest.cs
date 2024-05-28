using Desafio.Setis.Domain.Models.Aggregator;
using Desafio.Setis.Domain.Models.Entities;

namespace Desafio.Setis.Tests.Domain
{
    public class AdmDatabaseTest
    {
        #region private
        private AdmDatabase CreateInvalidAdmDatabaseByNotFoundId()
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
                        EntityId = 100, //Id Dont Exist
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

        private AdmDatabase CreateInvalidAdmDatabaseByStringLength()
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
                        Login = "OneLoginMuitoGrandeMesmo",
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
            db.RebuildRelationships();
            return db;
        }

        private AdmDatabase CreateInvalidAdmDatabaseByDuplicatedId()
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
                        Id = 1, //EqualID
                        LastAccessDate = DateTime.Now,
                        EntityId = 1,
                        IsBlocked = true,
                        Login = "OneLogin",
                        Name = "UserOne",
                        Password = "Password"

                    },
                    new AdmUser
                    {
                        Id = 1, //EqualID
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

        private AdmDatabase CreateInvalidAdmDatabaseByZeroId()
        {
            AdmDatabase db = new()
            {
                AdmSystems = [
                   new AdmSystem {
                        Id = 0, //Zero Id
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

        private AdmDatabase CreateInvalidAdmDatabaseByFieldRequired()
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
                        //Login = "OneLogin", //Required
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
        #endregion

        [Fact]
        public void Validate_ShouldSuccess()
        {
            var dataBase = CreateSuccessfulAdmDatabase();
            var result = dataBase.ValidateContext();
            Assert.Equal(string.Empty, result.Log);
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Validate_ShouldInvalidByStringLenght()
        {
            var dataBase = CreateInvalidAdmDatabaseByStringLength();
            var result = dataBase.ValidateContext();
            Assert.False(result.IsValid);
            Assert.Contains("precisa ser menor que", result.Log);
        }

        [Fact]
        public void Validate_ShouldInvalidByNotFoundId()
        {
            var dataBase = CreateInvalidAdmDatabaseByNotFoundId();
            var result = dataBase.ValidateContext();
            Assert.False(result.IsValid);
            Assert.Contains("não encontrada", result.Log);
        }

        [Fact]
        public void Validate_ShouldInvalidByDuplicatedId()
        {
            var dataBase = CreateInvalidAdmDatabaseByDuplicatedId();
            var result = dataBase.ValidateContext();
            Assert.False(result.IsValid);
            Assert.Contains("Id Duplicada", result.Log);
        }

        [Fact]
        public void Validate_ShouldInvalidByZeroId()
        {
            var dataBase = CreateInvalidAdmDatabaseByZeroId();
            var result = dataBase.ValidateContext();
            Assert.False(result.IsValid);
            Assert.Contains("precisa ser maior que 0", result.Log);
        }

        [Fact]
        public void Validate_ShouldInvalidByFieldRequired()
        {
            var dataBase = CreateInvalidAdmDatabaseByFieldRequired();
            var result = dataBase.ValidateContext();
            Assert.False(result.IsValid);
            Assert.Contains("é obrigatório", result.Log);
        }
    }
}
