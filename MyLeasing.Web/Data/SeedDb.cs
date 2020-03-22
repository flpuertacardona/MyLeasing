using System;
using System.Linq;
using System.Threading.Tasks;
using MyLeasing.Web.Data.Entities;
using MyLeasing.Web.Helpers;

namespace MyLeasing.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckRoles();
            var manager1= await CheckUserAsync("71579486","Francisco","Puerta","flpuertacardon@gmail.com", "3112363842", "Cra 43A 60 sur 64", "Manager");
            var owner1 =  await CheckUserAsync("71579486","Francisco","Puerta","flpuertacardon@hotmail.com", "3112363842", "Cra 43A 60 sur 64", "Owner");
            var owner2 =   await CheckUserAsync("43033005","Patricia","Bernal","patriciabernal1908@gmail.com","3112363842","Cra 43A 60 sur 64","Owner");
            var lessee =  await CheckUserAsync("1039460078","David", "Puerta","davidpb@gmail.com","3112363842","Cra 43A 60 sur 64","Lessee");
            var agent1 =  await CheckUserAsync("1039460275","Sebastian","Puerta","sebastianpb@gmail.com","3112363842","Cra 43A 60 sur 64","Agent");
            var agent2 =  await CheckUserAsync("1000415244","Andrea","Puerta","andreapb@gmail.com","3112363842","Cra 43A 60 sur 64", "Agent");
            var agent3 =  await CheckUserAsync("1039460078","David", "Puerta", "davidpuertab@gmail.com", "3112363842", "Cra 43A 60 sur 64", "Agent");

            await CheckPropertyTypesAsync();
            await CheckBusinessTypesAsync();
            await CheckPropertiesAsyn();
            await CheckManagerAsync(manager1);
            await CheckOwnerAsync(owner1);
            await CheckOwnerAsync(owner2);
            await CheckLesseesAsync(lessee);
            await CheckContractAsync();
            await CheckAgentAsync(agent1);
            await CheckAgentAsync(agent2);
            await CheckAgentAsync(agent3);
        }

        private async Task CheckRoles()
        {
            await _userHelper.CheckRoleAsync("Manager");
            await _userHelper.CheckRoleAsync("Owner");
            await _userHelper.CheckRoleAsync("Lessee");
            await _userHelper.CheckRoleAsync("Agent");
        }
        private async Task<User> CheckUserAsync(
            string document,
            string firstName,
            string lastName,
            string email,
            string phone,
            string address,
            string role)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document
                };

                await _userHelper.AddUserAsync(user, "flpc5416");
                await _userHelper.AddUserToRoleAsync(user, role);
                var token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);

            }
            return user;

        }
        private async Task CheckPropertiesAsyn()
        {
            var owner = _context.Owners.FirstOrDefault();
            var propertytype = _context.PropertyTypes.FirstOrDefault();

            if (!_context.Properties.Any())
            {
                AddProperty("Sabaneta", "Carrera 43A 60 sur 64 Casa 130",owner, propertytype, 800000M, 2, 72, 4,3,"100aaa");
                AddProperty("Sabaneta", "Carrera 45A 60 sur 74 Casa 130",owner, propertytype, 900000M, 3, 72, 4,3,"100aaa");
                AddProperty("Sabaneta", "Carrera 43A 60 sur 64 Casa 130",owner, propertytype, 1800000M, 4, 72, 4,3,"100aaa");
                await _context.SaveChangesAsync();
            }
        }

        private void AddProperty(
            string barrio,
            string address,
            Owner owner,
            PropertyType propertytype,
            decimal precio,
            int rooms,
            int area,
            int estrato,
            int baths,
            string escrito)
        {
            _context.Properties.Add(new Property
            {
                Address = address,
                Neighborhood = barrio,
                Owner = owner,
                PropertyType = propertytype,
                Price = precio,
                Rooms = rooms,
                SquareMeters = area,
                Stratum = estrato,
                BathRooms=baths,
                Escritura=escrito
            });
        }

        private async Task CheckPropertyTypesAsync()
        {
            if (!_context.PropertyTypes.Any())
            {
                _context.PropertyTypes.Add(new Entities.PropertyType { Name = "Apartamento" });
                _context.PropertyTypes.Add(new Entities.PropertyType { Name = "Casa" });
                _context.PropertyTypes.Add(new Entities.PropertyType { Name = "Aparta Estudio" });
                _context.PropertyTypes.Add(new Entities.PropertyType { Name = "Habitación" });
                _context.PropertyTypes.Add(new Entities.PropertyType { Name = "Finca" });
                _context.PropertyTypes.Add(new Entities.PropertyType { Name = "Lote" });
                _context.PropertyTypes.Add(new Entities.PropertyType { Name = "Garaje" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckBusinessTypesAsync()
        {
            if (!_context.BusinessTypes.Any())
            {
                _context.BusinessTypes.Add(new Entities.BusinessType { Name = "Vender" });
                _context.BusinessTypes.Add(new Entities.BusinessType { Name = "Alquiler" });
                _context.BusinessTypes.Add(new Entities.BusinessType { Name = "Permutar" });
                _context.BusinessTypes.Add(new Entities.BusinessType { Name = "Vender - Alquiler" });
                _context.BusinessTypes.Add(new Entities.BusinessType { Name = "Vender - Permutar" });
                _context.BusinessTypes.Add(new Entities.BusinessType { Name = "Permutar - Alquiler" });
                _context.BusinessTypes.Add(new Entities.BusinessType { Name = "Vender - Alquiler - Permutar" });

            }
            await _context.SaveChangesAsync();
        }

        private async Task CheckManagerAsync(User user)
        {
            if (!_context.Managers.Any())
            {
                _context.Managers.Add(new Manager { User = user });
                await _context.SaveChangesAsync();

            }
        }

        private async Task CheckOwnerAsync(User user)
        {
            if (!_context.Owners.Any())
            {
                _context.Owners.Add(new Owner { User = user });
                await _context.SaveChangesAsync();
            }
        }
        private async Task CheckLesseesAsync(User user)
        {
            if (!_context.Lessees.Any())
            {
                _context.Lessees.Add(new Lessee { User = user });
                await _context.SaveChangesAsync();
            }
        }
        private async Task CheckContractAsync()
        {
            var owner = _context.Owners.FirstOrDefault();
            var lessee = _context.Lessees.FirstOrDefault();
            var property = _context.Properties.FirstOrDefault();
            if (!_context.Contracts.Any())
            {
                _context.Contracts.Add(new Contract

                {
                    StartDate = DateTime.Today,
                    EndDate = DateTime.Today.AddDays(1),
                    IsActive = true,
                    Lessee = lessee,
                    Owner = owner,
                    Price = 800000M,
                    Property = property,
                    Remarks = "propiedad en excelnete estado, excelente ubicación, buen precio,...."

                });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckAgentAsync(User user)
        {
            if (!_context.Agents.Any())
            {
                _context.Agents.Add(new Agent { User = user });
                await _context.SaveChangesAsync();
            }
        }

    }
}